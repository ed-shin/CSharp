using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Comm.Http
{
    public class HttpWinResponse<T>
    {
        private HttpStatusCode _statusCode;
        private T _body;
        private string _result;

        public HttpStatusCode StatusCode
        {
            get { return _statusCode; }
        }

        public string Result
        {
            get { return _result; }
        }

        public T Body
        {
            get { return _body; }
        }

        public HttpWinResponse(HttpResponseMessage response)
        {
            _statusCode = response.StatusCode;
            _result = response.Content.ReadAsStringAsync().Result;
            _body = JsonParser.FromJson<T>(_result);
        }

        public HttpWinResponse(HttpStatusCode code, string result)
        {
            _statusCode = code;
            _result = result;
            _body = JsonParser.FromJson<T>(result);
        }

        public async static Task<HttpWinResponse<T>> FromMessage(HttpResponseMessage message)
        {
            string result = await message.Content.ReadAsStringAsync();

            HttpWinResponse<T> response = new HttpWinResponse<T>(message.StatusCode, result);
            return response;
        }
    }
}
