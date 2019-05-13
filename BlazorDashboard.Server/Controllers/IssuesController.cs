using BlazorDashboard.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDashboard.Shared.Models;
using BlazorDashboard.Server.Data;

namespace BlazorDashboard.Server.Controllers
{
    [Route("api/[controller]")]
    public class IssuesController : Controller
    {
        [HttpGet("[action]")]
        public async Task<IEnumerable<Issue>> GetIssues(DateTime timeRange)
        {
            return await IssuesGenerator.GenerateIssues(timeRange);
        }
    }
}
