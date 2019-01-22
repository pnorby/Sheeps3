using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sheeps3.Models;

namespace sheeps3.Controllers
{

    public class HandsController : Controller
    {
        private static int doublerCount { get; set; }
        private static int monetary { get; set; }
        private ISheepsRepository _repository;
        private static int GameHandNumber { get; set; }
        private static int CurrentGameInt { get; set; }
        private Player[] Opponents { get; set; }
        private static Game currentGame = null;
        private static List<GameHistory> currentPlayers;
        
        
        private GameController gC;
        private static Hand lastHand = null;

        
        
        public HandsController(ISheepsRepository repository)
        {
            _repository = repository;
        }

        public int GetGameHandNumber()
        {
            return GameHandNumber;
            
        }

        public void NextGameHand()
        {
            GameHandNumber = GameHandNumber + 1;
        }

        public IActionResult Index()
        {
            ViewBag.AvailableHands = _repository.GetAllHands();
            ViewBag.AvailablePlayers = _repository.GetAllPlayers();
            ViewBag.AvailableGames = _repository.GetAllGames();
            ViewBag.AvailableGameHistories = _repository.GetAllGameHistories();
            return View("Index");
        }

        

        [HttpGet]
        public IActionResult Game()
        {
            return View("Game");
        }

        [HttpGet]
        public IActionResult StartGame()
        {
            return View();
        }

        
        

        private Boolean NotEmptyOrNull(String s)
        {
            Boolean methodSuccess = true;

            if (s == null || s.Equals(""))
            {
                methodSuccess = false;
            }

            return methodSuccess;
        }

