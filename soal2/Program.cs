using System;
using McMaster.Extensions.CommandLineUtils;


namespace soal2
{
    class Program
    {
        static int Main(string[] args)
        {
            var root = new CommandLineApplication()
            {
                Name = "#2 Arithmetic",
                Description = "Aplikasi Arithmetic",
                ShortVersionGetter = () => "1.0.0",
            };

            root.Command("add",app => 
            {
                app.Description = "Menjumlahkan String";

                var text = app.Argument("angka","Masukkan angka",true);
                app.OnExecute(() => 
                {
                    int jumlah = 0;
                    foreach(var x in text.Values)
                    {
                         jumlah += Convert.ToInt32(x) ;
                    }
                    Console.WriteLine(jumlah);
                });
            });

            root.Command("subtract",app => 
            {
                app.Description = "Mengurangi String";

                var text = app.Argument("angka","Masukkan angka",true);
                app.OnExecute(() => 
                {
                    int jumlah = Convert.ToInt32(text.Values[0]);
                    for(int i = 2;i <= text.Values.Count;i++)
                    {
                        jumlah -= Convert.ToInt32(text.Values[i-1]);
                    } 
                    Console.WriteLine(jumlah);
                });
            });
            
            root.Command("multiply",app => 
            {
                app.Description = "Mengalikan String";

                var text = app.Argument("angka","Masukkan angka",true);
                app.OnExecute(() => 
                {
                    int jumlah = 1;
                    foreach(var x in text.Values)
                    {
                        jumlah = jumlah * Convert.ToInt32(x);
                    }
                    Console.WriteLine(jumlah);
                });
            });

            root.Command("divide",app => 
            {
                app.Description = "Membagi String";

                var text = app.Argument("angka","Masukkan angka",true);
                app.OnExecute(() => 
                {
                    int jumlah = Convert.ToInt32(text.Values[0]);
                    for(int i = 2;i <= text.Values.Count;i++)
                    {
                        jumlah = jumlah / Convert.ToInt32(text.Values[i-1]);
                    } 
                    Console.WriteLine(jumlah);
                });
            });

             return root.Execute(args);
        }
    }
}
