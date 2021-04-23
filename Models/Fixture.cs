using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAD_CA3.Models
{
    public class Fixture
    {
        [Key]
        public int MatchID { get; set; }

        [DisplayName("Match Date and Time")]
        public DateTime datetime { get; set; }
        public string Venue { get; set; }

        [DisplayName("Opposition")]
        public string OpponentTeam { get; set; }

        [DisplayName("Goals For")]
        public int GoalsFor { get; set; } = 0;

        [DisplayName("Goals Against")]
        public int GoalsAgainst { get; set; } = 0;

        [DisplayName("Goal Difference")]
        public int GoalDiff { get; set; }


    }
}

