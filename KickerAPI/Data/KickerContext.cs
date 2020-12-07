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
        public DbSet<File> Files { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<GameType>().ToTable("GameType");
            modelBuilder.Entity<Table>().ToTable("Table");
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Tournament>().ToTable("Tournament");
            modelBuilder.Entity<Competition>().ToTable("Competition");
            modelBuilder.Entity<File>().ToTable("File");


            modelBuilder.Entity<TeamUser>()
                .HasKey(tu => new { tu.TeamID, tu.UserID });
            modelBuilder.Entity<TeamUser>()
                .HasOne(tu => tu.Team)
                .WithMany(t => t.TeamUsers)
                .HasForeignKey(tu => tu.TeamID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TeamUser>()
                .HasOne(tu => tu.User)
                .WithMany(u => u.TeamUsers)
                .HasForeignKey(tu => tu.UserID);
            modelBuilder.Entity<Tournament>()
                .HasOne(t => t.Winner)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Table>()
                .HasOne(t => t.TablePicture)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Tournament)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
