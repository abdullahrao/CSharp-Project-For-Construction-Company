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
    public partial class VillaMaterial : Form
    {
        public VillaMaterial()
        {
            InitializeComponent();
            Fill_comboItem();
            Fill_comboVilla();
        }

        pg tea = new pg();
        string StrQuery = string.Empty;

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            try
            {
                string amountlabel = "SELECT tbl_store.item_totalamount as ItemAmount FROM tbl_villaMat INNER JOIN tbl_store ON tbl_villaMat.item_id = tbl_store.store_ID;";
                string ratelabel = "SELECT tbl_store.item_rate as ItemRate FROM tbl_villaMat INNER JOIN tbl_store ON tbl_villaMat.item_id = tbl_store.store_ID;";
                lblamount.Text = tea.SqlDatatable(amountlabel).ToString();
                //lblrate.Text = ratelabel.ToString();
                lblrate.Text = tea.SqlDatatable(ratelabel).ToString();


                string StrQuery1 = "Select sum(item_quantity) as totalQuantity From tbl_store Where store_ID='" + Convert.ToInt32(txt_itemname.Text) + "' and item_quantity >= '" + Convert.ToInt32(txt_item_quantity.Text) + "' group by store_ID;";
                decimal q = Convert.ToDecimal(tea.SqlDatatable(StrQuery1));
                decimal qty = Convert.ToDecimal(txt_item_quantity.Text);
                if (q >= qty)
                {
                    decimal min = q - qty;
                    //string a = "update tbl_store set item_quantity='"+Convert.ToInt32(min)+"' where store_ID = (select tbl_villaMat.item_id from tbl_villaMat INNER JOIN tbl_store ON tbl_villaMat.item_id =tbl_store.store_ID)";
                    //tea.simInsert(a);
                    //StrQuery = "insert into tbl_villaMat values('" + txt_villaname.SelectedValue + "','" + txt_itemname.SelectedValue + "','" + qty + "','" + Convert.ToDecimal(tea.SqlDatatable(ratelabel).ToString()) + "','" + Convert.ToDecimal(tea.SqlDatatable(amountlabel).ToString()) + "');";
                    StrQuery = "insert into tbl_villaMat values('" + txt_villaname.SelectedValue + "','" + txt_itemname.SelectedValue + "', '2','" + Convert.ToDecimal(lblrate.Text).ToString() + "','" +Convert.ToDecimal(lblamount.Text).ToString() + "');";
                    tea.simInsert(StrQuery);

                    MessageBox.Show("Successful Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StrQuery = "SELECT tbl_villa.villa_Name,tbl_store.item_Name,tbl_store.item_quantity as InventoryQuantity,vmat_quantity,vmat_rate,vmat_amount FROM tbl_villaMat INNER JOIN tbl_villa ON tbl_villaMat.vil_id = tbl_villa.villa_ID INNER JOIN tbl_store ON tbl_villaMat.item_id = tbl_store.store_ID;";
                    tea.SqlDatatable(StrQuery);
                    villamatgrid.DataSource = pg.dt;
                    clr();

                    StrQuery = "select ISNull (max(vmat_ID),0)+1 from tbl_villaMat";
                    tea.connection_Opener();
                    tea.data_fetchCmd(StrQuery);
                    if (pg.dr.Read())
                    {
                        txt_id.Text = pg.dr[0].ToString();
                    }
                    MessageBox.Show(" In Try Clause value of item name " + txt_itemname.SelectedValue + " and Villa Name is" + txt_villaname.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Quantity Not Available", "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" In Catch Clause value of item name " + txt_itemname.SelectedValue + " and Villa Name is" + txt_villaname.SelectedValue);
                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void VillaMaterial_Load(object sender, EventArgs e)
        {
            try
            {
                string amountlabel = "SELECT tbl_store.item_totalamount as ItemAmount FROM tbl_villaMat INNER JOIN tbl_store ON tbl_villaMat.item_id = tbl_store.store_ID;";
                string ratelabel = "SELECT tbl_store.item_rate as ItemRate FROM tbl_villaMat INNER JOIN tbl_store ON tbl_villaMat.item_id = tbl_store.store_ID;";
                lblamount.Text = tea.SqlDatatable(amountlabel).ToString();
                //lblrate.Text = ratelabel.ToString();
                lblrate.Text = tea.SqlDatatable(ratelabel).ToString();


                txt_id.Enabled = false;
                StrQuery = "SELECT tbl_villa.villa_Name,tbl_store.item_Name,tbl_store.item_quantity as InventoryQuantity,vmat_quantity,vmat_rate,vmat_amount FROM tbl_villaMat INNER JOIN tbl_villa ON tbl_villaMat.vil_id = tbl_villa.villa_ID INNER JOIN tbl_store ON tbl_villaMat.item_id = tbl_store.store_ID;";
                tea.SqlDatatable(StrQuery);
                villamatgrid.DataSource = pg.dt;

                StrQuery = "select ISNull (max(vmat_ID),0)+1 from tbl_villaMat";
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
        public void clr()
        {
            txt_id.Text = "";
            txt_itemname.SelectedItem = "";
            txt_item_quantity.Text = "";
            txt_villaname.SelectedItem = "";
            lblamount.Text = "";
            lblrate.Text = "";
        }
        public void Ref()
        {
            txt_id.Enabled = false;
            txt_itemname.Enabled = true;
            txt_item_quantity.Enabled = true;
            txt_villaname.Enabled = true;
            lblamount.Enabled = true;
            lblrate.Enabled = true;
        }
        public void id()
        {
            txt_id.Enabled = true;
            txt_itemname.Enabled = false;
            txt_item_quantity.Enabled = false;
            txt_villaname.Enabled = false;
            lblamount.Enabled = false;
            lblrate.Enabled = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "SELECT tbl_villa.villa_Name,tbl_store.item_Name,tbl_store.item_quantity as InventoryQuantity,vmat_quantity,vmat_rate,vmat_amount FROM tbl_villaMat INNER JOIN tbl_villa ON tbl_villaMat.vil_id = tbl_villa.villa_ID INNER JOIN tbl_store ON tbl_villaMat.item_id = tbl_store.store_ID;";
                tea.SqlDatatable(StrQuery);
                villamatgrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(vmat_ID),0)+1 from tbl_villaMat";
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {


                StrQuery = "delete tbl_villaMat where vmat_ID = '" + txt_id.Text.Trim().ToString() + "' ";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "SELECT tbl_villa.villa_Name,tbl_store.item_Name,tbl_store.item_quantity as InventoryQuantity,vmat_quantity,vmat_rate,vmat_amount FROM tbl_villaMat INNER JOIN tbl_villa ON tbl_villaMat.vil_id = tbl_villa.villa_ID INNER JOIN tbl_store ON tbl_villaMat.item_id = tbl_store.store_ID;";
                tea.SqlDatatable(StrQuery);
                villamatgrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(vmat_ID),0)+1 from tbl_villaMat";
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "SELECT tbl_villa.villa_Name,tbl_store.item_Name,tbl_store.item_quantity as InventoryQuantity,vmat_quantity,vmat_rate,vmat_amount FROM tbl_villaMat INNER JOIN tbl_villa ON tbl_villaMat.vil_id = tbl_villa.villa_ID INNER JOIN tbl_store ON tbl_villaMat.item_id = tbl_store.store_ID;";
                tea.SqlDatatable(StrQuery);
                villamatgrid.DataSource = pg.dt;
                MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
           /* try
            {

                if (comboBox1.Text == "Name")
                {
                    StrQuery = "select * from tbl_villaMat where vmat_item = '" + txt_name.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    villagridview.DataSource = pg.dt;

                }

                else if (comboBox1.Text == "Code")
                {
                    StrQuery = "select * from tbl_villaMat where villa_code = '" + txt_Code.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    villagridview.DataSource = pg.dt;

                }
                else if (comboBox1.Text == "Customer")
                {
                    StrQuery = "select * from tbl_villaMat where cust_name = '" + comboBox1.SelectedItem + "'";
                    tea.SqlDatatable(StrQuery);
                    villagridview.DataSource = pg.dt;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void villamatgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txt_id.Text = villamatgrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_villaname.SelectedItem = villamatgrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_itemname.SelectedItem = villamatgrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_item_quantity.Text = villamatgrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
