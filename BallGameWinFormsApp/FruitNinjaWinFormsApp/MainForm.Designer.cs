namespace FruitNinjaWinFormsApp
{
    partial class MainForm
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
            startButton = new Button();
            restartButton = new Button();
            resultLabel = new Label();
            wrongLabel = new Label();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Cursor = Cursors.Hand;
            startButton.FlatAppearance.BorderSize = 2;
            startButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            startButton.FlatAppearance.MouseOverBackColor = Color.Red;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Font = new Font("Comic Sans MS", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startButton.Location = new Point(632, 58);
            startButton.Name = "startButton";
            startButton.RightToLeft = RightToLeft.No;
            startButton.Size = new Size(112, 42);
            startButton.TabIndex = 2;
            startButton.Text = "Старт";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // restartButton
            // 
            restartButton.Cursor = Cursors.Hand;
            restartButton.FlatAppearance.BorderSize = 2;
            restartButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            restartButton.FlatAppearance.MouseOverBackColor = Color.Red;
            restartButton.FlatStyle = FlatStyle.Flat;
            restartButton.Font = new Font("Comic Sans MS", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            restartButton.Location = new Point(611, 106);
            restartButton.Name = "restartButton";
            restartButton.RightToLeft = RightToLeft.No;
            restartButton.Size = new Size(152, 42);
            restartButton.TabIndex = 3;
            restartButton.Text = "Перезапуск";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += restartButton_Click;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Font = new Font("Comic Sans MS", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resultLabel.Location = new Point(36, 31);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(120, 30);
            resultLabel.TabIndex = 4;
            resultLabel.Text = "Результат:";
            // 
            // wrongLabel
            // 
            wrongLabel.AutoSize = true;
            wrongLabel.Font = new Font("Comic Sans MS", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            wrongLabel.Location = new Point(36, 70);
            wrongLabel.Name = "wrongLabel";
            wrongLabel.Size = new Size(179, 30);
            wrongLabel.TabIndex = 5;
            wrongLabel.Text = "Промахи: 0 0 0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 694);
            Controls.Add(wrongLabel);
            Controls.Add(resultLabel);
            Controls.Add(restartButton);
            Controls.Add(startButton);
            DoubleBuffered = true;
            Name = "MainForm";
            Text = "MainForm";
            Paint += MainForm_Paint;
            MouseDown += MainForm_MouseDown;
            MouseMove += MainForm_MouseMove;
            MouseUp += MainForm_MouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button startButton;
        private Button restartButton;
        private Label resultLabel;
        private Label wrongLabel;
    }
}