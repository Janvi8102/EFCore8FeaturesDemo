using ComplexTypesDemo;

using var context = new ComplexTypesDemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

Console.WriteLine("Complex Types Sample");

var products = new List<Product>
                    {
                       new(){ Name = "Laptop",
                              Price = new Price { Amount = 1000, Currency = "USD" }
                            },
                       new(){ Name = "HeadPhones",
                              Price = new Price { Amount = 500, Currency = "USD" }
                            }
                    };

context.Products.AddRange(products);
context.SaveChanges();

var allProducts = context.Products.ToList();
allProducts.ForEach(product => Console.WriteLine($"{product.Name}: {product.Price.Amount} {product.Price.Currency}"));

Console.ReadLine();