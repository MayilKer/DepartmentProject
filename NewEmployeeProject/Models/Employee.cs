using System;
using System.Collections.Generic;
using System.Text;

namespace NewEmployeeProject.Models
{
    class Employee
    {
        public string No { get; set; }
        public string Fullname { get; set; }
        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value < 250)
                {
                    Console.WriteLine("Salary minimum 250 ola biler");
                    return;
                }
                _salary = value;
            }
        }
        private double _salary;
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (value.Length < 2)
                {
                    Console.WriteLine("Minimum 2 herif ola biler");
                    return;
                }
                _position = value;
            }
        }
        private string _position;
        public string DepartamnetName { get; set; }
        private static int count = 1000;
        public Employee(string fullname, double salary, string departamentname, string position)
        {

            Fullname = fullname;
            Salary = salary;
            DepartamnetName = departamentname;
            Position = position;
            count++;


            No += DepartamnetName.ToUpper().Substring(0, 2) + count;
        }
        public override string ToString()
        {
            return $"Full name: {Fullname} \nSalary: {Salary} \nNo: {No.ToUpper()} \nPosition: {Position} \nDepatmenName: {DepartamnetName}";
        }
    }
}
