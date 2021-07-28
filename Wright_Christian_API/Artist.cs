using System;
namespace Wright_Christian_API
{
    public class Artist
    {
        //Properties
        public string ArtistID { get; set; }
        public string ArtistName { get; set; }

        public Artist(string artID, string artistName)
        {
            ArtistID = artID;
            ArtistName = artistName; 
        }
    }
}
