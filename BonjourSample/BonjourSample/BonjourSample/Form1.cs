using Bonjour;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonjourServer
{
    public partial class Form1 : Form
    {
        private DNSSDEventManager m_eventManager = null;
        private DNSSDService m_service = null;
        private DNSSDService m_registrar = null;
        private DNSSDService m_browser = null;
        private DNSSDService m_resolver = null;

        private String m_name;
        private Socket m_socket = null;
        private const int BUFFER_SIZE = 1024 * 250;
        public byte[] m_buffer = new byte[BUFFER_SIZE];

        MemoryStream ms;

        public Form1()
        {
            InitializeComponent();

            try
            {
                m_service = new DNSSDService();
            }
            catch
            {
                MessageBox.Show("Bonjour Service is not available", "Error");
                Application.Exit();
            }

            m_eventManager = new DNSSDEventManager();
            m_eventManager.ServiceRegistered += new _IDNSSDEvents_ServiceRegisteredEventHandler(this.ServiceRegistered);
            m_eventManager.ServiceFound += new _IDNSSDEvents_ServiceFoundEventHandler(this.ServiceFound);
            m_eventManager.ServiceLost += new _IDNSSDEvents_ServiceLostEventHandler(this.ServiceLost);
            m_eventManager.ServiceResolved += new _IDNSSDEvents_ServiceResolvedEventHandler(this.ServiceResolved);
            m_eventManager.QueryRecordAnswered += new _IDNSSDEvents_QueryRecordAnsweredEventHandler(this.QueryAnswered);
            m_eventManager.OperationFailed += new _IDNSSDEvents_OperationFailedEventHandler(this.OperationFailed);
        }

        private void txtImagePath_TextChanged(object sender, EventArgs e)
        {
            string strFile = Path.GetFullPath(txtImagePath.Text);

            if (File.Exists(strFile))
            {
                picBox.ImageLocation = strFile;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image File (*.jpg)|*.jpg";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = ofd.FileName;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            ServiceInfo serviceInfor = (ServiceInfo)comboBox1.SelectedItem;

            IPEndPoint endPoint = new IPEndPoint(serviceInfor.Address, serviceInfor.Port);
            ms = new MemoryStream();

            picBox.Image.Save(ms, picBox.Image.RawFormat);
            byte[] buffer = ms.GetBuffer();

            try
            {
                m_socket.SendTo(buffer, endPoint);
            }
            catch
            {
                MessageBox.Show("Please select an image of size less than 100kb");
            }

            ms.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPEndPoint localEP = new IPEndPoint(IPAddress.Any, 0);

            //
            // create the socket and bind to INADDR_ANY
            //
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_socket.Bind(localEP);
            localEP = (IPEndPoint)m_socket.LocalEndPoint;

            //
            // start asynchronous read
            //
            //m_socket.BeginReceive(m_buffer, 0, BUFFER_SIZE, 0, new AsyncCallback(this.OnReadSocket), this);

            try
            {
                //
                // start the register and browse operations
                //
                m_registrar = m_service.Register(0, 0, "SERVER - " + System.Environment.UserName , "_soap._tcp,_imgsvc", null, null, (ushort)localEP.Port, null, m_eventManager);
                //m_registrar = m_service.Register(0, 0, System.Environment.UserName, "_p2pchat._udp", null, null, (ushort)localEP.Port, null, m_eventManager);
            }
            catch
            {
                MessageBox.Show("Bonjour service is not available", "Error");
                Application.Exit();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceInfo serviceInfo = (ServiceInfo)comboBox1.SelectedItem;

            try
            {
                m_resolver = m_service.Resolve(0, serviceInfo.InterfaceIndex, serviceInfo.InstanceName, serviceInfo.Type, serviceInfo.Domain, m_eventManager);
            }
            catch
            {
                MessageBox.Show("Unable to Resolve service", "Error");
                Application.Exit();
            }
        }

        //
        // QueryAnswered
        //
        // Called by DNSServices core as a result of DNSService.QueryRecord()
        // call
        //
        public void
        QueryAnswered
            (
            DNSSDService service,
            DNSSDFlags flags,
            uint ifIndex,
            String fullName,
            DNSSDRRType rrtype,
            DNSSDRRClass rrclass,
            Object rdata,
            uint ttl
            )
        {
            //
            // Stop the resolve to reduce the burden on the network
            //
            m_resolver.Stop();
            m_resolver = null;

            ServiceInfo serviceInfo = (ServiceInfo)comboBox1.SelectedItem;
            uint bits = BitConverter.ToUInt32((Byte[])rdata, 0);
            IPAddress address = new IPAddress(bits);
            serviceInfo.Address = address;
        }

        //
        // ServiceResolved
        //
        // Called by DNSServices core as a result of DNSService.Resolve()
        // call
        //
        public void
        ServiceResolved
                    (
                    DNSSDService sref,
                    DNSSDFlags flags,
                    uint ifIndex,
                    String fullName,
                    String hostName,
                    ushort port,
                    TXTRecord txtRecord
                    )
        {
            m_resolver.Stop();
            m_resolver = null;

            ServiceInfo serviceInfo = (ServiceInfo)comboBox1.SelectedItem;

            serviceInfo.Port = port;

            //
            // Query for the IP address associated with "hostName"
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

        //
        // ServiceLost
        //
        // Called by DNSServices core as a result of a Browse call
        //
        public void
        ServiceLost
                    (
                    DNSSDService sref,
                    DNSSDFlags flags,
                    uint ifIndex,
                    String serviceName,
                    String regType,
                    String domain
                    )
        {
            ServiceInfo serviceInfo = new ServiceInfo();

            serviceInfo.InterfaceIndex = ifIndex;
            serviceInfo.InstanceName = serviceName;
            serviceInfo.Type = regType;
            serviceInfo.Domain = domain;
            serviceInfo.Address = null;

            comboBox1.Items.Remove(serviceInfo);
        }

        //
        // ServiceFound
        //
        // Called by DNSServices core as a result of a Browse call
        //
        public void
        ServiceFound
                    (
                    DNSSDService sref,
                    DNSSDFlags flags,
                    uint ifIndex,
                    String serviceName,
                    String regType,
                    String domain
                    )
        {
            if (serviceName != m_name && serviceName.ToUpper().StartsWith("CLIENT"))
            {
                ServiceInfo serviceInfo = new ServiceInfo();

                serviceInfo.InterfaceIndex = ifIndex;
                serviceInfo.InstanceName = serviceName;
                serviceInfo.Type = regType;
                serviceInfo.Domain = domain;
                serviceInfo.Address = null;

                comboBox1.Items.Add(serviceInfo);

                if (comboBox1.Items.Count == 1)
                {
                    comboBox1.SelectedIndex = 0;
                }
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

            //
            // Try to start browsing for other instances of this service
            //
            try
            {
                m_browser = m_service.Browse(0, 0, "_soap._tcp,_imgsvc", null, m_eventManager);
                //m_browser = m_service.Browse(0, 0, "_p2pchat._udp", null, m_eventManager);
            }
            catch
            {
                MessageBox.Show("Browse Failed", "Error");
                Application.Exit();
            }
        }

        public void
        OperationFailed
                    (
                    DNSSDService service,
                    DNSSDError error
                    )
        {
            MessageBox.Show("Operation returned an error code " + error, "Error");
        }

        #region Overrides

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                if (m_registrar != null)
                {
                    m_registrar.Stop();
                }

                if (m_browser != null)
                {
                    m_browser.Stop();
                }

                if (m_resolver != null)
                {
                    m_resolver.Stop();
                }

                m_eventManager.ServiceFound -= new _IDNSSDEvents_ServiceFoundEventHandler(this.ServiceFound);
                m_eventManager.ServiceLost -= new _IDNSSDEvents_ServiceLostEventHandler(this.ServiceLost);
                m_eventManager.ServiceResolved -= new _IDNSSDEvents_ServiceResolvedEventHandler(this.ServiceResolved);
                m_eventManager.QueryRecordAnswered -= new _IDNSSDEvents_QueryRecordAnsweredEventHandler(this.QueryAnswered);
                m_eventManager.OperationFailed -= new _IDNSSDEvents_OperationFailedEventHandler(this.OperationFailed);
            }
            base.Dispose(disposing);
        }

        #endregion

    }
}
