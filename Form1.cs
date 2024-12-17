using System.Text.RegularExpressions;

namespace HeightMapGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Browse Source button click event.
        /// Sets Destination Path to SourcePath\HeightMaps_Output\textures\HeightMaps.
        /// </summary>
        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSourcePath.Text = folderBrowserDialog.SelectedPath;

                    // Auto-set the destination path
                    string outputPath = Path.Combine(folderBrowserDialog.SelectedPath, "HeightMaps_Output", "textures", "HeightMaps");
                    txtDestinationPath.Text = outputPath;
                }
            }
        }

        /// <summary>
        /// Handles Browse Destination button click event.
        /// Allows users to modify the output path manually.
        /// </summary>
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

        /// <summary>
        /// Handles Process Files button click event.
        /// Processes the files into the DestinationPath.
        /// </summary>
        private void btnProcessFiles_Click(object sender, EventArgs e)
        {
            string sourcePath = txtSourcePath.Text;
            string destinationPath = txtDestinationPath.Text;

            // Validate paths
            if (string.IsNullOrWhiteSpace(sourcePath) || !Directory.Exists(sourcePath))
            {
                MessageBox.Show("Please provide a valid source folder.", "Error");
                return;
            }

            if (string.IsNullOrWhiteSpace(destinationPath))
            {
                MessageBox.Show("Please provide a valid destination folder.", "Error");
                return;
            }

            try
            {
                // Ensure the destination directory exists
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                ProcessFiles(sourcePath, destinationPath);
                MessageBox.Show("Files processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Processes the files from Source Path and saves them into the Destination Path.
        /// </summary>
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
                    string prefix = match.Groups[1].Value;
                    string suffix = match.Groups[2].Value;

                    string[] suffixParts = suffix.Split('.');
                    if (suffixParts.Length >= 2)
                    {
                        string newSuffix = $"{string.Join(".", suffixParts.Take(suffixParts.Length - 2))}.-32768.32768.{string.Join(".", suffixParts.Skip(suffixParts.Length - 2))}";
                        string newFileName = $"{prefix}.HeightMap.{newSuffix}{extension}";
                        string newFilePath = Path.Combine(destinationPath, newFileName);

                        if (!File.Exists(newFilePath))
                        {
                            File.Copy(filePath, newFilePath);
                            Log($"Copied: {filePath} -> {newFilePath}");
                        }
                        else
                        {
                            Log($"Skipped existing file: {newFilePath}");
                        }
                    }
                }
                else
                {
                    Log($"Skipped file: {fileName}");
                }
            }
        }

        /// <summary>
        /// Logs messages to the Log TextBox.
        /// </summary>
        private void Log(string message)
        {
            txtLog.AppendText(message + Environment.NewLine);
        }
    }
}