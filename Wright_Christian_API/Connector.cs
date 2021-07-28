using System;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Collections.Generic; 

namespace Wright_Christian_API
{
    public class Connector
    {
        public Connector()
        {
        }

        public dynamic Connect(string url)
        {
            dynamic jo;

            using (WebClient wc = new WebClient())
            {
                string results = wc.DownloadString(url);
                jo = JObject.Parse(results);

            }

            return jo; 
            
        }


        public List<Artist> GetArtist()
        {
            List<Artist> artistList = new List<Artist>();
            string url = "https://api.happi.dev/v1/music/artists?page=1&apikey=c076cfkJAzGoKyKqJFtiI9sPoRCaEtf4a0n8vfxu3IyXTj1dZeq3CSKx";

            dynamic jo = Connect(url);

            foreach (dynamic artist in jo.result)
            {                
                //Create a variable to hold the values of the strings 
                string atistID = artist.id_artist;
                string artistName = artist.artist; 

                //INSTANTIATE AN ARTIST OBJECT TO HOLD THE VALUE OF THE CURRENT ARTIST
                Artist newArtist = new Artist(atistID, artistName);

                //ADD THE ARTIST TO THE ARTIST LIST
                artistList.Add(newArtist);                
            }

            //RETURN ARTIST LIST
            return artistList; 
        }


        public List<Albums> GetAlbums(string artistID)
        {
            List<Albums> albumList = new List<Albums>();
            string url = "https://api.happi.dev/v1/music/artists/301/albums?apikey=c076cfkJAzGoKyKqJFtiI9sPoRCaEtf4a0n8vfxu3IyXTj1dZeq3CSKx";

            dynamic jo = Connect(url);

            foreach(dynamic album in jo.result.albums)
            {
                //CREATE A VARIABLE 
                string albumID = album.id_album; 
                string albumTitle = album.album;

                //INSTANTIATE NEW 
                Albums newAlbum = new Albums(albumID, albumTitle);

                //ADD ALBUM TO ALBUM LIST
                albumList.Add(newAlbum); 
            }

            //RETURN ALBUM LIST
            return albumList; 
        }

        public List<Tracks> GetTracks(string artistID, string albumID)
        {
            List<Tracks> trackList = new List<Tracks>();
            string url = "https://api.happi.dev/v1/music/artists/301/albums/4161244/tracks?apikey=c076cfkJAzGoKyKqJFtiI9sPoRCaEtf4a0n8vfxu3IyXTj1dZeq3CSKx";

            //CONNECT TO THE API
            dynamic jo = Connect(url); 

            foreach(dynamic track in jo.result.tracks)
            {
                Console.WriteLine(track.track);
            }


            return trackList; 
        }



    }
}
