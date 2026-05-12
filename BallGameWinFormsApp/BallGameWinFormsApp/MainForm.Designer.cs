namespace BallGameWinFormsApp
{
    partial class MainForm
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
            startButton = new Button();
            stopButton = new Button();
            closeButton = new Button();
            resultLabel = new Label();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = Color.White;
            startButton.Cursor = Cursors.Hand;
            startButton.FlatAppearance.BorderSize = 0;
            startButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            startButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.ForeColor = SystemColors.ControlText;
            startButton.Location = new Point(341, 511);
            startButton.Name = "startButton";
            startButton.Size = new Size(112, 65);
            startButton.TabIndex = 0;
            startButton.Text = "Старт";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // stopButton
            // 
            stopButton.BackColor = Color.White;
            stopButton.Cursor = Cursors.Hand;
            stopButton.FlatAppearance.BorderSize = 0;
            stopButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            stopButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
            stopButton.FlatStyle = FlatStyle.Flat;
            stopButton.Location = new Point(491, 511);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(112, 65);
            stopButton.TabIndex = 1;
            stopButton.Text = "Стоп";
            stopButton.UseVisualStyleBackColor = false;
            stopButton.Click += stopButton_Click;
            // 
            // closeButton
            // 
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseDownBackColor = Color.Red;
            closeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            closeButton.Location = new Point(914, -1);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(64, 48);
            closeButton.TabIndex = 2;
            closeButton.Text = "X";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // resultLabel
            // 
            resultLabel.BackColor = Color.White;
            resultLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resultLabel.Location = new Point(46, 38);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(197, 50);
            resultLabel.TabIndex = 3;
            resultLabel.Text = "Результат:";
            resultLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(207, 197, 188);
            ClientSize = new Size(978, 644);
            Controls.Add(resultLabel);
            Controls.Add(closeButton);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "MainForm";
            MouseDown += MainForm_MouseDown;
            MouseMove += MainForm_MouseMove;
            ResumeLayout(false);
        }

        #endregion

        private Button startButton;
        private Button stopButton;
        private Button closeButton;
        private Label resultLabel;
    }
}
