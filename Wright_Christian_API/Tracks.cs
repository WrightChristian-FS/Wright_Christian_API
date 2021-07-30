/*
 * Christian Wright 
 * 30JUL2021
 * APA 
 * 
 * API Application
 * 
 */

using System;
namespace Wright_Christian_API
{
    public class Tracks
    {
        //Properties
        public string TrackID { get; }
        public string Track { get; }

        public Tracks(string trackID, string track)
        {
            Track = track;
            TrackID = trackID; 
        }
    }
}
