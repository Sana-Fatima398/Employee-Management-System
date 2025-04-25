using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDTO
{
    public class DepartmentDTO
    {
        public string DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptDescription { get; set; }

        public override string ToString()
        {
            return $"{DeptId},{DeptName},{DeptDescription}";
        }
    }
}
