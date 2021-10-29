using cookbookAPI.EFCore.UsersDatabaseModel;
using Microsoft.EntityFrameworkCore;


namespace cookbookAPI.EFCore.Context
{
    public partial class UsersDatabaseContext : DbContext 
    {
        public UsersDatabaseContext(DbContextOptions<UsersDatabaseContext> options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<AuthDetails> AuthDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.Property(e => e.Id)
                      .ValueGeneratedNever()
                      .HasColumnName("Id")
                      .IsRequired()
                      .HasMaxLength(36)
                      .IsUnicode(false);

                entity.Property(e => e.UserName)
                      .HasColumnName("UserName")
                      .IsRequired()
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.UserRole)    
                    .HasColumnName("UserRole");
            });

            modelBuilder.Entity<AuthDetails>(entity =>
            {
                entity.ToTable("AuthDetails");

                entity.Property(e => e.Id)
                      .ValueGeneratedNever()
                      .HasColumnName("Id")
                      .IsRequired()
                      .HasMaxLength(36)
                      .IsUnicode(false);

                entity.Property(e => e.Email)
                      .HasColumnName("Email")
                      .IsRequired()
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("Password")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UsersId)
                      .HasColumnName("UsersId")
                      .IsRequired()
                      .HasMaxLength(36)
                      .IsUnicode(false);

                entity.Property(e => e.Key)
                    .HasColumnName("Keys")
                    .IsRequired()
                    .IsUnicode(false);
            });
        }
    }
}
