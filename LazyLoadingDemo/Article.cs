using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoadingDemo
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = [];
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
