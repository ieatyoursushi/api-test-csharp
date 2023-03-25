using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace api_test_asp.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomDataController : ControllerBase
    {
        public static string generator(int length)
        {
            if (length == 0) return "";
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string randomString = "";
            for(int i = 0; i < length; i++)
            {
                randomString += chars.ToCharArray()[random.Next(0, chars.Length)];
            }
            return randomString;
            //return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                const int length = 10;
                string[] labels = new string[length];
                for (int i = 0; i < labels.Length; i++)
                {
                    labels[i] = generator(length - i);
                    Debug.WriteLine("test " + i);
                }
                return Ok(labels);
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        //wrong implementation
        [HttpPost]
        public IActionResult Post([FromBody] string inc_buffer)
        {
            try
            {
                return inc_buffer == null ? Ok("no data sent") : Ok(inc_buffer);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
 
 
