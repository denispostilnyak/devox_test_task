using System;
using System.Collections.Generic;
using System.Text;

namespace DevoxTestTaskCommon.Models
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int ProjectId { get; set; }
        public int ActivityTypeId { get; set; }
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        //here should be smth different from Entities
    }
}
