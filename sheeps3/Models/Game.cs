using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sheeps3.Models
{
    public class Game
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public String Player1 { get; set; }

        public String Player2 { get; set; }

        public String Player3 { get; set; }

        public String Player4 { get; set; }

        public String Player5 { get; set; }

        public String Player6 { get; set; }

        public String Player7 { get; set; }

        public int CurrentDoublers { get; set; }

        public int CurrentMonetary { get; set; }

    }
}
