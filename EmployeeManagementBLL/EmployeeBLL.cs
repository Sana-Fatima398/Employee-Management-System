using EmployeeManagementDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementDAL;
using System.Runtime.CompilerServices;

namespace EmployeeManagementBLL
{
    public class EmployeeBLL
    {
        public EmployeeDTO SearchEmployeeByID(String Id)
        {
            EmployeeDAL dal = new EmployeeDAL();

            foreach (EmployeeDTO emp in dal.ReadEmployee())
            {
                if (emp.Id == Id)
                {
                    return emp;
                }
            }

            return null;
        }
        private static bool nameValidation(string name) {
            name = name.ToLower();
            if (name == "") return false;
            bool flag = false;
            for (int i = 0; i < name.Length; i++) {
                if (name[i] == ' ' || (name[i] >= 'a' && name[i] <= 'z'))
                {
                    flag = true;
                }
                else 
                {
                    flag = false;
                    return flag;
                }
            }
            return flag;
        }

        // Create Function 
        public void Create() {

            Console.WriteLine("--- Add Employee ---");
            Console.Write("Enter Id: ");
            string? id = Console.ReadLine();
            EmployeeDTO emp = SearchEmployeeByID(id);
            if (id == "") {
                Console.WriteLine("Id cant be empty");
                return;
            }
            if (emp != null) {
                Console.WriteLine("--> Employee Already exists");
                return;
            }


            Console.Write("Enter Name: ");
            string? name = Console.ReadLine();
            if (!nameValidation(name)) {
                Console.WriteLine("Name should only contains alphabets and it cant be emptied");
                return;
            }


            Console.Write("Enter Age: ");
            string agetemp = Console.ReadLine();
            if (agetemp == "") {
                Console.WriteLine("Age cant be emptied");
                return;
            }
            int age = int.Parse(agetemp);
            if (age > 70  ||  age < 15) {
                Console.WriteLine("Age should be at least 15");
                return;
            }


            Console.Write("Enter Departemnt: ");
            string? dept = Console.ReadLine();

            Console.Write("Enter Salary: ");
            float salary = float.Parse(Console.ReadLine());
            
            Console.Write("Enter Joining Date: ");
            string? joiningdate = Console.ReadLine();

            EmployeeDTO employee = new EmployeeDTO();
            employee.Id = id;
            employee.Name = name;
            employee.Age = age;
            employee.Department = dept;
            employee.Salary = salary;
            employee.JoiningDate = joiningdate;

            EmployeeDAL dal = new EmployeeDAL();
            List<EmployeeDTO> tempList = dal.ReadEmployee();
             

            dal.AddEmployee(employee);
            Console.WriteLine("Added");

        }

        // Get Function
        public void GetEmployee() { 
            EmployeeDAL dal = new EmployeeDAL();
            List<EmployeeDTO> list = dal.ReadEmployee();
            EmployeeBLL.print(list);
        }

        private static void print(List<EmployeeDTO> list) {
            if (list.Count == 0)
            {
                Console.WriteLine("No Employee Found!");
            }
            else
            {
                Console.WriteLine("Employees are as follow: ");
                foreach (EmployeeDTO emp in list)
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"Id: {emp.Id}");
                    Console.WriteLine($"Name: {emp.Name}");
                    Console.WriteLine($"Age: {emp.Age}");
                    Console.WriteLine($"Department: {emp.Department}");
                    Console.WriteLine($"Salary: {emp.Salary}");
                    Console.WriteLine($"Joininng date: {emp.JoiningDate}");
                    
                }
                Console.WriteLine("--------------------------------------");
            }
        }


        // Search Functions 
        public void SearchEmployeeByName(String Name) {
            EmployeeDAL dal = new EmployeeDAL();
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            foreach (EmployeeDTO emp in dal.ReadEmployee())
            {
                string temp = emp.Name.Trim().ToLower();
                if (temp.Contains(Name.Trim().ToLower())) { 
                    list.Add( emp );
                }
            }
            EmployeeBLL.print(list);
            
        }

        public void SearchByID(String Id)
        {
            EmployeeDAL dal = new EmployeeDAL();
            bool flag = true;
            Console.WriteLine("----------------------------------");
            foreach (EmployeeDTO emp in dal.ReadEmployee())
            {
                if (emp.Id == Id)
                {
                    flag = false;
                    Console.Write($"Id: {emp.Id},   Name: {emp.Name}   ");
                    Console.WriteLine($"Age: {emp.Age},   Department: {emp.Department},  Joining Date: {emp.JoiningDate}");
                }

            }
            if (flag) {
                Console.WriteLine("No employee found");
            }
            Console.WriteLine("-----------------------------------");
        }

        public void SearchEmployeeBydept(String dept)
        {
            EmployeeDAL dal = new EmployeeDAL();
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            foreach (EmployeeDTO emp in dal.ReadEmployee())
            {
                if (emp.Department.ToLower() == dept.ToLower())
                {
                    list.Add(emp);
                }
            }
            EmployeeBLL.print(list);

        }

        public void SearchEmployeeByJoiningDate(String date)
        {
            EmployeeDAL dal = new EmployeeDAL();
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            foreach (EmployeeDTO emp in dal.ReadEmployee())
            {
                if (emp.JoiningDate == date)
                {
                    list.Add(emp);
                }
            }
            EmployeeBLL.print(list);

        }


        // Update Functions
        public void updateSalary(EmployeeDTO employee)
        {
            Console.Write("Enter new Salary: ");
            float sal = float.Parse(Console.ReadLine());
            employee.Salary = sal;           
            Update(employee);

        }
        public void updateEmployeeDepartment(EmployeeDTO employee)
        {
            Console.Write("Enter new departemnt of employee: ");
            string dept = Console.ReadLine();
            employee.Department = dept;        
            Update(employee);
        }


        private void Update(EmployeeDTO objEmployee) {

            EmployeeDAL employeeDAL = new EmployeeDAL();
            List<EmployeeDTO> listEmployee = employeeDAL.ReadEmployee();

            foreach (EmployeeDTO var in listEmployee)
            {
                if (var.Id == objEmployee.Id)
                {
                    var.Salary = objEmployee.Salary;
                    var.Department = objEmployee.Department;
                }
            }

            employeeDAL.writeEmployee(listEmployee);
        }

        // Delete Functon
        public void Delete() {
            EmployeeBLL empBLL = new EmployeeBLL();

            Console.WriteLine("--- Delete Employee ---");
            Console.Write("Enter the id of employee you want to delete: ");
            string id = Console.ReadLine();
            EmployeeDTO employee = empBLL.SearchEmployeeByID(id);

            if (employee != null)
            {
                EmployeeDAL employeeDAL = new EmployeeDAL();
                List<EmployeeDTO> listEmployee = employeeDAL.ReadEmployee();

                for (int i = 0; i < listEmployee.Count; i++)
                {
                    if (listEmployee[i].Id == employee.Id)
                    {
                        listEmployee.RemoveAt(i);
                    }
                }
                EmployeeDAL dal = new EmployeeDAL();
                dal.writeEmployee(listEmployee);
                Console.WriteLine("Employee Deleted");
            }

            else {
                Console.Write("EMployee not exist!");
            }
        }


    }
}
