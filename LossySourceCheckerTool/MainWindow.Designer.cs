namespace LossySourceCheckerTool
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.checkButton = new System.Windows.Forms.Button();
            this.fileListDataGridView = new System.Windows.Forms.DataGridView();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detectModeTrackBar = new System.Windows.Forms.TrackBar();
            this.detectModeLabel = new System.Windows.Forms.Label();
            this.detectModeLevelLabel = new System.Windows.Forms.Label();
            this.detectModeValueLabel = new System.Windows.Forms.Label();
            this.checkerBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.addFilesButton = new System.Windows.Forms.Button();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.fileListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectModeTrackBar)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(535, 10);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(134, 23);
            this.checkButton.TabIndex = 0;
            this.checkButton.Text = "CHECK!";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // fileListDataGridView
            // 
            this.fileListDataGridView.AllowUserToAddRows = false;
            this.fileListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fileListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileName,
            this.result});
            this.fileListDataGridView.Location = new System.Drawing.Point(0, 0);
            this.fileListDataGridView.Name = "fileListDataGridView";
            this.fileListDataGridView.Size = new System.Drawing.Size(681, 411);
            this.fileListDataGridView.TabIndex = 1;
            this.fileListDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.fileListDataGridView_RowsAdded);
            this.fileListDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.fileListDataGridView_RowsRemoved);
            // 
            // fileName
            // 
            this.fileName.HeaderText = "File Name";
            this.fileName.Name = "fileName";
            // 
            // result
            // 
            this.result.FillWeight = 50F;
            this.result.HeaderText = "Result";
            this.result.Name = "result";
            // 
            // detectModeTrackBar
            // 
            this.detectModeTrackBar.Location = new System.Drawing.Point(15, 32);
            this.detectModeTrackBar.Maximum = 40;
            this.detectModeTrackBar.Name = "detectModeTrackBar";
            this.detectModeTrackBar.Size = new System.Drawing.Size(398, 45);
            this.detectModeTrackBar.TabIndex = 4;
            this.detectModeTrackBar.Value = 8;
            this.detectModeTrackBar.Scroll += new System.EventHandler(this.detectModeTrackBar_Scroll);
            // 
            // detectModeLabel
            // 
            this.detectModeLabel.AutoSize = true;
            this.detectModeLabel.Location = new System.Drawing.Point(12, 16);
            this.detectModeLabel.Name = "detectModeLabel";
            this.detectModeLabel.Size = new System.Drawing.Size(401, 13);
            this.detectModeLabel.TabIndex = 5;
            this.detectModeLabel.Text = "Detect Mode (min. 0, max. 40, default 8, lower values are slower but more accurat" +
    "e)";
            // 
            // detectModeLevelLabel
            // 
            this.detectModeLevelLabel.AutoSize = true;
            this.detectModeLevelLabel.Location = new System.Drawing.Point(416, 50);
            this.detectModeLevelLabel.Name = "detectModeLevelLabel";
            this.detectModeLevelLabel.Size = new System.Drawing.Size(101, 13);
            this.detectModeLevelLabel.TabIndex = 6;
            this.detectModeLevelLabel.Text = "Detect Mode Level:";
            // 
            // detectModeValueLabel
            // 
            this.detectModeValueLabel.AutoSize = true;
            this.detectModeValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.detectModeValueLabel.ForeColor = System.Drawing.Color.Black;
            this.detectModeValueLabel.Location = new System.Drawing.Point(523, 45);
            this.detectModeValueLabel.Name = "detectModeValueLabel";
            this.detectModeValueLabel.Size = new System.Drawing.Size(18, 20);
            this.detectModeValueLabel.TabIndex = 7;
            this.detectModeValueLabel.Text = "8";
            // 
            // checkerBackgroundWorker
            // 
            this.checkerBackgroundWorker.WorkerSupportsCancellation = true;
            this.checkerBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkerBackgroundWorker_DoWork);
            this.checkerBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.checkerBackgroundWorker_RunWorkerCompleted);
            // 
            // addFilesButton
            // 
            this.addFilesButton.Location = new System.Drawing.Point(419, 10);
            this.addFilesButton.Name = "addFilesButton";
            this.addFilesButton.Size = new System.Drawing.Size(110, 23);
            this.addFilesButton.TabIndex = 8;
            this.addFilesButton.Text = "Add Files";
            this.addFilesButton.UseVisualStyleBackColor = true;
            this.addFilesButton.Click += new System.EventHandler(this.addFilesButton_Click);
            // 
            // clearAllButton
            // 
            this.clearAllButton.Location = new System.Drawing.Point(547, 40);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(121, 27);
            this.clearAllButton.TabIndex = 9;
            this.clearAllButton.Text = "Clear all";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.detectModeLabel);
            this.bottomPanel.Controls.Add(this.detectModeValueLabel);
            this.bottomPanel.Controls.Add(this.clearAllButton);
            this.bottomPanel.Controls.Add(this.checkButton);
            this.bottomPanel.Controls.Add(this.addFilesButton);
            this.bottomPanel.Controls.Add(this.detectModeTrackBar);
            this.bottomPanel.Controls.Add(this.detectModeLevelLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 417);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(681, 79);
            this.bottomPanel.TabIndex = 10;
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 496);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.fileListDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Lossless File Source Checker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.fileListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectModeTrackBar)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.DataGridView fileListDataGridView;
        private System.Windows.Forms.TrackBar detectModeTrackBar;
        private System.Windows.Forms.Label detectModeLabel;
        private System.Windows.Forms.Label detectModeLevelLabel;
        private System.Windows.Forms.Label detectModeValueLabel;
        private System.ComponentModel.BackgroundWorker checkerBackgroundWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.Button addFilesButton;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.Panel bottomPanel;
    }
}

