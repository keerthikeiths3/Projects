using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Net;

using Bonjour;
using System.IO;

namespace Client
{
    public partial class Client : Form
    {
        #region Variables

        private DNSSDEventManager m_eventManager = null;
        private DNSSDService m_service = null;
        private DNSSDService m_registrar = null;
        private DNSSDService m_browser = null;
        private DNSSDService m_resolver = null;

        private String m_name;
        private Socket m_socket = null;
        private const int BUFFER_SIZE = 1024 * 250;
        public byte[] m_buffer = new byte[BUFFER_SIZE];

        ServiceInfo sInfo = null;

        private static ManualResetEvent connectDone = new ManualResetEvent(false);

        #endregion

        #region Constructor

        public Client()
        {
            InitializeComponent();

            sInfo = new ServiceInfo();

            try
            {
                //creates a new service object and browses for the service type "_messageStreamer._tcp"
                m_service = new DNSSDService();
            }
            catch
            {
                MessageBox.Show("Browse Failed", "Error");
                Application.Exit();
            }

            //Creates a new event manager object and sets callback methods for the different service and query events
            m_eventManager = new DNSSDEventManager();
            m_eventManager.ServiceFound += new _IDNSSDEvents_ServiceFoundEventHandler(this.ServiceFound);
            m_eventManager.ServiceResolved += new _IDNSSDEvents_ServiceResolvedEventHandler(this.ServiceResolved);
            m_eventManager.QueryRecordAnswered += new _IDNSSDEvents_QueryRecordAnsweredEventHandler(this.QueryAnswered);
            m_eventManager.OperationFailed += new _IDNSSDEvents_OperationFailedEventHandler(this.OperationFailed);
        }

        #endregion

        //
        // QueryAnswered
        //
        // Called by DNSServices core as a result of DNSService.QueryRecord()
        // call
        //
        public void QueryAnswered(DNSSDService service, DNSSDFlags flags, uint ifIndex, String fullName, DNSSDRRType rrtype, DNSSDRRClass rrclass, Object rdata, uint ttl)
        {
            //
            // Stop the resolve to reduce the burden on the network
            //
            m_resolver.Stop();
            m_resolver = null;

            //Obtains the IP address of the service that it was querying for 
            uint bits = BitConverter.ToUInt32((Byte[])rdata, 0);
            System.Net.IPAddress address = new System.Net.IPAddress(bits);
            sInfo.Address = address;
        }

        //Callback method if any of the Bonjour methods fail (ex. Resolve, Query, Browse)
        public void OperationFailed(DNSSDService service, DNSSDError error)
        {
            MessageBox.Show("Operation returned an error code " + error, "Error");
        }

        //
        // ServiceFound
        //
        // Called by DNSServices core as a result of a Browse call
        //
        public void ServiceFound(DNSSDService sref, DNSSDFlags flags, uint ifIndex, String serviceName, String regType, String domain)
        {
            //check to see that this is a new service instance that we have not already found.
            if (serviceName != m_name)
            {
                ServiceInfo ServiceInformation = new ServiceInfo();

                ServiceInformation.InterfaceIndex = ifIndex;
                ServiceInformation.InstanceName = serviceName;
                ServiceInformation.Type = regType;
                ServiceInformation.Domain = domain;
                ServiceInformation.Address = null;

                //resolve the name in order to obtain the IP Address and port
                m_resolver = m_service.Resolve(0, ServiceInformation.InterfaceIndex, ServiceInformation.InstanceName, ServiceInformation.Type, ServiceInformation.Domain, m_eventManager);
            }
        }

        public void ServiceResolved(DNSSDService sref, DNSSDFlags flags, uint ifIndex, String fullName, String hostName, ushort port, TXTRecord txtRecord)
        {
            m_resolver.Stop();
            m_resolver = null;

            //received the port number of the service 
            sInfo.Port = port;

            //
            // Now query for the IP address associated with "hostName"
            //
            try
            {
                m_resolver = m_service.QueryRecord(0, ifIndex, hostName, DNSSDRRType.kDNSSDType_A, DNSSDRRClass.kDNSSDClass_IN, m_eventManager);
            }
            catch
            {
                MessageBox.Show("QueryRecord Failed", "Error");
                Application.Exit();
            }
        }

        // ServiceRegistered
        //
        // Called by DNSServices core as a result of Register()
        // call
        //
        public void
        ServiceRegistered
                    (
                    DNSSDService service,
                    DNSSDFlags flags,
                    String name,
                    String regType,
                    String domain
                    )
        {
            m_name = name;

            try
            {
                m_browser = m_service.Browse(0, 0, "_soap._tcp,_imgsvc", null, m_eventManager);
            }
            catch
            {
                MessageBox.Show("Browse Failed", "Error");
                Application.Exit();
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_browser != null)
                {
                    m_browser.Stop();
                }

                if (m_resolver != null)
                {
                    m_resolver.Stop();
                }
                m_eventManager.ServiceFound -= new _IDNSSDEvents_ServiceFoundEventHandler(this.ServiceFound);
                m_eventManager.ServiceResolved -= new _IDNSSDEvents_ServiceResolvedEventHandler(this.ServiceResolved);
                m_eventManager.QueryRecordAnswered -= new _IDNSSDEvents_QueryRecordAnsweredEventHandler(this.QueryAnswered);
                m_eventManager.OperationFailed -= new _IDNSSDEvents_OperationFailedEventHandler(this.OperationFailed);

                Thread.Sleep(500);
            }

            base.Dispose(disposing);
        }

        //Exit application when form is closed
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Receive()
        {
            try
            {
                // Begin receiving the data from the remote device.
                m_socket.BeginReceive(m_buffer, 0, BUFFER_SIZE, 0, new AsyncCallback(ReceiveCallback), m_socket);
            }
            catch
            {

            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Read data from the remote device.
                int bytesRead = m_socket.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // Get the rest of the data.
                    m_socket.BeginReceive(m_buffer, 0, BUFFER_SIZE, 0, new AsyncCallback(ReceiveCallback), m_socket);
                
                    string strFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), Guid.NewGuid().ToString() + ".jpg");
                    using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(m_buffer, 0, m_buffer.Length);
                        fs.Close();
                    }

                    if(picBox.InvokeRequired)
                    {
                        Invoke((Action)(() => { picBox.ImageLocation = strFileName; }));
                    }
                    else
                    {
                        picBox.ImageLocation = strFileName;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {
            IPEndPoint localEP = new IPEndPoint(System.Net.IPAddress.Any, 0);

            //
            // create the socket and bind to INADDR_ANY
            //
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_socket.Bind(localEP);
            localEP = (IPEndPoint)m_socket.LocalEndPoint;

            Receive();

            try
            {
                //
                // start the register and browse operations
                //
                m_registrar = m_service.Register(0, 0, "CLIENT - " + System.Environment.UserName , "_soap._tcp,_imgsvc", null, null, (ushort)localEP.Port, null, m_eventManager);
                m_browser = m_service.Browse(0, 0, "_soap._tcp,_imgsvc", null, m_eventManager);
            }
            catch
            {
                MessageBox.Show("Bonjour service is not available", "Error");
                Application.Exit();
            }
        }
    }
}