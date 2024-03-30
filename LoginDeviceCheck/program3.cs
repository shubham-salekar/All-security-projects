using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LoginDeviceCheck              // Using System.Environment
{
    public class program3
    {
        public static void Main()
        {
            bool os = Environment.Is64BitOperatingSystem;
            Console.WriteLine(os.ToString());

            //username Fetch
            string q1 = Environment.UserName;
            Console.WriteLine(q1);

            //Version Fetch

            string q2 = Environment.Version.ToString();
            Console.WriteLine(q2);

            //Os Version Fetch
            string q3 = Environment.OSVersion.ToString();

            /*        HttpBrowserCapabilities browse = Request.Browser;
                    string platform = browse.Platform;
                    Console.WriteLine(platform);*/

            //Processor Count Fetch
            string q4 = Environment.ProcessorCount.ToString();
            Console.WriteLine(q4);

            //System Pages Fetch
            string q5 = Environment.SystemPageSize.ToString();
            Console.WriteLine(q5);

            //Working Set Fetch
            string q6 = Environment.WorkingSet.ToString();
            Console.WriteLine(q6);

            //Current Directory Fetch
            string q7 = Environment.CurrentDirectory.ToString();
            Console.WriteLine(q7);

            //Command Line Fetch
            string q8 = Environment.CommandLine.ToString();
            Console.WriteLine(q8);


            Console.WriteLine("MachineName: {0}", Environment.MachineName.ToString());

            //Ip Address Fetch
            IPHostEntry host;
            string localIP = "?";
            host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {

                if (ip.AddressFamily.ToString() == "InterNetwork")
                {

                    localIP = ip.ToString();
                    Console.WriteLine(localIP);
                }
            }
        }
    }
}
