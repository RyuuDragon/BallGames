namespace BilliardBallsWinFormsApp
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
            closeButton = new Button();
            leftLabel = new Label();
            rightLabel = new Label();
            bottomLabel = new Label();
            topLabel = new Label();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            closeButton.FlatAppearance.MouseOverBackColor = Color.Red;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            closeButton.Location = new Point(774, -2);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(59, 49);
            closeButton.TabIndex = 0;
            closeButton.Text = "X";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // leftLabel
            // 
            leftLabel.AutoSize = true;
            leftLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            leftLabel.Location = new Point(20, 246);
            leftLabel.Name = "leftLabel";
            leftLabel.Size = new Size(25, 30);
            leftLabel.TabIndex = 1;
            leftLabel.Text = "0";
            // 
            // rightLabel
            // 
            rightLabel.AutoSize = true;
            rightLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rightLabel.Location = new Point(774, 246);
            rightLabel.Name = "rightLabel";
            rightLabel.Size = new Size(25, 30);
            rightLabel.TabIndex = 2;
            rightLabel.Text = "0";
            // 
            // bottomLabel
            // 
            bottomLabel.AutoSize = true;
            bottomLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bottomLabel.Location = new Point(404, 502);
            bottomLabel.Name = "bottomLabel";
            bottomLabel.Size = new Size(25, 30);
            bottomLabel.TabIndex = 3;
            bottomLabel.Text = "0";
            // 
            // topLabel
            // 
            topLabel.AutoSize = true;
            topLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            topLabel.Location = new Point(404, 9);
            topLabel.Name = "topLabel";
            topLabel.Size = new Size(25, 30);
            topLabel.TabIndex = 4;
            topLabel.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 541);
            Controls.Add(topLabel);
            Controls.Add(bottomLabel);
            Controls.Add(rightLabel);
            Controls.Add(leftLabel);
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

        private Button closeButton;
        private Label leftLabel;
        private Label rightLabel;
        private Label bottomLabel;
        private Label topLabel;
    }
}
