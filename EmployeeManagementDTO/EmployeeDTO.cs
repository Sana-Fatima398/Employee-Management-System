using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDTO
{
    public class EmployeeDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public float Salary { get; set; }
        public string JoiningDate { get; set; }

        public override string ToString()
        {
            return $"{Id},{Name},{Age},{Department},{Salary},{JoiningDate}";
        }
    }

  
}
