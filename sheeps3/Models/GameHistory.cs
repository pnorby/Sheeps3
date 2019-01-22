using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sheeps3.Models
{
    public class GameHistory
    {
        public int Id { get; set; }

        public int GameInt { get; set; }

        public string PlayerNickName { get; set; }

        public int CrackCount { get; set; }

        public int Score { get; set; }

        public Boolean PlayerInHand { get; set; }

        public Boolean PlayerActive { get; set; }

        public int PlayerPosition { get; set; }

        public double CurrentPoints { get; set; }
    }
}
