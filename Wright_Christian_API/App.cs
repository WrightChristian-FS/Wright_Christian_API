using System;
using System.Collections.Generic;

namespace Wright_Christian_API
{
    public class App
    {
        public App()
        {

            Console.Clear();

            //Connect to the API 
            Connector apiConnect = new Connector();

            apiConnect.GetArtist();

       

            apiConnect.GetTracks("301", "4161244"); 


        }
    }

}
