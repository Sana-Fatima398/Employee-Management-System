using EmployeeManagementDAL;
using EmployeeManagementDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBLL
{
    public class DepartmentBLL
    {
       
        public void SaveDepartment()
        {
            Console.Write("Enter Dept Id: ");
            string? id = Console.ReadLine();
            if (id == "")
            {
                Console.WriteLine("Id cant be empty");
                return;
            }

            Console.Write("Enter Dept Name: ");
            string? name = Console.ReadLine();
            if (name == "")
            {
                Console.WriteLine("Name cant be empty");
                return;
            }
            DepartmentDTO temp =  SearchDeptByName(name);
            if (temp != null) {
                Console.WriteLine($"--> This department {name} already exists");
                return;
            }

            Console.Write("Enter Dept Description: ");
            string? desc = Console.ReadLine();
           
            DepartmentDTO dept = new DepartmentDTO();
            dept.DeptId = id;
            dept.DeptName = name;
            dept.DeptDescription = desc;
            

            DepartmentDAL dal = new DepartmentDAL();
            dal.AddDepartment(dept);
            Console.WriteLine("Added");

        }
       
        public static void GetDepartments()
        {
            DepartmentDAL dal = new DepartmentDAL();
            foreach (DepartmentDTO dept in dal.ReadDepartment())
            {
                Console.WriteLine($"Id: {dept.DeptId}");
                Console.WriteLine($"Name: {dept.DeptName}");
                Console.WriteLine($"Description: {dept.DeptDescription}");
                Console.WriteLine("--------------------------------------");
            }
        }


        public static DepartmentDTO SearchDeptByName(string name) {
            DepartmentDAL dal = new DepartmentDAL();
            List<DepartmentDTO> dept = dal.ReadDepartment();
            string s1, s2;
            s1 = name.Trim().ToLower();
            
            for (int i = 0; i < dept.Count; i++)
            {
                s2 = dept[i].DeptName.Trim().ToLower();
                if (s2 == s1) {
                    return dept[i];
                }
            }
            return null;
        }


        public  void EditDepartment() {
            Console.WriteLine("--- Edit Department ---");
            Console.Write("Enter department name that you want to edit: ");
            string name = Console.ReadLine();

            DepartmentDTO objDept = DepartmentBLL.SearchDeptByName(name);
            if (objDept != null)
            {
                string k1, k2;
                k1 = name.Trim().ToLower();

                Console.WriteLine("Enter the new description: ");
                string desc = Console.ReadLine();
                objDept.DeptDescription = desc;
                DepartmentDAL departmentDAL = new DepartmentDAL();
                
                List<DepartmentDTO> list = departmentDAL.ReadDepartment();

                for (int i = 0; i < list.Count; i++)
                {
                    k2 = list[i].DeptName.Trim().ToLower();
                    if (k1 == k2)
                    {
                        list[i].DeptDescription = objDept.DeptDescription;
                    }
                }
                departmentDAL.modifyDepartments(list);
                Console.WriteLine("Edited");

            }
            else {
                Console.WriteLine($"-> The department {name} does not exist!!");
            }
        }

        public void DeleteDepartment() {
            Console.WriteLine("--- Delete Department ---");
            Console.Write("Enter department name that you want to delete: ");
            string name = Console.ReadLine();

            DepartmentDTO objDept = DepartmentBLL.SearchDeptByName(name);
            if (objDept != null)
            {
                DepartmentDAL departmentDAL = new DepartmentDAL();
        
                List<DepartmentDTO> list = departmentDAL.ReadDepartment();

                for (int i = 0; i < list.Count; i++)
                {

                    if (list[i].DeptName.Trim().ToLower() == objDept.DeptName.Trim().ToLower())
                    {
                        list.RemoveAt(i);
                    }
                }
                departmentDAL.modifyDepartments(list);
                Console.WriteLine("Deleted");
            }
            else
            {
                Console.WriteLine($"-> The department {name} does not exist.");
            }
        }
    }
}
