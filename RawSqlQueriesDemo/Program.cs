using Microsoft.EntityFrameworkCore;
using RawSqlQueriesDemo;

using var context = new RawSqlQueriesDemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var invoices = new List<Invoice>
        {
            new() { InvoiceNumber = "INV-001", Amount = 1500 },
            new() { InvoiceNumber = "INV-002", Amount = 800 },
            new() { InvoiceNumber = "INV-003", Amount = 1000 },
            new() { InvoiceNumber = "INV-004", Amount = 1200 },
            new() { InvoiceNumber = "INV-005", Amount = 600 },
            new() { InvoiceNumber = "INV-006", Amount = 870 },
            new() { InvoiceNumber = "INV-007", Amount = 2000 },
            new() { InvoiceNumber = "INV-008", Amount = 790 },
        };

context.Invoices.AddRange(invoices);
context.SaveChanges();

// Raw SQL query to return unmapped types
var unmappedInvoices = context.Invoices
    .FromSqlRaw("SELECT InvoiceNumber, Amount FROM Invoices WHERE Amount > 1000")
    .Select(i => new UnmappedType { InvoiceNumber = i.InvoiceNumber, Amount = i.Amount })
    .ToList();

foreach (var invoice in unmappedInvoices)
{
    Console.WriteLine($"Invoice: {invoice.InvoiceNumber}, Amount: {invoice.Amount}");
}