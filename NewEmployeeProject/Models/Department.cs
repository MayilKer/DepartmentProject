using System;
using System.Collections.Generic;
using System.Text;

namespace NewEmployeeProject.Models
{
    class Department
    {
        public string Name { get; set; }

        public int WorkerLimit
        {
            get
            {
                return _workerlimit;
            }
            set
            {
                if (value < 1)
                {
                    Console.WriteLine("Minimum 1 nefer ola biler");
                    return;
                }
                _workerlimit = value;
            }
        }
        private int _workerlimit;
        public double SlaryLimit
        {
            get
            {
                return _salarylimit;
            }
            set
            {
                if (value < 250)
                {
                    Console.WriteLine("Minimum limit 250 ola biler");
                    return;
                }
                _salarylimit = value;
            }
        }
        private double _salarylimit;
        public Employee[] Employees = { };
        

        public Department(string name, int workerLimit, double salarylimit)
        {
            WorkerLimit = workerLimit;

            SlaryLimit = salarylimit;
            Name = name;

        }
        public double TotalSalaryCount()
        {
            double TotalSalary = 0;
            foreach (Employee item in Employees)
            {
                if (item != null && item.DepartamnetName.ToLower() == Name.ToLower())
                {
                    TotalSalary += item.Salary;
                }
            }
            return TotalSalary;
        }
        public double CalcSalaryAverage()
        {
            double totalAmount = 0;
            int count = 0;
            foreach (Employee item in Employees)
            {
                if (item != null)
                {
                    count++;
                    totalAmount += item.Salary;
                }
            }
            if (count <= 0)
            {
                return 0;
            }
            else
            {
                return totalAmount / count;
            }
            
        }
        public override string ToString()
        {
            return $"Department: {Name.ToUpper()} \nWorker Limit: {WorkerLimit} \nSalary Limit: {SlaryLimit} \nAvarage Salary: {CalcSalaryAverage()} \nTotal Salary: {TotalSalaryCount()}";
        }
    }
}
