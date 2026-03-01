// using System;
// using System.IO;

// // ISP Violation
// public interface IEmployeeTasks
// {
//     void Work();
//     void Eat();
//     void Sleep();
//     void SendReport();
// }

// // DIP Violation 
// public class EmailSender
// {
//     public void Send(Employee emp)
//     {
//         Console.WriteLine("Sending email to " + emp.Name);
//     }
// }

// public class Employee : IEmployeeTasks
// {
//     public string Name { get; set; }
//     public string Type { get; set; }
//     public double Salary { get; set; }

//     public Employee(string name, string type, double salary)
//     {
//         Name = name;
//         Type = type;
//         Salary = salary;
//     }

//     // OCP Violation
//     public virtual double CalculateBonus()
//     {
//         if (Type == "FullTime")
//         {
//             return Salary * 0.2;
//         }
//         else if (Type == "PartTime")
//         {
//             return Salary * 0.1;
//         }
//         else if (Type == "Intern")
//         {
//             return Salary * 0.05;
//         }
//         return 0;
//     }

//     // SRP Violation 
//     public void SaveToFile()
//     {
//         File.WriteAllText("employee.txt", Name + " - " + Salary);
//     }

//     public void SendEmail()
//     {
//         EmailSender sender = new EmailSender(); 
//         sender.Send(this);
//     }

//     // ISP Violation
//     public void Work()
//     {
//         Console.WriteLine(Name + " is working.");
//     }

//     public void Eat()
//     {
//         Console.WriteLine(Name + " is eating.");
//     }

//     public void Sleep()
//     {
//         Console.WriteLine(Name + " is sleeping.");
//     }

//     public void SendReport()
//     {
//         Console.WriteLine(Name + " sends report.");
//     }
// }

// class PermanentEmployee : Employee
// {
//     public PermanentEmployee(string name, double salary)
//         : base(name, "FullTime", salary)
//     {
//     }

//     // LSP Violation
//     public override double CalculateBonus()
//     {
//         return Salary * 0.3;
//     }
// }

// class Intern : Employee
// {
//     public Intern(string name, double salary)
//         : base(name, "Intern", salary)
//     {
//     }

//     // LSP Violation
//     public override double CalculateBonus()
//     {
//         throw new NotImplementedException("Interns do not get bonus");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Employee emp = new Intern("Mim", 10000);

//         // LSP Violation
//         Console.WriteLine(emp.CalculateBonus());

//         // ISP Violation
//         emp.Sleep();
//         emp.SendReport();

//         // DIP Violation
//         emp.SendEmail();
//     }
// }