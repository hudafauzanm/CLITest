using System;
using McMaster.Extensions.CommandLineUtils;


namespace soal10
{
    class Program
    {
        static int Main(string[] args)
        {
            var root = new CommandLineApplication()
            {
                Name = "#10 Infinite inputs",
                Description = "Aplikasi Infinite inputs",
                ShortVersionGetter = () => "1.0.0",
            };

            root.Command("sum",app => 
            {
                app.Description = "Infinite inputs";

                var text = app.Argument("Text","Masukkan Text");
                app.OnExecute(() => 
                {
                    var jumlah = 0;
                    var x = 1;
                    var total = 0;
                    while (true) 
                        {
                            Console.Write($"Insert {x} number: ");
                            string line = Console.ReadLine();
                            if (line != "") 
                            {   
                                var hasil = Convert.ToInt32(line);
                                jumlah += hasil;
                                 x++;
                            }
                            else
                            {
                                total = jumlah;   
                                Console.WriteLine($"Result : {total}");
                                break;
                            }
                        }
                });
            });

            return root.Execute(args);
        }
    }
}
