using System;
using System.Collections.Generic;
using System.Text;

namespace DevoxTestTask.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
    }
}
