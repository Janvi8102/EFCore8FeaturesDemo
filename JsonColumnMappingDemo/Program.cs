using JsonColumnMappingDemo;

using var context = new JsonColumnMappingDemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

Console.WriteLine("Json Column Sample");

var users = new List<User>
{
   new()
    {
         Name = "User1",
         Attributes = new UserAttributes
         {
             Designation = "Sr. Engineer",
             Skills = ["C#", "EF Core", "SQL"]
         }
    },
   new()
    {
         Name = "User2",
         Attributes = new UserAttributes
         {
             Designation = "Jr. Engineer",
             Skills = ["C#", "SQL"]
         }
    },
   new()
    {
         Name = "User3",
         Attributes = new UserAttributes
         {
             Designation = "Engineer",
             Skills = ["HTML", "CSS"]
         }
    }
};

context.Users.AddRange(users);
context.SaveChanges();

Console.WriteLine("Updating Data");
var userDataToUpdate = context.Users.First(c => c.Name == "User1");
userDataToUpdate.Attributes.Designation = "Sr.SoftwareEngineer";
context.SaveChanges();

Console.WriteLine("List of all Users:");
users.ForEach(user =>
{
    Console.WriteLine($"Name: {user.Name}");
    Console.WriteLine($"Designation: {user.Attributes.Designation}");
    Console.WriteLine($"Skills: {string.Join(", ", user.Attributes.Skills)}");
    Console.WriteLine();
});