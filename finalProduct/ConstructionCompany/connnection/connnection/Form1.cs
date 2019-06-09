using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace connnection
{
    public partial class Connection_Form : Form
    {
        public Connection_Form()
        {
            InitializeComponent();
        }
        string paa;
        string qry;
        private void Connection_Form_Load(object sender, EventArgs e)
        {
            try
            {
            //    paa = @"D:\ConstructionCompany\" + txtfileName.Text.Trim() + ".txt";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Path Error" + Environment.NewLine + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                // set a default file name
                savefile.FileName = txtfileName.Text.Trim()+".txt";
                // set filters - this can be done in properties as well
                savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(savefile.FileName))
                    {
                        qry = "Data Source=" + txtServer.Text.Trim() + ";Initial Catalog=" + txtDatabase.Text.Trim() + ";User ID=" + txtid.Text.Trim() + ";Password=" + txtpass.Text.Trim() + "";
                        sw.WriteLine(qry);
                        MessageBox.Show("Successfully created Connection", "Connection");
                    }
                }

               
                 //File.WriteAllText(paa, qry);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error"+ Environment.NewLine+ex.Message);
               
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                var FD = new System.Windows.Forms.OpenFileDialog();
                if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileToOpen = FD.FileName;

                    SqlConnection con = new SqlConnection(File.ReadAllText(fileToOpen));
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    MessageBox.Show("Successfully Tested", "Connection");

               //     System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);

                    //OR

                 //   System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                    //etc
                }
                //var OpenFile = new System.IO.StreamReader(openFileDialog1.FileName);
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Test Error" + Environment.NewLine + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
