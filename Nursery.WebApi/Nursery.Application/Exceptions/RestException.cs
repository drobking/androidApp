using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Nursery.Application.Exceptions
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode code, object errors = null)
        {
            Code = code;
            Errors = errors;
        }

        public HttpStatusCode Code { get; }

        public object Errors { get; set; }
    }
}
