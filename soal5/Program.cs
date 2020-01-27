using System;
using McMaster.Extensions.CommandLineUtils;

namespace soal5
{
    class Program
    {
        public static string random(int length ,bool letter,bool number,bool uppercase,bool lowercase)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            if(!letter)
            {
                for (int i = 0; i < stringChars.Length; i++)
                {
                 stringChars[i] = chars[random.Next(chars.Length-10,chars.Length)];
                }
                return new String(stringChars);
            }
            else if(!number)
            {
                for (int i = 0; i < stringChars.Length; i++)
                {
                 stringChars[i] = chars[random.Next(chars.Length-10)];

                }
                if(uppercase == true)
                {
                    return new String(stringChars).ToUpper();
                }
                else if(lowercase == true)
                { 
                    return new String(stringChars).ToLower();
                }
                
                return new String(stringChars);
            }
            else
            {
                for (int i = 0; i < stringChars.Length; i++)
                {
                 stringChars[i] = chars[random.Next(chars.Length)];
                }
                
                if(uppercase == true)
                {
                    return new String(stringChars).ToUpper();
                }
                else if(lowercase == true)
                {
                    return new String(stringChars).ToLower();
                }
                return new String(stringChars);
            }
        }
        static int Main(string[] args)
        {
            var root = new CommandLineApplication()
            {
                Name = "#5 Random String",
                Description = "Aplikasi Random String",
                ShortVersionGetter = () => "1.0.0",
            };

            root.Command("random",app => 
            {
                app.Description = "Random String";

                var text = app.Argument("Text","Masukkan Text");
                var length = app.Option("--length","Panjang random",CommandOptionType.SingleOrNoValue);
                var letter = app.Option("--letters","Panjang random",CommandOptionType.SingleOrNoValue);
                var number = app.Option("--numbers","Panjang random",CommandOptionType.SingleOrNoValue);
                var upper = app.Option("--uppercase","Panjang random",CommandOptionType.SingleOrNoValue);
                var lower = app.Option("--lowercase","Panjang random",CommandOptionType.SingleOrNoValue);

                int ln = 32;
                bool lt = true;
                bool nm = true;
                bool up = false;
                bool low = false;

                app.OnExecute(() => 
                {
                    if (length.HasValue())
                    {
                        ln = Convert.ToInt32(length.Value());
                    }
                    if(letter.HasValue())
                    {
                        if(Convert.ToBoolean(letter.Value()) == false)
                        {
                            lt = false;
                        }
                    }
                    if(number.HasValue())
                    {
                        if(Convert.ToBoolean(number.Value()) == false)
                        {
                            nm = false;
                        }
                    }
                    if(upper.HasValue())
                    {
                       if(Convert.ToBoolean(upper.Value()) == true)
                        {
                            low = true;
                        }
                    }
                    if(lower.HasValue())
                    {
                        if(Convert.ToBoolean(lower.Value()) == true)
                        {
                            low = true;
                        }
                    }
                    Console.WriteLine(random(ln,lt,nm,up,low));
                });
            });
            
            return root.Execute(args);
        }
    }
}
