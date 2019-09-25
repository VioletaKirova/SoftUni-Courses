using JetBrains.Annotations;
using Messages.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Messages.Data
{
    public class MessagesDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public MessagesDbContext(DbContextOptions options) 
            : base(options)
        {
        }
    }
}
