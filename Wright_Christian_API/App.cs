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


            while (continueApplication)
            {
                PrintArtist(apiConnect);

                //Ask the user which artist they want to view
                Console.Write("\r\nEnter the artist ID to view the artist albums: ");

                //Capture the answer and validate the answer
                UI.InputUI();
                string userArtistChoice = Validation.StringValidation(Console.ReadLine());
                UI.StandardUI();


                //Pass the artist infomation
                bool isArtist = Artist.VerifyArtistSelection(userArtistChoice, artistMenuList);

                if (userArtistChoice.ToLower() == "exit")
                {
                    continueApplication = false;

                    Console.WriteLine("\r\nGoodbye..");
                    Continue();

                }
                else if (isArtist == false)
                {
                    Console.WriteLine("\r\nSorry, that is not a valid try again");
                    Continue();

                }
                else if (isArtist == true)
                {

                    PrintAlbums(apiConnect, userArtistChoice);

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

        public static void PrintTracks()
        {

        }



        public static void Continue()
        {
            Console.WriteLine("\r\nPress any key to continue...");
            Console.ReadLine();
            Console.Clear(); 
        }
    }

}
