using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public static int Start;
        public static int Total;

        private void button_Run_Click(object sender, EventArgs e)
        {
            Start = 0;
            Total = 0;

            fShow f = new fShow();
            f.Show();

            Thread t = new Thread(UpdateData);
            t.IsBackground = true;
            t.Start();
        }

        private void UpdateData() // truyền dữ liệu liên tục qua fShow
        {
            Start = Convert.ToInt32(textBox1.Text);
            Total = Convert.ToInt32(textBox2.Text);
            while (true)
            {
                if (fShow.isPause == false)
                {
                    Start++;

                    // code here
                    {
                        Thread.Sleep(10);
                    }

                    if (Start == Total)
                    {
                        //MessageBox.Show("Done fMain");
                        return;
                    }
                }
                else
                {
                    //MessageBox.Show("Pause fMain");
                    return;
                }
            }
        }
    }
}
