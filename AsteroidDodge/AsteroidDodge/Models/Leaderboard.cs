using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsteroidDodge.Models
{
    public class Leaderboard
    {
        public int LeaderboardId { get; set; }
        public int Score { get; set; }

        public string AsteroidUserId { get; set; }

        [ForeignKey("AsteroidUserId")]
        public AsteroidUser AsteroidUser { get; set; }
    }
}
