using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DiamondsCLI
{
    public class Serwis
    {
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string LinkDoLogowania { get; set; }
        public string LinkDoLosowania { get; set; }
        public CookieContainer CookieContainer { get; set; }
        public Serwis(string linkDoLogowania, string linkDoLosowania, string login, string haslo)
        {
            Login = login;
            Haslo = haslo;
            LinkDoLosowania = linkDoLosowania;
            LinkDoLogowania = linkDoLogowania;
        }
        public void Zaloguj()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(LinkDoLogowania);
            CookieContainer container = new CookieContainer();
            request.CookieContainer = container;
            request.Method = "POST";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:52.0) Gecko/20100101 Firefox/52.0";
            request.ContentType = "application/x-www-form-urlencoded";

            StringBuilder data = new StringBuilder();
            data.Append("loginUserLogin=" + Uri.EscapeDataString(Login));
            data.Append("&loginUserPass=" + Uri.EscapeDataString(Haslo));
            data.Append("&postAction=1");

            byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());
            request.ContentLength = byteData.Length;

            Stream postData = request.GetRequestStream();
            postData.Write(byteData, 0, byteData.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            CookieContainer = container;
        }
        public string Losuj()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(LinkDoLosowania);
            request.CookieContainer = CookieContainer;
            request.Method = "POST";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:52.0) Gecko/20100101 Firefox/52.0";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string responseString = reader.ReadToEnd();
            
            return responseString;
        }
    }
}
