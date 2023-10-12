using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
namespace event_logger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class event_logger : ControllerBase
    {
        [HttpGet("logger")]
        public IActionResult Logger(string s)
        {
            string filePath = "D:/sui/event_logger/event_logger/logger.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine("event: " + s + " time: " + DateTime.Now + ".");
                }
            }
            catch(Exception ex)
            {
                
            }


            return Ok("Action logged succesfully!!! ");
        }

        //The service caller method 

        //void UrlCaller(string error)  
        //{
        //    var uri = new Uri("https://localhost:7283/event_logger/logger");

        //    using (var client = new RestClient(uri))
        //    {
        //        var request = new RestRequest("", Method.Get);
        //        request.AddQueryParameter("s", error);
        //        var response = client.Execute(request);
        //        var ResponseData = JsonConvert.DeserializeObject<string>(response.Content);
        //        //return ResponseData;
        //    }
        }
    }
}