namespace snake_windows_forms.View
{
    partial class MainMenuView
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
            logo = new Label();
            startGameButton = new GameButton();
            leaderBoardButton = new GameButton();
            SuspendLayout();
            // 
            // logo
            // 
            logo.Anchor = AnchorStyles.None;
            logo.AutoSize = true;
            logo.BackColor = Color.Transparent;
            logo.Font = new Font("Courier New", 72F, FontStyle.Bold, GraphicsUnit.Point, 238);
            logo.ForeColor = Color.Green;
            logo.Location = new Point(75, 87);
            logo.Name = "logo";
            logo.Size = new Size(418, 137);
            logo.TabIndex = 1;
            logo.Text = "SNAKE";
            logo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startGameButton
            // 
            startGameButton.BackColor = Color.Black;
            startGameButton.BackgroundColor = Color.Black;
            startGameButton.BorderColor = Color.Green;
            startGameButton.BorderSize = 1;
            startGameButton.FlatAppearance.BorderSize = 0;
            startGameButton.FlatStyle = FlatStyle.Flat;
            startGameButton.Font = new Font("Courier New", 14F, FontStyle.Bold);
            startGameButton.ForeColor = Color.Green;
            startGameButton.Location = new Point(194, 257);
            startGameButton.Name = "startGameButton";
            startGameButton.Size = new Size(175, 75);
            startGameButton.TabIndex = 4;
            startGameButton.Text = "Start Game";
            startGameButton.TextColor = Color.Green;
            startGameButton.TextFont = new Font("Courier New", 14F, FontStyle.Bold);
            startGameButton.UseVisualStyleBackColor = false;
            // 
            // leaderBoardButton
            // 
            leaderBoardButton.BackColor = Color.Black;
            leaderBoardButton.BackgroundColor = Color.Black;
            leaderBoardButton.BorderColor = Color.Green;
            leaderBoardButton.BorderSize = 1;
            leaderBoardButton.FlatAppearance.BorderSize = 0;
            leaderBoardButton.FlatStyle = FlatStyle.Flat;
            leaderBoardButton.Font = new Font("Courier New", 14F, FontStyle.Bold);
            leaderBoardButton.ForeColor = Color.Green;
            leaderBoardButton.Location = new Point(194, 396);
            leaderBoardButton.Name = "leaderBoardButton";
            leaderBoardButton.Size = new Size(175, 76);
            leaderBoardButton.TabIndex = 5;
            leaderBoardButton.Text = "Leaderboard";
            leaderBoardButton.TextAlign = ContentAlignment.MiddleRight;
            leaderBoardButton.TextColor = Color.Green;
            leaderBoardButton.TextFont = new Font("Courier New", 14F, FontStyle.Bold);
            leaderBoardButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            leaderBoardButton.UseVisualStyleBackColor = false;
            // 
            // MainMenuView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(576, 672);
            Controls.Add(leaderBoardButton);
            Controls.Add(startGameButton);
            Controls.Add(logo);
            Name = "MainMenuView";
            Text = "Snake";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label logo;
        private GameButton startGameButton;
        private GameButton leaderBoardButton;
    }
}