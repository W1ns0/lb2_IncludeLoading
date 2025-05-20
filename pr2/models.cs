using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Position> Positions { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=lb2_Company;Username=postgres;Password=1111;");
    }
}
public class Department
{
    public int id { get; set; }//первичный ключ
    public string? name { get; set; }

    public List<Position> Positions { get; set; }
}
public class Position
{
    public int id { get; set; }
    public string? title { get; set; }
    public int DepartmentId { get; set; }//внешний ключ 
    public Department? Department { get; set; }  //навигационное свойствo
    public List<Employee> Employees { get; set; }
}
public class Employee
{
    public int id { get; set; }
    public string? name { get; set; }
    public int PositionId { get; set; }//внешний ключ 
    public Position? Position { get; set; } //навигационное свойство
}
