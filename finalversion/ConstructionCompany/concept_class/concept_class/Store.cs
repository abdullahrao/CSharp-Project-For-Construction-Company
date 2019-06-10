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
    public partial class Store : Form
    {
        public Store()
        {
            InitializeComponent();
        }
        pg tea = new pg();
        string StrQuery = string.Empty;

        private void txt_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txt_desc_TextChanged(object sender, EventArgs e)
        {

        }

        private void Store_Load(object sender, EventArgs e)
        {
            try
            {
                txt_id.Enabled = false;
                StrQuery = "select * from tbl_store";
                tea.SqlDatatable(StrQuery);
                storegrid.DataSource = pg.dt;

                StrQuery = "select ISNull (max(store_ID),0)+1 from tbl_store";
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "select * from tbl_store";
                tea.SqlDatatable(StrQuery);
                storegrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(store_ID),0)+1 from tbl_store";
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
            txt_itemname.Text = "";
            txt_rate.Text = "";
            txt_quantity.Text = "";
            txt_totalamount.Text = "";
            txt_comp_name.Text = "";
            txt_dis.Text = "";
            txt_tax.Text = "";
            txt_unit.Text = "";
            txt_g_amount.Text = "";
            txt_remarks.Text = "";
            txt_totalamount.Text = "";
        }
        public void Ref()
        {
            txt_id.Enabled = false;
            txt_itemname.Enabled =true;
            txt_rate.Enabled = true;
            txt_quantity.Enabled = true;
            txt_totalamount.Enabled = true;
            txt_comp_name.Enabled = true;
            txt_dis.Enabled = true;
            txt_tax.Enabled = true;
            txt_unit.Enabled =true;
            txt_g_amount.Enabled =true;
            txt_remarks.Enabled = true;
            txt_totalamount.Enabled = true;
        }
        public void id()
        {
            txt_id.Enabled = true;
            txt_itemname.Enabled = false;
            txt_rate.Enabled = false;
            txt_quantity.Enabled = false;
            txt_totalamount.Enabled = false;
            txt_comp_name.Enabled =false;
            txt_dis.Enabled = false;
            txt_tax.Enabled = false;
            txt_unit.Enabled = false;
            txt_g_amount.Enabled = false;
            txt_remarks.Enabled = false;
            txt_totalamount.Enabled = false;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "select * from tbl_store";
                tea.SqlDatatable(StrQuery);
                storegrid.DataSource = pg.dt;
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
            try
            {

                if (comboBox1.Text == "ItemName")
                {
                    StrQuery = "select * from tbl_store where item_Name = '" + txt_itemname.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    storegrid.DataSource = pg.dt;

                }

                else if (comboBox1.Text == "CompanyName")
                {
                    StrQuery = "select * from tbl_store where item_company_name = '" + txt_comp_name.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    storegrid.DataSource = pg.dt;

                }
                else if (comboBox1.Text == "Rate")
                {
                    StrQuery = "select * from tbl_store where item_rate = '" + txt_rate.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    storegrid.DataSource = pg.dt;
                }
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
                StrQuery = "delete tbl_store where store_ID = '" + txt_id.Text.Trim().ToString() + "' ";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_store";
                tea.SqlDatatable(StrQuery);
                storegrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(store_ID),0)+1 from tbl_store";
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

        private void storegrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_id.Text = storegrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_itemname.Text = storegrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_unit.SelectedItem = storegrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_quantity.Text = storegrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_rate.Text = storegrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_g_amount.Text = storegrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_dis.Text = storegrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                txt_tax.Text = storegrid.Rows[e.RowIndex].Cells[7].Value.ToString();
                txt_totalamount.Text = storegrid.Rows[e.RowIndex].Cells[8].Value.ToString();
                txt_deb_cred.SelectedItem = storegrid.Rows[e.RowIndex].Cells[9].Value.ToString();
                //txt_deb_cred.SelectedItem = storegrid.Rows[e.RowIndex].Cells[10].Value.ToString();
                //txt_deb_cred.SelectedItem = storegrid.Rows[e.RowIndex].Cells[11].Value.ToString();
                txt_remarks.Text = storegrid.Rows[e.RowIndex].Cells[12].Value.ToString();
                txt_con_ret.SelectedItem = storegrid.Rows[e.RowIndex].Cells[13].Value.ToString();
                txt_comp_name.Text = storegrid.Rows[e.RowIndex].Cells[14].Value.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            try
            {
                decimal gross_am = Convert.ToDecimal(txt_quantity.Text) * Convert.ToDecimal(txt_rate.Text);
                decimal pecentageAmount = (gross_am / 100) * Convert.ToDecimal(txt_dis.Text);
                decimal tot_amount = (gross_am + Convert.ToDecimal(txt_tax.Text)) - pecentageAmount;

                if (txt_deb_cred.SelectedItem.ToString() == "Credit")
                {
                    StrQuery = "insert into tbl_store values( '" + txt_itemname.Text.Trim().ToString() + "','" + txt_unit.SelectedItem.ToString() + "','" + txt_quantity.Text.Trim().ToString() + "','" + txt_rate.Text.Trim().ToString() + "','" + gross_am.ToString() + "','" + txt_dis.Text.Trim().ToString() + "','" + txt_tax.Text.Trim().ToString() + "','" + tot_amount.ToString() + "','" + txt_deb_cred.SelectedItem.ToString() + "','" + tot_amount.ToString() + "','-','" + txt_remarks.Text.Trim().ToString() + "','" + txt_con_ret.SelectedItem.ToString() + "','" + txt_comp_name.Text.Trim().ToString() + "');";
                    tea.simInsert(StrQuery);
                }
                if (txt_deb_cred.SelectedItem.ToString() == "Debit")
                {
                    StrQuery = "insert into tbl_store values( '" + txt_itemname.Text.Trim().ToString() + "','" + txt_unit.SelectedItem.ToString() + "','" + txt_quantity.Text.Trim().ToString() + "','" + txt_rate.Text.Trim().ToString() + "','" + gross_am.ToString() + "','" + txt_dis.Text.Trim().ToString() + "','" + txt_tax.Text.Trim().ToString() + "','" + tot_amount.ToString() + "','" + txt_deb_cred.SelectedItem.ToString() + "','-','" + tot_amount.ToString() + "','" + txt_remarks.Text.Trim().ToString() + "','" + txt_con_ret.SelectedItem.ToString() + "','" + txt_comp_name.Text.Trim().ToString() + "');";
                    tea.simInsert(StrQuery);
                }
                MessageBox.Show("Successful Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_store";
                tea.SqlDatatable(StrQuery);
                storegrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(store_ID),0)+1 from tbl_store";
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

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                decimal gross_am = Convert.ToDecimal(txt_quantity.Text) * Convert.ToDecimal(txt_rate.Text);
                decimal pecentageAmount = (gross_am / 100) * Convert.ToDecimal(txt_dis.Text);
                decimal tot_amount = (gross_am + Convert.ToDecimal(txt_tax.Text)) - pecentageAmount;
                if (txt_deb_cred.SelectedItem.ToString() == "Credit")
                {
                    StrQuery = "update tbl_store set item_Name= '" + txt_itemname.Text.Trim().ToString() + "', item_unit= '" + txt_unit.SelectedItem.ToString() + "',item_quantity='" + txt_quantity.Text.Trim().ToString() + "',item_rate='" + txt_rate.Text.Trim().ToString() + "',item_grossamount='" + gross_am.ToString() + "',item_discount='" + txt_dis.Text.Trim().ToString() + "',item_tax='" + txt_tax.Text.Trim().ToString() + "',item_totalamount='" + tot_amount.ToString() + "',item_deb_cred='" + txt_deb_cred.SelectedItem.ToString() + "',item_credit = '" + tot_amount.ToString() + "',item_debit= '-', item_remarks= '" + txt_remarks.Text.Trim().ToString() + "', item_con_ret ='" + txt_con_ret.SelectedItem.ToString() + "', item_company_name= '" + txt_comp_name.Text.Trim().ToString() + "' where store_ID = '" + txt_id.Text.Trim().ToString() + "');";
                    tea.simInsert(StrQuery);
                }
                if (txt_deb_cred.SelectedItem.ToString() == "Debit")
                {
                    StrQuery = "update tbl_store set item_Name= '" + txt_itemname.Text.Trim().ToString() + "', item_unit= '" + txt_unit.SelectedItem.ToString() + "',item_quantity='" + txt_quantity.Text.Trim().ToString() + "',item_rate='" + txt_rate.Text.Trim().ToString() + "',item_grossamount='" + gross_am.ToString() + "',item_discount='" + txt_dis.Text.Trim().ToString() + "',item_tax='" + txt_tax.Text.Trim().ToString() + "',item_totalamount='" + tot_amount.ToString() + "',item_deb_cred='" + txt_deb_cred.SelectedItem.ToString() + "',item_credit= '-',item_debit = '" + tot_amount.ToString() + "', item_remarks= '" + txt_remarks.Text.Trim().ToString() + "', item_con_ret ='" + txt_con_ret.SelectedItem.ToString() + "', item_company_name= '" + txt_comp_name.Text.Trim().ToString() + "' where store_ID = '" + txt_id.Text.Trim().ToString() + "');";
                    tea.simInsert(StrQuery);
                }
                MessageBox.Show("Successful Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_store";
                tea.SqlDatatable(StrQuery);
                storegrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(store_ID),0)+1 from tbl_store";
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
    }
}
