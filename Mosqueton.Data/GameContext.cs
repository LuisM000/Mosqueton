using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Mosqueton.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
