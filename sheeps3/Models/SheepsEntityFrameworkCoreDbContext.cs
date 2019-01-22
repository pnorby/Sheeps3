using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sheeps3.Models
{
    public class SheepsEntityFrameworkCoreDbContext : DbContext, ISheepsRepository
    {
        public SheepsEntityFrameworkCoreDbContext(DbContextOptions<SheepsEntityFrameworkCoreDbContext> options)
            : base(options)
        {

        }

        DbSet<Hand> Hands { get; set; }

        DbSet<Player> Players { get; set; }

        DbSet<Game> Games { get; set; }

        DbSet<GameHistory> GameHistories { get; set; }

        public void AddGameHistory(GameHistory gameHistory)
        {
            GameHistories.Add(gameHistory);
            SaveChanges();
        }

        public void AddHand(Hand hand)
        {
            Hands.Add(hand);
            SaveChanges();
        }
        public List<Game> GetAllGames()
        {
            return Games.ToList();
        }
        
        public List<Hand> GetAllHands()
        {
            return Hands.ToList();
        }

        public List<GameHistory> GetAllGameHistories()
        {
            return GameHistories.ToList();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            SaveChanges();
        }

        public void AddGame(Game game)
        {
            Games.Add(game);
            SaveChanges();
        }

        public List<Player> GetAllPlayers()
        {
            return Players.ToList();
        }

        //public virtual Player<Player>(Player player)
        //{
            //Players.Update(player);
            //SaveChanges();
        //}
    }
}
