namespace iadip
{
    partial class ClusterGraph
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxX = new System.Windows.Forms.ComboBox();
            this.comboBoxY = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(683, 345);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxY);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxX);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(683, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 345);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = " Ось Y";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = " Ось X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxX
            // 
            this.comboBoxX.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxX.FormattingEnabled = true;
            this.comboBoxX.Location = new System.Drawing.Point(0, 25);
            this.comboBoxX.Name = "comboBoxX";
            this.comboBoxX.Size = new System.Drawing.Size(177, 21);
            this.comboBoxX.TabIndex = 12;
            this.comboBoxX.SelectedIndexChanged += new System.EventHandler(this.comboBoxX_SelectedIndexChanged);
            // 
            // comboBoxY
            // 
            this.comboBoxY.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxY.FormattingEnabled = true;
            this.comboBoxY.Location = new System.Drawing.Point(0, 71);
            this.comboBoxY.Name = "comboBoxY";
            this.comboBoxY.Size = new System.Drawing.Size(177, 21);
            this.comboBoxY.TabIndex = 13;
            this.comboBoxY.SelectedIndexChanged += new System.EventHandler(this.comboBoxY_SelectedIndexChanged);
            // 
            // ClusterGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 345);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ClusterGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Граф";
            this.Load += new System.EventHandler(this.ClusterGraph_Load);
            this.Resize += new System.EventHandler(this.ClusterGraph_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.ComboBox comboBoxX;
    }
}