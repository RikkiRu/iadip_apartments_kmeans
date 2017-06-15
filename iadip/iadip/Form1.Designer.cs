namespace iadip
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bLoadData = new System.Windows.Forms.Button();
            this.dialogOpenDataFile = new System.Windows.Forms.OpenFileDialog();
            this.bTestEstimate = new System.Windows.Forms.Button();
            this.bBeginClasterize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bLoadData
            // 
            this.bLoadData.Location = new System.Drawing.Point(81, 31);
            this.bLoadData.Name = "bLoadData";
            this.bLoadData.Size = new System.Drawing.Size(189, 117);
            this.bLoadData.TabIndex = 0;
            this.bLoadData.Text = "Load Data";
            this.bLoadData.UseVisualStyleBackColor = true;
            this.bLoadData.Click += new System.EventHandler(this.bLoadData_Click);
            // 
            // dialogOpenDataFile
            // 
            this.dialogOpenDataFile.FileName = "data.tsv";
            this.dialogOpenDataFile.Filter = "data files|*.tsv; *.txt|All files|*.*";
            this.dialogOpenDataFile.FileOk += new System.ComponentModel.CancelEventHandler(this.dialogOpenDataFile_FileOk);
            // 
            // bTestEstimate
            // 
            this.bTestEstimate.Location = new System.Drawing.Point(81, 207);
            this.bTestEstimate.Name = "bTestEstimate";
            this.bTestEstimate.Size = new System.Drawing.Size(189, 23);
            this.bTestEstimate.TabIndex = 1;
            this.bTestEstimate.Text = "TestEstimate";
            this.bTestEstimate.UseVisualStyleBackColor = true;
            this.bTestEstimate.Click += new System.EventHandler(this.bTestEstimate_Click);
            // 
            // bBeginClasterize
            // 
            this.bBeginClasterize.Location = new System.Drawing.Point(81, 154);
            this.bBeginClasterize.Name = "bBeginClasterize";
            this.bBeginClasterize.Size = new System.Drawing.Size(189, 32);
            this.bBeginClasterize.TabIndex = 2;
            this.bBeginClasterize.Text = "Begin Clasterize";
            this.bBeginClasterize.UseVisualStyleBackColor = true;
            this.bBeginClasterize.Visible = false;
            this.bBeginClasterize.Click += new System.EventHandler(this.bBeginClasterize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 249);
            this.Controls.Add(this.bBeginClasterize);
            this.Controls.Add(this.bTestEstimate);
            this.Controls.Add(this.bLoadData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bLoadData;
        private System.Windows.Forms.OpenFileDialog dialogOpenDataFile;
        private System.Windows.Forms.Button bTestEstimate;
        private System.Windows.Forms.Button bBeginClasterize;
    }
}

