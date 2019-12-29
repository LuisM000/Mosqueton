using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Mosqueton.Model;
using Mosqueton.Model.Components;
using Mosqueton.Model.Descriptors;

namespace Mosqueton.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
       


        public GameContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
        }

    }
}
