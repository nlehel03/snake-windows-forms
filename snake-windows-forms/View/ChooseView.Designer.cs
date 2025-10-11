namespace snake_windows_forms.View
{
    partial class ChooseView
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
            smallMapButton = new GameButton();
            mediumMapButton = new GameButton();
            largeMapButton = new GameButton();
            label1 = new Label();
            label2 = new Label();
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
            logo.TabIndex = 2;
            logo.Text = "SNAKE";
            logo.TextAlign = ContentAlignment.MiddleCenter;
            
            // 
            // smallMapButton
            // 
            smallMapButton.BackColor = Color.Black;
            smallMapButton.BackgroundColor = Color.Black;
            smallMapButton.BorderColor = Color.Green;
            smallMapButton.BorderSize = 1;
            smallMapButton.FlatAppearance.BorderSize = 0;
            smallMapButton.FlatStyle = FlatStyle.Flat;
            smallMapButton.Font = new Font("Courier New", 14F, FontStyle.Bold);
            smallMapButton.ForeColor = Color.Green;
            smallMapButton.Location = new Point(194, 257);
            smallMapButton.Name = "smallMapButton";
            smallMapButton.Size = new Size(175, 75);
            smallMapButton.TabIndex = 5;
            smallMapButton.Text = "Small";
            smallMapButton.TextColor = Color.Green;
            smallMapButton.TextFont = new Font("Courier New", 14F, FontStyle.Bold);
            smallMapButton.UseVisualStyleBackColor = false;
            smallMapButton.Click += smallMapButton_Click;
            // 
            // mediumMapButton
            // 
            mediumMapButton.BackColor = Color.Black;
            mediumMapButton.BackgroundColor = Color.Black;
            mediumMapButton.BorderColor = Color.Green;
            mediumMapButton.BorderSize = 1;
            mediumMapButton.FlatAppearance.BorderSize = 0;
            mediumMapButton.FlatStyle = FlatStyle.Flat;
            mediumMapButton.Font = new Font("Courier New", 14F, FontStyle.Bold);
            mediumMapButton.ForeColor = Color.Green;
            mediumMapButton.Location = new Point(194, 396);
            mediumMapButton.Name = "mediumMapButton";
            mediumMapButton.Size = new Size(175, 76);
            mediumMapButton.TabIndex = 6;
            mediumMapButton.Text = "Medium";
            mediumMapButton.TextAlign = ContentAlignment.MiddleRight;
            mediumMapButton.TextColor = Color.Green;
            mediumMapButton.TextFont = new Font("Courier New", 14F, FontStyle.Bold);
            mediumMapButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            mediumMapButton.UseVisualStyleBackColor = false;
            mediumMapButton.Click += mediumMapButton_Click;
            // 
            // largeMapButton
            // 
            largeMapButton.BackColor = Color.Black;
            largeMapButton.BackgroundColor = Color.Black;
            largeMapButton.BorderColor = Color.Green;
            largeMapButton.BorderSize = 1;
            largeMapButton.FlatAppearance.BorderSize = 0;
            largeMapButton.FlatStyle = FlatStyle.Flat;
            largeMapButton.Font = new Font("Courier New", 14F, FontStyle.Bold);
            largeMapButton.ForeColor = Color.Green;
            largeMapButton.Location = new Point(194, 535);
            largeMapButton.Name = "largeMapButton";
            largeMapButton.Size = new Size(175, 76);
            largeMapButton.TabIndex = 7;
            largeMapButton.Text = "Large";
            largeMapButton.TextAlign = ContentAlignment.MiddleRight;
            largeMapButton.TextColor = Color.Green;
            largeMapButton.TextFont = new Font("Courier New", 14F, FontStyle.Bold);
            largeMapButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            largeMapButton.UseVisualStyleBackColor = false;
            largeMapButton.Click += largeMapButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(202, 543);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 8;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.ForeColor = Color.Green;
            label2.Location = new Point(175, 211);
            label2.Name = "label2";
            label2.Size = new Size(220, 28);
            label2.TabIndex = 9;
            label2.Text = "Choose the size of map!";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // ChooseView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(576, 672);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(largeMapButton);
            Controls.Add(mediumMapButton);
            Controls.Add(smallMapButton);
            Controls.Add(logo);
            Name = "ChooseView";
            Text = "Snake";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label logo;
        private GameButton smallMapButton;
        private GameButton mediumMapButton;
        private GameButton largeMapButton;
        private Label label1;
        private Label label2;
    }
}