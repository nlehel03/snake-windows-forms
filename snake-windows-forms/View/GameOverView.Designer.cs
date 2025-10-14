namespace snake_windows_forms.View
{
    partial class GameOverView
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
            gameOverText = new Label();
            scoreText = new Label();
            nameTextBox = new GameTextBox();
            menuButton = new GameButton();
            SuspendLayout();
            // 
            // gameOverText
            // 
            gameOverText.AutoSize = true;
            gameOverText.Font = new Font("Courier New", 36F, FontStyle.Bold, GraphicsUnit.Point, 238);
            gameOverText.ForeColor = Color.FromArgb(0, 192, 0);
            gameOverText.Location = new Point(90, 136);
            gameOverText.Name = "gameOverText";
            gameOverText.Size = new Size(353, 67);
            gameOverText.TabIndex = 0;
            gameOverText.Text = "GAME OVER";
            gameOverText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scoreText
            // 
            scoreText.AutoSize = true;
            scoreText.Font = new Font("Courier New", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 238);
            scoreText.ForeColor = Color.FromArgb(0, 192, 0);
            scoreText.Location = new Point(164, 217);
            scoreText.Name = "scoreText";
            scoreText.Size = new Size(218, 31);
            scoreText.TabIndex = 1;
            scoreText.Text = "Your scores:";
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = Color.Black;
            nameTextBox.BackgroundColor = Color.Black;
            nameTextBox.BorderColor = Color.Green;
            nameTextBox.BorderSize = 1;
            nameTextBox.BorderStyle = BorderStyle.None;
            nameTextBox.Font = new Font("Courier New", 14F, FontStyle.Bold);
            nameTextBox.ForeColor = Color.Green;
            nameTextBox.InnerPadding = 6;
            nameTextBox.Location = new Point(164, 311);
            nameTextBox.Multiline = true;
            nameTextBox.Name = "nameTextBox";
            nameTextBox.PlaceholderText = "Name";
            nameTextBox.Size = new Size(218, 27);
            nameTextBox.TabIndex = 2;
            nameTextBox.Tag = "";
            nameTextBox.TextColor = Color.Green;
            nameTextBox.TextFont = new Font("Courier New", 14F, FontStyle.Bold);
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
            menuButton.Location = new Point(192, 386);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(172, 67);
            menuButton.TabIndex = 3;
            menuButton.Text = "Menu";
            menuButton.TextColor = Color.Green;
            menuButton.TextFont = new Font("Courier New", 14F, FontStyle.Bold);
            menuButton.UseVisualStyleBackColor = false;
            menuButton.Click += menuButton_Click;
            // 
            // GameOverView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(576, 672);
            Controls.Add(menuButton);
            Controls.Add(nameTextBox);
            Controls.Add(scoreText);
            Controls.Add(gameOverText);
            Name = "GameOverView";
            Text = "Snake";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label gameOverText;
        private Label scoreText;
        private GameTextBox nameTextBox;
        private GameButton menuButton;
    }
}