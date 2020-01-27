using System;
using McMaster.Extensions.CommandLineUtils;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace soal6
{
    class Program
    {
        static int Main(string[] args)
        {
            var root = new CommandLineApplication()
            {
                Name = "#6 Get IP Address in private network",
                Description = "Aplikasi Get IP Address in private network",
                ShortVersionGetter = () => "1.0.0",
            };

            root.Command("ip",app => 
            {
                app.Description = "IP Address String";

                var text = app.Argument("Text","Masukkan Text");
                app.OnExecute(() => 
                {
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            Console.WriteLine(ip);
                        }
                    }
                });
            });

            return root.Execute(args);
        }
    }
}
