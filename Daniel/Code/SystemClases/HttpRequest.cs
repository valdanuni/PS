using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PS_Hospital_System_Project_2019.SystemClases
{
    public enum RequestType
    {
        GET, POST, PUT, DELETE
    }
    public class HttpRequest
    {
        private HttpWebRequest request;
        private Action<string> errorAction;

        public HttpRequest(string endpoint, RequestType requestType)
        {
            request = (HttpWebRequest)WebRequest.Create(endpoint);
            request.Method = requestType.ToString();
            request.ContentLength = 0;
        }

        public static HttpRequest Of(string endpoint, RequestType requestType)
        {
            return new HttpRequest(endpoint, requestType);
        }

        public HttpRequest ContentType(string contentType)
        {
            request.ContentType = contentType;
            return this;
        }

        public HttpRequest Header(string header, string value)
        {
            request.Headers.Add(header, value);
            return this;
        }

        public HttpRequest BasicAuthentication(string authentication)
        {
            request.Headers.Add("Authorization", $"Basic {authentication}");
            return this;
        }

        public HttpRequest BodyData<T>(T value)
        {
            request.ContentType = "application/json";
            byte[] data = null;
            if (value is JObject)
            {
                data = Encoding.ASCII.GetBytes(value.ToString());
            }
            else
            {
                data = Encoding.ASCII.GetBytes(new JavaScriptSerializer().Serialize(value));
            }
            request.ContentLength = data.Length;
            using var stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            return this;
        }

        public HttpRequest OnError(Action<string> errorAction)
        {
            this.errorAction = errorAction;
            return this;
        }

        public HttpResponse Execute()
        {
            using var response = (HttpWebResponse)request.GetResponseWithoutException();
            var bodyResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
            if (!IsSuccessful(response))
            {
                errorAction(new JavaScriptSerializer().Deserialize<string>(bodyResponse));
                return HttpResponse.Unsuccessful;
            }
            return new HttpResponse(bodyResponse, HttpResponseStatus.Successful);
        }

        private static bool IsSuccessful(HttpWebResponse response)
        {
            return response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.Created) || response.StatusCode.Equals(HttpStatusCode.Accepted) || response.StatusCode.Equals(HttpStatusCode.NoContent);
        }

        public enum HttpResponseStatus
        {
            Successful, Unsuccessful
        }
        public class HttpResponse
        {
            public static HttpResponse Unsuccessful = new HttpResponse(null, HttpResponseStatus.Unsuccessful);
            private string Body { get; set; }
            private HttpResponseStatus HttpResponseStatus { get; set; }

            public HttpResponse(string body, HttpResponseStatus httpResponseStatus)
            {
                Body = body;
                HttpResponseStatus = httpResponseStatus;
            }

            public R DeserializeBody<R>()
            {
                if (HttpResponseStatus.Equals(HttpResponseStatus.Unsuccessful))
                {
                    return default;
                }
                return new JavaScriptSerializer().Deserialize<R>(Body);
            }

            public bool IsSuccessful()
            {
                return HttpResponseStatus == HttpResponseStatus.Successful;
            }
        }
    }
}

