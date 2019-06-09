using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace concept_class
{
    public partial class encryption : Form
    {
        public encryption()
        {
            InitializeComponent();
        }
        enMethod cls = new enMethod();
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = cls.MD5Encrypt(textBox1.Text);
        }
    }
}
