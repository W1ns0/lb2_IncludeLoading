using Microsoft.EntityFrameworkCore;


class Program
{
    static void Main()
    {
        using (ApplicationContext db = new ApplicationContext())
        {

            var employees = db.Employees
            .Include(u => u.Position)
            .ThenInclude(c => c!.Department)
            .ToList();

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.name} - {e.Position?.title} - {e.Position?.Department?.name}");
            }



            /*            var employees = db.Employees.ToList();

                        foreach (var e in employees)
                        {
                            db.Entry(e).Reference(emp => emp.Position).Load();
                            db.Entry(e.Position!).Reference(pos => pos.Department).Load();

                            Console.WriteLine($"{e.name} - {e.Position?.title} - {e.Position?.Department?.name}");
                        }*/
        }
    }
}
