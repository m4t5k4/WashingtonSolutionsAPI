using KickerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Data
{
    public class KickerContext : DbContext
    {
        public KickerContext(DbContextOptions<KickerContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentGame> TournamentGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<GameType>().ToTable("GameType");
            modelBuilder.Entity<Table>().ToTable("Table");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<TeamUser>().ToTable("TeamUser");
            modelBuilder.Entity<Tournament>().ToTable("Tournament");
            modelBuilder.Entity<TournamentGame>().ToTable("TournamentGames");

            modelBuilder.Entity<TeamUser>()
                .HasKey(tu => new { tu.TeamID, tu.UserID });
            modelBuilder.Entity<TeamUser>()
                .HasOne(tu => tu.Team)
                .WithMany(tu => tu.TeamUsers)
                .HasForeignKey(tu => tu.Team);
            modelBuilder.Entity<TeamUser>()
                .HasOne(tu => tu.User)
                .WithMany(tu => tu.TeamUsers)
                .HasForeignKey(tu => tu.UserID);

            modelBuilder.Entity<TournamentGame>()
                .HasKey(tg => new { tg.TournamentID, tg.GameID });
            modelBuilder.Entity<TournamentGame>()
                .HasOne(tg => tg.Tournament)
                .WithMany(tg => tg.TournamentGames)
                .HasForeignKey(tg => tg.TournamentID);
            modelBuilder.Entity<TournamentGame>()
                .HasOne(tg => tg.Game)
                .WithOne(tg => tg.TournamentGame)
                .HasForeignKey<TournamentGame>(tg => tg.GameID);
        }
    }
}
