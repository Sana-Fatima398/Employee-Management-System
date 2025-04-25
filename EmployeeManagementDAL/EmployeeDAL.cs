using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementDTO;
namespace EmployeeManagementDAL
{
    public class EmployeeDAL
    {
        public void AddEmployee(EmployeeDTO employee) {
            StreamWriter sw = new StreamWriter("Employees.txt", true);
            sw.WriteLine(employee.ToString());
            sw.Close();
        }

        public List<EmployeeDTO> ReadEmployee()
        {
            StreamReader reader = new StreamReader("Employees.txt");
           
            List<EmployeeDTO> list = new List<EmployeeDTO>();

            string line = reader.ReadLine();
            while (line != null)
            {
                string[] output = line.Split(",");

                EmployeeDTO employee = new EmployeeDTO();
                employee.Id = output[0];
                employee.Name = output[1];
                employee.Age = int.Parse(output[2]);
                employee.Department = output[3];
                employee.Salary = float.Parse(output[4]);
                employee.JoiningDate = output[5];
                list.Add(employee);
                line = reader.ReadLine();
            }
            reader.Close();
            return list;
            

        }
        

        // Used in employee Update and Delete functions
        public void writeEmployee(List<EmployeeDTO> listEmployee) {          

            StreamWriter writer = new StreamWriter("Employees.txt", false);
            
            for (int i = 0; i < listEmployee.Count; i++)
            {
                writer.WriteLine(listEmployee[i].ToString());
            }

            writer.Close();
        }
    }
}
