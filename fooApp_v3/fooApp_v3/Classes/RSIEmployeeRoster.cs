using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fooApp_v3.Classes
{
    public class RSIEmployeeRoster
    {
        /*
         *  Fields from tbl_RSI_Employee_Roster
         */
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Extension { get; set; }
    }
}
