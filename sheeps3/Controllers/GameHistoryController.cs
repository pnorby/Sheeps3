using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sheeps3.Models;

namespace sheeps3.Controllers
{
    public class GameHistoryController : Controller
    {
        private ISheepsRepository _repository;
        public static GameHistory P1GH { get; private set; }
        public static GameHistory P2GH { get; private set; }
        public static GameHistory P3GH { get; private set; }
        public static GameHistory P4GH { get; private set; }
        public static GameHistory P5GH { get; private set; }
        public static GameHistory P6GH { get; private set; }
        public static GameHistory P7GH { get; private set; }
        private static List<GameHistory> currentGameHistories;


        public GameHistoryController(ISheepsRepository repository)
        {
            _repository = repository;
            currentGameHistories = new List<GameHistory>();
        }

        

        public void UpdateCrackCount(string playerName)
        {
            foreach (GameHistory gH in currentGameHistories)
            {
                if (gH.PlayerNickName.Equals(playerName))
                {
                    gH.CrackCount = gH.CrackCount + 1;
                }
            }
        }

        


        



    }
}
