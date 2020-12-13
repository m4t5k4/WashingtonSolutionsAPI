using KickerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace KickerAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(KickerContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {

                //return;
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            var gameType1 = new GameType { Name = "1v1" };
            var gameType2 = new GameType { Name = "2v2" };
            context.GameTypes.AddRange(gameType1, gameType2);
            context.SaveChanges();

            var gameStatus1 = new GameStatus { Name = "Challenged" };
            var gameStatus2 = new GameStatus { Name = "Planned" };
            var gameStatus3 = new GameStatus { Name = "Playing" };
            var gameStatus4 = new GameStatus { Name = "Played" };
            var gameStatus5 = new GameStatus { Name = "Dispute" };
            var gameStatus6 = new GameStatus { Name = "Declined" };
            var gameStatus7 = new GameStatus { Name = "Verify" };
            context.GameStatus.AddRange(gameStatus1, gameStatus2, gameStatus3, gameStatus4, gameStatus5, gameStatus6, gameStatus7);
            context.SaveChanges();

            var userRole = new Role { Name = "User" };
            var adminRole = new Role { Name = "Admin" };
            var captainRole = new Role { Name = "Captain" };
            context.Roles.AddRange(
              userRole, adminRole, captainRole);
            context.SaveChanges();

            var pic1 = new File { Name = "Morty Smith", Path = "Morty_Smith.jpg" };
            context.Files.Add(pic1);
            context.SaveChanges();

            var group1 = new Group { Name = "Thomas More Kicker Team", CompanyName = "Thomas More", Location = "Geel", GroupPicture = pic1 };
            var group2 = new Group { Name = "UCLL Kicker Team", CompanyName = "UCLL", Location = "Hasselt", GroupPicture = pic1 };
            context.Groups.AddRange(group1, group2);
            context.SaveChanges();

            var user1 = new User { Role = adminRole, Username = "admin", Password = BC.HashPassword("admin123"), FirstName = "admin", LastName = "Istrator", Email = "admin.istrator@thomasmore.be", Group = group1, UserPicture = pic1 };
            var user2 = new User { Role = userRole, Username = "user1", Password = BC.HashPassword("user123"), FirstName = "User1", LastName = "Test", Email = "user1.test@thomasmore.be", Group = group1, UserPicture = pic1 };
            var user3 = new User { Role = userRole, Username = "user2", Password = BC.HashPassword("user123"), FirstName = "User2", LastName = "Test", Email = "user2.test@thomasmore.be", Group = group2, UserPicture = pic1 };
            var user4 = new User { Role = captainRole, Username = "captain1", Password = BC.HashPassword("captian123"), FirstName = "captain1", LastName = "Test", Email = "captain1.test@thomasmore.be", Group = group1, UserPicture = pic1 };
            var user5 = new User { Role = captainRole, Username = "captain2", Password = BC.HashPassword("captian123"), FirstName = "captain2", LastName = "Test", Email = "captain2.test@thomasmore.be", Group = group2, UserPicture = pic1 };
            context.Users.AddRange(user1, user2, user3, user4, user5);
            context.SaveChanges();

            var team1 = new Team { TeamName = "TM Team 1", Group = group1};
            var team2 = new Team { TeamName = "UCLL Team 1", Group = group2};
            context.Teams.AddRange(team1, team2);
            context.SaveChanges();

            var teamUser1 = new TeamUser { Team = team1, User = user2 };
            var teamUser2 = new TeamUser { Team = team1, User = user4 };            
            var teamUser3 = new TeamUser { Team = team2, User = user3 };
            var teamUser4 = new TeamUser { Team = team2, User = user5 };
            context.TeamUsers.AddRange(teamUser1, teamUser2, teamUser3, teamUser4);
            context.SaveChanges();

            team1.TeamUsers.Add(teamUser1);
            team1.TeamUsers.Add(teamUser1);
            team2.TeamUsers.Add(teamUser3);
            team2.TeamUsers.Add(teamUser4);
            context.SaveChanges();

            user2.TeamUsers.Add(teamUser1);
            user3.TeamUsers.Add(teamUser3);
            user4.TeamUsers.Add(teamUser2);
            user5.TeamUsers.Add(teamUser4);
            context.SaveChanges();

            var table1 = new Table { TableName = "TM Table 1", CompanyName = "Thomas More", ContactPerson = user1, Address = "Geel", TablePicture = pic1 };
            var table2 = new Table { TableName = "UCLL Table 1", CompanyName = "UCLL", ContactPerson = user1, Address = "Hasselt", TablePicture = pic1 };
            context.Table.AddRange(table1, table2);
            context.SaveChanges();

            var competition1 = new Competition { Name = "Kicker Championship 2020", GameType = gameType1 };
            context.Competitions.Add(competition1);
            context.SaveChanges();

            var tournament1 = new Tournament { Name = "Semi-finals", Competition = competition1};
            context.Tournaments.Add(tournament1);
            context.SaveChanges();

            var game1 = new Game { TeamA = team1, TeamB = team2, Table = table1, GameType = gameType1, Tournament = tournament1, ChallengedBy = group1, ChallengedGroup = group2, GameStatus = gameStatus2 };
            var game2 = new Game { TeamA = team2, TeamB = team1, Table = table1, GameType = gameType2, Tournament = tournament1, ScoreTeamA = 1, ScoreTeamB = 2, ChallengedBy = group2, ChallengedGroup = group1, GameStatus = gameStatus5 };
            context.Games.AddRange(game1, game2);
            context.SaveChanges();

            
        }
    }
}
