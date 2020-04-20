using Bogus;
using SolidariusAPI.Api.Models;

namespace SolidariusAPI.Api.Data
{
    public class MyDatabaseSeeder
    {
        public static void Seed(IDatabase myDatabase)
        {
            //var faker = new Faker();

            //var beneficiario = new[]
            //{
            //    new Beneficiario { Id = 1, Nome = "Fulano"},
            //    new Beneficiario { Id = 2, Nome = "Beltrano"},
            //    new Beneficiario { Id = 3, Nome = "Cicrano"}
            //};

            //var items = new[]
            //{
            //    new Item { Id = 1, Descricao = "item 1"},
            //    new Item { Id = 2, Descricao = "item 2"}
            //};

            //var blogs = new[]
            //{
            //    new Blog {Id = 1, Url = "/my-blog", Author = faker.PickRandom(authors)},
            //    new Blog {Id = 2, Url = "/your-blog", Author = faker.PickRandom(authors)},
            //    new Blog {Id = 3, Url = "/their-blog", Author = faker.PickRandom(authors)},
            //    new Blog {Id = 4, Url = "/our-blog", Author = faker.PickRandom(authors)},
            //    new Blog {Id = 5, Url = "/his-blog", Author = faker.PickRandom(authors)}
            //};

            //var postId = 0;
            //var tagId = 0;

            //foreach (var blog in blogs)
            //{
            //    for (var i = 0; i < faker.Random.Int(2, 10); i++)
            //    {
            //        var post = new Post
            //        {
            //            Id = ++postId,
            //            Title = faker.Lorem.Sentence(range: 5),
            //            Content = faker.Lorem.Paragraphs()
            //        };

            //        for (var j = 0; j < faker.Random.Int(1, 5); j++)
            //        {
            //            var tag = new Tag
            //            {
            //                Id = ++tagId,
            //                Value = faker.Random.Word()
            //            };
            //            post.Tags.Add(tag);
            //        }

            //        blog.Posts.Add(post);
            //    }
            //}

            //myDatabase.Beneficiario.AddRange(beneficiario);
            //myDatabase.Item.AddRange(items);

            //myDatabase.SaveChanges();
        }
    }
}