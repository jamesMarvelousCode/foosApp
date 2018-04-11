using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fooApp_v3.Classes
{
    public class UserLogin
    {
        // Internal backing variables used for get-set routines (these hold the actual values for the properties they back)
        private int _UserRole_ID = 0;

        /*
         *  Fields from tbl_Login_Credentials
         */
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int EmployeeRoster_ID { get; set; }

        public int UserRole_ID
        {
            get
            {
                return _UserRole_ID;
            }
            set
            {
                // Check that the value we are attempting to assign is valid
                if (Enum.IsDefined(typeof(Constants.UserRolePermissions), value))
                {
                    _UserRole_ID = value;
                }

                // If the value being passed in is not in the UserRolePermissions Enum, _UserRole_ID will be 0
                // This can probably be useful for troubleshooting / watching for errors
            }
        }


        /*
         *  Field from tbl_RSI_Employee_Roster
         *  Used to help populate the new record in tbl_Login_Credentials
         */
        public int Extension { get; set; }
    }
}
