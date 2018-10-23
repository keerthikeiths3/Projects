using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//provides socket implementation
using System.Net;
using System.Net.Sockets;


namespace ServerClass
{
    class Program
    {
        static void Main(string[] args)
        {


            //Accepting any client requests coming on the interface, 
            //initializes a new instance of the listener class on a specified port. 
            TcpListener listener = new TcpListener(IPAddress.Any, 1200);
            //Message displayed when listener is created              
            Console.WriteLine("Listener created");
            // Listening for incoming connection requests
            listener.Start();
            // Retrive the Name of HOST
            //string hostName = Dns.GetHostName();
            //Retrieve the Ip address of the client
            //string IPaddress = Dns.GetHostByName(hostName).AddressList[0].ToString();
            //Accepting the client via TCP
            TcpClient UserClient = listener.AcceptTcpClient();
            //Displays a message once the client connection is successful                          
            Console.WriteLine(" Client connection established");
            try
            {
                //Creates a new instance of the NetworkStream class, and Getstream is used to send and receive data                       
                NetworkStream st = UserClient.GetStream();
                //Sets the buffer size of the TCP client to receive data                                   
                byte[] buffertorec = new byte[UserClient.ReceiveBufferSize];
                //Reads data from the network stream and assigning to the data type int              
                int data = st.Read(buffertorec, 0, UserClient.ReceiveBufferSize);
                //Decodes a range of bytes from a byte array to a string           
                string charac = Encoding.Unicode.GetString(buffertorec, 0, data);
                //Message to display when data is received from the client          
                Console.WriteLine("Message received from Client:" + charac + "  Client IpAddress:" + UserClient.Client.RemoteEndPoint);
                //Displaying the hostname and Ip address
                //Console.WriteLine("Client IpAddress:" + UserClient.Client.RemoteEndPoint );
                //Console.WriteLine("HostName: " + hostName + "\nIpAddress of the Client : " + IPaddress);
                //Prompts the user to type any message
                Console.WriteLine("Please enter any text to respond :");
                //Allows the user to enter the message                  
                string msg = Console.ReadLine();
                //Encodes the characters in a string to a sequence of bytes                                              
                byte[] displaymsg = Encoding.Unicode.GetBytes(msg);
                //Writes data to the network stream                        
                st.Write(displaymsg, 0, displaymsg.Length);
                Console.WriteLine("*****Message Sent*****");
                st.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            //Closes the connection and disposes the TcpClient instance                                                           
            UserClient.Close();
            //Obtains the next character entered by the user         
            Console.ReadKey();
        }
    }
}
