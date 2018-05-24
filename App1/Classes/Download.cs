using Ionic.Zip;
using System;
using System.Net;

namespace App1.Classes
{
    abstract class Download
    {
        protected ErrorMessage erm;
        protected WebClient client = new WebClient();

        public Download(ErrorMessage erm)
        {
            this.erm = erm;
        }

        public void DownloadFile()
        {
            try
            {
                DoDownload();
            }
            catch (Exception exc)
            {
                erm.GetError(exc.Message);
            }
        }

        protected virtual void DoDownload()
        {
        }

    }

    class DownloadFromBossa : Download
    {
        public DownloadFromBossa(ErrorMessage erm) : base(erm)
        {
        }

        protected override void DoDownload()
        {
            client.DownloadFile("http://bossa.pl/pub/metastock/mstock/mstall.zip", @"E:\ZTP\bossa\mstall.zip");
            using (ZipFile zip = ZipFile.Read(@"E:\ZTP\bossa\mstall.zip"))
            {
                zip.ExtractAll(@"E:\ZTP\bossa");
            }
        }
    }

    class DownloadFromBankier : Download
    {
        public DownloadFromBankier(ErrorMessage erm) : base(erm)
        {
        }
        protected override void DoDownload()
        {
            client.DownloadFile("https://www.bankier.pl/inwestowanie/profile/quote.html?symbol=PKNORLEN", @"E:\ZTP\bossa\bankier.html");
        }
    }

    abstract class ErrorMessage
    {
        public virtual void GetError(string message)
        {
        }
    }

    class ErrorMessageToFile : ErrorMessage
    {
        public override void GetError(string message)
        {
            //System.IO.File.AppendAllText(@"C:\Users\Piotr Waleczek\Desktop\ZTP\bossa\log.txt", message);
        }
    }

    class ErrorMessageToUser : ErrorMessage
    {
        public override void GetError(string message)
        {
            Console.WriteLine(message);
        }
    }
}









