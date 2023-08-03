using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar2Forms
{
    public partial class fProgressBar : Form
    {
        public fProgressBar()
        {
            InitializeComponent();
        }

        public static bool isCancel = false;

        private void fProgressBar_Load(object sender, EventArgs e)
        {
            isCancel = false;
            Task.Run(() =>
            {
                while (isCancel == false)
                {
                    int startNumber = fMain.startProgressBar;
                    int totalNumber = fMain.totalProgressBar;
                    int value = Convert.ToInt32(Math.Round((double)startNumber / totalNumber * 100));
                    Invoke(new Action(() => { progressBar.Value = value; }));

                    if (startNumber == totalNumber)
                    {
                        break;
                    }
                }
            });
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            isCancel = true;
        }
    }
}
