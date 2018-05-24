using Ionic.Zip;
using System;
using System.Net;

namespace App1.Classes
{
    class Download0
    {
        public void DownloadFile(int source, int err)
        {
            WebClient client = new WebClient();
            try
            {
                if (source == 1)
                {
                    client.DownloadFile("https://www.bankier.pl/inwestowanie/profile/quote.html?symbol=PKNORLEN", @"C:\Users\Piotr Waleczek\Desktop\ZTP\bossa\log.txt");
                }
                else if (source == 2)
                {
                    client.DownloadFile("http://bossa.pl/pub/metastock/mstock/mstall.zip", @"C:\Users\Piotr Waleczek\Desktop\ZTP\bossa\log.txt");
                    using (ZipFile zip = ZipFile.Read(@"C:\Users\Piotr Waleczek\Desktop\ZTP\bossa\log.txt"))
                    {
                        zip.ExtractAll(@"C:\Users\Piotr Waleczek\Desktop\ZTP\bossa");
                    }
                }
            }
            catch (Exception exc)
            {
                if (err == 1)
                {
                    //System.IO.File.AppendAllText(@"C:\Users\Piotr Waleczek\Desktop\ZTP\bossa\log.txt", exc.Message);
                }
                else if (err == 2)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }
    }
}
