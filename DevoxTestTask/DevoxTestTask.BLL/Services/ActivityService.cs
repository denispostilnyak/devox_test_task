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
using DevoxTestTaskCommon.Models;

namespace DevoxTestTask.BLL.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IMapper _mapper;
        private readonly DevoxTestTaskDbContext _devoxTestTaskDbContext;

        public ActivityService(DevoxTestTaskDbContext devoxTestTaskDbContext, IMapper mapper)
        {
            _devoxTestTaskDbContext = devoxTestTaskDbContext;
            _mapper = mapper;
        }
        public async Task<ActivityDTO> GetActivitiesByEmployeePerDate(int id, DateTime date)
        {
            var activities = _devoxTestTaskDbContext.Activities.ToList();

            if (activities.Any((activity) => activity.EmployeeId == id && activity.Date == date))
            {
                throw new NotFoundException("activity");
            }

            var employeeActivities = activities.Where(activity => activity.EmployeeId == id && activity.Date == date);
        }

        public async Task<ActivityDTO> GetActivitiesByEmployeePerWeek(int id, int week)
        {
            var activities = _devoxTestTaskDbContext.Activities.ToList();

            if (activities.Any((activity) => activity.EmployeeId == id && GetWeekNumber(activity.Date) == week)) {
                throw new NotFoundException("activity");
            }
            var employeeActivities = activities.Where(activity => activity.EmployeeId == id && GetWeekNumber(activity.Date) == week);
        }

        private static int GetWeekNumber(DateTime date)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday) {
                date = date.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
