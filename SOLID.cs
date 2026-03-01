using System;
using System.IO;

public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

public interface IReportSender
{
    void SendReport();
}

public interface IBonusCalculator
{
    double CalculateBonus();
}

public interface IMessageSender
{
    void Send(string name);
}

public class EmailSender : IMessageSender
{
    public void Send(string name)
    {
        Console.WriteLine("Sending email to " + name);
    }
}

public abstract class Employee : IWorkable, IEatable, ISleepable, IReportSender, IBonusCalculator
{
    public string Name { get; private set; }
    public double Salary { get; private set; }

    protected Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

    public abstract double CalculateBonus();
    public void Work() => Console.WriteLine($"{Name} is working.");
    public void Eat() => Console.WriteLine($"{Name} is eating.");
    public void Sleep() => Console.WriteLine($"{Name} is sleeping.");
    public void SendReport() => Console.WriteLine($"{Name} sends report.");
}

public class PermanentEmployee : Employee
{
    public PermanentEmployee(string name, double salary) : base(name, salary) { }

    public override double CalculateBonus() => Salary * 0.3;
}

public class PartTimeEmployee : Employee
{
    public PartTimeEmployee(string name, double salary) : base(name, salary) { }

    public override double CalculateBonus() => Salary * 0.1;
}

public class Intern : Employee
{
    public Intern(string name, double salary) : base(name, salary) { }

    public override double CalculateBonus() => Salary * 0.05;
}
public class EmployeeOnContract : Employee
{
    public override double CalculateBonus() => Salary * 0.15;

}

public interface IEmployeeRepository
{
    void Save(Employee emp);
}

public class FileEmployeeRepository : IEmployeeRepository
{
    public void Save(Employee emp)
    {
        File.WriteAllText("employee.txt", $"{emp.Name} - {emp.Salary}");
    }
}

public class NotificationService
{
    public IMessageSender sender;

    public NotificationService(IMessageSender sender)
    {
        this.sender = sender;
    }

    public void Notify(Employee emp)
    {
        sender.Send(emp.Name);
    }
}

class Program
{
    static void Main()
    {
        Employee intern = new Intern("Mim", 10000);
        Employee permanent = new PermanentEmployee("Mahjabin", 50000);
        Employee contractWorker = new EmployeeOnContract("Raihan", 25000);

        Console.WriteLine($"Intern bonus: {intern.CalculateBonus()}");
        Console.WriteLine($"Permanent bonus: {permanent.CalculateBonus()}");
        Console.WriteLine($"Contract bonus: {contractWorker.CalculateBonus()}");

        intern.Work();
        intern.Eat();
        intern.Sleep();
        intern.SendReport();

        contractWorker.Work();
        contractWorker.Eat();
        contractWorker.Sleep();
        contractWorker.SendReport();

        IEmployeeRepository repository = new FileEmployeeRepository();
        repository.Save(intern);

        IMessageSender emailSender = new EmailSender();
        NotificationService notifier = new NotificationService(emailSender);
        notifier.Notify(intern);

        notifier.Notify(contractWorker);
    }
}