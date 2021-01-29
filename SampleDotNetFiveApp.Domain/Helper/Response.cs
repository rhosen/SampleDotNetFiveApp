using System;

namespace SampleDotNetFiveApp.Data.Domain.Helper
{
    public class Response
    {
        public ResponseCode Code { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }


        public void Success(dynamic data, string message = "Operation Successful")
        {
            Code = ResponseCode.Success;
            Message = message;
            Data = data;
        }

        public void Error(Exception exception)
        {
            Code = ResponseCode.Error;
            Message = exception.InnerException != null ? $"Exception: {exception.Message} Inner Exception: {exception.InnerException}"
                : $"Exception: {exception.Message}";
        }
    }
}
