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
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ChooseOutputPath: ";
            // 
            // txtTestDataPath
            // 
            this.txtTestDataPath.Location = new System.Drawing.Point(154, 29);
            this.txtTestDataPath.Name = "txtTestDataPath";
            this.txtTestDataPath.Size = new System.Drawing.Size(352, 20);
            this.txtTestDataPath.TabIndex = 2;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(154, 75);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(352, 20);
            this.txtOutputPath.TabIndex = 3;
            // 
            // btnBrowse1
            // 
            this.btnBrowse1.Location = new System.Drawing.Point(539, 25);
            this.btnBrowse1.Name = "btnBrowse1";
            this.btnBrowse1.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse1.TabIndex = 4;
            this.btnBrowse1.Text = "Browse";
            this.btnBrowse1.UseVisualStyleBackColor = true;
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.Location = new System.Drawing.Point(539, 72);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse2.TabIndex = 5;
            this.btnBrowse2.Text = "Browse";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(154, 157);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnReRun
            // 
            this.btnReRun.Location = new System.Drawing.Point(298, 157);
            this.btnReRun.Name = "btnReRun";
            this.btnReRun.Size = new System.Drawing.Size(75, 23);
            this.btnReRun.TabIndex = 7;
            this.btnReRun.Text = "ReRun";
            this.btnReRun.UseVisualStyleBackColor = true;
            this.btnReRun.Click += new System.EventHandler(this.btnReRun_Click);
            // 
            // btnMapping
            // 
            this.btnMapping.Location = new System.Drawing.Point(431, 157);
            this.btnMapping.Name = "btnMapping";
            this.btnMapping.Size = new System.Drawing.Size(75, 23);
            this.btnMapping.TabIndex = 8;
            this.btnMapping.Text = "Mapping";
            this.btnMapping.UseVisualStyleBackColor = true;
            this.btnMapping.Click += new System.EventHandler(this.btnMapping_Click);
            // 
            // BatchRunDriverPluginTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 231);
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
    }
}

