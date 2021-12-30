using NewEmployeeProject.Interface;
using NewEmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEmployeeProject.Service
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Department[] Departments => _departments;
        private Department[] _departments;
        public HumanResourceManager()
        {
            _departments = new Department[0];
        }
        public void AddDepartment(string name, int workerLimit, double salarylimit)
        {
            Department department = new Department(name: name, workerLimit: workerLimit, salarylimit: salarylimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
        }

        public void AddEmployee(string fullname, double salary, string departamentname, string position)
        {
            Employee employee = new Employee(fullname:fullname, salary:salary, departamentname: departamentname, position: position);
            
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == employee.DepartamnetName.ToLower())
                {

                    Array.Resize(ref item.Employees, item.Employees.Length + 1);
                    item.Employees[item.Employees.Length - 1] = employee;


                }
            }

        }

        public void EditDepartments(string oldDepname, string newDepname)
        {
            Department department = null;
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == oldDepname.ToLower())
                {
                    department = item;
                }
            }
            department.Name = newDepname;
        }

        public void RemoveEmployee(string EmpNo, string DepName)
        {
            foreach (Department item in _departments)
            {
                if (item != null)
                {
                    for (int i = 0; i < item.Employees.Length; i++)
                    {
                        if (item.Employees[i] != null && item.Employees[i].No.ToUpper() == EmpNo.ToUpper() && item.Employees[i].DepartamnetName.ToLower() == DepName.ToLower())
                        {
                            item.Employees[i] = null;
                            return;
                        }
                    }
                }

            }
        }

        public void EditEmployee(string EmpNO, string FullName, string newPositiom, double newSalary)
        {
            Employee employee = null;
            foreach (Department item in _departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item2 != null && item2.No.ToUpper() == EmpNO.ToUpper() && item2.Fullname.ToLower() == FullName.ToLower())
                    {
                        employee = item2;
                    }
                }
            }
            
            employee.Position = newPositiom;
            employee.Salary = newSalary;
        }

        public Department[] GetDepartments()
        {
            Department[] department = new Department[0];
            foreach (Department item in _departments)
            {
                if (item != null)
                {
                    Array.Resize(ref department, department.Length + 1);
                    department[department.Length - 1] = item;
                }
            }
            return department;
        }
    }
}
