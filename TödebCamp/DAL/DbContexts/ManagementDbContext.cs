using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.DbContexts
{
    public class ManagementDbContext : DbContext
    {
        public ManagementDbContext(DbContextOptions<ManagementDbContext> options) : base(options)
        {

        }

        // Database işlemlerimizi DAL katmanında yapıyoruz.

        // ConnectionString kullandığımda migration yaparken hata aldığım için
        // database bağlantısını bu şekilde kullandım.
        


        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
           base.OnConfiguring(optionBuilder.UseSqlServer("server=localhost; database=muhammedkilic1; user=sa; password=mY_1pssMk"));
            //var connectionString = _configuration.GetConnectionString("MsComm");
           // base.OnConfiguring(optionBuilder.UseSqlServer(connectionString));
        }

        // Migration Dotnet CLI codes
        // dotnet ef migrations add CreateDatabaseAndTables
        // dotnet ef database update
        // dotnet ef migrations remove


    }
}
