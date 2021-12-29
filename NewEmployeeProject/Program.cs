using NewEmployeeProject.Models;
using NewEmployeeProject.Service;
using System;

namespace NewEmployeeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            do
            {
                Console.WriteLine("-------------------------HumanResource Managment---------------------------");
                Console.WriteLine("Etmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                Console.WriteLine("1 - Departmen uzerinde emeliyyatlar:");
                Console.WriteLine("2 - Employee uzerinde emeliyyatlar:");
                Console.WriteLine("3 - Sistemden Cix:");
                Console.Write("Daxil Et:");
                string choose = Console.ReadLine();
                int choosenum;
                int.TryParse(choose, out choosenum);
                switch (choosenum)
                {
                    case 1:
                        Console.Clear();
                        DepartmentOperation(ref humanResourceManager);
                        break;
                    case 2:
                        Console.Clear();
                        EmployeeOperation(ref humanResourceManager);
                        break;
                    case 3:
                        Console.Clear();

                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzzgun daxil et");
                        break;
                }
            } while (true);
            static void DepartmentOperation(ref HumanResourceManager humanResourceManager)
            {
                do
                {

                    Console.WriteLine("-------------------------Department Managment---------------------------");
                    Console.WriteLine("Etmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                    Console.WriteLine("1 - Departameantlerin siyahisini gostermek:");
                    Console.WriteLine("2 - Departamenet yaratmaq:");
                    Console.WriteLine("3 - Departmanetde deyisiklik etmek:");
                    Console.WriteLine("4 - Esas menyuya qayidis");
                    Console.Write("Daxil Et:");
                    string choose = Console.ReadLine();
                    int choosenum;
                    int.TryParse(choose, out choosenum);
                    switch (choosenum)
                    {
                        case 1:
                            Console.Clear();
                            GetDepartmenList(ref humanResourceManager);
                            break;
                        case 2:
                            Console.Clear();
                            AddDepartment(ref humanResourceManager);
                            break;
                        case 3:
                            Console.Clear();
                            EditDepartment(ref humanResourceManager);
                            break;
                        case 4:
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Duzzgun daxil et");
                            break;
                    }
                } while (true);
            }
            static void EmployeeOperation(ref HumanResourceManager humanResourceManager)
            {
                do
                {

                    Console.WriteLine("-------------------------Employee Managment---------------------------");
                    Console.WriteLine("Etmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                    Console.WriteLine("1 - Isci elave etmek:");
                    Console.WriteLine("2 - Iscilerin siyahisini gostermek:");
                    Console.WriteLine("3 - Departamentdeki iscilerin siyahisini gostermrek:");
                    Console.WriteLine("4 - Isci uzerinde deyisiklik etmek:");
                    Console.WriteLine("5 - Departamentden isci silinmesi :");
                    Console.WriteLine("6 - Esas menyuya qayidis :");
                    Console.Write("Daxil Et:");
                    string choose = Console.ReadLine();
                    int choosenum;
                    int.TryParse(choose, out choosenum);
                    switch (choosenum)
                    {
                        case 1:
                            Console.Clear();
                            AddEmployee(ref humanResourceManager);
                            break;
                        case 2:
                            Console.Clear();
                            GetEmployeeList(ref humanResourceManager);
                            break;
                        case 3:
                            Console.Clear();
                            GetEmployeeByDepartment(ref humanResourceManager);
                            break;
                        case 4:
                            Console.Clear();
                            EditEmployee(ref humanResourceManager);
                            break;
                        case 5:
                            Console.Clear();
                            //RemoveEmployee(ref humanResourceManager);
                            break;
                        case 6:
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Duzzgun daxil et");
                            break;
                    }
                } while (true);
            }
            static void AddDepartment(ref HumanResourceManager humanResourceManager)
            {
                Console.Write("Yeni Department adini daxil edin: ");
                string name = Console.ReadLine();
                int count = 0;
                bool res = true;
                while (res)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        if (item.Name.ToLower() == name.ToLower())
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        Console.WriteLine("Ad movcuddur");
                        Console.WriteLine("Yeni department ad daxil edin");
                        name = Console.ReadLine();
                    }
                    else
                    {
                        res = false;
                    }

                    count = 0;
                }
                Console.WriteLine("Departament worker limit sayini daxil edin");
                string worker = Console.ReadLine();
                int workeNum;
                while (!int.TryParse(worker, out workeNum) || workeNum <= 0)
                {
                    Console.WriteLine("Duzgun say daxil edin");
                    worker = Console.ReadLine();
                }
                Console.WriteLine("Departament ucun salary limit daxil edin");
            mon:
                string salary = Console.ReadLine();
                double salaryNum;


                while (!double.TryParse(salary, out salaryNum) || salaryNum <= 0)
                {
                    Console.WriteLine("Duzgun salary limit Daxil Et:");
                    salary = Console.ReadLine();
                }
                if (salaryNum < 250)
                {
                    Console.WriteLine("Salary 250-den asagi ola bilmez");
                    Console.WriteLine("Yeniden daxil edin");
                    goto mon;
                }
                humanResourceManager.AddDepartment(name, workeNum, salaryNum);
            }
            static void GetEmployeeList(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Departments.Length < 0)
                {
                    Console.WriteLine("Once Department yaradin");
                }
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Employees != null && item.Employees.Length <= 0)
                    {
                        Console.WriteLine("Departamentlerivizde iwci yoxdu");
                        return;
                    }
                }
                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee item2 in item.Employees)
                    {
                        if (item2 != null)
                        {
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine(item2);
                        }
                    }
                }
            }
            static void AddEmployee(ref HumanResourceManager humanResourceManager)
            {

                if (humanResourceManager.Departments.Length <= 0)
                {
                    Console.WriteLine("Once Department yaradmalisiz");
                    return;
                }

                
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Employees.Length >= item.WorkerLimit)
                    {
                        Console.WriteLine("Limiti kecdiz");
                        return;
                    }
                }

            
                Console.WriteLine("Iscini elave etmek istediyiviz Departamentin adini daxil edin");
                Console.WriteLine("Movcud olan Departamentinin adini daxil edin");
                foreach (Department item in humanResourceManager.Departments)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine(item.Name);
                }
                
                check2:
                   string departmen = Console.ReadLine();
                int count = 0;
                bool res = true;
                while (res)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        if (item.Name.ToLower() == departmen.ToLower())
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        res = false;
                    }
                    else
                    {
                        Console.WriteLine("Daxil etdiyiniz Department ad movcud deil");
                        Console.WriteLine("Yeniden daxil edin");
                        departmen = Console.ReadLine();
                        goto check2;
                    }
                    count = 0;
                }
                Console.WriteLine("Employee-nin Adini ve Soyadini daxil edin");
                string FullName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(FullName))
                {
                    Console.WriteLine("Bos ola bilmez");
                    Console.WriteLine("Duzgun daxil edin");
                    FullName = Console.ReadLine();
                    goto check2;
                }
                Console.WriteLine("Iscinin mawini daxil edin");

                string salary = Console.ReadLine();
                double salaryNum;
                while (!double.TryParse(salary, out salaryNum) || salaryNum <= 0)
                {
                    Console.WriteLine("Duzgun mas Daxil Et:");
                    salary = Console.ReadLine();
                }
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == departmen.ToLower())
                    {
                        if (item.SlaryLimit < salaryNum)
                        {
                            Console.WriteLine("Limiti kecdiz");
                            
                        }
                    }
                }
                Console.WriteLine("Position daxil edin");
            again:
                string position = Console.ReadLine();
                double positionnum;
                if (double.TryParse(position, out positionnum))
                {
                    Console.WriteLine("Tekce reqem daxil ede bilmersiz");
                    Console.WriteLine("Yeniden daxil edin");
                    position = Console.ReadLine();
                    goto again;
                }
                if (string.IsNullOrWhiteSpace(position))
                {
                    Console.WriteLine("Bos ola bilmez");
                    Console.WriteLine("Duzgun daxil edin");
                    position = Console.ReadLine();
                    goto again;
                }
                

                humanResourceManager.AddEmployee(FullName, salaryNum, departmen, position);

            }
            static void EditDepartment(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Departments.Length <= 0)
                {
                    Console.WriteLine("Department list bowdu");
                    return;
                }
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item != null)
                    {
                        Console.WriteLine("-------------------------");
                        Console.WriteLine(item);
                    }

                }
                Console.WriteLine("Deyiwilik etmek istediyiviz Departamentin adini daxil edin");
                string DepName = Console.ReadLine();
                bool res = true;
                int count = 0;
                while (res)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        if (item.Name.ToLower() == DepName.ToLower())
                        {
                            count++;
                        }
                    }
                    if (count <= 0)
                    {
                        Console.WriteLine("Daxil etdiyiviz Departament adi sefdir");
                        Console.WriteLine("Yeniden daxil edin");
                        DepName = Console.ReadLine();
                    }
                    else
                    {
                        res = false;
                    }
                    count = 0;
                }
            again:
                Console.WriteLine("Yeni Departament adini daxil edin");
                string NewDepName = Console.ReadLine();
                int word;
                bool res1 = true;
                int check = 0;
                while (res1)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        if (item.Name.ToLower() == NewDepName.ToLower())
                        {
                            check++;
                        }
                    }
                    if (check > 0)
                    {
                        Console.WriteLine("Daxil etiyinizz ad movcudur");
                        NewDepName = Console.ReadLine();
                    }
                    else if (int.TryParse(NewDepName, out word))
                    {
                        Console.WriteLine("Reqem daxil ede bilmersiz");
                        goto again;
                    }
                    else
                    {
                        res1 = false;
                    }
                    check = 0;
                }
                if (string.IsNullOrWhiteSpace(NewDepName))
                {
                    Console.WriteLine("Bos ola bilmez");
                    Console.WriteLine("Duzgun daxil edin");
                    NewDepName = Console.ReadLine();
                    goto again;
                }
                humanResourceManager.EditDepartments(DepName, NewDepName);
            }
            static void GetEmployeeByDepartment(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Departments.Length <= 0)
                {
                    Console.WriteLine("Once department yaradin");
                    return;
                }
                Console.WriteLine("Departament adini daxil edin");

                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item != null)
                    {
                        Console.WriteLine("---------------------------");
                        Console.WriteLine(item);
                    }
                }
                string answer = Console.ReadLine();
                bool res = true;
                int count = 0;
                while (res)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        if (item.Name.ToLower() == answer.ToLower())
                        {
                            count++;
                        }
                            if (count <= 0)
                            {
                                Console.WriteLine("Duzgun Departament adi daxil edin");
                            }
                            else
                            {
                                res = false;
                            }
                        count = 0;
                    }
                }
                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee item2 in item.Employees)
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine(item2);
                    }
                }
            }
            static void GetDepartmenList(ref HumanResourceManager humanResourceManager)
                {
                    if (humanResourceManager.Departments.Length <= 0)
                    {
                        Console.WriteLine("Department list bowdur");
                        return;
                    }
                    Department[] departments = humanResourceManager.GetDepartments();
                foreach (Department item in departments)
                {
                    if (item != null)
                    {
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine(item);
                    }
                }
                    
                }
            static void EditEmployee(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Departments.Length <= 0)
                {
                    Console.WriteLine("Once Department yaratmalisiz");
                    return;
                }
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Employees != null && item.Employees.Length <= 0)
                    {
                        Console.WriteLine("Departamentlerivizde iwci yoxdu");
                        return;
                    }
                }


                
            }
            





        }
    }
}
