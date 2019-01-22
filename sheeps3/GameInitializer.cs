using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sheeps3.Models;
using Microsoft.AspNetCore.Mvc;

namespace sheeps3
{
    public class GameInitializer : Controller
    {
        private ISheepsRepository _repository;

        public GameInitializer(ISheepsRepository repository)
        {
            _repository = repository;
        }

        public IActionResult InitializeNewGame()
        {
            Hand newGameHandZero = new Hand();
            int totalHands = _repository.GetAllHands().Count();

            newGameHandZero.GameInt.Equals(totalHands + 1);
            newGameHandZero.GameHandNumber.Equals(0);

            _repository.AddHand(newGameHandZero);

            return View("Index");


        }

    }
}
