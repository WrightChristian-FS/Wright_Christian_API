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
            //List to hold the artist 
            List<Artist> artistList = new List<Artist>();


            dynamic jo = Connect("https://api.happi.dev/v1/music/artists?page=1&apikey=c076cfkJAzGoKyKqJFtiI9sPoRCaEtf4a0n8vfxu3IyXTj1dZeq3CSKx");

            

            return artistList; 
        }
    }
}
