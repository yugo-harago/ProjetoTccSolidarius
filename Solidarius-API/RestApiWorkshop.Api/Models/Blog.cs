using System.Collections.Generic;

namespace RestApiWorkshop.Api.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();

        public Author Author { get; set; }
    }
}