using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;

namespace concept_class
{
    public partial class MDIParent1 : Form
    {
        DataSet DS = new DataSet();
        string OptionID = string.Empty;
        string Menu_Description = string.Empty;
        pg obj = new pg();

        

        public MDIParent1()
        {
            InitializeComponent();
        }



        private void MDIParent1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = DateTime.Now.ToLongTimeString();




            //string StrQuery = string.Empty;


            //StrQuery = "SELECT C.USername, A.id, A.name, B.RightID, B.UserID, B.menuID, B.status , C.userID  FROM stripname AS A INNER JOIN  UserRights AS B ON A.id = B.menuID INNER JOIN users_name AS C ON B.UserID = C.userID where B.UserID = " + Program.gh;
            //DS.Reset();
            //obj.ConnectionOpenFillDt(StrQuery, DS);
            //for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            //{
            //    OptionID = DS.Tables[0].Rows[i]["id"].ToString();
            //    Menu_Description = DS.Tables[0].Rows[i]["name"].ToString();

            //    ToolStripMenuItem TS = new ToolStripMenuItem();
            //    TS.Name = OptionID;
            //    TS.Text = Menu_Description;


            //    menuStrip1.Items.Add(TS);
            //}
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PassChangeFrm frm = new PassChangeFrm();
            frm.MdiParent = this;
            frm.Show();

        }

        private void testFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTeacher obj = new FrmTeacher();
            obj.MdiParent = this;
            obj.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.Close();
            Thread thr = new Thread(new ThreadStart(app));
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
            
        }
        public void app()
        {
            Application.Run(new Form1());
        }

    }
}

