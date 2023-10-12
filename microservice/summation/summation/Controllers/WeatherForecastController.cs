using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace summation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        [HttpGet("add/{a}/{b}")]
        public IActionResult GetSum(int a, int b)
        {
            int result = a + b;
            return Ok(result);
        }
        [HttpGet("multiply/{a}/{b}")]
        public IActionResult GetMultiply(int a, int b)
        {
            int result = a * b;
            return Ok(result);
        }
        [HttpGet("subtract/{a}/{b}")]
        public IActionResult GetSubtract(int a, int b)
        {
            int result = a - b;
            return Ok(result);
        }
        [HttpGet("devide/{a}/{b}")]
        public IActionResult GetDiv(int a, int b)
        {

            try
            {
                int result = a / b;
                return Ok(result);
            }
            catch (Exception exp)
            {
                
                UrlCaller(exp.Message);
                return BadRequest("this is not allowed ");
            }


        }
        void UrlCaller(string error)
        {
            var uri = new Uri("https://localhost:7283/event_logger/logger");
       
            using (var client = new RestClient(uri))
            {
                var request = new RestRequest("", Method.Get);
                request.AddQueryParameter("s", error);
                var response = client.Execute(request);
                var ResponseData = JsonConvert.DeserializeObject<string>(response.Content);
                //return ResponseData;
            }
        }
    }
}