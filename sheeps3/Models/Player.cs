using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sheeps3.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        public String NickName { get; set; }

    }
}
