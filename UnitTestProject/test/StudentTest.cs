using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Xunit;

namespace UnitTestProject.test;

public class StudentTest
{
    [Fact]
    public void CanAddStudent()
    {
        var options = new DbContextOptionsBuilder<StudentContext>()
            .UseInMemoryDatabase(databaseName:"StudentDB")
            .Options;
        
        using (var context = new StudentContext(options))
        {
            context.Students.Add(new Student(){Name = "Peter1"});
            context.SaveChanges();
        }
        
        using (var context = new StudentContext(options))
        {
            var students = context.Students.ToList();

            foreach (var student in students)
            {
                Console.WriteLine("Name = " + student.Name);
            }
            
            var studentFirst = context.Students.FirstOrDefault(x => x.Name == "Peter1");
            Assert.Equal("Peter1", studentFirst.Name);
        }
    }

    [Fact]
    public void GetByIdStudent()
    {
        var options = new DbContextOptionsBuilder<StudentContext>()
            .UseInMemoryDatabase(databaseName:"StudentDB1")
            .Options;
        
        using (var context = new StudentContext(options))
        {
            context.Students.Add(new Student(){Id = 1, Name = "Max"});
            context.SaveChanges();
        }

        using (var context = new StudentContext(options))
        {
            var student =  context.Students.Find(1);
            Assert.Equal(1, student?.Id);
        }
        
    }
    
}