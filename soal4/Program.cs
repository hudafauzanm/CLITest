using System;
using System.Text;
using McMaster.Extensions.CommandLineUtils;

namespace soal4
{
    class Program
    {
        public static string obsfus(string text)
        {
            var hasil = "";
            byte[] asciiBytes = Encoding.ASCII.GetBytes(text);
            foreach(var x in asciiBytes)
            {
                hasil += $"&#{Convert.ToString(x)};";
            }
            return hasil;
        }
        static int Main(string[] args)
        {
            var root = new CommandLineApplication()
            {
                Name = "#4 Obsfuscate",
                Description = "Aplikasi Obsfuscate",
                ShortVersionGetter = () => "1.0.0",
            };

            root.Command("obsfuscate",app => 
            {
                app.Description = "Obsfuscate String";

                var text = app.Argument("Text","Masukkan Text");
                app.OnExecute(() => 
                {
                    Console.WriteLine(obsfus(text.Value));
                });
            });
            
            return root.Execute(args);
        }
    }
}
