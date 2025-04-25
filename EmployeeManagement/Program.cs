using EmployeeManagement;
using EmployeeManagementBLL;
using EmployeeManagementDTO;
using System.Linq.Expressions;


EmployeeBLL objEmp = new EmployeeBLL();
DepartmentBLL objDept = new DepartmentBLL();
int check = 0;
Console.WriteLine("System Started");

while (check != 1)
{
    SystemInterface.Menu();
    check = SystemInterface.MenuInput(objEmp, objDept);
}

Console.WriteLine("System Closed");






