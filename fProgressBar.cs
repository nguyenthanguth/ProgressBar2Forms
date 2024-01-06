using System;
using System.Windows.Forms;

namespace ProgressBar2Forms
{
    public partial class fProgressBar : Form
    {
        public fProgressBar()
        {
            InitializeComponent();
        }

        public bool IsCancel { get; set; }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            IsCancel = true;
        }

        public void UpdateProgress(int i, int total)
        {
            if (i != 0)
            {
                int value = Convert.ToInt32(i * 100 / total);
                if (value >= progressBar.Minimum && value <= progressBar.Maximum)
                {
                    Invoke(new Action(() => { progressBar.Value = value; }));
                }
            }
        }
    }
}
