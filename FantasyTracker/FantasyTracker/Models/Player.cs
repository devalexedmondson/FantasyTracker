using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FantasyTracker.Models
{
    public class Player
    {
        [Key]
        public int ID { get; set; }
        public string PlayerName { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        public double PointsAvg { get; set; }
        public double AssistsAvg { get; set; }
        public double BlocksAvg { get; set; }
        public double StealsAvg { get; set; }

    }
}