using System;
using System.Collections.Generic;
using System.Text;

namespace DevoxTestTaskCommon.Models
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        //here should be smth different from Entities
    }
}
