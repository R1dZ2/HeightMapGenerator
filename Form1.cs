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
            var allFiles = Directory.GetFiles(sourcePath, "*.dds", SearchOption.AllDirectories);

            foreach (var filePath in allFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string extension = Path.GetExtension(filePath);
                string pattern = @"^(.*)\.Terrain\.HeightMap\.(.*)$";

                if (Regex.IsMatch(fileName, pattern))
                {
                    var match = Regex.Match(fileName, pattern);
                    string prefix = match.Groups[1].Value; // Part before .Terrain
                    string suffix = match.Groups[2].Value; // Part after .HeightMap

                    string[] suffixParts = suffix.Split('.');
                    if (suffixParts.Length >= 2)
                    {
                        // Insert -32768.32768 before the last two parts
                        string newSuffix = $"{string.Join(".", suffixParts.Take(suffixParts.Length - 2))}.-32768.32768.{string.Join(".", suffixParts.Skip(suffixParts.Length - 2))}";
                        string newFileName = $"{prefix}.HeightMap.{newSuffix}{extension}";
                        string newFilePath = Path.Combine(destinationPath, newFileName);

                        // Check if the file already exists to prevent overwriting
                        if (File.Exists(newFilePath))
                        {
                            Log($"Skipped existing file: {newFilePath}");
                        }
                        else
                        {
                            // Copy the file to the destination
                            File.Copy(filePath, newFilePath);
                            Log($"Copied: {filePath} -> {newFilePath}");
                        }
                    }
                }
                else
                {
                    Log($"Skipped file (no match): {fileName}");
                }
            }

            MessageBox.Show("File processing complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
