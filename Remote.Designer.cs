namespace image_puzzle
{
    partial class Remote
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
            this.Pieces = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SubButton = new System.Windows.Forms.Button();
            this.currentNumber = new System.Windows.Forms.Label();
            this.PlusButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.TurnButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pieces
            // 
            this.Pieces.Location = new System.Drawing.Point(12, 12);
            this.Pieces.Name = "Pieces";
            this.Pieces.Size = new System.Drawing.Size(450, 450);
            this.Pieces.TabIndex = 0;
            this.Pieces.TabStop = false;
            this.Pieces.Text = "Pieces";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PlusButton);
            this.groupBox2.Controls.Add(this.currentNumber);
            this.groupBox2.Controls.Add(this.SubButton);
            this.groupBox2.Location = new System.Drawing.Point(468, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 160);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select pieces";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RightButton);
            this.groupBox1.Controls.Add(this.TurnButton);
            this.groupBox1.Controls.Add(this.LeftButton);
            this.groupBox1.Controls.Add(this.DownButton);
            this.groupBox1.Controls.Add(this.UpButton);
            this.groupBox1.Location = new System.Drawing.Point(468, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 284);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controll";
            // 
            // SubButton
            // 
            this.SubButton.Location = new System.Drawing.Point(6, 69);
            this.SubButton.Name = "SubButton";
            this.SubButton.Size = new System.Drawing.Size(75, 23);
            this.SubButton.TabIndex = 0;
            this.SubButton.Text = "Sub";
            this.SubButton.UseVisualStyleBackColor = true;
            this.SubButton.Click += new System.EventHandler(this.SubButton_Click);
            // 
            // currentNumber
            // 
            this.currentNumber.AutoSize = true;
            this.currentNumber.Location = new System.Drawing.Point(116, 74);
            this.currentNumber.Name = "currentNumber";
            this.currentNumber.Size = new System.Drawing.Size(13, 13);
            this.currentNumber.TabIndex = 1;
            this.currentNumber.Text = "0";
            // 
            // PlusButton
            // 
            this.PlusButton.Location = new System.Drawing.Point(166, 69);
            this.PlusButton.Name = "PlusButton";
            this.PlusButton.Size = new System.Drawing.Size(75, 23);
            this.PlusButton.TabIndex = 2;
            this.PlusButton.Text = "Plus";
            this.PlusButton.UseVisualStyleBackColor = true;
            this.PlusButton.Click += new System.EventHandler(this.PlusButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Location = new System.Drawing.Point(85, 96);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(75, 23);
            this.UpButton.TabIndex = 3;
            this.UpButton.Text = "Up";
            this.UpButton.UseVisualStyleBackColor = true;
            // 
            // DownButton
            // 
            this.DownButton.Location = new System.Drawing.Point(85, 154);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(75, 23);
            this.DownButton.TabIndex = 4;
            this.DownButton.Text = "Down";
            this.DownButton.UseVisualStyleBackColor = true;
            // 
            // LeftButton
            // 
            this.LeftButton.Location = new System.Drawing.Point(4, 125);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(75, 23);
            this.LeftButton.TabIndex = 5;
            this.LeftButton.Text = "Left";
            this.LeftButton.UseVisualStyleBackColor = true;
            // 
            // TurnButton
            // 
            this.TurnButton.Location = new System.Drawing.Point(85, 125);
            this.TurnButton.Name = "TurnButton";
            this.TurnButton.Size = new System.Drawing.Size(75, 23);
            this.TurnButton.TabIndex = 6;
            this.TurnButton.Text = "Turn";
            this.TurnButton.UseVisualStyleBackColor = true;
            this.TurnButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // RightButton
            // 
            this.RightButton.Location = new System.Drawing.Point(166, 125);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(75, 23);
            this.RightButton.TabIndex = 7;
            this.RightButton.Text = "Right";
            this.RightButton.UseVisualStyleBackColor = true;
            // 
            // Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 470);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Pieces);
            this.Name = "Remote";
            this.Text = "Remote";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Pieces;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button PlusButton;
        private System.Windows.Forms.Label currentNumber;
        private System.Windows.Forms.Button SubButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button TurnButton;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button UpButton;
    }
}