namespace FileSearchApp2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txbDirectoryPath = new System.Windows.Forms.TextBox();
            this.buDirectoryPath = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buLoadDirectory = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buPause = new System.Windows.Forms.Button();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.laCurDir = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.laTimer = new System.Windows.Forms.Label();
            this.laFilesCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbDirectoryPath
            // 
            this.txbDirectoryPath.Location = new System.Drawing.Point(12, 12);
            this.txbDirectoryPath.Name = "txbDirectoryPath";
            this.txbDirectoryPath.Size = new System.Drawing.Size(695, 22);
            this.txbDirectoryPath.TabIndex = 0;
            // 
            // buDirectoryPath
            // 
            this.buDirectoryPath.Location = new System.Drawing.Point(713, 11);
            this.buDirectoryPath.Name = "buDirectoryPath";
            this.buDirectoryPath.Size = new System.Drawing.Size(75, 23);
            this.buDirectoryPath.TabIndex = 1;
            this.buDirectoryPath.Text = "...";
            this.buDirectoryPath.UseVisualStyleBackColor = true;
            this.buDirectoryPath.Click += new System.EventHandler(this.buDirectoryPath_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 51);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(776, 440);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "file.png");
            // 
            // buLoadDirectory
            // 
            this.buLoadDirectory.Location = new System.Drawing.Point(530, 497);
            this.buLoadDirectory.Name = "buLoadDirectory";
            this.buLoadDirectory.Size = new System.Drawing.Size(75, 23);
            this.buLoadDirectory.TabIndex = 4;
            this.buLoadDirectory.Text = "Поиск";
            this.buLoadDirectory.UseVisualStyleBackColor = true;
            this.buLoadDirectory.Click += new System.EventHandler(this.buLoadDirectory_Click);
            // 
            // buPause
            // 
            this.buPause.Enabled = false;
            this.buPause.Location = new System.Drawing.Point(611, 497);
            this.buPause.Name = "buPause";
            this.buPause.Size = new System.Drawing.Size(177, 23);
            this.buPause.TabIndex = 5;
            this.buPause.Text = "Приостановить поиск";
            this.buPause.UseVisualStyleBackColor = true;
            this.buPause.Click += new System.EventHandler(this.buPause_Click);
            // 
            // txbSearch
            // 
            this.txbSearch.Location = new System.Drawing.Point(12, 498);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(512, 22);
            this.txbSearch.TabIndex = 6;
            // 
            // laCurDir
            // 
            this.laCurDir.AutoSize = true;
            this.laCurDir.Location = new System.Drawing.Point(12, 555);
            this.laCurDir.Name = "laCurDir";
            this.laCurDir.Size = new System.Drawing.Size(0, 16);
            this.laCurDir.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // laTimer
            // 
            this.laTimer.AutoSize = true;
            this.laTimer.Location = new System.Drawing.Point(12, 539);
            this.laTimer.Name = "laTimer";
            this.laTimer.Size = new System.Drawing.Size(0, 16);
            this.laTimer.TabIndex = 8;
            // 
            // laFilesCount
            // 
            this.laFilesCount.AutoSize = true;
            this.laFilesCount.Location = new System.Drawing.Point(12, 523);
            this.laFilesCount.Name = "laFilesCount";
            this.laFilesCount.Size = new System.Drawing.Size(0, 16);
            this.laFilesCount.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 612);
            this.Controls.Add(this.laFilesCount);
            this.Controls.Add(this.laTimer);
            this.Controls.Add(this.laCurDir);
            this.Controls.Add(this.txbSearch);
            this.Controls.Add(this.buPause);
            this.Controls.Add(this.buLoadDirectory);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.buDirectoryPath);
            this.Controls.Add(this.txbDirectoryPath);
            this.MaximumSize = new System.Drawing.Size(818, 659);
            this.MinimumSize = new System.Drawing.Size(818, 659);
            this.Name = "Form1";
            this.Text = "Поиск файлов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbDirectoryPath;
        private System.Windows.Forms.Button buDirectoryPath;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buLoadDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buPause;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.Label laCurDir;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label laTimer;
        private System.Windows.Forms.Label laFilesCount;
    }
}

