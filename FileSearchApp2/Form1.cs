using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace FileSearchApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (StreamReader reader = new StreamReader(path)) // Считывание директории и шаблона поиска из файла
            {
                txbDirectoryPath.Text = reader.ReadLine();
                txbSearch.Text = reader.ReadLine();
            }
        }
        Thread thread;
        string path = "../var.txt"; // путь к файлу директории и шаблона поиска
        DateTime timeStart; // Время запуска поиска
        TimeSpan timeSum; // Суммарное время поиска
        int FilesCountCur; // Количество найденных файлов
        bool ThreadStateForPause = false; // Состояние потока для кнопки паузы поиска
        private void buDirectoryPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txbDirectoryPath.Text; // Выбор директории поиска
            DialogResult drResult = folderBrowserDialog1.ShowDialog();
            if (drResult == System.Windows.Forms.DialogResult.OK)
            {
                txbDirectoryPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void buLoadDirectory_Click(object sender, EventArgs e)
        {
            if(thread != null) // Очистка переменных
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }
            timer1.Enabled = false;
            ThreadStateForPause = false;
            buPause.Enabled = false;
            buPause.Text = "Приостановить поиск";
            // Очистка дерева
            treeView1.Nodes.Clear();
            thread = new Thread(() => LoadDirectory(txbDirectoryPath.Text, txbSearch.Text)) { IsBackground = true };
            if (txbDirectoryPath.Text != "" && Directory.Exists(txbDirectoryPath.Text)) // Запуск поиска
            {
                thread.Start();
                timeStart = DateTime.Now;
                timeSum = new TimeSpan();
                timer1.Enabled = true;
                ThreadStateForPause = true;
                buPause.Enabled = true;
            }
            else
            {
                MessageBox.Show("Выберите директорию для поиска");
            }
        }
        private void LoadDirectory(string Dir, string Pattern) // Проверка стартовой директории
        {
            DirectoryInfo di = new DirectoryInfo(Dir);
            laCurDir.Invoke(new Action(() => laCurDir.Text = "Текущая директория поиска: " + di.FullName));
            FilesCountCur = 0;
            TreeNode tds = new TreeNode();
            treeView1.Invoke(new Action(() => tds = treeView1.Nodes.Add(di.Name)));
            treeView1.Invoke(new Action(() => tds.Tag = di.FullName));
            treeView1.Invoke(new Action(() => tds.StateImageIndex = 0));
            LoadFiles(Dir, tds, Pattern);
            LoadSubDirectories(Dir, tds, Pattern);
            timer1.Enabled = false;
            buPause.Invoke(new Action(() => buPause.Enabled = false));
            ThreadStateForPause = false;
        }
        private void LoadSubDirectories(string dir, TreeNode td, string pattern) // Проверка подпапок директории
        {
            // Получение подпапок текущей папки
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            // Проверка подпапок на наличие у них своих подпапок
            foreach (string subdirectory in subdirectoryEntries)
            {
                try
                {
                    if (Directory.GetFiles(subdirectory, pattern, SearchOption.AllDirectories).Length > 0)
                    {
                        DirectoryInfo di = new DirectoryInfo(subdirectory);
                        laCurDir.Invoke(new Action(() => laCurDir.Text = "Текущая директория поиска: " + di.FullName));
                        TreeNode tds = new TreeNode();
                        treeView1.Invoke(new Action(() => tds = td.Nodes.Add(di.Name)));
                        treeView1.Invoke(new Action(() => tds.Tag = di.FullName));
                        treeView1.Invoke(new Action(() => tds.StateImageIndex = 0));
                        LoadFiles(subdirectory, tds, pattern);
                        LoadSubDirectories(subdirectory, tds, pattern);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
            }
        }
        private void LoadFiles(string dir, TreeNode td, string pattern) // Проверка файлов директории
        {
            try
            {
                string[] Files = Directory.GetFiles(dir, pattern);
                // Проверка папки на наличие файлов
                foreach (string file in Files)
                {
                    FileInfo fi = new FileInfo(file);
                    FilesCountCur++;
                    TreeNode tds = new TreeNode();
                    treeView1.Invoke(new Action(() => tds = td.Nodes.Add(fi.Name)));
                    treeView1.Invoke(new Action(() => tds.Tag = fi.FullName));
                    treeView1.Invoke(new Action(() => tds.StateImageIndex = 1));
                    laFilesCount.Invoke(new Action(() => laFilesCount.Text = FilesCountCur.ToString() + " файлов найдено"));
                }
            }
            catch (UnauthorizedAccessException)
            {
                ;
            }
        }
        private void buPause_Click(object sender, EventArgs e) // Приостановка и возобновление поиска
        {
            if (ThreadStateForPause)
            {
                thread.Suspend();
                timer1.Enabled = false;
                timeSum += DateTime.Now - timeStart;
                buPause.Text = "Возобновить поиск";
            }
            else
            {
                thread.Resume();
                timeStart = DateTime.Now;
                timer1.Enabled = true;
                buPause.Text = "Приостановить поиск";
            }
            ThreadStateForPause = !ThreadStateForPause;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // Сохранение директории и паттерна поиска
        {
            string text = txbDirectoryPath.Text + "\n" + txbSearch.Text;
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(text);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            laTimer.Text = "Время поиска: " + (timeSum + (DateTime.Now - timeStart)).ToString();
        }
    }
}
