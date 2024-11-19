using ExecuteUpdateDeleteDemo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using var context = new ExecuteUpdateDeleteDemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var products = new[]
{
    new Product { Name = "Product1", Price = 1200 },
    new Product { Name = "Product2", Price = 1300 },
    new Product { Name = "Product3", Price = 20 },
    new Product { Name = "Product4", Price = 500 },
    new Product { Name = "Product5", Price = 1000, IsInStock = true},
    new Product { Name = "Product6", Price = 630, IsInStock = true},
    new Product { Name = "Product7", Price = 780, IsInStock = true},
    new Product { Name = "Product8", Price = 1450, IsInStock = true}
};

context.Products.AddRange(products);
context.SaveChanges();

var allProducts = context.Products.ToList();
Console.WriteLine("All Products");
allProducts.ForEach(product => Console.WriteLine($"{product.Name}: {product.Price}, InStock: {product.IsInStock}"));

// Update product names for in-stock products
context.Products
    .Where(p => p.IsInStock)
    .ExecuteUpdate(p => p.SetProperty(p => p.Name, p => p.Name + "(InStock)"));

// Delete products with price less than 100
context.Products
    .Where(p => p.Price < 100)
    .ExecuteDelete();

// Reload the updated products from the database
var updatedProducts = context.Products.AsNoTracking().ToList();
Console.WriteLine("Updated Products");
updatedProducts.ForEach(product =>
{
    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, InStock: {product.IsInStock}");
});
