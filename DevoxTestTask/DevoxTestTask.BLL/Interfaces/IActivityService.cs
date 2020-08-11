using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevoxTestTaskCommon.Models;

namespace DevoxTestTask.BLL.Interfaces
{
    public interface IActivityService
    {
        Task<ActivityDTO> GetActivitiesByEmployeePerDate(int id, DateTime date);
        Task<ActivityDTO> GetActivitiesByEmployeePerWeek(int id, int week);
    }
}
