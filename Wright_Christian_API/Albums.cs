using System;
namespace Wright_Christian_API
{
    public class Albums
    {
        //Properties
        public string ArtistID { get;  }
        public string AlbumID { get; }
        public string AlbumTitle { get;  }
        
        public Albums(string artistID, string albumID, string albumTitle)
        {
            ArtistID = artistID; 
            AlbumID = albumID;
            AlbumTitle = albumTitle; 
        }
    }
}
