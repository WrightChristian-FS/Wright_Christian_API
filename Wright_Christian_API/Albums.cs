using System;
namespace Wright_Christian_API
{
    public class Albums
    {
        //Properties 
        public string ArtistID { get; }
        public string AlbumTitle { get;  }
        
        public Albums(string artistID, string albumTitle)
        {
            ArtistID = artistID;
            AlbumTitle = albumTitle; 
        }
    }
}
