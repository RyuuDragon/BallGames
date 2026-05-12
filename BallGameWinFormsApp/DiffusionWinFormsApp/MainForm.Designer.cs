namespace DiffusionWinFormsApp
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
            topBlueLabel = new Label();
            bottomBlueLabel = new Label();
            rightBlueLabel = new Label();
            leftBlueLabel = new Label();
            closeButton = new Button();
            topRedLabel = new Label();
            bottomRedLabel = new Label();
            leftRedLabel = new Label();
            rightRedLabel = new Label();
            switchButton = new Button();
            restartButton = new Button();
            SuspendLayout();
            // 
            // topBlueLabel
            // 
            topBlueLabel.AutoSize = true;
            topBlueLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            topBlueLabel.ForeColor = Color.Blue;
            topBlueLabel.Location = new Point(368, 11);
            topBlueLabel.Name = "topBlueLabel";
            topBlueLabel.Size = new Size(25, 30);
            topBlueLabel.TabIndex = 9;
            topBlueLabel.Text = "0";
            // 
            // bottomBlueLabel
            // 
            bottomBlueLabel.AutoSize = true;
            bottomBlueLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bottomBlueLabel.ForeColor = Color.Blue;
            bottomBlueLabel.Location = new Point(368, 504);
            bottomBlueLabel.Name = "bottomBlueLabel";
            bottomBlueLabel.Size = new Size(25, 30);
            bottomBlueLabel.TabIndex = 8;
            bottomBlueLabel.Text = "0";
            // 
            // rightBlueLabel
            // 
            rightBlueLabel.AutoSize = true;
            rightBlueLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rightBlueLabel.ForeColor = Color.Blue;
            rightBlueLabel.Location = new Point(790, 223);
            rightBlueLabel.Name = "rightBlueLabel";
            rightBlueLabel.Size = new Size(25, 30);
            rightBlueLabel.TabIndex = 7;
            rightBlueLabel.Text = "0";
            // 
            // leftBlueLabel
            // 
            leftBlueLabel.AutoSize = true;
            leftBlueLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            leftBlueLabel.ForeColor = Color.Blue;
            leftBlueLabel.Location = new Point(12, 223);
            leftBlueLabel.Name = "leftBlueLabel";
            leftBlueLabel.Size = new Size(25, 30);
            leftBlueLabel.TabIndex = 6;
            leftBlueLabel.Text = "0";
            // 
            // closeButton
            // 
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            closeButton.FlatAppearance.MouseOverBackColor = Color.Red;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            closeButton.Location = new Point(773, -8);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(59, 49);
            closeButton.TabIndex = 5;
            closeButton.Text = "X";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // topRedLabel
            // 
            topRedLabel.AutoSize = true;
            topRedLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            topRedLabel.ForeColor = Color.Red;
            topRedLabel.Location = new Point(441, 11);
            topRedLabel.Name = "topRedLabel";
            topRedLabel.Size = new Size(25, 30);
            topRedLabel.TabIndex = 10;
            topRedLabel.Text = "0";
            // 
            // bottomRedLabel
            // 
            bottomRedLabel.AutoSize = true;
            bottomRedLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bottomRedLabel.ForeColor = Color.Red;
            bottomRedLabel.Location = new Point(441, 504);
            bottomRedLabel.Name = "bottomRedLabel";
            bottomRedLabel.Size = new Size(25, 30);
            bottomRedLabel.TabIndex = 11;
            bottomRedLabel.Text = "0";
            // 
            // leftRedLabel
            // 
            leftRedLabel.AutoSize = true;
            leftRedLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            leftRedLabel.ForeColor = Color.Red;
            leftRedLabel.Location = new Point(12, 287);
            leftRedLabel.Name = "leftRedLabel";
            leftRedLabel.Size = new Size(25, 30);
            leftRedLabel.TabIndex = 12;
            leftRedLabel.Text = "0";
            // 
            // rightRedLabel
            // 
            rightRedLabel.AutoSize = true;
            rightRedLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rightRedLabel.ForeColor = Color.Red;
            rightRedLabel.Location = new Point(790, 287);
            rightRedLabel.Name = "rightRedLabel";
            rightRedLabel.Size = new Size(25, 30);
            rightRedLabel.TabIndex = 13;
            rightRedLabel.Text = "0";
            // 
            // switchButton
            // 
            switchButton.Location = new Point(515, 479);
            switchButton.Name = "switchButton";
            switchButton.Size = new Size(112, 34);
            switchButton.TabIndex = 14;
            switchButton.Text = "Старт/Стоп";
            switchButton.UseVisualStyleBackColor = true;
            switchButton.Click += switchButton_Click;
            // 
            // restartButton
            // 
            restartButton.Location = new Point(643, 479);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(118, 34);
            restartButton.TabIndex = 15;
            restartButton.Text = "Перезапуск";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += restartButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 541);
            Controls.Add(restartButton);
            Controls.Add(switchButton);
            Controls.Add(rightRedLabel);
            Controls.Add(leftRedLabel);
            Controls.Add(bottomRedLabel);
            Controls.Add(topRedLabel);
            Controls.Add(topBlueLabel);
            Controls.Add(bottomBlueLabel);
            Controls.Add(rightBlueLabel);
            Controls.Add(leftBlueLabel);
            Controls.Add(closeButton);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            Paint += MainForm_Paint;
            MouseDown += MainForm_MouseDown;
            MouseMove += MainForm_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label topBlueLabel;
        private Label bottomBlueLabel;
        private Label rightBlueLabel;
        private Label leftBlueLabel;
        private Button closeButton;
        private Label topRedLabel;
        private Label bottomRedLabel;
        private Label leftRedLabel;
        private Label rightRedLabel;
        private Button switchButton;
        private Button restartButton;
    }
}