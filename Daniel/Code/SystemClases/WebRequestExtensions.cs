using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PS_Hospital_System_Project_2019
{
   public static class WebRequestExtensions
    {
        public static WebResponse GetResponseWithoutException(this WebRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            try
            {
                return request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Response == null)
                {
                    throw;
                }

                return e.Response;
            }
        }
    }
}
