/// <summary>
/// @ScripTech
/// @Author: Edilson Mucanze
/// @Email: edilsonhmberton@gmail.com
/// This transforms the data of Type T and pass it to our response Object
/// and build the response in order to return a default response for all requests
/// ---------------------------:
///     <param name="T">Oject T</param>
///     <param name="isSuccess">Boolean</param>
///     <param name="error">Error</param>
/// </summary>

using System;
using System.ComponentModel.DataAnnotations;

namespace TwiggStock.Transformers
{
    public class ResponseModel<T>
    {
        #nullable enable
        public Error? Error { get; set; }

        #nullable enable
        public ResponseMessage? Messages { get; set; }

        #nullable enable
        public T? Response { get; set; }

        #nullable disable
        public string Status { get; set; }

    }


    public class Error
    {
        public string Code { get; set; }
        public string InnerError { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }

    }
    public class ResponseMessage
    {
        public string Code { get; set; }
        public string MessageText { get; set; }
        public string Type { get; set; }
    }
    public static class ResponseTransformer
    {
        /// <summary>
        /// This Method transforms the data of Type T and pass it to our response Object
        /// and build the response in order to return a default response for all requests
        /// ---------------------------:
        ///     <param name="T">Oject T</param>
        ///     <param name="isSuccess">Boolean</param>
        ///     <param name="error">Error</param>
        /// </summary>
        public static ResponseModel<T> TransformResponse<T>(T data, bool isSuccess = true, ResponseMessage Messages = default, Error errors = null)
        {
            if(isSuccess)
            {
                Error error = default;
                ResponseMessage messages = new ResponseMessage(){
                    Code ="200",
                    MessageText = Messages != null ? Messages.MessageText : "Data returned successfully",
                    Type = Messages != null ? Messages.Type : "Success Request Service",
                };
                var response = new ResponseModel<T>(){
                    Error = error,
                    Messages = messages,
                    Response = data,
                    Status = "200,OK"
                };
                return response;
            }
            else
            {
                Error error = new Error(){
                    Code = errors.Code ?? "RF023T003",
                    InnerError = errors?.InnerError,
                    Message = errors?.Message,
                    Type = errors?.Type
                };
                ResponseMessage messages = default;
                var response = new ResponseModel<T>(){
                    Error = error,
                    Messages = messages,
                    Response = default,
                    Status = "200,OK"
                };
                return response;
            }

        }
    }
}
