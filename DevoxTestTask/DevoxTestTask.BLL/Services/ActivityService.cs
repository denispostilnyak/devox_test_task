using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DevoxTestTask.BLL.Exceptions;
using DevoxTestTask.BLL.Interfaces;
using DevoxTestTask.DAL;
using DevoxTestTask.DAL.Entities;
using DevoxTestTaskCommon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevoxTestTask.BLL.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ActivityService> _logger;
        private readonly DevoxTestTaskDbContext _devoxTestTaskDbContext;

        public ActivityService(DevoxTestTaskDbContext devoxTestTaskDbContext, IMapper mapper, ILogger<ActivityService> logger)
        {
            _devoxTestTaskDbContext = devoxTestTaskDbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<string> GetActivitiesByEmployeePerDate(int id, DateTime date)
        {
            var activities = _devoxTestTaskDbContext.Activities.ToList();

            if (!activities.Any((activity) => activity.EmployeeId == id && activity.Date == date))
            {
                _logger.LogError("Entity activity was not found");
                throw new NotFoundException("activity");
            }

            var employeeActivities = activities.Where(activity => activity.EmployeeId == id && activity.Date == date);

            var result = await GetActivitiesTemplate(employeeActivities);
            _logger.LogInformation(result);

            return result;
        }

        public async Task<string> GetActivitiesByEmployeePerWeek(int id, int week)
        {
            var activities = _devoxTestTaskDbContext.Activities.ToList();

            if (!activities.Any((activity) => activity.EmployeeId == id && GetWeekNumber(activity.Date) == week)) {
                _logger.LogError("Entity activity was not found");
                throw new NotFoundException("activity");
            }

            var employeeActivities = activities.Where(activity => activity.EmployeeId == id && GetWeekNumber(activity.Date) == week);

            var result = await GetActivitiesTemplate(employeeActivities);
            _logger.LogInformation(result);

            return result;
        }

        private static int GetWeekNumber(DateTime date)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday) {
                date = date.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private async Task<string> GetActivitiesTemplate(IEnumerable<Activity> activities)
        {
            var result = "";
            foreach (var activity in activities) {

                if (!_devoxTestTaskDbContext.Roles.Any(role => role.Id == activity.RoleId))
                {
                    _logger.LogError("Entity role was not found");
                    throw new NotFoundException("role");
                }

                if (!_devoxTestTaskDbContext.ActivityTypes.Any(type => type.Id == activity.ActivityTypeId)) {
                    _logger.LogError("Entity activity-type was not found");
                    throw new NotFoundException("activity-type");
                }

                if (!_devoxTestTaskDbContext.Projects.Any(project => project.Id == activity.ProjectId)) {
                    _logger.LogError("Entity project was not found");
                    throw new NotFoundException("project");
                }

                result += result == "" ? "" : " and ";

                var role = await _devoxTestTaskDbContext.Roles.FirstOrDefaultAsync(role => role.Id == activity.RoleId);
                var activityType = await _devoxTestTaskDbContext.ActivityTypes.FirstOrDefaultAsync(type => type.Id == activity.ActivityTypeId);
                var project = await _devoxTestTaskDbContext.Projects.FirstOrDefaultAsync(project => project.Id == activity.ProjectId);

                result += $"{activity.Date.ToShortDateString()} as a {role.Name} I worked on the {project.Name} {activity.Duration} hours {activityType.Name}";
            }

            return result;
        }
    }
}
