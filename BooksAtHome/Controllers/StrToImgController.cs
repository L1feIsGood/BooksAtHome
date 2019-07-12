using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BooksAtHome.Controllers
{
    [Route("api/[controller]")]
    public class StrToImgController : Controller
    {
        [HttpGet("[action]")]
        public string GetImage([FromQuery] string str)
        {
            // how do I get an image?
            return str;
        }
    }
}
