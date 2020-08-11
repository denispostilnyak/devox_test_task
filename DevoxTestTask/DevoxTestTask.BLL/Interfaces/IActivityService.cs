using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevoxTestTaskCommon.Models;

namespace DevoxTestTask.BLL.Interfaces
{
    public interface IActivityService
    {
        Task<string> GetActivitiesByEmployeePerDate(int id, DateTime date);
        Task<string> GetActivitiesByEmployeePerWeek(int id, int week);
    }
}
