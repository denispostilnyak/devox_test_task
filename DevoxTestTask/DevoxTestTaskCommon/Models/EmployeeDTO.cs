using System;
using System.Collections.Generic;
using System.Text;

namespace DevoxTestTaskCommon.Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        //here should be smth different from Entities
    }
}
