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
        public async Task<ActionResult<ActivityDTO>> GetActivityByEmployeePerDay(int id, DateTime date)
        {
            return Ok(await _activityService.GetActivitiesByEmployeePerDate(id, date));
        }

        [HttpGet("week")]
        public async Task<ActionResult<ActivityDTO>> GetActivityByEmployeePerWeek(int id, int week)
        {
            return Ok(await _activityService.GetActivitiesByEmployeePerWeek(id, week));
        }
    }
}