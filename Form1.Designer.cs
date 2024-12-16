namespace HeightMapGenerator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // UI Controls
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.Button btnProcessFiles;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblSourcePath;
        private System.Windows.Forms.Label lblDestinationPath;

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.btnProcessFiles = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblSourcePath = new System.Windows.Forms.Label();
            this.lblDestinationPath = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Source Path Label
            this.lblSourcePath.AutoSize = true;
            this.lblSourcePath.Location = new System.Drawing.Point(12, 15);
            this.lblSourcePath.Name = "lblSourcePath";
            this.lblSourcePath.Size = new System.Drawing.Size(71, 13);
            this.lblSourcePath.TabIndex = 0;
            this.lblSourcePath.Text = "Source Path:";

            // Source Path TextBox
            this.txtSourcePath.Location = new System.Drawing.Point(100, 12);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(300, 20);
            this.txtSourcePath.TabIndex = 1;

            // Browse Source Button
            this.btnBrowseSource.Location = new System.Drawing.Point(410, 10);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSource.TabIndex = 2;
            this.btnBrowseSource.Text = "Browse...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);

            // Destination Path Label
            this.lblDestinationPath.AutoSize = true;
            this.lblDestinationPath.Location = new System.Drawing.Point(12, 50);
            this.lblDestinationPath.Name = "lblDestinationPath";
            this.lblDestinationPath.Size = new System.Drawing.Size(92, 13);
            this.lblDestinationPath.TabIndex = 3;
            this.lblDestinationPath.Text = "Destination Path:";

            // Destination Path TextBox
            this.txtDestinationPath.Location = new System.Drawing.Point(100, 47);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.Size = new System.Drawing.Size(300, 20);
            this.txtDestinationPath.TabIndex = 4;

            // Browse Destination Button
            this.btnBrowseDestination.Location = new System.Drawing.Point(410, 45);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDestination.TabIndex = 5;
            this.btnBrowseDestination.Text = "Browse...";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);

            // Process Files Button
            this.btnProcessFiles.Location = new System.Drawing.Point(15, 80);
            this.btnProcessFiles.Name = "btnProcessFiles";
            this.btnProcessFiles.Size = new System.Drawing.Size(470, 30);
            this.btnProcessFiles.TabIndex = 6;
            this.btnProcessFiles.Text = "Process Files";
            this.btnProcessFiles.UseVisualStyleBackColor = true;
            this.btnProcessFiles.Click += new System.EventHandler(this.btnProcessFiles_Click);

            // Log TextBox
            this.txtLog.Location = new System.Drawing.Point(15, 120);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(470, 200);
            this.txtLog.TabIndex = 7;

            // Form1
            this.ClientSize = new System.Drawing.Size(500, 340);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnProcessFiles);
            this.Controls.Add(this.btnBrowseDestination);
            this.Controls.Add(this.txtDestinationPath);
            this.Controls.Add(this.lblDestinationPath);
            this.Controls.Add(this.btnBrowseSource);
            this.Controls.Add(this.txtSourcePath);
            this.Controls.Add(this.lblSourcePath);
            this.Name = "Form1";
            this.Text = "File Processor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
