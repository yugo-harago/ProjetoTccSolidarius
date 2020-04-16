using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApiWorkshop.Api.Models;

namespace RestApiWorkshop.Api.Data
{
    public class MyDatabase : DbContext, IMyDatabase
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public MyDatabase(DbContextOptions options)
            : base(options)
        {
        }
    }
}