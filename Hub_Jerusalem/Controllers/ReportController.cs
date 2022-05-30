using BL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hub_Jerusalem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        IReportBL rpbl;

        public ReportController(IReportBL rpbl)
        {
            this.rpbl = rpbl;
        }
        [HttpGet]
        public async Task Create_pdf(DateTime date, string type)
        {
            await rpbl.create_pdf(date, type);
        }
        //GET: api/<ReportController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


    }
}
