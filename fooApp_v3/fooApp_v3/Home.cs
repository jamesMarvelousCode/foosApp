using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fooApp_v3
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void GotoManageContestants_Click(object sender, EventArgs e)
        {
            //open the manage contestant form
            //ManageContestants manageContestants = new ManageContestants();
            //manageContestants.ShowDialog();
            DialogForm dialog = new DialogForm();
            dialog.ShowDialog();
            //show a dialog  team or individual?
            //MessageBox.Show("Player or Team?", "");
        }

        private void GoToPlayAMatch_Click(object sender, EventArgs e)
        {
            //open the play a match form
            PlayMatch playMatch = new PlayMatch();
            playMatch.ShowDialog();
        }

        private void GoToViewStats_Click(object sender, EventArgs e)
        {
            //open the view stats form
            ViewStats viewStats = new ViewStats();
            viewStats.ShowDialog();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
