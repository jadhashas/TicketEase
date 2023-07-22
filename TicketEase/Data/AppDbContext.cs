using Microsoft.EntityFrameworkCore;
using TicketEase.Models;

namespace TicketEase.Data
{
    public class AppDbContext:DbContext
    {
        // DbSet pour les entités (tables) de la base de données
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        // Méthode appelée lors de la création du modèle de données
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de la clé primaire pour l'entité Actor_Movie
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new { am.ActorId, am.MovieId });

            // Configuration de la relation entre l'entité Movie et Actor_Movie
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie)
                .WithMany(am => am.Actors_Movies)
                .HasForeignKey(m => m.MovieId);

            // Configuration de la relation entre l'entité Actor et Actor_Movie
            modelBuilder.Entity<Actor_Movie>().HasOne(a => a.Actor)
                .WithMany(am => am.Actors_Movies)
                .HasForeignKey(a => a.ActorId);

            // Appelle la méthode OnModelCreating du DbContext de base pour effectuer d'autres configurations
            base.OnModelCreating(modelBuilder);
        }


    }
}
