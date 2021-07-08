using EBookPresenter.Models;
using Microsoft.EntityFrameworkCore;

namespace EBookPresenter.Context
{
    public class EBookContext : DbContext
    {
        public EBookContext(DbContextOptions<EBookContext> contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<EBook> EBooks;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EBook>().HasKey(x => x.Id);
        }
    }
}