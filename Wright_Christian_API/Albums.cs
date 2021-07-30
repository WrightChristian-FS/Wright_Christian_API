/*
 * Christian Wright 
 * 30JUL2021
 * APA 
 * 
 * API Application
 * 
 */

using System;
using System.Collections.Generic; 

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

        public static bool VerifyAlbumSelection(string userInput, Dictionary<string, string> albumInformation)
        {
            bool albumConfirmation = false;


            foreach (KeyValuePair<string, string> item in albumInformation)
            {
                if (userInput == item.Key)
                {
                    albumConfirmation = true;
                    break;
                }
            }

            return albumConfirmation;
        }



    }
}
