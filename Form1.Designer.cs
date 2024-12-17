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

        private void InitializeComponent()
        {
            txtSourcePath = new TextBox();
            btnBrowseSource = new Button();
            txtDestinationPath = new TextBox();
            btnBrowseDestination = new Button();
            btnProcessFiles = new Button();
            txtLog = new TextBox();
            lblSourcePath = new Label();
            lblDestinationPath = new Label();
            SuspendLayout();
            // 
            // txtSourcePath
            // 
            txtSourcePath.Location = new Point(107, 12);
            txtSourcePath.Name = "txtSourcePath";
            txtSourcePath.Size = new Size(422, 23);
            txtSourcePath.TabIndex = 1;
            // 
            // btnBrowseSource
            // 
            btnBrowseSource.Location = new Point(535, 15);
            btnBrowseSource.Name = "btnBrowseSource";
            btnBrowseSource.Size = new Size(75, 23);
            btnBrowseSource.TabIndex = 2;
            btnBrowseSource.Text = "Browse...";
            btnBrowseSource.UseVisualStyleBackColor = true;
            btnBrowseSource.Click += btnBrowseSource_Click;
            // 
            // txtDestinationPath
            // 
            txtDestinationPath.Location = new Point(107, 47);
            txtDestinationPath.Name = "txtDestinationPath";
            txtDestinationPath.Size = new Size(422, 23);
            txtDestinationPath.TabIndex = 4;
            // 
            // btnBrowseDestination
            // 
            btnBrowseDestination.Location = new Point(535, 50);
            btnBrowseDestination.Name = "btnBrowseDestination";
            btnBrowseDestination.Size = new Size(75, 23);
            btnBrowseDestination.TabIndex = 5;
            btnBrowseDestination.Text = "Browse...";
            btnBrowseDestination.UseVisualStyleBackColor = true;
            btnBrowseDestination.Click += btnBrowseDestination_Click;
            // 
            // btnProcessFiles
            // 
            btnProcessFiles.Location = new Point(15, 80);
            btnProcessFiles.Name = "btnProcessFiles";
            btnProcessFiles.Size = new Size(595, 30);
            btnProcessFiles.TabIndex = 6;
            btnProcessFiles.Text = "Process Files";
            btnProcessFiles.UseVisualStyleBackColor = true;
            btnProcessFiles.Click += btnProcessFiles_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(15, 120);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(595, 200);
            txtLog.TabIndex = 7;
            // 
            // lblSourcePath
            // 
            lblSourcePath.AutoSize = true;
            lblSourcePath.Location = new Point(12, 15);
            lblSourcePath.Name = "lblSourcePath";
            lblSourcePath.Size = new Size(73, 15);
            lblSourcePath.TabIndex = 0;
            lblSourcePath.Text = "Source Path:";
            // 
            // lblDestinationPath
            // 
            lblDestinationPath.AutoSize = true;
            lblDestinationPath.Location = new Point(12, 50);
            lblDestinationPath.Name = "lblDestinationPath";
            lblDestinationPath.Size = new Size(97, 15);
            lblDestinationPath.TabIndex = 3;
            lblDestinationPath.Text = "Destination Path:";
            // 
            // Form1
            // 
            ClientSize = new Size(622, 340);
            Controls.Add(txtLog);
            Controls.Add(btnProcessFiles);
            Controls.Add(btnBrowseDestination);
            Controls.Add(txtDestinationPath);
            Controls.Add(lblDestinationPath);
            Controls.Add(btnBrowseSource);
            Controls.Add(txtSourcePath);
            Controls.Add(lblSourcePath);
            Name = "Form1";
            Text = "Height Map Generator";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
