using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Chinook.WebApi.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(new List<string> {"Testing", "Testing", "Testing", "Testing", "Testing", "Testing", "Testing", "Testing", "Testing", "Testing"
            , "Testing", "Testing", "Testing", "Testing", "Testing", "Testing", "Testing", "Testing", "Testing", "Testing", "Testing", "Testing"});
        }
    }
}