using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PuppeteerSharp;
using McMaster.Extensions.CommandLineUtils;

namespace soal8
{
    class Program
    {
        public static async Task screenshot(string url ,string format)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync(url);

            var optScreen = new ScreenshotOptions()
            {
                FullPage = true
                
            };

            if(format == "jpg" || format == "png")
            {
                if(format == "jpg")
                {
                    string path = "D:/Users/bsi50128/CLITest/soal8/";
                    string[] files = Directory.GetFiles(path,"*.jpg");
                    foreach(string file in files)
                    {
                        Console.WriteLine(file);
                        if(file.Contains("screenshot"))
                        {
                            var hasil = Path.GetFileNameWithoutExtension(file);
                            var coba = hasil.Replace("screenshot-","");
                            var tambah = int.Parse(coba)+1;
                            await page.ScreenshotAsync($"screenshot-0{tambah}.{format}",optScreen);
                        }
                    }
                    await page.ScreenshotAsync($"screenshot-0{1}.{format}",optScreen);
                    
                    await page.CloseAsync();
                }
                else if (format == "png")
                {
                    string path = "D:/Users/bsi50128/CLITest/soal8/";
                    string[] files = Directory.GetFiles(path,"*.png");
                    foreach(string file in files)
                    {
                        if(file.Contains("screenshot"))
                        {
                            var hasil = Path.GetFileNameWithoutExtension(file);
                            var coba = hasil.Replace("screenshot-","");
                            var tambah = int.Parse(coba)+1;
                            await page.ScreenshotAsync($"screenshot-0{tambah}.{format}",optScreen);
                        }
                    }
                    await page.ScreenshotAsync($"screenshot-0{1}.{format}",optScreen);
                    await page.CloseAsync();
                }
                  
            }
            else if(format =="pdf")
            {
                string path = "D:/Users/bsi50128/CLITest/soal8/";
                string[] files = Directory.GetFiles(path,"*.pdf");
                foreach(string file in files)
                {
                    //Console.WriteLine(file);
                    if(file.Contains("screenshot"))
                    {
                        string hasil = Path.GetFileNameWithoutExtension(file);
                        string coba = hasil.Replace("screenshot-","");
                        var tambah = int.Parse(coba)+1;
                        await page.PdfAsync($"screenshot-0{tambah}.{format}");
                    }
                    await page.PdfAsync($"screenshot-0{1}.{format}");
                }
                await page.CloseAsync();
            }
        }

        public static async Task screenshotoutput(string url,string output)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync(url);

            var optScreen = new ScreenshotOptions()
            {
                FullPage = true
                
            };

            var hasil = output.LastIndexOf(".")+1;
            var jawaban = output.Substring(hasil,3);

            if(jawaban == "jpg")
            {
                    string path = "D:/Users/bsi50128/CLITest/soal8/";
                    string[] files = Directory.GetFiles(path,"*.jpg");
                    foreach(string file in files)
                    {
                        if(File.Exists(file))
                        {
                            await page.ScreenshotAsync($"{output}",optScreen);
                        }
                    }
                    await page.ScreenshotAsync($"{output}",optScreen);
                    await page.CloseAsync();   
            }

            if(jawaban == "png")
            {
                    string path = "D:/Users/bsi50128/CLITest/soal8/";
                    string[] files = Directory.GetFiles(path,"*.png");
                    foreach(string file in files)
                    {
                        if(File.Exists(file))
                        {
                            await page.ScreenshotAsync($"{output}",optScreen);
                        }
                        
                    }
                    await page.ScreenshotAsync($"{output}",optScreen);
                    await page.CloseAsync();   
            }

            if(jawaban == "pdf")
            {
                    string path = "D:/Users/bsi50128/CLITest/soal8/";
                    string[] files = Directory.GetFiles(path,"*.png");
                    foreach(string file in files)
                    {
                        if(File.Exists(file))
                        {
                            await page.PdfAsync($"{output}");
                        }
                    }
                    await page.PdfAsync($"{output}");   
                    await page.CloseAsync();
            }

            //await page.ScreenshotAsync($"{output}",optScreen);
            
        }
        static async Task<int> Main(string[] args)
        {
            //await screenshotoutput("https://google.com","hasil1.jpg");   
            var root = new CommandLineApplication()
            {
                Name = "#8 Get a screenshot from a URL",
                Description = "Aplikasi Get a screenshot from a URL",
                ShortVersionGetter = () => "1.0.0",
            };

            root.Command("screenshot",app => 
            {
                app.Description = "Get a screenshot from a URL";

                var text = app.Argument("Text","Masukkan Text");
                var format = app.Option("--format","Panjang random",CommandOptionType.SingleOrNoValue);
                var output = app.Option("--output","Panjang random",CommandOptionType.SingleOrNoValue);
                
                
                app.OnExecuteAsync(async cancellationToken => 
                {
                    if(format.HasValue())
                    {
                        await screenshot(text.Value,format.Value());
                    }
                    if(output.HasValue())
                    {
                        await screenshotoutput(text.Value,output.Value());
                    }
                });
            });

            return root.Execute(args);
        }
    }
}
