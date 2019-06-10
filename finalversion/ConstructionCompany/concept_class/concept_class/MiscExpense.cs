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
    public partial class MiscExpense : Form
    {
        public MiscExpense()
        {
            InitializeComponent();
        }

        private void genexpensegrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_id.Text = miscexpensegrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_con_name.Text = miscexpensegrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_quantity.Text = miscexpensegrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_unit.Text = miscexpensegrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_unit_qty.Text = miscexpensegrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_amount.Text = miscexpensegrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_remarks.Text = miscexpensegrid.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        pg tea = new pg();
        string StrQuery = string.Empty;
        private void MiscExpense_Load(object sender, EventArgs e)
        {
            try
            {
                string StrQry = "SELECT SUM(misc_amount) AS TotalAmount FROM tbl_miscexpense;";
                lbl_totalamount.Text = tea.SqlDatatable(StrQry).ToString();
                txt_id.Enabled = false;
                StrQuery = "select * from tbl_miscexpense";
                tea.SqlDatatable(StrQuery);
                miscexpensegrid.DataSource = pg.dt;

                StrQuery = "select ISNull (max(misc_ID),0)+1 from tbl_miscexpense";
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

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "select * from tbl_miscexpense";
                tea.SqlDatatable(StrQuery);
                miscexpensegrid.DataSource = pg.dt;
                MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboBox1.Text == "Name")
                {
                    StrQuery = "select * from tbl_miscexpense where misc_Name = '" + txt_con_name.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    miscexpensegrid.DataSource = pg.dt;

                }

                else if (comboBox1.Text == "Amount")
                {
                    StrQuery = "select * from tbl_miscexpense where misc_amount = '" + txt_amount.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    miscexpensegrid.DataSource = pg.dt;

                }
                else if (comboBox1.Text == "UnitQuantity")
                {
                    StrQuery = "select * from tbl_miscexpense where misc_unit_quantity = '" + txt_unit_qty + "'";
                    tea.SqlDatatable(StrQuery);
                    miscexpensegrid.DataSource = pg.dt;
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
                string StrQry = "SELECT SUM(misc_amount) AS TotalAmount FROM tbl_miscexpense;";
                lbl_totalamount.Text = StrQry.ToString();
                StrQuery = "select * from tbl_miscexpense";
                tea.SqlDatatable(StrQuery);
                miscexpensegrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(misc_ID),0)+1 from tbl_miscexpense";
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
            txt_con_name.Text = "";
            txt_quantity.Text = "";
            txt_unit.Text = "";
            txt_unit_qty.Text = "";
            txt_amount.Text = "";
            txt_remarks.Text = "";
        }
        public void Ref()
        {
            txt_id.Enabled = false;
            txt_con_name.Enabled = true;
            txt_quantity.Enabled = true;
            txt_unit.Enabled = true;
            txt_unit_qty.Enabled = true;
            txt_amount.Enabled = true;
            txt_remarks.Enabled = true;
        }
        public void id()
        {
            txt_id.Enabled = true;
            txt_con_name.Enabled = false;
            txt_quantity.Enabled = false;
            txt_unit.Enabled = false;
            txt_unit_qty.Enabled = false;
            txt_amount.Enabled = false;
            txt_remarks.Enabled = false;

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {


                StrQuery = "delete tbl_miscexpense where misc_ID = '" + txt_id.Text.Trim().ToString() + "' ";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_miscexpense";
                tea.SqlDatatable(StrQuery);
                miscexpensegrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(misc_ID),0)+1 from tbl_miscexpense";
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
            try
            {
                string StrQry = "SELECT SUM(misc_amount) AS TotalAmount FROM tbl_miscexpense;";
                lbl_totalamount.Text = tea.SqlDatatable(StrQry).ToString();
                decimal amount = Convert.ToDecimal(txt_quantity.Text) * Convert.ToDecimal(txt_unit_qty.Text);
                StrQuery = "insert into tbl_miscexpense values('" + txt_con_name.Text.Trim().ToString() + "','" + txt_quantity.Text.Trim().ToString() + "','" + txt_unit.SelectedItem.ToString() + "','" + txt_unit_qty.Text.Trim().ToString() + "','" + amount.ToString() + "','" + txt_remarks.Text.Trim().ToString() + "');";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_miscexpense";
                tea.SqlDatatable(StrQuery);
                miscexpensegrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(misc_ID),0)+1 from tbl_miscexpense";
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string StrQry = "SELECT SUM(misc_amount) AS TotalAmount FROM tbl_miscexpense;";
                lbl_totalamount.Text = tea.SqlDatatable(StrQry).ToString();
                decimal amount = Convert.ToDecimal(txt_quantity.Text) * Convert.ToDecimal(txt_unit_qty.Text);
                StrQuery = "update tbl_miscexpense set misc_Name = '" + txt_con_name.Text.Trim().ToString() + "',misc_quantity = '" + txt_quantity.Text.Trim().ToString() + "',misc_unit = '" + txt_unit.SelectedItem.ToString() + "',misc_unit_quantity = '" + txt_unit_qty.Text.Trim().ToString() + "',misc_amount = '" + amount.ToString() + "',misc_remakrs = '" + txt_remarks.Text.Trim().ToString() + "' where misc_ID = '" + txt_id.Text.Trim().ToString() + "'";
                tea.simInsert(StrQuery);
                MessageBox.Show("Successful Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_miscexpense";
                tea.SqlDatatable(StrQuery);
                miscexpensegrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(misc_ID),0)+1 from tbl_miscexpense";
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
