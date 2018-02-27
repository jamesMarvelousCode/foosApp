namespace fooApp_v3
{
    partial class ManageContestants
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playerEntryTextBox = new System.Windows.Forms.TextBox();
            this.enterPlayerButton = new System.Windows.Forms.Button();
            this.teamEntryButton = new System.Windows.Forms.Button();
            this.teamEntryTextBox = new System.Windows.Forms.TextBox();
            this.playerOneComboBox = new System.Windows.Forms.ComboBox();
            this.playerTwoComboBox = new System.Windows.Forms.ComboBox();
            this.manageContestantsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playerEntryTextBox
            // 
            this.playerEntryTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.playerEntryTextBox.Location = new System.Drawing.Point(12, 12);
            this.playerEntryTextBox.Name = "playerEntryTextBox";
            this.playerEntryTextBox.Size = new System.Drawing.Size(123, 20);
            this.playerEntryTextBox.TabIndex = 0;
            this.playerEntryTextBox.Text = "Enter new player name";
            // 
            // enterPlayerButton
            // 
            this.enterPlayerButton.Location = new System.Drawing.Point(169, 12);
            this.enterPlayerButton.Name = "enterPlayerButton";
            this.enterPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.enterPlayerButton.TabIndex = 1;
            this.enterPlayerButton.Text = "Enter Player";
            this.enterPlayerButton.UseVisualStyleBackColor = true;
            // 
            // teamEntryButton
            // 
            this.teamEntryButton.Location = new System.Drawing.Point(169, 114);
            this.teamEntryButton.Name = "teamEntryButton";
            this.teamEntryButton.Size = new System.Drawing.Size(75, 23);
            this.teamEntryButton.TabIndex = 2;
            this.teamEntryButton.Text = "Enter Team";
            this.teamEntryButton.UseVisualStyleBackColor = true;
            // 
            // teamEntryTextBox
            // 
            this.teamEntryTextBox.Location = new System.Drawing.Point(12, 60);
            this.teamEntryTextBox.Name = "teamEntryTextBox";
            this.teamEntryTextBox.Size = new System.Drawing.Size(123, 20);
            this.teamEntryTextBox.TabIndex = 3;
            this.teamEntryTextBox.Text = "Enter new team name";
            // 
            // playerOneComboBox
            // 
            this.playerOneComboBox.FormattingEnabled = true;
            this.playerOneComboBox.Location = new System.Drawing.Point(169, 60);
            this.playerOneComboBox.Name = "playerOneComboBox";
            this.playerOneComboBox.Size = new System.Drawing.Size(121, 21);
            this.playerOneComboBox.TabIndex = 4;
            this.playerOneComboBox.Text = "Select Player One";
            // 
            // playerTwoComboBox
            // 
            this.playerTwoComboBox.FormattingEnabled = true;
            this.playerTwoComboBox.Location = new System.Drawing.Point(169, 87);
            this.playerTwoComboBox.Name = "playerTwoComboBox";
            this.playerTwoComboBox.Size = new System.Drawing.Size(121, 21);
            this.playerTwoComboBox.TabIndex = 5;
            this.playerTwoComboBox.Text = "Select Player Two";
            // 
            // manageContestantsStatusStrip
            // 
            this.manageContestantsStatusStrip.Location = new System.Drawing.Point(0, 280);
            this.manageContestantsStatusStrip.Name = "manageContestantsStatusStrip";
            this.manageContestantsStatusStrip.Size = new System.Drawing.Size(460, 22);
            this.manageContestantsStatusStrip.TabIndex = 6;
            this.manageContestantsStatusStrip.Text = "FOOS!";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 180);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "add new user";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Add user";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ManageContestants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 302);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.manageContestantsStatusStrip);
            this.Controls.Add(this.playerTwoComboBox);
            this.Controls.Add(this.playerOneComboBox);
            this.Controls.Add(this.teamEntryTextBox);
            this.Controls.Add(this.teamEntryButton);
            this.Controls.Add(this.enterPlayerButton);
            this.Controls.Add(this.playerEntryTextBox);
            this.Name = "ManageContestants";
            this.Text = "ManageContestants";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox playerEntryTextBox;
        private System.Windows.Forms.Button enterPlayerButton;
        private System.Windows.Forms.Button teamEntryButton;
        private System.Windows.Forms.TextBox teamEntryTextBox;
        private System.Windows.Forms.ComboBox playerOneComboBox;
        private System.Windows.Forms.ComboBox playerTwoComboBox;
        private System.Windows.Forms.StatusStrip manageContestantsStatusStrip;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}