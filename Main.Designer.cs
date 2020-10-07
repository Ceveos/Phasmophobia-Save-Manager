namespace Phasmophobia_Save_Manager
{
    partial class Main
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
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btOpenSaveDirectory = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(12, 12);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(358, 31);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "Start Save File Monitor";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Enabled = false;
            this.btStop.Location = new System.Drawing.Point(12, 49);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(358, 31);
            this.btStop.TabIndex = 1;
            this.btStop.Text = "Stop Save File Monitor";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Location = new System.Drawing.Point(12, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 40);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(6, 16);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(38, 13);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "Ready";
            // 
            // btOpenSaveDirectory
            // 
            this.btOpenSaveDirectory.Location = new System.Drawing.Point(13, 86);
            this.btOpenSaveDirectory.Name = "btOpenSaveDirectory";
            this.btOpenSaveDirectory.Size = new System.Drawing.Size(358, 31);
            this.btOpenSaveDirectory.TabIndex = 3;
            this.btOpenSaveDirectory.Text = "Open Save Folder";
            this.btOpenSaveDirectory.UseVisualStyleBackColor = true;
            this.btOpenSaveDirectory.Click += new System.EventHandler(this.btOpenSaveDirectory_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 185);
            this.Controls.Add(this.btOpenSaveDirectory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phasmophobia Save Manager";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btOpenSaveDirectory;
    }
}

