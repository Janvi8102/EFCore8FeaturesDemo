using LazyLoadingDemo;

using var context = new LazyLoadingDemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var article = new Article
{
    Title = "Understanding Lazy Loading in EF Core"
};

context.Articles.Add(article);
context.SaveChanges();

var comments = new List<Comment>
{
    new(){Text = "Great article!", ArticleId = article.Id},
    new(){Text = "Good article!", ArticleId = article.Id}
};

context.Comments.AddRange(comments);
context.SaveChanges();

// Lazy loading will automatically load the related Comments collection
var retrievedArticle = context.Articles.Find(article.Id);
Console.WriteLine($"Article: {retrievedArticle.Title}, Comments Count: {retrievedArticle.Comments.Count}");