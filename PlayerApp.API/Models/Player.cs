using System;

namespace PlayerApp.API.Models
{
    public class Player
    {
        
        public int Id {get; set;}

        public string Name {get; set;}

        public string Club { get; set;}

        public string Position { get; set;}
        
        public DateTime JoinedClubOn { get; set;}
    }
}