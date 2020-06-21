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
            this.groupBox2.Location = new System.Drawing.Point(468, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 446);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select pieces";
            // 
            // Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 470);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Pieces);
            this.Name = "Remote";
            this.Text = "Remote";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Pieces;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}