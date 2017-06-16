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
            this.btnXConst = new System.Windows.Forms.Button();
            this.btnYRooms = new System.Windows.Forms.Button();
            this.btnYBath = new System.Windows.Forms.Button();
            this.btnYArea = new System.Windows.Forms.Button();
            this.btnYCost = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXRooms = new System.Windows.Forms.Button();
            this.btnXBath = new System.Windows.Forms.Button();
            this.btnXArea = new System.Windows.Forms.Button();
            this.btnXCost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYConst = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(614, 345);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnYConst);
            this.panel1.Controls.Add(this.btnXConst);
            this.panel1.Controls.Add(this.btnYRooms);
            this.panel1.Controls.Add(this.btnYBath);
            this.panel1.Controls.Add(this.btnYArea);
            this.panel1.Controls.Add(this.btnYCost);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnXRooms);
            this.panel1.Controls.Add(this.btnXBath);
            this.panel1.Controls.Add(this.btnXArea);
            this.panel1.Controls.Add(this.btnXCost);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(614, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 345);
            this.panel1.TabIndex = 1;
            // 
            // btnXConst
            // 
            this.btnXConst.Location = new System.Drawing.Point(17, 69);
            this.btnXConst.Name = "btnXConst";
            this.btnXConst.Size = new System.Drawing.Size(144, 38);
            this.btnXConst.TabIndex = 10;
            this.btnXConst.Text = "Константа";
            this.btnXConst.UseVisualStyleBackColor = true;
            this.btnXConst.Click += new System.EventHandler(this.btnXConst_Click);
            // 
            // btnYRooms
            // 
            this.btnYRooms.Location = new System.Drawing.Point(167, 182);
            this.btnYRooms.Name = "btnYRooms";
            this.btnYRooms.Size = new System.Drawing.Size(76, 38);
            this.btnYRooms.TabIndex = 9;
            this.btnYRooms.Text = "Комнаты";
            this.btnYRooms.UseVisualStyleBackColor = true;
            this.btnYRooms.Click += new System.EventHandler(this.btnYRooms_Click);
            // 
            // btnYBath
            // 
            this.btnYBath.Location = new System.Drawing.Point(167, 138);
            this.btnYBath.Name = "btnYBath";
            this.btnYBath.Size = new System.Drawing.Size(76, 38);
            this.btnYBath.TabIndex = 8;
            this.btnYBath.Text = "Ванные";
            this.btnYBath.UseVisualStyleBackColor = true;
            this.btnYBath.Click += new System.EventHandler(this.btnYBath_Click);
            // 
            // btnYArea
            // 
            this.btnYArea.Location = new System.Drawing.Point(83, 138);
            this.btnYArea.Name = "btnYArea";
            this.btnYArea.Size = new System.Drawing.Size(78, 38);
            this.btnYArea.TabIndex = 7;
            this.btnYArea.Text = "Площадь";
            this.btnYArea.UseVisualStyleBackColor = true;
            this.btnYArea.Click += new System.EventHandler(this.btnYArea_Click);
            // 
            // btnYCost
            // 
            this.btnYCost.Location = new System.Drawing.Point(17, 138);
            this.btnYCost.Name = "btnYCost";
            this.btnYCost.Size = new System.Drawing.Size(60, 38);
            this.btnYCost.TabIndex = 6;
            this.btnYCost.Text = "Цена";
            this.btnYCost.UseVisualStyleBackColor = true;
            this.btnYCost.Click += new System.EventHandler(this.btnYCost_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = " Ось Y";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnXRooms
            // 
            this.btnXRooms.Location = new System.Drawing.Point(167, 69);
            this.btnXRooms.Name = "btnXRooms";
            this.btnXRooms.Size = new System.Drawing.Size(76, 38);
            this.btnXRooms.TabIndex = 4;
            this.btnXRooms.Text = "Комнаты";
            this.btnXRooms.UseVisualStyleBackColor = true;
            this.btnXRooms.Click += new System.EventHandler(this.btnXRooms_Click);
            // 
            // btnXBath
            // 
            this.btnXBath.Location = new System.Drawing.Point(167, 25);
            this.btnXBath.Name = "btnXBath";
            this.btnXBath.Size = new System.Drawing.Size(76, 38);
            this.btnXBath.TabIndex = 3;
            this.btnXBath.Text = "Ванные";
            this.btnXBath.UseVisualStyleBackColor = true;
            this.btnXBath.Click += new System.EventHandler(this.btnXBath_Click);
            // 
            // btnXArea
            // 
            this.btnXArea.Location = new System.Drawing.Point(83, 25);
            this.btnXArea.Name = "btnXArea";
            this.btnXArea.Size = new System.Drawing.Size(78, 38);
            this.btnXArea.TabIndex = 2;
            this.btnXArea.Text = "Площадь";
            this.btnXArea.UseVisualStyleBackColor = true;
            this.btnXArea.Click += new System.EventHandler(this.btnXArea_Click);
            // 
            // btnXCost
            // 
            this.btnXCost.Location = new System.Drawing.Point(17, 25);
            this.btnXCost.Name = "btnXCost";
            this.btnXCost.Size = new System.Drawing.Size(60, 38);
            this.btnXCost.TabIndex = 1;
            this.btnXCost.Text = "Цена";
            this.btnXCost.UseVisualStyleBackColor = true;
            this.btnXCost.Click += new System.EventHandler(this.btnXCost_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = " Ось X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnYConst
            // 
            this.btnYConst.Location = new System.Drawing.Point(17, 182);
            this.btnYConst.Name = "btnYConst";
            this.btnYConst.Size = new System.Drawing.Size(144, 38);
            this.btnYConst.TabIndex = 11;
            this.btnYConst.Text = "Константа";
            this.btnYConst.UseVisualStyleBackColor = true;
            this.btnYConst.Click += new System.EventHandler(this.btnYConst_Click);
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
        private System.Windows.Forms.Button btnYRooms;
        private System.Windows.Forms.Button btnYBath;
        private System.Windows.Forms.Button btnYArea;
        private System.Windows.Forms.Button btnYCost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXRooms;
        private System.Windows.Forms.Button btnXBath;
        private System.Windows.Forms.Button btnXArea;
        private System.Windows.Forms.Button btnXCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXConst;
        private System.Windows.Forms.Button btnYConst;
    }
}