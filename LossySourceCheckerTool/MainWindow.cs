using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace LossySourceCheckerTool
{
    public partial class MainWindow : Form
    {
        private const string appName = "Lossless File Source Checker";

        private int red = 0, green = 0;
        private const int COLOR_MAX_VALUE = 255;
        private string[] allowedFormats = { ".wav", ".flac" };
        private string tempPath;

        private bool isProcessing = false;

        private void updateHeader()
        {
            this.Text = appName + " - " + fileListDataGridView.Rows.Count + " files selected";
        }

        private string convertFlacToWav(string fileName)
        {
            string result = null;
            string simpleFileName = Path.GetFileNameWithoutExtension(fileName);
            result = tempPath + simpleFileName + ".wav";

            string parameterString = "-d \"" + fileName + "\" -o \"" + result + "\"";

            LaunchEXE.Run(tempPath + "LossySourceCheckerTool.flac.exe", parameterString, 0);

            return result;
        }

        private void updateColorValues()
        {
            double redWeight = COLOR_MAX_VALUE * (Convert.ToDouble(detectModeTrackBar.Value) / 40);
            red = Convert.ToInt32(redWeight);
            green = COLOR_MAX_VALUE - red;
            detectModeValueLabel.ForeColor = Color.FromArgb(red, green, 0);
        }

        private bool isAlreadyAdded(String fileName)
        {
            bool result = false;
            foreach (DataGridViewRow row in fileListDataGridView.Rows)
            {
                if (row.Cells["fileName"].Value == null) continue;
                string rowValue = row.Cells["fileName"].Value.ToString();
                if (fileName == rowValue) result = true;
            }
            return result;
        }

        private bool isValidFileFormat(String fileName)
        {
            bool result = false;
            foreach (string format in allowedFormats)
            {
                if (fileName.EndsWith(format)) result = true;
            }
            return result;
        }

        private int parseResult(string resultString)
        {
            int result = 0;

            int percentageIndex = resultString.LastIndexOf("%");
            int spaceIndex = resultString.LastIndexOf(" ");

            if (resultString.Contains("This track looks like MPEG with probability"))
            {
                result = (-1) * Convert.ToInt32(resultString.Substring(spaceIndex, percentageIndex - spaceIndex));
            }
            else if (resultString.Contains("This track looks like CDDA with probability"))
            {
                result = Convert.ToInt32(resultString.Substring(spaceIndex, percentageIndex - spaceIndex));
            }
            else
            {
                throw new Exception("File could not be read.");
            }
            return result;
        }

        private void addFilesToTable(string[] fileNames)
        {
            List<string> allFiles = new List<string>();

            foreach (string fileName in fileNames)
            {
                FileAttributes attr = File.GetAttributes(fileName);

                // is it a directory?
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    foreach (string format in allowedFormats)
                    {
                        string[] filePaths = Directory.GetFiles(fileName, "*" + format, SearchOption.AllDirectories);
                        foreach (string fn in filePaths)
                        {
                            if (!isAlreadyAdded(fn) && isValidFileFormat(fn))
                                allFiles.Add(fn);
                        }

                    }
                }
                else
                {
                    if (!isAlreadyAdded(fileName) && isValidFileFormat(fileName))
                        allFiles.Add(fileName);
                }
            }
            foreach (string currentFile in allFiles)
            {
                fileListDataGridView.Rows.Add(currentFile, "Not processed");
            }
        }

        private void recreateAllExecutableResources()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string[] arrResources = currentAssembly.GetManifestResourceNames();

            foreach (string resourceName in arrResources)
            {
                if (resourceName.EndsWith(".exe"))
                {
                    string saveAsName = resourceName;
                    FileInfo fileInfoOutputFile = new FileInfo(tempPath + saveAsName);
                    if (!fileInfoOutputFile.Exists)
                    {
                        FileStream streamToOutputFile = fileInfoOutputFile.OpenWrite();
                        Stream streamToResourceFile =
                                            currentAssembly.GetManifestResourceStream(resourceName);

                        const int size = 4096;
                        byte[] bytes = new byte[4096];
                        int numBytes;
                        while ((numBytes = streamToResourceFile.Read(bytes, 0, size)) > 0)
                        {
                            streamToOutputFile.Write(bytes, 0, numBytes);
                        }

                        streamToOutputFile.Close();
                        streamToResourceFile.Close();
                    }
                }

            }
        }

        private void removeAllExecutableResources()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string[] arrResources = currentAssembly.GetManifestResourceNames();

            foreach (string resourceName in arrResources)
            {
                if (resourceName.EndsWith(".exe"))
                {
                    string saveAsName = resourceName;
                    FileInfo fileInfoOutputFile = new FileInfo(tempPath + saveAsName);
                    if (fileInfoOutputFile.Exists)
                    {
                        fileInfoOutputFile.Delete();
                    }
                }
            }
        }


        // ----------------------------- GENERATED ---------------------------------------------

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            tempPath = System.IO.Path.GetTempPath();
            detectModeValueLabel.Text = detectModeTrackBar.Value.ToString();
            updateColorValues();
            updateHeader();
            recreateAllExecutableResources();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                checkerBackgroundWorker.CancelAsync();
            }
            else
            {
                if (fileListDataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No files to process!");
                }
                else
                {
                    recreateAllExecutableResources();
                    checkButton.Text = "STOP!";
                    checkerBackgroundWorker.RunWorkerAsync(detectModeTrackBar.Value);
                }
            }
        }



        private void detectModeTrackBar_Scroll(object sender, EventArgs e)
        {
            detectModeValueLabel.Text = detectModeTrackBar.Value.ToString();
            updateColorValues();
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }



        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            addFilesToTable(fileNames);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkerBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            isProcessing = true;
            foreach (DataGridViewRow row in fileListDataGridView.Rows)
            {
                try
                {
                    string fileName = row.Cells["fileName"].Value.ToString();
                    bool isFlac = false;

                    row.Cells["result"].Style.ForeColor = Color.Black;

                    if (fileName.EndsWith(".flac"))
                    {
                        isFlac = true;
                        row.Cells["result"].Value = "Decoding...";
                        fileName = convertFlacToWav(fileName);
                    }


                    row.Cells["result"].Value = "Checking...";
                    string parameterString = "\"" + fileName + "\" -m" + e.Argument.ToString();

                    string result = LaunchEXE.Run(tempPath + "LossySourceCheckerTool.auCDtect.exe", parameterString, 0);


                    int losslessProbability = parseResult(result);
                    if (losslessProbability > 0)
                    {
                        row.Cells["result"].Style.ForeColor = Color.DarkGreen;
                        row.Cells["result"].Value = "Lossless (CDDA) with probability " + losslessProbability + "%";
                    }
                    else
                    {
                        row.Cells["result"].Style.ForeColor = Color.Red;
                        row.Cells["result"].Value = "Lossy (MPEG) with probability " + (-losslessProbability) + "%";
                    }


                    if (isFlac)
                    {
                        File.Delete(fileName);
                    }
                }
                catch (Exception ex)
                {
                    row.Cells["result"].Value = "Error on checking file : " + ex.Message;
                }

                if (checkerBackgroundWorker.CancellationPending)
                {
                    isProcessing = false;
                    return;
                }
            }

            isProcessing = false;
        }



        private void checkerBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            checkButton.Text = "START!";
        }

        private void addFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "FLAC Files|*.flac|WAVE Files|*.wav";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] fileNames = openFileDialog.FileNames;
                addFilesToTable(fileNames);
            }
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            fileListDataGridView.Rows.Clear();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            removeAllExecutableResources();
        }

        private void fileListDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            updateHeader();
        }

        private void fileListDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateHeader();
        }
    }
}
