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
using System.Security.Cryptography;
using System.Threading;

namespace concept_class
{
    public partial class Form1 : Form
    {
        pg obj = new pg();
        string val1 = string.Empty;
       public static string val2 = string.Empty;
        public static string _txtName = string.Empty; 
        string val3 = string.Empty;
        string val4 = string.Empty;
        string val5 = string.Empty;
        string qrylg = string.Empty;
        string StrQurey = string.Empty;
        DataTable Dt;
        SqlDataReader Dr;
        string StrQuery;
        enMethod cls = new enMethod();
        
        
    
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            int wid, hig;
            wid = this.Width - panel1.Width;
            hig = this.Height - panel1.Height;

            panel1.Left = wid / 2;
            panel1.Top = hig / 2;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
             try
            {

                if (checkBox1.Checked)
                {
                    Properties.Settings.Default.username = textBox1.Text.Trim().ToString();
                    Properties.Settings.Default.password = textBox2.Text.Trim().ToString();
                    Properties.Settings.Default.Save();
                }
                if (checkBox1.Checked == false)
                {
                    Properties.Settings.Default.username ="";
                    Properties.Settings.Default.password = "";
                    Properties.Settings.Default.Save();
                    checkBox1.Checked = false;
                }
               

                obj.connection_Opener();
                _txtName = textBox1.Text.Trim().ToString();
                val1 = textBox1.Text.Trim() + textBox2.Text.Trim() + "abdullah";
                val2 = cls.MD5Encrypt(val1);
                obj.data_fetchCmd("select * from users where IsStatus='A' And Users_name='" + textBox1.Text.Trim() + "'");
                if (pg.dr.Read())
                {
                    val3 = pg.dr["Field2"].ToString();
                }

                if (val2 == val3)
                {
                    messageBoxSu MxgSuccess = new messageBoxSu();
                    MxgSuccess.ShowDialog();
                    //MessageBox.Show("Login Successful", "Login Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Program.gh = pg.dr["Users_id"].ToString();
                    qrylg = "insert into login_Time values('" + textBox1.Text + "',Getdate(),null)";
                    obj.simInsert(qrylg);
                    if (pg.dr["FirstLogin"].ToString() =="True")
                    {
                        PassChangeFrm pfrm = new PassChangeFrm();
                        pfrm.ShowDialog();
                    }
                    this.Close();
                    Thread thr = new Thread(new ThreadStart(app));
                    thr.SetApartmentState(ApartmentState.STA);
                    thr.Start();
                }
                else
                {

                    StrQuery = "update users set IvalidCount = IvalidCount+1 where IsStatus ='A' And Users_name='" + textBox1.Text.Trim() + "'";
                    obj.simInsert(StrQuery);

                    obj.data_fetchCmd("Select InvalidAttamp, IvalidCount, IsStatus From users Where IsStatus = 'A' And Users_name='" + textBox1.Text.Trim() + "'"); 

                 if (pg.dr.Read())
                {

                    val4 = pg.dr["IvalidCount"].ToString();
                    val5 = pg.dr["InvalidAttamp"].ToString();
                    

                    }
                 if (val4 == val5)
                {
                    StrQuery = " Update users set IsStatus = 'X' Where IsStatus = 'A' And Users_name='" + textBox1.Text.Trim() + "'";
                    obj.simInsert(StrQuery);
                        //MessageBox.Show("User ID Has Been Blocked!" + Environment.NewLine + "Please Contact Admin!", "Error", MessageBoxButtons.OK);
                        MessageBoxConfrm mxgCon = new MessageBoxConfrm();
                        mxgCon.ShowDialog();
                        this.Close();
                }
                    else
                    {
                        // MessageBox.Show("Wrong ID or Password", "Login Panel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBoxWarning mxgWarning = new MessageBoxWarning();
                        mxgWarning.ShowDialog();

                    }    
                       
                    
                    clr();

                }
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void clr() {
            textBox1.Text = "";
            textBox2.Text = "";

        }
        public void app() {
            Application.Run(new loading_Form());
        }
        

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.com");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.username != string.Empty)
            {
                textBox1.Text = Properties.Settings.Default.username;
                textBox2.Text = Properties.Settings.Default.password;
                checkBox1.Checked = true;
            }
        }

    }
}
