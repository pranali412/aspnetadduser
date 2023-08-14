using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using User.Domain.Common;
using User.Domain.Entities;

namespace User.Infrastructure.Persistence
{
    public class ASPUserDbContext : DbContext
    {
        public ASPUserDbContext(DbContextOptions<ASPUserDbContext> options) : base(options)
        {

        }

        public DbSet<Userr> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Appointment> Appointments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Domain.ViewModel.DoctorDropdownVm>().ToView(nameof(Domain.ViewModel.DoctorDropdownVm)).HasNoKey();
        }
        public DbSet<Domain.ViewModel.DoctorDropdownVm> doctorDropdownVms { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {

                switch (entry.State)
                {

                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "";
                        entry.Entity.LastModifiedDate = null;
                        entry.Entity.LastModifiedBy = "";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}

