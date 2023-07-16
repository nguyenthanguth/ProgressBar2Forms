using System;
using System.Threading;
using System.Windows.Forms;

namespace ProgressBar2Forms
{
    public partial class fShow : Form
    {
        public fShow()
        {
            InitializeComponent();
        }

        public static bool isPause = false;

        private void fShow_Load(object sender, EventArgs e)
        {
            isPause = false;

            Thread t = new Thread(UpdateData);
            t.IsBackground = true;
            t.Start();
        }

        private void UpdateData()
        {
            while (true)
            {
                if (isPause == false)
                {
                    try
                    {
                        int startNumber = fMain.Start;
                        int endNumber = fMain.Total;
                        progressBar.Value = (int)Math.Round((double)startNumber / endNumber * 100); // bắt lỗi = 0

                        if (startNumber == endNumber)
                        {
                            //MessageBox.Show("Done fShow");
                            Close();
                            break;
                        }
                    }
                    catch { }
                }
                else
                {
                    //MessageBox.Show("Pause fShow");
                    Close();
                    break;
                }
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            isPause = true;
            Close();
        }
    }
}
