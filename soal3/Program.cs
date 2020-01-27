using System;
using McMaster.Extensions.CommandLineUtils;

namespace soal3
{
    class Program
    {
        public static bool palindrom (string text)
        {
            int length = text.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (text[i] != text[length - i - 1])
                {
                return false;
                }
            }
            return true; 
        }
        static int Main(string[] args)
        {
            
            var root = new CommandLineApplication()
            {
                Name = "#3 Palindrome",
                Description = "Aplikasi Palindrom",
                ShortVersionGetter = () => "1.0.0",
            };

            root.Command("palindrom", app => 
            {
                app.Description = "Membagi String";

                var text = app.Argument("angka","Masukkan angka");

                app.OnExecute(() =>
                {
                    var hasil = text.Value.Replace(" ","").Replace(".","").Replace(",","").ToLower();
                    if(palindrom(hasil) == true)
                    {
                        Console.WriteLine("String : " + text.Value);
                        Console.WriteLine("Is Palindrom? Yes");
                    }
                    else{
                        Console.WriteLine("String : " + text.Value);
                        Console.WriteLine("Is Palindrom? No");
                    }      
                });
            });

            return root.Execute(args);
        }
    }
}
