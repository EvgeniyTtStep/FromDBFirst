//using OfficeP32.Models;

using Microsoft.EntityFrameworkCore;
using OfficeP32.Models;

class Program
{
    public static void Main(string[] args)
    {
        OfficeP32Context context = new OfficeP32Context();
        context.Database.EnsureCreated();

        // context.Skills.Add(new Skill(){NameSkill = "XeroxUser"});
        // context.Positions.Add(new Position(){NamePosition = "Junior"});
        // context.SaveChanges();
        //
        // context.Employees.Add(new Employee(){NameEmployee = "Jack", PositionId = 1, SkillsId = 1});
        // context.SaveChanges();
        
        //context.Employees.Add(new Employee(){NameEmployee = "Trump", Salary = 100, PositionId = 1, SkillsId = 1});
        //context.SaveChanges();

        var contextView2S = context.View_2s.ToList();

        foreach (var view2 in contextView2S)
        {
            Console.WriteLine(view2.NameEmployee +" "+view2.NamePosition+ " " + view2.NameSkill);
        }

        context.SaveChanges();

        var getAllEmployeesList = context.GetAllEmployees.FromSqlRaw("EXEC getAllEmployees").ToList();

         foreach (var employee in getAllEmployeesList)
         {
             Console.WriteLine("Name Employee = " + employee.NameEmployee);
         }
         
         
         var getMaxSalaries = context.GetMaxSalary.FromSqlRaw("EXEC getMaxSalary @CurrentSalary={0}", 1500).ToList();

         foreach (var salary in getMaxSalaries)
         {
             Console.WriteLine("Salary = " + salary.AverSalary);
         }
    }
}