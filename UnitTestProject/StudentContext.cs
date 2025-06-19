using Microsoft.EntityFrameworkCore;

namespace UnitTestProject;

public class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public StudentContext(DbContextOptions options) : base(options) {}
    
}