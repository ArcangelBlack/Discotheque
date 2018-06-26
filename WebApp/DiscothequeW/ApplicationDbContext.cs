using Microsoft.EntityFrameworkCore;
using System.Linq;
using D.Models.Models;

namespace DiscothequeW
{
    public class ApplicationDbContext : DbContext
    {
        #region Fields

        public string CurrentUserId { get; set; }

        public DbSet<Company> Companie { get; set; }

        public DbSet<Discotheque> Discotheque { get; set; }

        public DbSet<DiscothequeCategory> DiscothequeCategorie { get; set; }

        public DbSet<DiscothequeDetail> DiscothequeDetail { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Music> Music { get; set; }

        public DbSet<MusicDetail> MusicDetail { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Rol> Rol { get; set; }

        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            builder.Entity<Company>().ToTable($"App{nameof(this.Companie)}");
            builder.Entity<Discotheque>().ToTable($"App{nameof(this.Discotheque)}");
            builder.Entity<DiscothequeCategory>().ToTable($"App{nameof(this.DiscothequeCategorie)}");
            builder.Entity<DiscothequeDetail>().ToTable($"App{nameof(this.DiscothequeDetail)}");
            builder.Entity<Company>().ToTable($"App{nameof(this.Employee)}");
            builder.Entity<Music>().ToTable($"App{nameof(this.Music)}");
            builder.Entity<MusicDetail>().ToTable($"App{nameof(this.MusicDetail)}");
            builder.Entity<User>().ToTable($"App{nameof(this.User)}");
            builder.Entity<Rol>().ToTable($"App{nameof(this.Rol)}");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
