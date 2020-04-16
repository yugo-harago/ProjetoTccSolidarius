using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApiWorkshop.Api.Models;

namespace RestApiWorkshop.Api.Data
{
    public interface IMyDatabase
    {
        DbSet<Blog> Blogs { get; }
        DbSet<Author> Authors { get; }
        DbSet<Post> Posts { get; }
        DbSet<Tag> Tags { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}