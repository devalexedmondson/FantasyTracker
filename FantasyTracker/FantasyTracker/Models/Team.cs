using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FantasyTracker.Models
{
    public class Team
    {
        [Key]
        public int ID { get; set; }
        public string TeamName { get; set; }

        public int PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public Player PlayerInfo { get; set; }
    }
}