using Microsoft.EntityFrameworkCore;


#nullable disable

namespace cookbookAPI
{
    public partial class CookbookDatabaseContext : DbContext
    {
        public CookbookDatabaseContext()
        {
        }

        public CookbookDatabaseContext(DbContextOptions<CookbookDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<PrepInstruct> PrepInstructs { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
          
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<PrepInstruct>(entity =>
            {
                entity.ToTable("Prep_instruct");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Instructions).IsUnicode(false);

                entity.Property(e => e.RecipesId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("Recipes_ID");

                entity.HasOne(d => d.Recipes)
                    .WithMany(p => p.PrepInstructs)
                    .HasForeignKey(d => d.RecipesId)
                    .HasConstraintName("FK__Prep_inst__Recip__30F848ED");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.ToTable("Recipe_Ingredients");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.IngredientsId).HasColumnName("ingredients_ID");

                entity.Property(e => e.Quantity)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("quantity");

                entity.Property(e => e.RecipesId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("recipes_ID");

                entity.HasOne(d => d.Ingredients)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.IngredientsId)
                    .HasConstraintName("FK__Recipe_In__ingre__35BCFE0A");

                entity.HasOne(d => d.Recipes)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RecipesId)
                    .HasConstraintName("FK__Recipe_In__recip__36B12243");
            });

        }

    }
}
