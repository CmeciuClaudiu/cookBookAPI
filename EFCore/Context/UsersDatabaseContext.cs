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
        public DbSet<Messages> Messages { get; set; }
        public DbSet<UserComment> UserComments { get; set; }

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

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.ToTable("Messages");

                entity.Property(e => e.Id)
                      .ValueGeneratedNever()
                      .HasColumnName("Id")
                      .IsRequired()
                      .HasMaxLength(36)
                      .IsUnicode(false);

                entity.Property(e => e.Username)
                      .HasColumnName("username")
                      .IsRequired()
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.Message)
                      .HasColumnName("message")
                      .IsRequired()
                      .IsUnicode(false);

                entity.Property(e => e.DateTime)
                      .HasColumnName("date_time")
                      .IsRequired()
                      .IsUnicode(false);
            });

            modelBuilder.Entity<UserComment>(entity =>
            {
                entity.ToTable("UserComments");

                entity.Property(e => e.Id)
                      .ValueGeneratedNever()
                      .HasColumnName("Id")
                      .IsRequired()
                      .HasMaxLength(36)
                      .IsUnicode(false);

                entity.Property(e => e.RecipesId)
                     .HasColumnName("recipesId")
                     .IsRequired()
                     .HasMaxLength(36)
                     .IsUnicode(false);

                entity.Property(e => e.UserName)
                      .HasColumnName("userName")
                      .IsRequired()
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.Message)
                      .HasColumnName("message")
                      .IsUnicode(false);

                entity.Property(e => e.Rating)
                      .HasColumnName("rating")
                      .IsRequired()
                      .IsUnicode(false);

                entity.Property(e => e.CurrentDate)
                      .HasColumnName("messageDate")
                      .IsRequired()
                      .IsUnicode(false);
            });

        }
    }
}
