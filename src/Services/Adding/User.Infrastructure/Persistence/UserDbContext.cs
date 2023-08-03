using Microsoft.EntityFrameworkCore;
using User.Domain.Common;
using User.Domain.Entities;

namespace User.Infrastructure.Persistence
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<Userr> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {

                switch (entry.State)
                {

                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "pr";
                        entry.Entity.LastModifiedDate = null;
                        entry.Entity.LastModifiedBy = "";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "pr";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
