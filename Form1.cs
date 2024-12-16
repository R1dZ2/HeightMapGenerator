using System.Text.RegularExpressions;

namespace HeightMapGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSourcePath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDestinationPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnProcessFiles_Click(object sender, EventArgs e)
        {
            string sourcePath = txtSourcePath.Text;
            string destinationPath = txtDestinationPath.Text;

            if (string.IsNullOrWhiteSpace(sourcePath) || string.IsNullOrWhiteSpace(destinationPath))
            {
                MessageBox.Show("Please provide both source and destination paths.", "Error");
                return;
            }

            if (!Directory.Exists(sourcePath))
            {
                MessageBox.Show("Source folder does not exist.", "Error");
                return;
            }

            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
                MessageBox.Show("Destination folder created.");
            }

            ProcessFiles(sourcePath, destinationPath);
        }

        private void ProcessFiles(string sourcePath, string destinationPath)
        {
            var subfolders = Directory.GetDirectories(sourcePath);

            foreach (var subfolder in subfolders)
            {
                var files = Directory.GetFiles(subfolder);
                foreach (var filePath in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string extension = Path.GetExtension(filePath);
                    string pattern = @"^(.*)\.Terrain\.HeightMap\.(.*)$";

                    if (Regex.IsMatch(fileName, pattern))
                    {
                        var match = Regex.Match(fileName, pattern);
                        string prefix = match.Groups[1].Value;
                        string suffix = match.Groups[2].Value;

                        string[] suffixParts = suffix.Split('.');
                        if (suffixParts.Length >= 2)
                        {
                            string newSuffix = $"{string.Join(".", suffixParts.Take(suffixParts.Length - 2))}.-32768.32768.{string.Join(".", suffixParts.Skip(suffixParts.Length - 2))}";
                            string newFileName = $"{prefix}.HeightMap.{newSuffix}{extension}";
                            string newFilePath = Path.Combine(destinationPath, newFileName);

                            File.Move(filePath, newFilePath);
                            Log($"Renamed: {filePath} -> {newFileName}");
                        }
                    }
                }
            }
        }

        private void Log(string message)
        {
            txtLog.AppendText(message + Environment.NewLine);
        }

        private void txtSourcePath_TextChanged(object sender, EventArgs e)
        {
            // Optional: Add logic here if needed
        }
    }
}
