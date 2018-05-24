using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using App1.Classes;


namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Download0 d0 = new Download0();
            //d0.DownloadFile(1, 1);

            //Download d = new DownloadFromBossa(new ErrorMessageToFile());
            //d.DownloadFile();

            //ISignals s1 = Factory.CreateSignal("a");
            //Operations op = new Operations(s1);

            //s1.xx(new List<(string, double) > () { ("a", 32), ("b", 34), ("c", 38) });

            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Piotr Waleczek\Desktop\ZTP\ZTP\bossa\mstall");
            FileInfo[] fi = di.GetFiles();
            Directory.CreateDirectory("data");
            Parallel.For(0, fi.Length, async i =>
            {
                Indicators ind = new Indicators();
                Dictionary<string, string> w = ind.Wskazniki(20, fi[i].FullName);

                await Writer.WriteAsyncToFile("data/" + fi[i].Name, w);
                foreach (var item in w)
                {
                    Console.WriteLine($"Data {item.Key} = {item.Value}");
                }
            });

            Console.WriteLine("Nacisnij dowolny przycisk.");
            Console.Read();

        }

        public class Writer
        {
            public static async Task WriteAsyncToFile(string path, Dictionary<string, string> data)
            {
                StreamWriter sww = new StreamWriter(path, false);
                foreach (var item in data)
                {
                    await sww.WriteLineAsync($"Data {item.Key} = {item.Value}");
                }
                sww.Close();
            }
        }
    }
}
    

