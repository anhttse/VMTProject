using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VMT.Models;

namespace VMT.Identity
{
    public class ApplicationIdentityDbContext: IdentityDbContext<User,RoleGroup,string>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
        :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RoleGrouPermission>()
                .HasKey(c => new { c.RoleGroupId, c.PermissionId });
        }

        public virtual DbSet<RoleGrouPermission> RoleGrouPermission { get; set; }
        public virtual DbSet<Permission > Permission { get; set; }
        public virtual DbSet<PermissionAction> PermissionAction { get; set; }
    }
}
