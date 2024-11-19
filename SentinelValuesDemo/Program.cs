using SentinelValuesDemo;

using var context = new SentinelValuesDemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var employees = new List<Employee>
                { 
                    new(){ Name = "Employee1" },
                    new(){ Name = "Employee2" },
                    new(){ Name = "Employee3" },
                };

foreach (var employee in employees)
{
    context.Employees.Add(employee);
    await context.SaveChangesAsync();
    await Task.Delay(2000); // Delay of 1 second
}

var retrievedEmployee = context.Employees.ToList();
Console.WriteLine("All Employee");
retrievedEmployee.ForEach(Employee =>
    {
        Console.WriteLine($"Employee: {Employee.Name}, CreatedAt: {Employee.CreatedAt}");
    });