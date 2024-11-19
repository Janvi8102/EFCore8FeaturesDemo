using PrimitiveCollectionsDemo;

using var context = new PrimitiveCollectionsDemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

Console.WriteLine("Primitive Collection Sample");

var orders = new List<Order>
{
    new() { CustomerName = "Customer1", ProductIds = { 1, 2, 3 }},
    new() { CustomerName = "Customer2", ProductIds = { 4, 5, 6 }},
    new() { CustomerName = "Customer3", ProductIds = { 7, 8, 9 }},
};

context.Orders.AddRange(orders);
context.SaveChanges();

var allOrders = context.Orders.ToList();
Console.WriteLine("List of all Orders");
allOrders.ForEach(order => Console.WriteLine($"{order.CustomerName}: {string.Join(", ", order.ProductIds)}"));

Console.ReadLine();