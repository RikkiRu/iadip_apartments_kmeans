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
            this.btnShowClusters = new System.Windows.Forms.Button();
            this.showClusterGraph = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bLoadData
            // 
            this.bLoadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLoadData.Location = new System.Drawing.Point(35, 31);
            this.bLoadData.Margin = new System.Windows.Forms.Padding(4);
            this.bLoadData.Name = "bLoadData";
            this.bLoadData.Size = new System.Drawing.Size(148, 68);
            this.bLoadData.TabIndex = 0;
            this.bLoadData.Text = "Загрузить";
            this.bLoadData.UseVisualStyleBackColor = false;
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
            this.bTestEstimate.BackColor = System.Drawing.Color.AliceBlue;
            this.bTestEstimate.Enabled = false;
            this.bTestEstimate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTestEstimate.Location = new System.Drawing.Point(35, 107);
            this.bTestEstimate.Margin = new System.Windows.Forms.Padding(4);
            this.bTestEstimate.Name = "bTestEstimate";
            this.bTestEstimate.Size = new System.Drawing.Size(148, 68);
            this.bTestEstimate.TabIndex = 1;
            this.bTestEstimate.Text = "Оценить";
            this.bTestEstimate.UseVisualStyleBackColor = false;
            this.bTestEstimate.Click += new System.EventHandler(this.bTestEstimate_Click);
            // 
            // bBeginClasterize
            // 
            this.bBeginClasterize.BackColor = System.Drawing.Color.LightGreen;
            this.bBeginClasterize.Enabled = false;
            this.bBeginClasterize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBeginClasterize.Location = new System.Drawing.Point(192, 31);
            this.bBeginClasterize.Margin = new System.Windows.Forms.Padding(4);
            this.bBeginClasterize.Name = "bBeginClasterize";
            this.bBeginClasterize.Size = new System.Drawing.Size(195, 68);
            this.bBeginClasterize.TabIndex = 2;
            this.bBeginClasterize.Text = "Кластеризация";
            this.bBeginClasterize.UseVisualStyleBackColor = false;
            this.bBeginClasterize.Click += new System.EventHandler(this.bBeginClasterize_Click);
            // 
            // btnShowClusters
            // 
            this.btnShowClusters.BackColor = System.Drawing.Color.Thistle;
            this.btnShowClusters.Enabled = false;
            this.btnShowClusters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowClusters.Location = new System.Drawing.Point(293, 107);
            this.btnShowClusters.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowClusters.Name = "btnShowClusters";
            this.btnShowClusters.Size = new System.Drawing.Size(93, 68);
            this.btnShowClusters.TabIndex = 3;
            this.btnShowClusters.Text = "Таблица";
            this.btnShowClusters.UseVisualStyleBackColor = false;
            this.btnShowClusters.Click += new System.EventHandler(this.btnShowClusters_Click);
            // 
            // showClusterGraph
            // 
            this.showClusterGraph.BackColor = System.Drawing.Color.Thistle;
            this.showClusterGraph.Enabled = false;
            this.showClusterGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showClusterGraph.Location = new System.Drawing.Point(192, 107);
            this.showClusterGraph.Margin = new System.Windows.Forms.Padding(4);
            this.showClusterGraph.Name = "showClusterGraph";
            this.showClusterGraph.Size = new System.Drawing.Size(93, 68);
            this.showClusterGraph.TabIndex = 4;
            this.showClusterGraph.Text = "Граф";
            this.showClusterGraph.UseVisualStyleBackColor = false;
            this.showClusterGraph.Click += new System.EventHandler(this.showClusterGraph_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(431, 212);
            this.Controls.Add(this.showClusterGraph);
            this.Controls.Add(this.btnShowClusters);
            this.Controls.Add(this.bBeginClasterize);
            this.Controls.Add(this.bTestEstimate);
            this.Controls.Add(this.bLoadData);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ИАДиП Архиреев Солдаткин";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bLoadData;
        private System.Windows.Forms.OpenFileDialog dialogOpenDataFile;
        private System.Windows.Forms.Button bTestEstimate;
        private System.Windows.Forms.Button bBeginClasterize;
        private System.Windows.Forms.Button btnShowClusters;
        private System.Windows.Forms.Button showClusterGraph;
    }
}

