using DateOnlyTimeOnlyDemo;

using var context = new DateOnlyTimeOnlyDemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
Console.WriteLine("DateOnly TimeOnly Sample");

var date = DateOnly.FromDateTime(DateTime.UtcNow);
var time = TimeOnly.FromDateTime(DateTime.UtcNow);

var events = new List<Event>()
{
    new Event() { Name = "Event 1", Date = date, Time = time },
    new Event() { Name = "Event 2", Date = date, Time = time },
    new Event() { Name = "Event 3", Date = date, Time = time }
};

context.Events.AddRange(events);
context.SaveChanges();

var allProducts = context.Events.ToList();
allProducts.ForEach(eventdata =>
{
    Console.WriteLine($"Name: {eventdata.Name}, Date: {eventdata.Date}, Time: {eventdata.Time}");
});

Console.ReadLine();