using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fooApp_v3.Classes
{
    public class Mega_Handler_Tron
    {
        public Mega_Handler_Tron()
        {

        }

        /// <summary>
        /// This is the big ass event handler that all button clicks
        /// should respond to if the button's action results in changing the 
        /// current form displayed on the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BigAss_EventHandler (object sender, EventArgs e)
        {
            // Validate the object type of the caller for this event handler
            if (sender != null && sender.GetType() == typeof(Button))
            {
                // Cast the sender to a Button Control
                Button button_Clicked = (Button)sender;

                // Detect what button was clicked based on name so we know what action to take
                switch (button_Clicked.Name)
                {
                    // I'll let James do more of this stuff himself before he throws another temper tantrum
                    case "1":
                        break;

                    case "2":
                        break;

                    case "3":
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
