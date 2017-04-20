



 using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            bool run = true;
            Task t1, t2;
            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            Console.WriteLine("You are connected");
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
              using ( BinaryWriter writer = new BinaryWriter(stream))
           // NetworkStream stream = client.GetStream();
           // StreamReader reader = new StreamReader(stream);
           // StreamWriter writer = new StreamWriter(stream);
            {
                Console.Write("Please enter a command: ");
                string command = Console.ReadLine();
                if (command.StartsWith("generate") || command.StartsWith("solve"))
                {
                    writer.Write(command);
                    writer.Flush();
                    //Get result from server
                    string result = reader.ReadString();
                   Console.WriteLine("Result = {0}", result);
                    Console.ReadKey();
                   
                }
                else
                {

                    //open a task that will wait for message from the server
                    //run until we got "close" from the server

                    t2 = new Task(() =>
                    {
                        while (run)
                        {
                           
                            //get the command from the user
                            Console.WriteLine("arrive");
                            writer.Write(command);
                            writer.Flush();
                            Console.Write("Please enter a command: ");
                            command = Console.ReadLine();

                        }
                    }, ct);
                    t2.Start();
                    while (run)
                    {
                       string result = reader.ReadString();
                        Console.WriteLine(result);
                        Console.Write("Please enter a command: ");
                        if (result.Contains("close"))
                        {
                            run = false;
                            Console.WriteLine("close connection");
                            ts.Cancel();
                        }
                    }
                }
                writer.Write("close me");
                writer.Flush();
                Console.ReadKey();
            }
            
            client.Close();
        }
    }
}

















/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            bool run = true;
            Console.WriteLine("You are connected");
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                while (run)
                {
                    // Send data to server
                    Console.Write("Please enter a command: ");
                    string command = (Console.ReadLine());
                    if(command.StartsWith("generate") || command.StartsWith("solve"))
                    {
                        run = false;
                    }
                    writer.Write(command);
                    // Get result from server
                    string result = reader.ReadString();
                    if(result.Contains("close"))
                    {
                        run = false;
                    }
                    Console.WriteLine("Result = {0}", result);
                    Console.ReadKey();
                }
            }
            client.Close();
        }
    }
}*/

 