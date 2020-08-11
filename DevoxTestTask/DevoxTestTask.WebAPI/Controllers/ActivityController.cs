using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevoxTestTask.BLL.Interfaces;
using DevoxTestTaskCommon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevoxTestTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("day")]
        public async Task<ActionResult<string>> GetActivityByEmployeePerDay([FromBody]ActivityDataDTO data)
        {
            return Ok(await _activityService.GetActivitiesByEmployeePerDate(data.EmployeeId, data.Date));
        }

        [HttpGet("week")]
        public async Task<ActionResult<string>> GetActivityByEmployeePerWeek(int id, int week)
        {
            return Ok(await _activityService.GetActivitiesByEmployeePerWeek(id, week));
        }
    }
}