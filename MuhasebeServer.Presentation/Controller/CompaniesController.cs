using Microsoft.AspNetCore.Mvc;
using MuhasebeServer.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeServer.Presentation.Controller
{
    public sealed class CompaniesController : ApiController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Companies");
        }
    }
}
