using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace FantasyTracker.Models
{
    public class UserViewModel
    {
        public bool HasTeam { get; set; }
        public bool HasPlayer { get; set; }
    }
    public class CreateTeamViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [Display(Name = "TeamName")]
        public string Team { get; set; }

        [Required]
        [Display(Name = "Sport")]
        public string Sport { get; set; }
    }

    
    
}