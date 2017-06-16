namespace iadip {
    partial class ShowEstematedResult {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gridResultCluster = new System.Windows.Forms.DataGridView();
            this.tbResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultCluster)).BeginInit();
            this.SuspendLayout();
            // 
            // gridResultCluster
            // 
            this.gridResultCluster.AllowUserToAddRows = false;
            this.gridResultCluster.AllowUserToDeleteRows = false;
            this.gridResultCluster.AllowUserToResizeColumns = false;
            this.gridResultCluster.AllowUserToResizeRows = false;
            this.gridResultCluster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridResultCluster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResultCluster.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridResultCluster.Location = new System.Drawing.Point(0, 0);
            this.gridResultCluster.Name = "gridResultCluster";
            this.gridResultCluster.ReadOnly = true;
            this.gridResultCluster.RowHeadersVisible = false;
            this.gridResultCluster.Size = new System.Drawing.Size(745, 44);
            this.gridResultCluster.TabIndex = 0;
            // 
            // tbResult
            // 
            this.tbResult.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbResult.ForeColor = System.Drawing.Color.Black;
            this.tbResult.Location = new System.Drawing.Point(0, 44);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.Size = new System.Drawing.Size(745, 169);
            this.tbResult.TabIndex = 1;
            // 
            // ShowEstematedResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 213);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.gridResultCluster);
            this.Name = "ShowEstematedResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результат";
            ((System.ComponentModel.ISupportInitialize)(this.gridResultCluster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridResultCluster;
        private System.Windows.Forms.TextBox tbResult;
    }
}