using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAD_CA3.Models
{
    public class Fixture
    {
        [Key]
        public int MatchID { get; set; }
        public DateTime datetime { get; set; }
        public string Venue { get; set; }
        public string OpponentTeam { get; set; }

        public int GoalsFor { get; set; } = 0;

        public int GoalsAgainst { get; set; } = 0;
    }
}

