namespace snake_windows_forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            scoresLabel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // scoresLabel
            // 
            scoresLabel.AutoSize = true;
            scoresLabel.BackColor = Color.Transparent;
            scoresLabel.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            scoresLabel.ForeColor = Color.FromArgb(0, 192, 0);
            scoresLabel.Location = new Point(12, 9);
            scoresLabel.Name = "scoresLabel";
            scoresLabel.Size = new Size(76, 22);
            scoresLabel.TabIndex = 1;
            scoresLabel.Text = "Score:";
            scoresLabel.Click += scoresLabel_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(504, 504);
            Controls.Add(scoresLabel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label scoresLabel;
        private System.Windows.Forms.Timer timer1;
    }
}
