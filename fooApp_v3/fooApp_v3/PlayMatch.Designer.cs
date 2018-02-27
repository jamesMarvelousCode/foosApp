namespace fooApp_v3
{
    partial class PlayMatch
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
            this.components = new System.ComponentModel.Container();
            this.playMatchStatusStrip = new System.Windows.Forms.StatusStrip();
            this.contestantOneComboBox = new System.Windows.Forms.ComboBox();
            this.contestantTwoComboBox = new System.Windows.Forms.ComboBox();
            this.contestantOneScoreTextBox = new System.Windows.Forms.TextBox();
            this.contestantTwoScoreTextBox = new System.Windows.Forms.TextBox();
            this.submitMatchButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // playMatchStatusStrip
            // 
            this.playMatchStatusStrip.Location = new System.Drawing.Point(0, 332);
            this.playMatchStatusStrip.Name = "playMatchStatusStrip";
            this.playMatchStatusStrip.Size = new System.Drawing.Size(550, 22);
            this.playMatchStatusStrip.TabIndex = 0;
            this.playMatchStatusStrip.Text = "FOOS!";
            // 
            // contestantOneComboBox
            // 
            this.contestantOneComboBox.FormattingEnabled = true;
            this.contestantOneComboBox.Location = new System.Drawing.Point(6, 19);
            this.contestantOneComboBox.Name = "contestantOneComboBox";
            this.contestantOneComboBox.Size = new System.Drawing.Size(121, 21);
            this.contestantOneComboBox.TabIndex = 1;
            this.contestantOneComboBox.Text = "Select team/player";
            // 
            // contestantTwoComboBox
            // 
            this.contestantTwoComboBox.FormattingEnabled = true;
            this.contestantTwoComboBox.Location = new System.Drawing.Point(6, 55);
            this.contestantTwoComboBox.Name = "contestantTwoComboBox";
            this.contestantTwoComboBox.Size = new System.Drawing.Size(121, 21);
            this.contestantTwoComboBox.TabIndex = 2;
            this.contestantTwoComboBox.Text = "Select team/player";
            // 
            // contestantOneScoreTextBox
            // 
            this.contestantOneScoreTextBox.Location = new System.Drawing.Point(99, 55);
            this.contestantOneScoreTextBox.Name = "contestantOneScoreTextBox";
            this.contestantOneScoreTextBox.Size = new System.Drawing.Size(95, 20);
            this.contestantOneScoreTextBox.TabIndex = 3;
            this.contestantOneScoreTextBox.Text = "enter Score";
            // 
            // contestantTwoScoreTextBox
            // 
            this.contestantTwoScoreTextBox.Location = new System.Drawing.Point(99, 81);
            this.contestantTwoScoreTextBox.Name = "contestantTwoScoreTextBox";
            this.contestantTwoScoreTextBox.Size = new System.Drawing.Size(95, 20);
            this.contestantTwoScoreTextBox.TabIndex = 4;
            this.contestantTwoScoreTextBox.Text = "enter Score";
            // 
            // submitMatchButton
            // 
            this.submitMatchButton.Location = new System.Drawing.Point(54, 236);
            this.submitMatchButton.Name = "submitMatchButton";
            this.submitMatchButton.Size = new System.Drawing.Size(91, 23);
            this.submitMatchButton.TabIndex = 5;
            this.submitMatchButton.Text = "Submit Match";
            this.submitMatchButton.UseVisualStyleBackColor = true;
            this.submitMatchButton.Click += new System.EventHandler(this.submitMatchButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.contestantOneComboBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.contestantTwoComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 102);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "matchStart";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(148, 66);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(91, 17);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "team or player";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 82);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "match in progres...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "00.00.00";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "END";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.contestantOneScoreTextBox);
            this.groupBox3.Controls.Add(this.contestantTwoScoreTextBox);
            this.groupBox3.Controls.Add(this.submitMatchButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 278);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "match resolution";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Recorded match time 00.00.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "player 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "player B";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(99, 173);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(95, 20);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "enter Self-goals";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(99, 199);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(95, 20);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "enter Self-goals";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "player 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "player A";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 121);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(95, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "enter Self-goals";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(99, 147);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(95, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "enter Self-goals";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contestant 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Contestant A";
            // 
            // PlayMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(550, 354);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.playMatchStatusStrip);
            this.Name = "PlayMatch";
            this.Text = "FOOS FOR THE FOOS-GODS";
            this.Load += new System.EventHandler(this.PlayMatch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip playMatchStatusStrip;
        private System.Windows.Forms.ComboBox contestantOneComboBox;
        private System.Windows.Forms.ComboBox contestantTwoComboBox;
        private System.Windows.Forms.TextBox contestantOneScoreTextBox;
        private System.Windows.Forms.TextBox contestantTwoScoreTextBox;
        private System.Windows.Forms.Button submitMatchButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}