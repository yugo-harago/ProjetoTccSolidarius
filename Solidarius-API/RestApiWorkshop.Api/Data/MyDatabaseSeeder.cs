using Bogus;
using RestApiWorkshop.Api.Models;

namespace RestApiWorkshop.Api.Data
{
    public class MyDatabaseSeeder
    {
        public static void Seed(IMyDatabase myDatabase)
        {
            var faker = new Faker();

            var authors = new[]
            {
                new Author {Id = 1, Name = "Fulano"},
                new Author {Id = 2, Name = "Beltrano"},
                new Author {Id = 3, Name = "Cicrano"}
            };

            var blogs = new[]
            {
                new Blog {Id = 1, Url = "/my-blog", Author = faker.PickRandom(authors)},
                new Blog {Id = 2, Url = "/your-blog", Author = faker.PickRandom(authors)},
                new Blog {Id = 3, Url = "/their-blog", Author = faker.PickRandom(authors)},
                new Blog {Id = 4, Url = "/our-blog", Author = faker.PickRandom(authors)},
                new Blog {Id = 5, Url = "/his-blog", Author = faker.PickRandom(authors)}
            };

            var postId = 0;
            var tagId = 0;

            foreach (var blog in blogs)
            {
                for (var i = 0; i < faker.Random.Int(2, 10); i++)
                {
                    var post = new Post
                    {
                        Id = ++postId,
                        Title = faker.Lorem.Sentence(range: 5),
                        Content = faker.Lorem.Paragraphs()
                    };

                    for (var j = 0; j < faker.Random.Int(1, 5); j++)
                    {
                        var tag = new Tag
                        {
                            Id = ++tagId,
                            Value = faker.Random.Word()
                        };
                        post.Tags.Add(tag);
                    }

                    blog.Posts.Add(post);
                }
            }

            myDatabase.Blogs.AddRange(blogs);

            myDatabase.SaveChanges();
        }
    }
}