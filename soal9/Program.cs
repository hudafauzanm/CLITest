using System;
using McMaster.Extensions.CommandLineUtils;
using PuppeteerSharp;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace soal9
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
                    var change = url.Replace("/","_");
                    await page.ScreenshotAsync($"{change}.{format}",optScreen);
                    await page.CloseAsync();
                }
                else if (format == "png")
                {
                    var change = url.Replace("/","_").Replace(":","_");
                    await page.ScreenshotAsync($"{change}.{format}",optScreen);
                    await page.CloseAsync();
                }
            }
            else if(format =="pdf")
            {
                var change = url.Replace("/","_").Replace(":","_");
                await page.PdfAsync($"{change}.{format}");
                await page.CloseAsync();
            }
        }
        static async Task<int> Main(string[] args)
        {
            var root = new CommandLineApplication()
            {
                Name = "#6 Get IP Address in private network",
                Description = "Aplikasi Get IP Address in private network",
                ShortVersionGetter = () => "1.0.0",
            };

            root.Command("screenshot-list",app => 
            {
                app.Description = "Get a screenshot from a URL";

                var text = app.Argument("Text","Masukkan Text");
                var format = app.Option("--format","Panjang random",CommandOptionType.SingleOrNoValue);
                
                
                app.OnExecuteAsync(async cancellationToken => 
                {
                    if(format.HasValue())
                    {
                        var lines = File.ReadLines(text.Value);
                        foreach(var l in lines)
                        {
                            await screenshot(l,format.Value());
                        }
                    }
                });
            });

            return root.Execute(args);
        }
    }
}
