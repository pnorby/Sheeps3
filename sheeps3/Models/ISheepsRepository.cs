using System.Collections.Generic;

namespace sheeps3.Models
{
    public interface ISheepsRepository
    {
        void AddHand(Hand hand);
        void AddPlayer(Player player);
        void AddGame(Game game);
        void AddGameHistory(GameHistory gameHistory);
        List<GameHistory> GetAllGameHistories();
        List<Hand> GetAllHands();
        List<Player> GetAllPlayers();
        List<Game> GetAllGames();
        //void UpdatePlayer(Player player);
    }
}