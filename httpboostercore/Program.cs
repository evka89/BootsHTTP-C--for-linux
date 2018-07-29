using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;

namespace httpboostercore
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadTest TH = new ThreadTest();
            Console.Title = "HTTP BOOSTER by promychev. StopDDoS.PRO";
            Console.WriteLine("HTTP-BOOSTER By Promychev\nStopDDoS.PRO Layer7 Testing Tool");
            Console.WriteLine("Put proxy hosts list in to the file proxy.txt without empty or whitespase string!");
            Console.WriteLine("Put 1 target URL in to the file target.txt");
            Console.WriteLine("Type threads count for example 500 or 1000");

            int i = 0;
            int a;
            a = Convert.ToInt32(Console.ReadLine());

            while (i < a)
            {
                new Thread(TH.WriteY).Start();
                //System.Threading.Thread.Sleep(50);
                i++;
            }

            Console.ReadKey();
        }
    }
}
