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
                            RemoveEmployee(ref humanResourceManager);
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
                simple:
                string name = Console.ReadLine();
                int count = 0;
                bool res = true;
                double check;
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Bos ola bilmez");
                    Console.WriteLine("Yeniden daxil edin");
                    goto simple;
                }
                if (name.Length < 2)
                {
                    Console.WriteLine("Departament adi minimum 2 herif olmalidir");
                    Console.WriteLine("Yeniden daxil edin");
                    goto simple;
                }
                if (double.TryParse(name,out check))
                {
                    Console.WriteLine("Ancaq reqem daxil ede bilmresiz");
                    Console.WriteLine("Yeniden daxil edin");
                    goto simple;
                }
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
                Console.WriteLine("Departamente Worker Limit sayini daxil edin");
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
                if (humanResourceManager.Departments.Length <= 0)
                {
                    Console.WriteLine("Once Department yaradin");
                    return;
                }
                
                int check = 0;
                int nulll = 0;
                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee employee in item.Employees)
                    {
                        if (employee != null)
                        {
                            check++;
                        }
                        else
                        {
                            nulll++;
                        }
                    }
                }
                if (nulll > 0 &&  check <= 0)
                {
                    Console.WriteLine("Employee listi bosdur");
                    return;
                }
                else if (nulll == 0 && check == 0)
                {
                    Console.WriteLine("Employee listi bosdur");
                    return;
                }
                
                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee item2 in item.Employees)
                    {
                        if (item2 != null)
                        {
                            Console.WriteLine("---------------------------");
                            Console.WriteLine(item2);
                            Console.WriteLine("---------------------------");
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
                Console.WriteLine("Iscini elave etmek istediyiviz Departamentin adini daxil edin");
                Console.WriteLine("Movcud olan Departamentinin adini daxil edin");
                foreach (Department item in humanResourceManager.Departments)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine(item.Name.ToUpper());
                    Console.WriteLine("---------------------------");
                }

            check2:
                string departmen = Console.ReadLine();
                int count = 0;
                int check = 0;
                bool res = true;
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == departmen.ToLower())
                    {
                        for (int i = 0; i < item.Employees.Length; i++)
                        {
                            if (item.Employees[i] != null)
                            {
                                check++;
                            }
                        }
                    }
                }
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == departmen.ToLower())
                    {
                        if (check >= item.WorkerLimit)
                        {
                            Console.WriteLine($"Departamente say Limiti kecdiz,Worker Limit: {item.WorkerLimit}");
                            return;
                        }
                        else
                        {
                            goto yesnoo;
                        }
                    }
                }
                
                yesnoo:
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
                        goto check2;
                    }
                    count = 0;
                }
                Console.WriteLine("Employee-nin Adini ve Soyadini daxil edin");
            winner:
                string FullName = Console.ReadLine();
                double str;
                if (double.TryParse(FullName,out str))
                {
                    Console.WriteLine("Tekce reqem daxil ede bilmersiz");
                    Console.WriteLine("Yeniden daxil edin");
                    goto winner;
                }
                if (string.IsNullOrWhiteSpace(FullName))
                {
                    Console.WriteLine("Full Name bos ola bilmez");
                    Console.WriteLine("Duzgun daxil edin");                    
                    goto winner;
                }

                Console.WriteLine("Iscinin mawini daxil edin");
            letsgo:
                string salary = Console.ReadLine();
                double salaryNum;
                while (!double.TryParse(salary, out salaryNum) || salaryNum <= 0)
                {
                    Console.WriteLine("Duzgun mas Daxil Et:");
                    salary = Console.ReadLine();
                }
                if (salaryNum < 250)
                {
                    Console.WriteLine("Salary limit  minum 250 olmalidir");
                    return;
                }
                double total = 0;
                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee money in item.Employees)
                    {
                        if (money != null && item.Name == departmen)
                        {
                            total += money.Salary;
                        }
                    }
                }
                total += salaryNum;
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == departmen.ToLower())
                    {
                        if (item.SlaryLimit < total)
                        {
                            Console.WriteLine("Salary Limiti kecdiz");
                            Console.WriteLine($"Salary limit: {item.SlaryLimit}");
                            Console.WriteLine("Yeniden daxil edin");
                            goto letsgo;
                            
                        }
                        else if (item.SlaryLimit < total)
                        {
                            Console.WriteLine("Salary limit kece bilmersiz");
                            Console.WriteLine($"Salary limit: {item.SlaryLimit}");
                            Console.WriteLine("Yeniden daxil edin");
                            goto letsgo;
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
                    goto again;
                }
                if (string.IsNullOrWhiteSpace(position))
                {
                    Console.WriteLine("Bos ola bilmez");
                    Console.WriteLine("Duzgun daxil edin");
                    goto again;
                }
                if (position.Length < 2)
                {
                    Console.WriteLine("Position adi minimum 2 herifden ibaret olmalidir");
                    Console.WriteLine("Yeniden daxil edin");
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
                        Console.WriteLine("-------------------------");
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
                  Console.WriteLine("Yeni Departament adini daxil edin");
            again:                
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
                        Console.WriteLine("Yeniden daxil edin");
                        goto again;
                    }
                    else if (int.TryParse(NewDepName, out word))
                    {
                        Console.WriteLine("Reqem daxil ede bilmersiz");
                        Console.WriteLine("Yeniden daxil edin");
                        goto again;
                    }
                    else
                    {
                        res1 = false;
                    }
                    check = 0;
                }
                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee employee in item.Employees)
                    {
                        if (employee != null && employee.DepartamnetName.ToLower() == DepName.ToLower())
                        {
                            employee.DepartamnetName = NewDepName;
                            string sub = NewDepName.ToUpper().Substring(0, 2) + employee.No.Substring(2,4);
                            employee.No = sub;
                        }
                    }
                }
                if (string.IsNullOrWhiteSpace(NewDepName))
                {
                    Console.WriteLine("Bos ola bilmez");
                    Console.WriteLine("Yeniden daxil edin");                    
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
                        Console.WriteLine("---------------------------");
                    }
                }
            no:
                string answer = Console.ReadLine();
                bool res = true;
                int count = 0;
                int check = 0;
                int nulll = 0;
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == answer.ToLower())
                    {
                        foreach (Employee employee in item.Employees)
                        {
                            if (employee != null)
                            {
                                check++;
                            }
                            else
                            {
                                nulll++;
                            }
                        }
                    }
                }
                if (nulll > 0 && check <= 0)
                {
                    Console.WriteLine("Employee listi bosdur");
                    return;
                }
                else if (nulll == 0 && check == 0)
                {
                    Console.WriteLine("Employee listi bosdurr");
                    return;
                }
                while (res)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        if (item.Name.ToLower() == answer.ToLower())
                        {
                            count++;
                        }
                    }
                    if (count <= 0)
                    {
                        Console.WriteLine("Duzgun Departament adi daxil edin");
                        goto no;
                    }
                    else
                    {
                        res = false;

                    }
                    count = 0;
                }

                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee item2 in item.Employees)
                    {
                        if (item2 != null && item2.DepartamnetName.ToLower() == answer.ToLower())
                        {
                            Console.WriteLine("---------------------------");
                            Console.WriteLine(item2);
                            Console.WriteLine("---------------------------");
                        }
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
                        Console.WriteLine("---------------------------");
                        Console.WriteLine(item);
                        Console.WriteLine("---------------------------");
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

                Console.WriteLine("Deyisilik etmek istediyiviz iscivizin Departamentini daxil edin");
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item != null)
                    {
                        Console.WriteLine("---------------------------");
                        Console.WriteLine(item);
                        Console.WriteLine("---------------------------");
                    }
                }
                string choose = Console.ReadLine();
                int count = 0;
                bool res = true;
                int check = 0;
                int nulll = 0;
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == choose.ToLower())
                    {
                        foreach (Employee employee in item.Employees)
                        {
                            if (employee != null)
                            {
                                check++;
                            }
                            else
                            {
                                nulll++;
                            }
                        }
                    }
                }
                if (nulll > 0 && check <= 0)
                {
                    Console.WriteLine("Employee listi bosdur");
                    return;
                }
                else if (nulll == 0 && check == 0)
                {
                    Console.WriteLine("Employee listi bosdurr");
                    return;
                }
                while (res)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        if (item.Name.ToLower() == choose.ToLower())
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        res = false;
                        foreach (Department item in humanResourceManager.Departments)
                        {
                            foreach (Employee item2 in item.Employees)
                            {
                                if (item2 != null && item2.DepartamnetName.ToLower() == choose.ToLower())
                                {
                                    Console.WriteLine("---------------------------");
                                    Console.WriteLine(item2);
                                    Console.WriteLine("---------------------------");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Depatamentinin adini duz daxil edin");
                        Console.WriteLine("Yeniden daxil edin");
                        choose = Console.ReadLine();
                    }
                    count = 0;
                }
                Console.WriteLine("Duzeliw elemey iwcinin NO-ni ve FullName-ni daxil edin");
            ready:
                Console.Write("NO: ");
                string No = Console.ReadLine();
                Console.Write("FullName: ");
                string FullName = Console.ReadLine();
                bool finish = true;
                int num = 0;
                while (finish)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        foreach (Employee item2 in item.Employees)
                        {
                            if (item2 != null && item2.No.ToLower() == No.ToLower() && item2.Fullname.ToLower() == FullName.ToLower())
                            {
                                num++;
                            }
                        }
                    }
                    if (num <= 0)
                    {
                        Console.WriteLine("NO-re ve ya FullName sef daxil etmisizin");
                        Console.WriteLine("Yeniden daxil edin");
                        goto ready;
                    }
                    else
                    {
                        finish = false;
                    }
                    num = 0;
                }
                Console.WriteLine("Iscinin yeni positionunu daxil edin");
            yess:
                string NewPosition = Console.ReadLine();
                double NewPositionNum;
                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee item2 in item.Employees)
                    {
                        if (item2 != null && item2.No.ToLower() == No.ToLower() && item2.Position.ToLower() == NewPosition.ToLower())
                        {
                            Console.WriteLine("Eyni position ad daxil ede bilmersiz");
                            Console.WriteLine("Yeniden daxil edin");
                            goto yess;
                        }
                    }
                }
                if (string.IsNullOrWhiteSpace(NewPosition))
                {
                    Console.WriteLine("Sef Daxil etmisiniz");
                    Console.WriteLine("Yeniden daxil edin");
                    goto yess;
                }
                else if (double.TryParse(NewPosition, out NewPositionNum))
                {
                    Console.WriteLine("Reqem daxil ede bilmersiz");
                    Console.WriteLine("Yeniden daxil edin");
                    goto yess;
                }
                else if (NewPosition.Length < 2)
                {
                    Console.WriteLine("Position adi minimum 2 herifden ibaret olmalidir");
                    Console.WriteLine("Yeniden daxil edin");
                    goto yess;
                }
                Console.WriteLine("Iscinin yeni Salary-ni daxil edin");
            strong:
                string newSalary = Console.ReadLine();
                double newSalarynum;

                while (!double.TryParse(newSalary, out newSalarynum) || newSalarynum <= 0)
                {
                    Console.WriteLine("Duzgun reqem daxil edin daxil edin");
                    newSalary = Console.ReadLine();
                }

                if (newSalarynum < 250)
                {
                    Console.WriteLine("Iscinin masi 250-den asagi  ola bilmez");
                    Console.WriteLine("Yeniden daxill edin");
                    goto strong;
                }
                double total = 0;
                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee money2 in item.Employees)
                    {
                        if (money2 != null && item.Name == choose && money2.No.ToLower() != No.ToLower())
                        {
                            total += money2.Salary;
                        }
                    }
                }
                total += newSalarynum;
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == choose.ToLower())
                    {
                        if (item.SlaryLimit < total)
                        {
                            Console.WriteLine("Limiti kecdiz");
                            Console.WriteLine("Yeniden daxil edin");
                            goto strong;
                        }
                        else if (item.SlaryLimit < total)
                        {
                            Console.WriteLine("Salary limit kece bilmersiz");
                            Console.WriteLine("Yeniden daxil edin");
                            goto strong;
                        }
                    }
                }

                humanResourceManager.EditEmployee(No, FullName, NewPosition, newSalarynum);

            }
            static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Departments.Length <= 0)
                {
                    Console.WriteLine("Departament siyahisi bosdur,once departament yaradin");
                    return;
                }
                Console.WriteLine("Departament adini daxil edin");

                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item != null)
                    {
                        Console.WriteLine("---------------------------");
                        Console.WriteLine(item);
                        Console.WriteLine("---------------------------");
                    }
                }
                yo:
                string DepName = Console.ReadLine();
                bool res = true;
                int count = 0;
                int check = 0;
                int nulll = 0;
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == DepName.ToLower())
                    {
                        foreach (Employee employee in item.Employees)
                        {
                            if (employee != null)
                            {
                                check++;
                            }
                            else
                            {
                                nulll++;
                            }
                        }
                    }
                }
                if (nulll > 0 && check <= 0)
                {
                    Console.WriteLine("Employee listi bosdur");
                    return;
                }
                else if (nulll == 0 && check == 0)
                {
                    Console.WriteLine("Employee listi bosdurr");
                    return;
                }
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
                        Console.WriteLine("Duzgun Departament adi daxil edin");
                        goto yo;
                    }
                    else
                    {
                        res = false;

                    }
                    count = 0;
                }
                Console.WriteLine("Silinme etmek istediyiviz iscinin NO-ni daxil edin");
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item != null && item.Name.ToLower() == DepName.ToLower())
                    {
                        foreach (Employee item2 in item.Employees)
                        {
                            if (item2 != null)
                            {
                                Console.WriteLine("---------------------------");
                                Console.WriteLine(item2);
                                Console.WriteLine("---------------------------");
                            }
                        }
                    }
                }
                swim:
                string NO = Console.ReadLine();
                bool resul = true;
                int counter = 0;
                while (resul)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        foreach (Employee employee in item.Employees)
                        {
                            if (employee != null && employee.No.ToLower() == NO.ToLower())
                            {
                                counter++;
                            }
                        }
                    }
                    if (counter > 0)
                    {
                        resul = false;
                    }
                    else
                    {
                        Console.WriteLine("Duzgun NO-re daxil edin");
                        goto swim;
                    }
                    counter = 0;
                }
                humanResourceManager.RemoveEmployee(NO, DepName);
            }





        }
    }
}
