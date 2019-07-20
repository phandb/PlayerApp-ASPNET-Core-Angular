using System;

namespace PlayerApp.API.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }

        // Store id key from cloudinary
        public string PublicId { get; set; }

        //Define Many-To-One relationship b/t Photo and User
        public User User { get; set; }

        public int UserId { get; set; }
    }
}