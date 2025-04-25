using EmployeeManagementDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementBLL;
using System.Reflection.Metadata.Ecma335;
namespace EmployeeManagement
{
    internal class SystemInterface
    {
        public static void Menu() {
            Console.WriteLine("\n-------------- Employee Management System ------------- \n");
            Console.WriteLine("1. List All Employees");
            Console.WriteLine("2. Add New Employee");
            Console.WriteLine("3. Update Employee Details");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Search Employees (by ID, Name, Department, Date Range)");
            Console.WriteLine("6. Manage Departments (Add, Edit, Delete Departments)");
            Console.WriteLine("7. Quit\n");
        }

        public static int MenuInput(EmployeeBLL objEmp, DepartmentBLL objDept) {

            string check = "0";
        
            Console.Write("Enter the number:");
            check = Console.ReadLine();

            switch (check)
            {
                case "1":
                    objEmp.GetEmployee(); 
                    break;

                case "2":
                    objEmp.Create(); 
                    break;

                case "3":
                    UpdateMenu();
                    break;

                case "4":
                    objEmp.Delete();
                    break;

                case "5":
                    SearchMenu();
                    break;

                case "6":
                    DepartmentMenu();
                    break;

                case "7":
                    return 1; 

                default:
                Console.WriteLine("Wrong Input!!");
                break;

            }
            
            return 0;
        }


        public static void SearchMenu()
        {
            EmployeeBLL temp = new EmployeeBLL();

            while (true)
            {
                Console.WriteLine("----- Search Functionality -----");
                Console.WriteLine("you can search Employees by their: ");
                Console.WriteLine("Id");
                Console.WriteLine("Name");
                Console.WriteLine("Department");
                Console.WriteLine("Joiningdate");
                Console.WriteLine("To quit enter exit");
                Console.Write("\nEnter your choice:");
                
                string check = Console.ReadLine();
                string result;

                check = check.ToLower().Trim();
                if (check == "name")
                {
                    result = getInfo("Name");
                    temp.SearchEmployeeByName(result);
                    break;
                }
                else if (check == "id")
                {
                    result = getInfo("ID");
                    temp.SearchByID(result);
                    break;
                }
                else if (check == "department")
                {
                    result = getInfo("Department");
                    temp.SearchEmployeeBydept(result);
                    break;
                }
                else if (check == "joiningdate")
                {
                    result = getInfo("Joinig Date");
                    temp.SearchEmployeeByJoiningDate(result);
                    break;
                }
                else if (check == "exit" || check == "quit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Looks like yo have entered the wrong input!!");
                    Console.WriteLine("enter name if you want to search by name\n");
                }

            }

        }

        public static void UpdateMenu()
        {

            EmployeeBLL empBLL = new EmployeeBLL();

            while (true)
            {
                Console.WriteLine("---- Update Employee Information ----");
                Console.Write("Enter Employee ID: ");
                string id = Console.ReadLine();
                EmployeeDTO emp = empBLL.SearchEmployeeByID(id);
                if (emp != null)
                {
                   
                    Console.WriteLine("1.Change Salary\n2.Change Despartemnt");
                    Console.Write("Enter: ");

                    string value = Console.ReadLine();
                    value = value.Trim().ToLower();

                    if (value == "1" || value == "salary")
                    {
                        empBLL.updateSalary(emp);
                        break;
                    }
                    else if (value == "2" || value == "department")
                    {
                        empBLL.updateEmployeeDepartment(emp);
                        break;
                    }
                    else if (value == "3" || value == "quit" || value == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input entered!!");
                    }
                }
                else
                {
                    Console.WriteLine("ID NOT found!");
                    break;
                }
            }
        }


        public static void DepartmentMenu()
        {
            DepartmentBLL departmentBLL = new DepartmentBLL();
            while (true)
            {
                Console.WriteLine("---- Manage Department ----");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Edit Department");
                Console.WriteLine("3. Delete Department");
                Console.WriteLine("4. Exit\n");

                Console.Write("Enter: ");
                string value = Console.ReadLine();

                if (value == "1")
                {
                    departmentBLL.SaveDepartment();
                    break;
                }

                else if (value == "2")
                {
                    departmentBLL.EditDepartment();
                    break;
                }
                else if (value == "3")
                {
                    departmentBLL.DeleteDepartment();
                    break;
                }
                else if (value == "4")
                {
                    break;
                }
            }
        }



        public static string getInfo(string value)
        {
            Console.Write($"\nEnter {value} of Employee: ");
            string ans = Console.ReadLine();
            return ans;
        }


    }


}
