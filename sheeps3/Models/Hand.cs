using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sheeps3.Models
{
    public class Hand
{
    public int Id { get; set; }

    public int GameInt { get; set; }

    public int GameHandNumber { get; set; }

    public String HandType { get; set; }

    public String Dealer { get; set; }
    
    public String Picker { get; set; }

    public String Partner { get; set; }

    public String Opponent1 { get; set; }

    public String Opponent2 { get; set; }

    public String Opponent3 { get; set; }

    public String Opponent4 { get; set; }

    public int HandScore { get; set; }

    public String BQBlitz { get; set; }

    public String RQBlitz { get; set; }

    public String BJBlitz { get; set; }

    public String RJBlitz { get; set; }

    public String Crack { get; set; }

    public String CrackBack { get; set; }

    public String ReCrack { get; set; }

    public bool Doubler { get; set; }

    public int Deals { get; set; }

    public string Result { get; set; }

    public double PointMonetary { get; set; }

    public DateTime Completed { get; set; }

    }
}