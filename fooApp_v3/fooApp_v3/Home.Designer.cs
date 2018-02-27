namespace fooApp_v3
{
    partial class Home
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
            this.GoToPlayAMatch = new System.Windows.Forms.Button();
            this.GoToManageContestants = new System.Windows.Forms.Button();
            this.GoToViewStats = new System.Windows.Forms.Button();
            this.homeStatusStrip = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // GoToPlayAMatch
            // 
            this.GoToPlayAMatch.BackColor = System.Drawing.Color.Gray;
            this.GoToPlayAMatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoToPlayAMatch.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoToPlayAMatch.Location = new System.Drawing.Point(103, 40);
            this.GoToPlayAMatch.Name = "GoToPlayAMatch";
            this.GoToPlayAMatch.Size = new System.Drawing.Size(283, 47);
            this.GoToPlayAMatch.TabIndex = 0;
            this.GoToPlayAMatch.Text = "Play a Match";
            this.GoToPlayAMatch.UseVisualStyleBackColor = false;
            this.GoToPlayAMatch.Click += new System.EventHandler(this.GoToPlayAMatch_Click);
            // 
            // GoToManageContestants
            // 
            this.GoToManageContestants.BackColor = System.Drawing.Color.Gray;
            this.GoToManageContestants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoToManageContestants.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold);
            this.GoToManageContestants.Location = new System.Drawing.Point(103, 120);
            this.GoToManageContestants.Name = "GoToManageContestants";
            this.GoToManageContestants.Size = new System.Drawing.Size(283, 47);
            this.GoToManageContestants.TabIndex = 1;
            this.GoToManageContestants.Text = "Manage Contestants";
            this.GoToManageContestants.UseVisualStyleBackColor = false;
            this.GoToManageContestants.Click += new System.EventHandler(this.GotoManageContestants_Click);
            // 
            // GoToViewStats
            // 
            this.GoToViewStats.BackColor = System.Drawing.Color.Gray;
            this.GoToViewStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoToViewStats.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold);
            this.GoToViewStats.Location = new System.Drawing.Point(103, 200);
            this.GoToViewStats.Name = "GoToViewStats";
            this.GoToViewStats.Size = new System.Drawing.Size(283, 47);
            this.GoToViewStats.TabIndex = 2;
            this.GoToViewStats.Text = "View stats";
            this.GoToViewStats.UseVisualStyleBackColor = false;
            this.GoToViewStats.Click += new System.EventHandler(this.GoToViewStats_Click);
            // 
            // homeStatusStrip
            // 
            this.homeStatusStrip.Location = new System.Drawing.Point(0, 348);
            this.homeStatusStrip.Name = "homeStatusStrip";
            this.homeStatusStrip.Size = new System.Drawing.Size(506, 22);
            this.homeStatusStrip.TabIndex = 3;
            this.homeStatusStrip.Text = "ALL YOUR FOOS ARE BELONG TO US";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(506, 370);
            this.Controls.Add(this.homeStatusStrip);
            this.Controls.Add(this.GoToViewStats);
            this.Controls.Add(this.GoToManageContestants);
            this.Controls.Add(this.GoToPlayAMatch);
            this.Name = "Home";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GoToPlayAMatch;
        private System.Windows.Forms.Button GoToManageContestants;
        private System.Windows.Forms.Button GoToViewStats;
        private System.Windows.Forms.StatusStrip homeStatusStrip;
    }
}

