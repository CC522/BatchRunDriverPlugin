namespace BatchRunDriverPluginUI
{
    partial class BatchRunDriverPluginTool
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTestDataPath = new System.Windows.Forms.TextBox();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.btnBrowse1 = new System.Windows.Forms.Button();
            this.btnBrowse2 = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnReRun = new System.Windows.Forms.Button();
            this.btnMapping = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboRunTimeValues = new System.Windows.Forms.ComboBox();
            this.btnShowRunTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ChooseTestDataPath: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ChooseOutputPath: ";
            // 
            // txtTestDataPath
            // 
            this.txtTestDataPath.Location = new System.Drawing.Point(154, 29);
            this.txtTestDataPath.Name = "txtTestDataPath";
            this.txtTestDataPath.Size = new System.Drawing.Size(344, 20);
            this.txtTestDataPath.TabIndex = 2;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(154, 71);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(344, 20);
            this.txtOutputPath.TabIndex = 3;
            // 
            // btnBrowse1
            // 
            this.btnBrowse1.Location = new System.Drawing.Point(520, 25);
            this.btnBrowse1.Name = "btnBrowse1";
            this.btnBrowse1.Size = new System.Drawing.Size(94, 23);
            this.btnBrowse1.TabIndex = 4;
            this.btnBrowse1.Text = "Browse";
            this.btnBrowse1.UseVisualStyleBackColor = true;
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.Location = new System.Drawing.Point(520, 68);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(94, 23);
            this.btnBrowse2.TabIndex = 5;
            this.btnBrowse2.Text = "Browse";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(154, 174);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnReRun
            // 
            this.btnReRun.Location = new System.Drawing.Point(298, 174);
            this.btnReRun.Name = "btnReRun";
            this.btnReRun.Size = new System.Drawing.Size(75, 23);
            this.btnReRun.TabIndex = 7;
            this.btnReRun.Text = "ReRun";
            this.btnReRun.UseVisualStyleBackColor = true;
            this.btnReRun.Click += new System.EventHandler(this.btnReRun_Click);
            // 
            // btnMapping
            // 
            this.btnMapping.Location = new System.Drawing.Point(431, 174);
            this.btnMapping.Name = "btnMapping";
            this.btnMapping.Size = new System.Drawing.Size(75, 23);
            this.btnMapping.TabIndex = 8;
            this.btnMapping.Text = "Mapping";
            this.btnMapping.UseVisualStyleBackColor = true;
            this.btnMapping.Click += new System.EventHandler(this.btnMapping_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Choose RunTime for Run:";
            // 
            // cboRunTimeValues
            // 
            this.cboRunTimeValues.FormattingEnabled = true;
            this.cboRunTimeValues.Location = new System.Drawing.Point(154, 114);
            this.cboRunTimeValues.Name = "cboRunTimeValues";
            this.cboRunTimeValues.Size = new System.Drawing.Size(144, 21);
            this.cboRunTimeValues.TabIndex = 10;
            this.cboRunTimeValues.Visible = false;
            // 
            // btnShowRunTime
            // 
            this.btnShowRunTime.Location = new System.Drawing.Point(520, 114);
            this.btnShowRunTime.Name = "btnShowRunTime";
            this.btnShowRunTime.Size = new System.Drawing.Size(94, 23);
            this.btnShowRunTime.TabIndex = 11;
            this.btnShowRunTime.Text = "ShowRunTime";
            this.btnShowRunTime.UseVisualStyleBackColor = true;
            this.btnShowRunTime.Click += new System.EventHandler(this.btnShowRunTime_Click);
            // 
            // BatchRunDriverPluginTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 231);
            this.Controls.Add(this.btnShowRunTime);
            this.Controls.Add(this.cboRunTimeValues);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMapping);
            this.Controls.Add(this.btnReRun);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnBrowse2);
            this.Controls.Add(this.btnBrowse1);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.txtTestDataPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BatchRunDriverPluginTool";
            this.Text = "BatchRunDriverPlugin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTestDataPath;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button btnBrowse1;
        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnReRun;
        private System.Windows.Forms.Button btnMapping;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboRunTimeValues;
        private System.Windows.Forms.Button btnShowRunTime;
    }
}

