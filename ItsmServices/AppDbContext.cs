using Microsoft.EntityFrameworkCore;
using ItsmServices.Src.Tickets.Domain;
using ItsmServices.Src.ObjectTypes.Domain;
using ItsmServices.Src.Users.Domain;
using ItsmServices.Src.ObjectTypes.Infrastructure.Persistence;
using ItsmServices.Src.Users.Infrastructure.Persistence;

namespace ItsmServices
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public required DbSet<ObjectType> ObjectType { get; set; }
        public required DbSet<User> User { get; set; }
        public required DbSet<UserRight> UserRight { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ObjectTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserRightEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());


            base.OnModelCreating(modelBuilder);
        }

    }
}
