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
            //FrmTeacher obj = new FrmTeacher();
            //obj.MdiParent = this;
            //obj.Show();
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

        private void villaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Villa obj = new Villa();
            obj.MdiParent = this;
            obj.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer obj = new Customer();
            obj.MdiParent = this;
            obj.Show();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            staff obj = new staff();
            obj.MdiParent = this;
            obj.Show();
        }

        private void contractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contratctor obj = new Contratctor();
            obj.MdiParent = this;
            obj.Show();
        }

        private void storeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Store obj = new Store();
            obj.MdiParent = this;
            obj.Show();
        }

        private void contractsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contract obj = new Contract();
            obj.MdiParent = this;
            obj.Show();
        }

        private void generalExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenExpense obj = new GenExpense();
            obj.MdiParent = this;
            obj.Show();
        }

        private void miscleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MiscExpense obj = new MiscExpense();
            obj.MdiParent = this;
            obj.Show();
        }

        private void villaMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* VillaMaterial obj = new VillaMaterial();
            obj.MdiParent = this;
            obj.Show();*/
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void boundaryWallMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*BoundaryWall obj = new BoundaryWall();
            obj.MdiParent = this;
            obj.Show();*/
        }

        private void runningBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunningBillCon obj = new RunningBillCon();
            obj.MdiParent = this;
            obj.Show();
        }

        private void runningBillsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RunningBillCon obj = new RunningBillCon();
            obj.MdiParent = this;
            obj.Show();
        }

        private void billVillaWiseRptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BillVillaWiseRpt frm1 = new BillVillaWiseRpt();
                BillVillaRpt rp = new BillVillaRpt();

                frm1.RD = rp;
                frm1.strQuery = "select * from tbl_villa";
                frm1.Show();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void billContractWiseRptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BillContractWiseRpt frm1 = new BillContractWiseRpt();
                BillContractRpt rp = new BillContractRpt();

                frm1.RD = rp;
                frm1.strQuery = "select * from tbl_contract";
                frm1.Show();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void staffRptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffRpt frm1 = new StaffRpt();
                StaffRPT1 rp = new StaffRPT1();

                frm1.RD = rp;
                frm1.strQuery = "select * from tbl_staff";
                frm1.Show();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void runningBillsRptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RunningBillRpt frm1 = new RunningBillRpt();
                RunningRpt rp = new RunningRpt();

                frm1.RD = rp;
                frm1.strQuery = "select * from tbl_bill";
                frm1.Show();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

