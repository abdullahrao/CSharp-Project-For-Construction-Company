using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace concept_class
{
    public partial class BoundaryWall : Form
    {
        public BoundaryWall()
        {
            InitializeComponent();
        }
        pg tea = new pg();
        string StrQuery = string.Empty;
        private void BoundaryWall_Load(object sender, EventArgs e)
        {
            try
            {
                string amountlabel = "SELECT tbl_store.item_totalamount as ItemAmount FROM tbl_bound INNER JOIN tbl_store ON tbl_bound.item_id = tbl_store.store_ID;";
                string ratelabel = "SELECT tbl_store.item_rate as ItemRate FROM tbl_bound INNER JOIN tbl_store ON tbl_bound.item_id = tbl_store.store_ID;";
                lblamount.Text = tea.SqlDatatable(amountlabel).ToString();
                //lblrate.Text = ratelabel.ToString();
                lblrate.Text = tea.SqlDatatable(ratelabel).ToString();


                txt_id.Enabled = false;
                StrQuery = "SELECT tbl_villa.villa_Name,tbl_store.item_Name,tbl_store.item_quantity as InventoryQuantity,bound_quantity,bound_rate,bound_amount FROM tbl_bound INNER JOIN tbl_villa ON tbl_bound.vil_id = tbl_villa.villa_ID INNER JOIN tbl_store ON tbl_bound.item_id = tbl_store.store_ID;";
                tea.SqlDatatable(StrQuery);
                boundgrid.DataSource = pg.dt;

                StrQuery = "select ISNull (max(bound_ID),0)+1 from tbl_bound";
                tea.connection_Opener();
                tea.data_fetchCmd(StrQuery);
                if (pg.dr.Read())
                {
                    txt_id.Text = pg.dr[0].ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Fill_comboVilla()
        {
            try
            {
                StrQuery = "select * from tbl_villa";
                tea.SqlDatatable(StrQuery);// da = new SqlDataAdapter("Select * from tbl_customer", Connection);
                for (int i = 0; i < pg.dt.Rows.Count; i++)
                {
                    txt_villaname.Items.Add(pg.dt.Rows[i]["villa_Name"]);
                }
                txt_villaname.DisplayMember = "villa_Name";
                txt_villaname.ValueMember = "villa_ID";
            }
            catch (Exception exx)
            {

            }
        }
        public void Fill_comboItem()
        {
            try
            {
                StrQuery = "select * from tbl_store";
                tea.SqlDatatable(StrQuery);// da = new SqlDataAdapter("Select * from tbl_customer", Connection);
                for (int i = 0; i < pg.dt.Rows.Count; i++)
                {
                    txt_itemname.Items.Add(pg.dt.Rows[i]["item_Name"]);
                }
                txt_itemname.DisplayMember = "item_Name";
                txt_itemname.ValueMember = "store_ID";
            }
            catch (Exception ex)
            {

            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "select * from tbl_bound";
                tea.SqlDatatable(StrQuery);
                boundgrid.DataSource = pg.dt;
                MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "select * from tbl_bound";
                tea.SqlDatatable(StrQuery);
                boundgrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(bound_ID),0)+1 from tbl_bound";
                tea.connection_Opener();
                tea.data_fetchCmd(StrQuery);
                if (pg.dr.Read())
                {
                    txt_id.Text = pg.dr[0].ToString();
                }
                Ref();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clr()
        {
            txt_id.Text = "";
            txt_itemname.SelectedItem = "";
            txt_item_quantity.SelectedText = "";
            txt_villaname.Text = "";
            //txt_desc.Text = "";
        }
        public void Ref()
        {
            txt_id.Enabled = false;
            txt_itemname.Enabled = true;
            txt_item_quantity.Enabled = true;
            txt_villaname.Enabled = true;
            //txt_desc.Enabled = true;
        }
        public void id()
        {
            txt_id.Enabled = true;
            txt_itemname.Enabled = false;
            txt_item_quantity.Enabled = false;
            txt_villaname.Enabled = false;
            // txt_desc.Enabled = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {


                StrQuery = "delete tbl_bound where bound_ID = '" + txt_id.Text.Trim().ToString() + "' ";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_bound";
                tea.SqlDatatable(StrQuery);
                boundgrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(bound_ID),0)+1 from tbl_bound";
                tea.connection_Opener();
                tea.data_fetchCmd(StrQuery);
                if (pg.dr.Read())
                {
                    txt_id.Text = pg.dr[0].ToString();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
