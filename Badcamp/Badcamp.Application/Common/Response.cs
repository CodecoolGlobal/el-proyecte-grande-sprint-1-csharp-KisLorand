using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.Common
{
    public class Response
    {
        public bool Success { get; private set; }
        public string Error { get; private set; }
        public bool Failure
        {
            get { return !Success; }
        }
        protected Response(bool success, string error)
        {
            Guard.Require(success || !string.IsNullOrEmpty(error), "Error message is not required because the result is success");
            Guard.Require(!success || string.IsNullOrEmpty(error), "Error message is required if the success is false");
            Success = success;
            Error = error;
        }
        public static Response Fail(string message)
        {
            return new Response(false, message);
        }
        public static Response Ok()
        {
            return new Response(true, string.Empty);
        }
        public static Response<T> Ok<T>(T value)
        {
            return new Response<T>(true, string.Empty, value);
        }
        public static Response<T> Fail<T>(string message)
        {
            return new Response<T>(false, message, default);
        }
    }
    public class Response<T> : Response
    {
        public T Value { get; }

        public Response(bool success, string errorMessage, T value) : base(success, errorMessage)
        {
            Value = value;
        }
    }

}
