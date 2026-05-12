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
            clearButton = new Button();
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
            // clearButton
            // 
            clearButton.BackColor = Color.White;
            clearButton.Cursor = Cursors.Hand;
            clearButton.FlatAppearance.BorderSize = 0;
            clearButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            clearButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Location = new Point(491, 511);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(112, 65);
            clearButton.TabIndex = 1;
            clearButton.Text = "Очистить";
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += clearButton_Click;
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
            Controls.Add(clearButton);
            Controls.Add(startButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            MouseClick += MainForm_MouseClick;
            MouseDown += MainForm_MouseDown;
            MouseMove += MainForm_MouseMove;
            ResumeLayout(false);
        }

        #endregion

        private Button startButton;
        private Button clearButton;
        private Button closeButton;
        private Label resultLabel;
    }
}
