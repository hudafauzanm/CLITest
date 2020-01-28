using System;
using McMaster.Extensions.CommandLineUtils;
using System.Net;
using System.Text.RegularExpressions;

namespace soal7
{
    class Program
    {
        static int Main(string[] args)
        {
            var root = new CommandLineApplication()
            {
                Name = "#7 Get External IP Address",
                Description = "Get External IP Address",
                ShortVersionGetter = () => "1.0.0",
            };

            root.Command("ip-external",app => 
            {
                app.Description = "IP Address External String";

                var text = app.Argument("Text","Masukkan Text");
                app.OnExecute(() => 
                {
                    string externalIP = "";
                    externalIP = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
                    externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")).Matches(externalIP)[0].ToString();
                    Console.WriteLine(externalIP);
                });
            });

            return root.Execute(args);
        }
    }
}
