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
    public class Artist
    {
        //Properties
        public string ArtistID { get; }
        public string ArtistName { get; }

        public Artist(string artID, string artistName)
        {
            ArtistID = artID;
            ArtistName = artistName; 
        }

        public static bool VerifyArtistSelection(string userInput, Dictionary<string, string> artistInfomation)
        {
            bool artistConfirmation = false;


            foreach(KeyValuePair<string, string> item in artistInfomation)
            {
                if(userInput == item.Key)
                {
                    artistConfirmation = true;
                    break;
                }
            }

            return artistConfirmation; 
        }
    }
}
