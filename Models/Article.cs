using System;

namespace PersonalBlog.Models
{
    public class Article
    {
        public string Id { get; set;} = Guid.NewGuid().ToString();
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime PublicationDate { get; set; } = DateTime.Now;
        
    }
}

