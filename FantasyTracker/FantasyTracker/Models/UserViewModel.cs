using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace FantasyTracker.Models
{
    public class UserViewModel
    {
        public bool HasTeam { get; set; }
    }
    public class AddTeam
    {
        [Required]
        [Display(Name = "Team")]
        public string Team { get; set; }
    }

    public class AddPlayers
    {

    }

    
}