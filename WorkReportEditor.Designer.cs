namespace NEXUS.SCG.TOOLS
{
    partial class WorkReportEditor
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkReportEditor));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnImportCsv = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxExcelSheets = new System.Windows.Forms.ComboBox();
            this.WorkDataGridView = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.WorkDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpenFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOpenFile.FlatAppearance.BorderSize = 0;
            this.btnOpenFile.ForeColor = System.Drawing.Color.Black;
            this.btnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.Image")));
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(32, 32);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.FlatAppearance.BorderSize = 0;
            this.btnSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveFile.Image")));
            this.btnSaveFile.Location = new System.Drawing.Point(50, 12);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(34, 32);
            this.btnSaveFile.TabIndex = 1;
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnImportCsv
            // 
            this.btnImportCsv.FlatAppearance.BorderSize = 0;
            this.btnImportCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnImportCsv.Image")));
            this.btnImportCsv.Location = new System.Drawing.Point(99, 12);
            this.btnImportCsv.Name = "btnImportCsv";
            this.btnImportCsv.Size = new System.Drawing.Size(32, 32);
            this.btnImportCsv.TabIndex = 2;
            this.btnImportCsv.UseVisualStyleBackColor = true;
            this.btnImportCsv.Click += new System.EventHandler(this.btnImportCsv_Click);
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.FlatAppearance.BorderSize = 0;
            this.btnExportCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnExportCsv.Image")));
            this.btnExportCsv.Location = new System.Drawing.Point(139, 12);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(32, 32);
            this.btnExportCsv.TabIndex = 3;
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "表示ファイル";
            // 
            // lblFileName
            // 
            this.lblFileName.Location = new System.Drawing.Point(76, 57);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(309, 15);
            this.lblFileName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "表示シート";
            // 
            // cbxExcelSheets
            // 
            this.cbxExcelSheets.FormattingEnabled = true;
            this.cbxExcelSheets.Location = new System.Drawing.Point(464, 53);
            this.cbxExcelSheets.Name = "cbxExcelSheets";
            this.cbxExcelSheets.Size = new System.Drawing.Size(324, 20);
            this.cbxExcelSheets.TabIndex = 7;
            // 
            // WorkDataGridView
            // 
            this.WorkDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WorkDataGridView.Location = new System.Drawing.Point(12, 79);
            this.WorkDataGridView.Name = "WorkDataGridView";
            this.WorkDataGridView.RowTemplate.Height = 21;
            this.WorkDataGridView.Size = new System.Drawing.Size(776, 359);
            this.WorkDataGridView.TabIndex = 8;
            // 
            // WorkReportEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.WorkDataGridView);
            this.Controls.Add(this.cbxExcelSheets);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportCsv);
            this.Controls.Add(this.btnImportCsv);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "WorkReportEditor";
            this.Text = "勤怠予実エディタ";
            this.Load += new System.EventHandler(this.WorkReportEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WorkDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnImportCsv;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxExcelSheets;
        private System.Windows.Forms.DataGridView WorkDataGridView;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

