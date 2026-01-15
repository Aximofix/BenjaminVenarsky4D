using Microsoft.EntityFrameworkCore;
using UserApp.DataLayer.Entities;

namespace UserApp.DataLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<UsersEntity> TUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var basePath = Path.GetFullPath(
                    Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\UserApp.DataLayer")
                );
                var dbPath = Path.Combine(basePath, "appdata.db");

                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
            //optionsBuilder.UseSqlite("Data Source=userApp.db");
        }

        //private void OnModelCreating(ModelBuilder modelBuilder) {
            
        //}
    }
}
