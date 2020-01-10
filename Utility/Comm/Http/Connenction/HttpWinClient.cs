using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EDEN.Utility.Comm.Http
{
    public class HttpWinClient : IDisposable
    {
        private HttpClientHandler _handler = null;
        private HttpClient _client = null;  // client socket
        private Uri _uri = null;    // server address

        public Uri Uri
        {
            get { return _uri; }
        }

        /// <param name="uri">Server address</param>
        public HttpWinClient(string uri)
        {
            _handler = new HttpClientHandler();
            _client = new HttpClient(_handler);
            _uri = new Uri(uri);
        }

        public HttpWinResponse<T> Get<T>(HttpWinGetRequest request)
        {
            UriBuilder builder = new UriBuilder(this._uri);
            builder.Path = request.Path;
            builder.Query = request.QueryString;

            HttpWinResponse<T> response = null;
            using (HttpResponseMessage message = _client.GetAsync(builder.Uri).Result)
            {
                response = new HttpWinResponse<T>(message);
            }
            return response;
        }

        public async Task<HttpWinResponse<T>> GetAsync<T>(HttpWinGetRequest request)
        {
            UriBuilder builder = new UriBuilder(this._uri);
            builder.Path = request.Path;
            builder.Query = request.QueryString;

            HttpWinResponse<T> response = null;
            using (HttpResponseMessage message = await _client.GetAsync(builder.Uri))
            {
                response = await HttpWinResponse<T>.FromMessage(message);
            }
            return response;
        }

        public HttpWinResponse<T> Post<T>(HttpWinPostRequest request)
        {
            UriBuilder builder = new UriBuilder(this._uri);
            builder.Path = request.Path;

            HttpWinResponse<T> response = null;
            using (HttpContent content = request.GetPostContent())
            {
                HttpResponseMessage message = _client.PostAsync(builder.Uri, content).Result;
                response = new HttpWinResponse<T>(message);
            }

            return response;
        }

        public async Task<HttpWinResponse<T>> PostAsync<T>(HttpWinPostRequest request)
        {
            UriBuilder builder = new UriBuilder(this._uri);
            builder.Path = request.Path;

            HttpWinResponse<T> response = null;
            using (HttpContent content = request.GetPostContent())
            {
                HttpResponseMessage message = await _client.PostAsync(builder.Uri, content);
                response = await HttpWinResponse<T>.FromMessage(message);
            }

            return response;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