        [HttpPost]
        public IActionResult AddGameHand(Hand hand)
        {
            int handPoints;
            int currentDoublers;
            int newAdditionalDoublers;

            Player[] opponents;

            try
            {

                if (currentGame == null)
                {
                    foreach (Game g in _repository.GetAllGames())
                    {
                        if (g.Id == hand.GameInt)
                        {
                            currentGame = g;
                        }
                    }
                }

                if (currentPlayers == null)
                {
                    currentPlayers = new List<GameHistory>();
                    foreach (GameHistory gh in _repository.GetAllGameHistories())
                    {
                        if (gh.GameInt == hand.GameInt)
                        {
                            currentPlayers.Add(gh);
                        }
                    }                               
                }

                currentDoublers = currentGame.CurrentDoublers;
                monetary = currentGame.CurrentMonetary;
                hand.PointMonetary = monetary;

                    if (currentDoublers > 0)
                    {
                    hand.Doubler = true;
                    currentDoublers = currentDoublers - 1;
                    }

                    if (hand.Deals > 1)
                    {

                    newAdditionalDoublers = hand.Deals - 1;
                    currentDoublers = currentDoublers + newAdditionalDoublers;
                    //Done Processing Doublers, update the game
                    currentGame.CurrentDoublers = currentDoublers;                        
                    }

                    if (hand.Doubler)
                    {
                        handPoints = 2;
                    }
                    else
                    {
                        handPoints = 1;
                    }

                    if (hand.BQBlitz != null)
                    {
                        handPoints = handPoints * 2;           
                    
                    }

                    if (hand.RQBlitz != null)
                    {
                        handPoints = handPoints * 2;                        
                    }

                    if (hand.BJBlitz != null)
                    {
                        handPoints = handPoints * 2;                        
                    }

                    if (hand.RJBlitz != null)
                    {
                        handPoints = handPoints * 2;                        
                    }

                    if (hand.Crack != null)
                    {
                        handPoints = handPoints * 2;
                        UpdateCrackCount(hand.Crack);                        
                    }

                    if (hand.CrackBack != null)
                    {
                        handPoints = handPoints * 2;
                        UpdateCrackCount(hand.Crack);                        
                    }

                    if (hand.ReCrack != null)
                    {
                        handPoints = handPoints * 2;
                        UpdateCrackCount(hand.Crack);                        
                    }

                    if (hand.Result.Equals("winNoSchneider"))
                    {
                        handPoints = handPoints * 2;
                        Console.WriteLine($"Result win No Schneider, hand worth {handPoints} points");
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (hand.Result.Equals("winNoTricker"))
                    {
                        handPoints = handPoints * 3;
                        Console.WriteLine($"Result win No Tricker, hand worth {handPoints} points");
                        System.Threading.Thread.Sleep(2000);

                    }

                    if (hand.Result.Equals("lostWithSchneider"))
                    {
                        handPoints = handPoints * -2;
                        Console.WriteLine($"Result lost with Schneider, hand worth {handPoints} points");
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (hand.Result.Equals("lostNoSchneider"))
                    {
                        handPoints = handPoints * -4;
                        Console.WriteLine($"Result Lost No Schneider, hand worth {handPoints} points");
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (hand.Result.Equals("lostNoTricker"))
                    {
                        handPoints = handPoints * -6;
                        Console.WriteLine($"Result Lost No Tricker, hand worth {handPoints} points");
                        System.Threading.Thread.Sleep(2000);
                    }

                    hand.GameInt = CurrentGameInt;
                    hand.Dealer = "Test";
                    hand.GameHandNumber = GameHandNumber;
                    hand.HandScore = handPoints;



                    /*-----ASSIGNS AND SCORES OPPONENTS-----*/
                    opponents = FindAndScoreOpponents(hand);

                    if (opponents.Length.Equals(3))
                    {
                        hand.Opponent1 = opponents[0].Name;
                        hand.Opponent2 = opponents[1].Name;
                        hand.Opponent3 = opponents[2].Name;
                    }
                    else if (opponents.Length.Equals(4))
                    {
                        hand.Opponent1 = opponents[0].Name;
                        hand.Opponent2 = opponents[1].Name;
                        hand.Opponent3 = opponents[2].Name;
                        hand.Opponent4 = opponents[3].Name;
                    }

                    UpdateWinners(hand);

                _repository.AddHand(hand);                   

                    NextGameHand();

                    return RedirectToAction("Index");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return RedirectToAction("Index");
            }
        
        }

        public void UpdateWinners(Hand hand)
        {
            Boolean alone = false;

            if (hand.Partner == null )
            {
                alone = true;
            }


            foreach (Player player in _repository.GetAllPlayers())
            {
                if (alone)
                {

                    foreach (GameHistory gh in currentPlayers)
                    {
                        if (player.NickName.Equals(gh.PlayerNickName) && player.NickName.Equals(hand.Picker))
                        {
                            gh.Score = gh.Score + (hand.HandScore * 4);
                        }
                        else
                        {
                            throw new ApplicationException("error updating winners");
                        }
                    }

                }
                else
                {
                    foreach (GameHistory gh in currentPlayers)
                    {
                        if (player.NickName.Equals(hand.Picker) && player.NickName.Equals(gh.PlayerNickName))
                        {
                            gh.Score = gh.Score + (hand.HandScore * 2);
                        }
                        else if (player.NickName.Equals(hand.Partner) && player.NickName.Equals(gh.PlayerNickName))
                        {
                            gh.Score = gh.Score + hand.HandScore;
                        }
                    }
                }
            }
        }

        public IActionResult EditHand(Hand hand)
        {
            return View("EditHand");
        }

        private void UpdateCrackCount(string pNickName)
        {
            foreach (GameHistory gh in currentPlayers)
            {
                if (gh.PlayerNickName.Equals(pNickName))
                {
                    gh.CrackCount = gh.CrackCount + 1;
                }
            }
        }

        

        public void AssignCurrentGHs(int position, GameHistory gh)
        {
            
        }

        public Player[] FindAndScoreOpponents(Hand hand)
        {
            List<Player> opponents = new List<Player>();

            foreach (Player player in _repository.GetAllPlayers())
            {

                foreach (GameHistory gameH in currentPlayers)
                {
                    if (gameH.PlayerNickName.Equals(player.Name))
                    {
                        if (!player.NickName.Equals(hand.Picker) && !(player.NickName == hand.Partner))
                        {
                            opponents.Add(player);
                            gameH.Score = gameH.Score - hand.HandScore;
                        }
                    }
                }

            }
            return opponents.ToArray();
        }


    }
}

