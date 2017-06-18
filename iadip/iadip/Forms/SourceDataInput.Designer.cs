namespace iadip {
    partial class SourceDataInput {
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
            this.labelInputText = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.tbInput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelInputText
            // 
            this.labelInputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInputText.AutoSize = true;
            this.labelInputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInputText.Location = new System.Drawing.Point(12, 9);
            this.labelInputText.MinimumSize = new System.Drawing.Size(436, 37);
            this.labelInputText.Name = "labelInputText";
            this.labelInputText.Size = new System.Drawing.Size(436, 37);
            this.labelInputText.TabIndex = 0;
            this.labelInputText.Text = "Введите стоимость квартиры";
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.BackColor = System.Drawing.Color.IndianRed;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(12, 110);
            this.buttonStart.MinimumSize = new System.Drawing.Size(430, 61);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(430, 61);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Найти квартиру";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // tbInput
            // 
            this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbInput.Location = new System.Drawing.Point(12, 49);
            this.tbInput.MinimumSize = new System.Drawing.Size(430, 64);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(430, 64);
            this.tbInput.TabIndex = 3;
            this.tbInput.Text = "";
            // 
            // SourceDataInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 183);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelInputText);
            this.MinimumSize = new System.Drawing.Size(465, 210);
            this.Name = "SourceDataInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оценка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInputText;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.RichTextBox tbInput;
    }
}