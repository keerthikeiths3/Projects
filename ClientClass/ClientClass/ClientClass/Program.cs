using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//provides socket implementation
using System.Net;
using System.Net.Sockets;


namespace ClientClass
{
    class Program
    {
        static void Main(string[] args)
            {
            
                //Creates a new instance and connects to a remote Tcp host using local host and a port number
                TcpClient UserClient = new TcpClient("localhost", 1200);
                //Displays a message when connecting to the server
                Console.WriteLine("Connecting to the server");
                //Displays message when coonection is successful          
                Console.WriteLine("Connection established");
                //Prompts user to enter text  
                try
                {
                Console.WriteLine("Please enter any text: ");
                //Creates a new instance of the NetworkStream class, and Getstream is used to send and receive data    
                NetworkStream nS = UserClient.GetStream();
                //Enabling the user to respond     
                string msg = Console.ReadLine();
                //Encodes the characters in a string to a sequence of bytes                    
                byte[] displaymsg = Encoding.Unicode.GetBytes(msg);
                //Writes data to the network stream
                nS.Write(displaymsg, 0, displaymsg.Length);
                //Displays text message when message sent is successful         
                Console.WriteLine("*****Message Sent*****");
                //Sets the buffer size of the TCP client to receive data 
                byte[] buffertorec = new byte[UserClient.ReceiveBufferSize];
                //Reads data from the network stream and assigning to the data type int
                int data = nS.Read(buffertorec, 0, UserClient.ReceiveBufferSize);
                //Decodes a range of bytes from a byte array to a string  
                string charac = Encoding.Unicode.GetString(buffertorec, 0, data);
                //Displays the server's response
                Console.WriteLine("Server's Response:" + charac);
                nS.Close();
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

