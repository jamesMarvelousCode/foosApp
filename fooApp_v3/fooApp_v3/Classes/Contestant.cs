using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fooApp_v3.Classes
{
    public class Contestant
    {
        /*
         *  Fields from tbl_Contestants
         */
        public int ID { get; set; }

        public string Name { get; set; }

        public int Type_ID { get; set; }

        public int Status_ID { get; set; }

        public int Login_ID { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Self_Goals { get; set; }
    }
}
