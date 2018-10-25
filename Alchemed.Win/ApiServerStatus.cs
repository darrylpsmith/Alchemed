using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ConsultWill
{
    public static class ApiServerStatus
    {

        public static bool PingHost(string hostUri, int portNumber)
        {
            return true;
            try
            {
                using (var client = new TcpClient(hostUri, portNumber))
                    return true;
            }
            catch (SocketException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error pinging host:'" + hostUri + ":" + portNumber.ToString() + "'");
                return false;
            }
        }

        public static bool ServerStatusBy(string url)

        {

            Ping pingSender = new Ping();
            url = "localhost";
            PingReply reply = pingSender.Send(url);


            Console.WriteLine("Status of Host: {0}", url);


            if (reply.Status == IPStatus.Success)

            {

                Console.WriteLine("IP Address: {0}", reply.Address.ToString());

                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);

                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);

                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);

                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);

                return true;
            }

            else
            {
                Console.WriteLine(reply.Status);
                return false;
            }
                

        }
    }
}
