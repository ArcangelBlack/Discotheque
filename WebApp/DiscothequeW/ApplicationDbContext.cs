using Microsoft.EntityFrameworkCore;
using System.Linq;
using D.Models.Models;

namespace DiscothequeW
{
    public class ApplicationDbContext : DbContext
    {
        #region Fields

        public string CurrentUserId { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Discotheque> Discotheques { get; set; }

        public DbSet<DiscothequeCategory> DiscothequeCategories { get; set; }

        public DbSet<DiscothequeDetail> DiscothequeDetails { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Music> Musics { get; set; }

        public DbSet<MusicDetail> MusicDetails { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Rol> Rols { get; set; }

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


            builder.Entity<Company>().ToTable($"App{nameof(this.Companies)}");
            builder.Entity<Discotheque>().ToTable($"App{nameof(this.Discotheques)}");
            builder.Entity<DiscothequeCategory>().ToTable($"App{nameof(this.DiscothequeCategories)}");
            builder.Entity<DiscothequeDetail>().ToTable($"App{nameof(this.DiscothequeDetails)}");
            builder.Entity<Employee>().ToTable($"App{nameof(this.Employees)}");
            builder.Entity<Music>().ToTable($"App{nameof(this.Musics)}");
            builder.Entity<MusicDetail>().ToTable($"App{nameof(this.MusicDetails)}");
            builder.Entity<User>().ToTable($"App{nameof(this.Users)}");
            builder.Entity<Rol>().ToTable($"App{nameof(this.Rols)}");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
