using EDEN.Utility.Comm.Http;
using EDEN.Utility.Comm.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Comm.Protocol
{
    public partial class HttpProtocol
    {
        private static HttpProtocol _instance = null;

        public static HttpProtocol Open(string uri)
        {
            if (_instance == null)
                _instance = new HttpProtocol(uri);

            return _instance;
        }

        public static void Close()
        {
            if(_instance != null)
            {
                _instance.Dispose();
                _instance = null;
            }
        }
    }


    public partial class HttpProtocol : IDisposable
    {
        private HttpWinClient _client = null;

        public Uri Uri
        {
            get { return _client?.Uri; }
        }

        private HttpProtocol(string uri)
        {
            _client = new HttpWinClient(uri);
        }

        public void Dispose()
        {
            _client.Dispose();
            _client = null;
        }
    }

    public partial class HttpProtocol
    {
		// example
        public ResponseVO<ResponseVO.Login> Login(RequestVO.Login vo)
        {
            return post<ResponseVO.Login>("auth/login", vo);
        }
    }

    public partial class HttpProtocol
    {
        private ResponseVO<T> get<T>(string path) where T : IResponseVO
        {
            HttpWinGetRequest request = new HttpWinGetRequest(path);
            HttpWinResponse<ResponseVO<T>> response = _client.Get<ResponseVO<T>>(request);
            ResponseVO<T> body = response.Body;

            return body;
        }

        private ResponseVO<T> get<T>(string path, object vo) where T : IResponseVO
        {
            HttpWinGetRequest request = new HttpWinGetRequest(path, vo);
            HttpWinResponse<ResponseVO<T>> response = _client.Get<ResponseVO<T>>(request);
            ResponseVO<T> body = response.Body;

            return body;
        }

        private ResponseVO<T> post<T>(string path, object vo) where T : IResponseVO
        {
            HttpWinPostRequest request = new HttpWinPostRequest(path, vo);
            HttpWinResponse<ResponseVO<T>> response = _client.Post<ResponseVO<T>>(request);
            ResponseVO<T> body = response.Body;

            return body;
        }

        private async Task<ResponseVO<T>> postAsync<T>(string path, object vo) where T : IResponseVO
        {
            HttpWinPostRequest request = new HttpWinPostRequest(path, vo);
            HttpWinResponse<ResponseVO<T>> response = await _client.PostAsync<ResponseVO<T>>(request);
            ResponseVO<T> body = response.Body;

            return body;
        }
    }
}
