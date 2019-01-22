using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sheeps3.Models;

namespace sheeps3.Controllers
{
    public class GameController : Controller
    {
        private ISheepsRepository _repository;
        private static Game currentGame;
        private GameHistoryController gHc;
        

        public GameController(ISheepsRepository repository)
        {
            _repository = repository;
        }

        public int GetGameId() {
            return currentGame.Id;
        }

        public int GetPointMonetary()
        {
            return currentGame.CurrentMonetary;
        }

        public void SetPointMonetary(int pM)
        {
            currentGame.CurrentMonetary = pM;
        }

        public void SetGameDoublers(int gD)
        {
            currentGame.CurrentDoublers = gD;
        }

        public int GetGameDoublers()
        {
            return currentGame.CurrentDoublers;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult NewGame()
        {
            ViewBag.AvailablePlayers = _repository.GetAllPlayers();
            return View("NewGame");
        }

        [HttpPost]
        public IActionResult BeginNewGame(Game game)
        {
            
            
            game.CurrentMonetary = 1;
            game.StartTime = DateTime.Now;
            game.CurrentDoublers = 0;
            _repository.AddGame(game);
            int counter = -1;
            

            foreach (Game g in _repository.GetAllGames())
            {
                if (g.Id > counter)
                {
                    counter = g.Id;
                    currentGame = g;
                }
            }

            foreach (GameHistory gh in _repository.GetAllGameHistories())
            {
                if (gh.PlayerActive.Equals(true))
                {
                    gh.PlayerActive = false;
                }
            }
            

            foreach (Player player in _repository.GetAllPlayers())
            {
                if (player.NickName.Equals(game.Player1))
                {
                    CreateNewGameHistory(player.NickName, true, true, 1, currentGame.Id);             
                                       
                }
                else if (player.NickName.Equals(game.Player2))
                {
                    CreateNewGameHistory(player.NickName, true, true, 2, currentGame.Id);                    
                }
                else if (player.NickName.Equals(game.Player3))
                {
                    CreateNewGameHistory(player.NickName, true, true, 3, currentGame.Id);                    
                }
                else if (player.NickName.Equals(game.Player4))
                {
                    CreateNewGameHistory(player.NickName, true, true, 4, currentGame.Id);                    
                }
                else if (player.NickName.Equals(game.Player5))
                {
                    CreateNewGameHistory(player.NickName, true, true, 5, currentGame.Id);                    
                }
                else if (player.NickName.Equals(game.Player6))
                {                    
                    CreateNewGameHistory(player.NickName, true, false, 6, currentGame.Id);                    
                }
                else if (player.NickName.Equals(game.Player7))
                {
                    CreateNewGameHistory(player.NickName, true, false, 7, currentGame.Id);                                        
                }                

            }

            InitializeHands();
            List<Game> gs = new List<Game>();
            gs.Add(currentGame);
            ViewBag.AvailableGameHistories = _repository.GetAllGameHistories();
            ViewBag.AvailableGames = gs;
            
            return RedirectToRoute("Hands/Index");
            
            
        }

        
        private void CreateNewGameHistory(string pName, bool isActive, bool inHand, int position, int gameId)
        {
            GameHistory newGH = new GameHistory();
            newGH.GameInt = currentGame.Id;
            newGH.Score = 0;
            newGH.PlayerNickName = pName;
            newGH.PlayerActive = isActive;
            newGH.PlayerInHand = inHand;
            newGH.PlayerPosition = position;
            newGH.CrackCount = 0;
            newGH.CurrentPoints = 0;

            _repository.AddGameHistory(newGH);

        }

        public void InitializeHands()
        {

            Hand initializerHand = new Hand();
            initializerHand.GameInt = currentGame.Id;
            initializerHand.GameHandNumber = 0;
            initializerHand.HandType = "Regular";
            initializerHand.Dealer = null;
            initializerHand.Picker = null;
            initializerHand.Partner = null;
            initializerHand.Opponent1 = null;
            initializerHand.Opponent2 = null;
            initializerHand.Opponent3 = null;
            initializerHand.Opponent4 = null;
            initializerHand.HandScore = 0;
            initializerHand.BQBlitz = null;
            initializerHand.RQBlitz = null;
            initializerHand.BJBlitz = null;
            initializerHand.RJBlitz = null;
            initializerHand.Crack = null;
            initializerHand.ReCrack = null;
            initializerHand.CrackBack = null;
            initializerHand.Doubler = false;
            initializerHand.Deals = 0;
            initializerHand.Result = null;
            initializerHand.PointMonetary = 0;
            initializerHand.Completed = DateTime.Now;

            _repository.AddHand(initializerHand);

        }
    }
}
