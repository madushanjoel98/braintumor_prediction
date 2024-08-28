using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuthApp.utils
{
    public class ResponseModel
    {
        public static ContentResult CreateResponse(object data, string message, HttpStatusCode code)
        {
            var output = new
            {
                data = data,
                message = message
            };

            // Serialize the object to a JSON string
            string jsonString = JsonSerializer.Serialize(output);

            ContentResult result = new ContentResult
            {
                Content = jsonString,
                ContentType = MediaTypeNames.Application.Json,
                StatusCode = (int)code
            };

            return result;
        }
    }
}
