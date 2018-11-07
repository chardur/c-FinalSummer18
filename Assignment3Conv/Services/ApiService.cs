using System;
using System.IO;
using System.Net;
using System.Text;

namespace Assignment3Conv.Services
{
    public class ApiService
    {
        protected static Encoding Encoder => Encoding.UTF8;
        protected static string ContentType => "application/json";
        protected HttpWebRequest Request { get; set; }

        //prime request, add headers, then get response


        public virtual void PrimeRequest(string url, string requestType, string data = null)
        {
            Request = (HttpWebRequest)WebRequest.Create(url);
            Request.Method = requestType;
            Request.ContentType = ContentType;
            if (data == null)
            {
                return;
            }

            var bytes = Encoder.GetBytes(data);
            Request.ContentLength = bytes.Length;


            using (var stream = Request.GetRequestStream())
                stream.Write(bytes, 0, bytes.Length);
        }

        public string GetResponse(string url, string data)
        {
            if (Request == null)
            {
                throw new Exception("Must generate request before response");
            }

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)Request.GetResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            var statusCode = response.StatusCode;
            if (statusCode != HttpStatusCode.OK)
            {
                return null;
            }

            using (var reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}