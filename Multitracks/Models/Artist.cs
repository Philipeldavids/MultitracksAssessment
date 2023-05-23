using System;

namespace Multitracks.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string Title { get; set; }
        public DateTime DateCreation { get; set; }

        public string Biography { get; set; }
        public string ImageUrl { get; set; }
        public string HeroUrl { get; set; }
    }
}
