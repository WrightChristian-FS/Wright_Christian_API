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
    public class App
    {
        public static Dictionary<string, string> artistMenuList = new Dictionary<string, string>();
        public static Dictionary<string, string> albumMenuList = new Dictionary<string, string>();
        public static Dictionary<string, string> trackMenuList = new Dictionary<string, string>();

        public App()
        {
            Console.Clear();

            //INSTANTIATE THE API CONNECTOR
            Connector apiConnect = new Connector();

            //VARIABLES
            bool continueApplication = true;
            string artistChoice;
            string albumChoice; 

            while (continueApplication)
            {
                PrintArtist(apiConnect);

                //Ask the user which artist they want to view
                UI.ConfirmUI(); 
                Console.Write("\r\nEnter the artist ID to view the artist albums: ");
                UI.StandardUI();

                //Capture the answer and validate the answer
                UI.InputUI();
                artistChoice = Validation.StringValidation(Console.ReadLine());
                UI.StandardUI();


                //Pass the artist infomation
                bool isArtist = Artist.VerifyArtistSelection(artistChoice, artistMenuList);

                if (artistChoice.ToLower() == "exit")
                {
                    continueApplication = false;

                    Console.WriteLine("\r\nGoodbye..");
                    Continue();
                    break; 

                }
                else if (isArtist == false)
                {
                    //Tell the user the artist they selected is not a valid artist 
                    UI.ErrorUI(); 
                    Console.WriteLine("\r\nSorry, that is not a valid try again");
                    UI.StandardUI(); 
                    Continue();

                }
                else if (isArtist == true)
                {

                    
                    //Print the artist album list
                    PrintAlbums(apiConnect, artistChoice);

                    //Ask the user which artist they want to see
                    Console.Write("\r\nEnter the album ID to view the albums tracks: ");

                    //Capture the answer and validate the answer
                    UI.InputUI();
                    albumChoice = Validation.StringValidation(Console.ReadLine());
                    UI.StandardUI();

                    //Verify the user album selection is a valid album 
                    bool isAlbum = Albums.VerifyAlbumSelection(albumChoice, albumMenuList);

                    if(albumChoice.ToLower() == "exit")
                    {
                        continueApplication = false;

                        Console.WriteLine("\r\nGoodbye..");
                        Continue();
                        break;
                    }

                    else if (isAlbum == false)
                    {
                        //Tell the user the artist they selected is not a valid artist 
                        UI.ErrorUI();
                        Console.WriteLine("\r\nSorry, that is not a valid album ID try again");
                        UI.StandardUI();
                        Continue();
                    }

                    else if (isAlbum == true)
                    {
                        //Print the album tracks 
                        PrintTracks(apiConnect, artistChoice, albumChoice); 
                    }

                    Continue(); 
                }

            }


        }


        public static void PrintArtist(Connector apiConector)
        {
            Connector apiConnect = new Connector();
            
            List <Artist> artistListObject = apiConector.GetArtist();
            Dictionary<string, string> artistList = new Dictionary<string, string>();


            //Add artist information to the dictionary 
            foreach (Artist artist in artistListObject)
            {
                //Capture the parameters for the dictionary
                string artistID = artist.ArtistID;
                string artistName = artist.ArtistName;

                //Add to the dictionary
                artistList.Add(artistID, artistName);


                Console.WriteLine($"{artistID} {artistName}");
            }

            //SET THE ARTIST MENU 
            artistMenuList = artistList; 

            //PRINT THE MENU 
            Menu.Init("Artist", artistMenuList);
            Menu.Display();
        }

        public static void PrintAlbums(Connector apiConnector, string artistID)
        {

            Connector apiConnection = new Connector();

            List<Albums> albumListObject = apiConnection.GetAlbums(artistID); 
            Dictionary<string, string> albumList = new Dictionary<string, string>();

            foreach (Albums album in albumListObject)
            { 
                //Capture parameters for the dictionary
                string albumID = album.AlbumID;
                string titleOfAlbum = album.AlbumTitle;

                albumList.Add(albumID, titleOfAlbum); 
            }

            //PRINT THE MENU 
            Menu.Init("Albums", albumList);
            Menu.Display();

            albumMenuList = albumList;

        }

        public static void PrintTracks(Connector apiConnector, string artistID, string albumID)
        {
            Connector apiConnection = new Connector();

            //Capture list of 
            List<Tracks> trackListObject = apiConnection.GetTracks(artistID, albumID);
            Dictionary<string, string> trackList = new Dictionary<string, string>(); 

            //Print list of tracks 
            foreach(Tracks track in trackListObject)
            {
                string trackID = track.TrackID;
                string trackName = track.Track;

                trackList.Add(trackID, trackName); 
                
            }


            //Initate the menu
            Menu.Init("Tracks", trackList);
            Menu.Display(); 
            


        }



        public static void Continue()
        {
            Console.WriteLine("\r\nPress any key to continue...");
            Console.ReadLine();
            Console.Clear(); 
        }
    }

}
