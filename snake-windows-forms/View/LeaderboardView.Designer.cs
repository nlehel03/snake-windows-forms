namespace snake_windows_forms.View
{
    partial class LeaderboardView
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
            label1 = new Label();
            scoresListBox = new GameListBox();
            menuButton = new GameButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Courier New", 72F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 192, 0);
            label1.Location = new Point(91, 65);
            label1.Name = "label1";
            label1.Size = new Size(337, 110);
            label1.TabIndex = 1;
            label1.Text = "SNAKE";
            // 
            // scoresListBox
            // 
            scoresListBox.BackColor = Color.Black;
            scoresListBox.BorderStyle = BorderStyle.None;
            scoresListBox.BoxBackground = Color.Black;
            scoresListBox.BoxForeColor = Color.Lime;
            scoresListBox.DrawMode = DrawMode.OwnerDrawFixed;
            scoresListBox.Font = new Font("Courier New", 12F, FontStyle.Bold);
            scoresListBox.ForeColor = Color.Lime;
            scoresListBox.FormattingEnabled = true;
            scoresListBox.ItemHeight = 28;
            scoresListBox.Location = new Point(91, 163);
            scoresListBox.Name = "scoresListBox";
            scoresListBox.SelectionBackColor = Color.Green;
            scoresListBox.SelectionForeColor = Color.Black;
            scoresListBox.Size = new Size(337, 252);
            scoresListBox.TabIndex = 2;
            // 
            // menuButton
            // 
            menuButton.BackColor = Color.Black;
            menuButton.BackgroundColor = Color.Black;
            menuButton.BorderColor = Color.Green;
            menuButton.BorderSize = 1;
            menuButton.FlatAppearance.BorderSize = 0;
            menuButton.FlatStyle = FlatStyle.Flat;
            menuButton.Font = new Font("Courier New", 14F, FontStyle.Bold);
            menuButton.ForeColor = Color.Green;
            menuButton.Location = new Point(184, 421);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(153, 56);
            menuButton.TabIndex = 3;
            menuButton.Text = "Menu";
            menuButton.TextColor = Color.Green;
            menuButton.TextFont = new Font("Courier New", 14F, FontStyle.Bold);
            menuButton.UseVisualStyleBackColor = false;
            menuButton.Click += menuButton_Click;
            // 
            // LeaderboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(504, 504);
            Controls.Add(menuButton);
            Controls.Add(scoresListBox);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LeaderboardView";
            Text = "LeaderboardView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private GameListBox scoresListBox;
        private GameButton menuButton;
    }
}