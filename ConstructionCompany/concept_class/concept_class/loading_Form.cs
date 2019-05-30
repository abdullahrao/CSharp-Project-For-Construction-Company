using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace concept_class
{
    public partial class loading_Form : Form
    {
        public loading_Form()
        {
            InitializeComponent();
        }

        private void loading_Form_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                this.Close();
                Thread thr = new Thread(new ThreadStart(app));
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
            }
            else
            {
                progressBar1.Value = progressBar1.Value + 10;
            }
        }

        public void app() {
            Application.Run(new MDIParent1());
        }

    }
}
