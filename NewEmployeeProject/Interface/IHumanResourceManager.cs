using NewEmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEmployeeProject.Interface
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }
        void AddDepartment(string name, int workerLimit, double salarylimit);
        void AddEmployee(string fullname, double salary, string departamentname, string position);
        void EditDepartments(string oldDepname, string newDepname);
        void RemoveEmployee(string EmpNo, string DepName);
        void EditEmployee(string EmpNO, string FullName, string newPositiom, double newSalary);
        Department[] GetDepartments();
    }
}
