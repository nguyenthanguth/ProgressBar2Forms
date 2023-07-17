using System;
using System.Threading;
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

        private void fShow_Load(object sender, EventArgs e)
        {
            isCancel = false;
            Task.Run(() =>
            {
                while (true)
                {
                    if (isCancel == false)
                    {
                        int startNumber = fMain.Start;
                        int totalNumber = fMain.Total;
                        labelNumber.Text = $"{startNumber}/{totalNumber}";
                        progressBar.Value = (int)Math.Round((double)startNumber / totalNumber * 100);

                        if (startNumber == totalNumber)
                        {
                            Close();
                            break;
                        }
                    }
                    else
                    {
                        Close();
                        break;
                    }
                }
            });
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            isCancel = true;
            Close();
        }
    }
}
