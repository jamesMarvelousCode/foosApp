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
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            //comment

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //on load show the login screen
            MainTab.SelectTab(LoginTab);
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            //logs the user out and shows the login screen
            MainTab.SelectTab(LoginTab);
        }

        private void ViewStatsButton_Click(object sender, EventArgs e)
        {
            //open the view stats form
            ViewStats viewStats = new ViewStats();
            viewStats.ShowDialog();
            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //add credential check
            //if ok cred login
            //opens the home tab after cred verification
            MainTab.SelectTab(HomeTab);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //closes the main form
            this.Close();
        }

        private void PlayAMatchButton_Click(object sender, EventArgs e)
        {
            //opens the play a match tab which allows users to enter the contestants and start the match
            MainTab.SelectTab(StartMatchTab);
        }

        private void ManageContestantsButton_Click(object sender, EventArgs e)
        {
            //opens the first manage contestant tab where users select what to manage
            MainTab.SelectTab(ManageWhichTab);
        }

        private void StartMatchButton_Click(object sender, EventArgs e)
        {
            //hold onto who is playing
            //start the countdown to match start and the timer
            MainTab.SelectTab(MatchInProgressTab);
        }

        private void EndMatchButton_Click(object sender, EventArgs e)
        {
            //Ends the current match and shows resolution tab
            //record match time
            MainTab.SelectTab(MatchResolutionTab);
        }

        private void CancelMatchButton_Click(object sender, EventArgs e)
        {
            //Cancels the match in progress
            //does not record time or contestants
            //returns user to home tab or to Start Match tab?
            //start matc for now
            MainTab.SelectTab(StartMatchTab);
        }

        private void SubmitMatchButton_Click(object sender, EventArgs e)
        {
            //saves all match information to the database and returns user to the home screen
            MainTab.SelectTab(HomeTab);
        }

        private void BackToHome_Click(object sender, EventArgs e)
        {
            //handler for all buttons that return to home
            MainTab.SelectTab(HomeTab);
        }

        private void CancelToManageWhat_Click(object sender, EventArgs e)
        {
            //handler for all cancel buttons that return to manage which tab
            MainTab.SelectTab(ManageWhichTab);
        }

        private void NewUserBackButton_Click(object sender, EventArgs e)
        {
            //cancels new user input and returns to login tab
            MainTab.SelectTab(LoginTab);
        }

        private void CreateNewUserButton_Click(object sender, EventArgs e)
        {
            //validation checks and creates new user
        }

        private void GOTOCreatNewUserButton_Click(object sender, EventArgs e)
        {
            //opens the create new user tab
            MainTab.SelectTab(NewUserTab);
        }

        private void GOTOAddPlayerButton_Click(object sender, EventArgs e)
        {
            //opens the add player tab
            MainTab.SelectTab(AddPlayerTab);
        }

        private void GOTOAddTeambutton_Click(object sender, EventArgs e)
        {
            //opens the add team tab
            MainTab.SelectTab(AddTeamTab);
        }

        private void GOTOEditPlayerButton_Click(object sender, EventArgs e)
        {
            //opens the edit player tab
            MainTab.SelectTab(EditPlayerTab);
        }

        private void GOTOEditTeamButton_Click(object sender, EventArgs e)
        {
            //opens the edit team tab
            MainTab.SelectTab(EditTeamTab);
            //test change

        }
    }
}
