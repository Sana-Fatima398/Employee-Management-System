using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementDTO;

namespace EmployeeManagementDAL
{
    public class DepartmentDAL
    {
        public void AddDepartment(DepartmentDTO department)
        {
            StreamWriter writer = new StreamWriter("Departments.txt", true);
            string input = $"{department.DeptId},{department.DeptName},{department.DeptDescription}";
            writer.WriteLine(input);
            writer.Close();
        }

        public List<DepartmentDTO> ReadDepartment()
        {
            StreamReader reader = new StreamReader("Departments.txt");

            List<DepartmentDTO> list = new List<DepartmentDTO>();

            string line = reader.ReadLine();
            while (line != null)
            {
                string[] output = line.Split(",");

                DepartmentDTO dept = new DepartmentDTO();
                dept.DeptId = output[0];
                dept.DeptName = output[1];
                dept.DeptDescription = output[2];
              
                list.Add(dept);
                line = reader.ReadLine();
            }
            reader.Close();
            return list;


        }

        
        public void modifyDepartments(List<DepartmentDTO> list) {

            StreamWriter writer = new StreamWriter("Departments.txt", false);

            for (int i = 0; i < list.Count; i++)
            {
                writer.WriteLine(list[i].ToString());
            }

            writer.Close();
        }

       
    }
}
