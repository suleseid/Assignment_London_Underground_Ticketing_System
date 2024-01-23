using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_London_Underground_Ticketing_System
{
    public class Rider
    {
        public int UniqueNumber { get; set; }
        public Station StationOn { get; set; }
        public Station StationOff { get; set; }
        public int StartStation { get; set; }

        public Rider(int uniqueNumber, Station on, Station off)
        {
            UniqueNumber = uniqueNumber;
            StationOn = on;
            StationOff = off;
        }

        public bool IsActive
        {
            get => (StationOff == 0) ? true : false;
        }
        
    } // class

} // namespace
