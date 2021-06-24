using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DriverReport.Managers;
using DriverReport.Models;

namespace DriverReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        ReportManager reportManager = new ReportManager();

        [HttpPost("[action]")]
        //[HttpPost("ProcessInputFile")]
        public async Task<IEnumerable<DriverModel>> ProcessInputFile([FromBody] FileTextModel file)
        {
            var data = await reportManager.ProcessInputFile(file.fileText);
            return data.OrderBy(o=>o.Miles).Reverse();
        }
    }
}