using System;
using System.Threading;
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

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        public static int Start;
        public static int Total;

        private void UpdateData() // truyền dữ liệu liên tục qua fShow
        {
            Start = Convert.ToInt32(textBox1.Text); // = 0
            Total = Convert.ToInt32(textBox2.Text);
            if (Total > Start)
            {
                fProgressBar f = new fProgressBar();
                f.Show();

                #region case 1
                //Thread t = new Thread(() =>
                //{
                //    for (int i = 0; i < Total; i++)
                //    {
                //        if (fShow.isPause == false)
                //        {
                //            #region code here
                //            {
                //                Thread.Sleep(1000);
                //            }
                //            #endregion
                //            Start++;
                //        }
                //        else
                //        {
                //            return;
                //        }
                //    }
                //});
                //t.Start();
                #endregion

                #region case 2
                Task.Run(() =>
                {
                    for (int i = 0; i < Total; i++)
                    {
                        if (fProgressBar.isCancel == false)
                        {
                            #region code here
                            {
                                Thread.Sleep(1);
                            }
                            #endregion
                            Start++;
                        }
                        else
                        {
                            return;
                        }
                    }
                });
                #endregion
            }
        }
    }
}
