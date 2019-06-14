using System;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;

namespace EDEN.Utility.Comm.Http
{
    public abstract class HttpWinRequest
    {
        private static string DEFAULT_MEDIA_TYPE = "application/json";
        private static Encoding DEFAULT_ENCODING = Encoding.UTF8;

        public string Method { get; set; }
        
        public Encoding Encoding { get; set; }

        public string MediaType { get; set; }

        public string Path { get; set; }

        public Object Body { get; set; }

        protected HttpWinRequest(string path)
        {
            this.Encoding = HttpWinRequest.DEFAULT_ENCODING;
            this.MediaType = HttpWinRequest.DEFAULT_MEDIA_TYPE;

            this.Path = path;
        }
    }

    public class HttpWinGetRequest : HttpWinRequest
    {
        public string QueryString { get; set; }

        public HttpWinGetRequest(string path) : base(path) { }

        public HttpWinGetRequest(string path, object param) : this(path)
        {
            this.Method = "GET";

            List<string> values = new List<string>();
            foreach (var prop in param.GetType().GetProperties())
            {
                string name = prop.Name;
                object value = prop.GetValue(param);

                values.Add(name + "=" + value.ToString());
            }

            this.QueryString = string.Join("&", values);
        }
    }

    public class HttpWinPostRequest : HttpWinRequest
    {
        public HttpWinPostRequest(string path, object body) : base(path)
        {
            this.Method = "POST";
            this.Body = body;
        }

        public HttpContent GetPostContent()
        {
            string body = JsonParser.ToJson(this.Body);
            HttpContent content = new StringContent(body, this.Encoding, this.MediaType);

            return content;
        }
    }
}
