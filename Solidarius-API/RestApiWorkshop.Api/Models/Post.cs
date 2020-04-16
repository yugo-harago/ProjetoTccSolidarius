using System.Collections.Generic;

namespace RestApiWorkshop.Api.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}