using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
namespace Client
{
    /// <summary>
    /// the main for the client
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Int32.Parse(ConfigurationManager.AppSettings["Port"]));
            TcpClient client = new TcpClient();
            //conect server
            client.Connect(ep);
            bool run = true;
            Task t2;
            var ts = new CancellationTokenSource();
            var ct = ts.Token;
            Console.WriteLine("You are connected");
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                Console.Write("Please enter a command: ");
                string command = Console.ReadLine();
                //we want to open the connection only to one message
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
                    //open the conection to many message transpatent
                    //open a task that will wait for message from the console and sent it to server
                    //run until we got "close" from the server, and then we will cancale it
                    t2 = new Task(() =>
                    {
                        while (run)
                        {

                            //get the command from the user
                            writer.Write(command);
                            writer.Flush();
                            Console.Write("Please enter a command: ");
                            command = Console.ReadLine();

                        }
                    }, ct);
                    t2.Start();
                    //recive massage from server if accept close 'close the server
                    while (run)
                    {
                        string result = reader.ReadString();


                        if (result.Equals("close"))
                        {
                            run = false;
                            Console.WriteLine("close connection");
                            ts.Cancel();

                        }
                        else
                        {
                            Console.WriteLine(result);
                            Console.Write("Please enter a command: ");
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
