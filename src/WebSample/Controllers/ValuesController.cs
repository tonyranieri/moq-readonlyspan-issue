using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSample.Services;

namespace WebSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IFooService _fooService;

        public ValuesController(IFooService fooService)
        {
            _fooService = fooService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return _fooService.GetSomeData().ToString();
        }
    }
}
