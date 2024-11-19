using HierarchyIdDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Linq;

using var context = new HierarchyIdDemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

Console.WriteLine("Hierarchy IDs Sample");

var categories = new List<Category>
{
    new() { Name = "Electronics", Path = HierarchyId.Parse("/") },
    new() { Name = "Computers", Path = HierarchyId.Parse("/1/") },
    new() { Name = "Laptops", Path = HierarchyId.Parse("/1/1/") },
    new() { Name = "Desktops", Path = HierarchyId.Parse("/1/2/") },
    new() { Name = "Accessories", Path = HierarchyId.Parse("/1/3/") },
    new() { Name = "Smartphones", Path = HierarchyId.Parse("/2/") },
    new() { Name = "Android Phones", Path = HierarchyId.Parse("/2/1/") },
    new() { Name = "iPhones", Path = HierarchyId.Parse("/2/2/") }
};

context.Categories.AddRange(categories);
context.SaveChanges();

var laptopsCategory = context.Categories.First(c => c.Path == HierarchyId.Parse("/1/1/"));

// Get subcategories of Laptops
var laptopSubcategories = context.Categories
    .AsNoTracking()
    .Where(c => c.Path.IsDescendantOf(laptopsCategory.Path))
    .ToList();

Console.WriteLine("Laptop Subcategories:");
laptopSubcategories.ForEach(subcategory => Console.WriteLine($"{subcategory.Name}: {subcategory.Path}"));

//Get Laptop Ancestors
var upperCategories = FindAllAncestors("Laptops").ToList();
Console.WriteLine("Laptops UpperCategories");
upperCategories.ForEach(Console.WriteLine);

var electronicsCategory = context.Categories.First(c => c.Path == HierarchyId.Parse("/"));

// Check hierarchy relationships
Console.WriteLine($"Is Laptops a descendant of Electronics? {laptopsCategory.Path.IsDescendantOf(electronicsCategory.Path)}");
Console.WriteLine($"Is Electronics a descendant of Laptops? {electronicsCategory.Path.IsDescendantOf(laptopsCategory.Path)}");

Console.ReadLine();

IQueryable<Category> FindAllAncestors(string name)
    => context.Categories.Where(
            ancestor => context.Categories
                .Single(
                    descendent =>
                        descendent.Name == name
                        && ancestor.Id != descendent.Id)
                .Path.IsDescendantOf(ancestor.Path))
        .OrderByDescending(ancestor => ancestor.Path.GetLevel());
