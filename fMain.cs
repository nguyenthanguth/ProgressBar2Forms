using ProgressBar2Forms.Properties;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar2Forms
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            tbStart.Text = Settings.Default.saveStart;
            tbEnd.Text = Settings.Default.saveEnd;
            tbTimeDelay.Text = Settings.Default.saveTime;
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.saveStart = tbStart.Text;
            Settings.Default.saveEnd = tbEnd.Text;
            Settings.Default.saveTime = tbTimeDelay.Text;
            Settings.Default.Save();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            Run();
        }

        private async void Run()
        {
            fProgressBar progressBar = new fProgressBar();
            progressBar.Show();

            int totalCountObject = Convert.ToInt32(tbEnd.Text);
            for (int i = 1; i <= totalCountObject; i++)
            {
                if (progressBar.IsCancel)
                {
                    break;
                }

                progressBar.UpdateProgress(i, totalCountObject);
                await Task.Delay(Convert.ToInt32(1));

                // công việc thực hiện...
                for (int j = 1; j < 1000000; j++)
                {
                    Console.WriteLine(j);
                }
            }

            progressBar.Close();
        }
    }
}
