using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayRoll
{
    public partial class Loader1 : Form
    {
        public Loader1()
        {
            InitializeComponent();
        }

        private void Loader1_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.progressBar1.Increment(5);

            if (progressBar1.Value == 100)
            {
                Payroll P = new Payroll();
                P.Show();
                this.Hide();
                timer1.Stop();
            }

        }
    }
}
