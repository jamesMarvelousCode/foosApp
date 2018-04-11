using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fooApp_v3.Classes
{
    public class Match
    {
        /*
         *  Fields from tbl_Matches
         */
        public int ID { get; set; }

        public DateTime Date_Played { get; set; }   // TODO: This may need to become an INT as we are working with it in UNIX format in the database

        public int Duration_In_Seconds { get; set; }
    }
}
