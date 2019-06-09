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
    public partial class GenExpense : Form
    {
        public GenExpense()
        {
            InitializeComponent();
        }
        pg tea = new pg();
        string StrQuery = string.Empty;
        private void GenExpense_Load(object sender, EventArgs e)
        {
            try
            {
                string StrQry = "SELECT SUM(gen_amount) AS TotalAmount FROM tbl_genexpense;";
                if (tea.SqlDatatable(StrQry) != null)
                {
                    //int conv = Convert.ToInt32(StrQry);
                    lbl_totalamount.Text = tea.SqlDatatable(StrQry).ToString();
                }
                else
                {
                    lbl_totalamount.Text = "Null";
                }
                txt_id.Enabled = false;
                StrQuery = "select * from tbl_contract";
                tea.SqlDatatable(StrQuery);
                genexpensegrid.DataSource = pg.dt;

                StrQuery = "select ISNull (max(gen_ID),0)+1 from tbl_genexpense";
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {


                StrQuery = "delete tbl_genexpense where gen_ID = '" + txt_id.Text.Trim().ToString() + "' ";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_genexpense";
                tea.SqlDatatable(StrQuery);
                genexpensegrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(gen_ID),0)+1 from tbl_genexpense";
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                string StrQry = "SELECT SUM(gen_amount) AS TotalAmount FROM tbl_genexpense;";
                lbl_totalamount.Text = StrQry.ToString();
                StrQuery = "select * from tbl_genexpense";
                tea.SqlDatatable(StrQuery);
                genexpensegrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(gen_ID),0)+1 from tbl_genexpense";
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "select * from tbl_genexpense";
                tea.SqlDatatable(StrQuery);
                genexpensegrid.DataSource = pg.dt;
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

                if (comboBox1.Text == "Name")
                {
                    StrQuery = "select * from tbl_genexpense where gen_Name = '" + txt_con_name.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    genexpensegrid.DataSource = pg.dt;

                }

                else if (comboBox1.Text == "Amount")
                {
                    StrQuery = "select * from tbl_genexpense where gen_amount = '" + txt_amount.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    genexpensegrid.DataSource = pg.dt;

                }
                else if (comboBox1.Text == "UnitQuantity")
                {
                    StrQuery = "select * from tbl_genexpense where gen_unit_quantity = '" + txt_unit_qty + "'";
                    tea.SqlDatatable(StrQuery);
                    genexpensegrid.DataSource = pg.dt;
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
                string StrQry = "SELECT SUM(gen_amount) AS TotalAmount FROM tbl_genexpense;";
                lbl_totalamount.Text = tea.SqlDatatable(StrQry).ToString();
                decimal amount = Convert.ToDecimal(txt_quantity.Text) * Convert.ToDecimal(txt_unit_qty.Text);// * Convert.ToDecimal(txt_amount);
                StrQuery = "insert into tbl_genexpense values('" + txt_con_name.Text.Trim().ToString() + "','" + txt_quantity.Text.Trim().ToString() + "','" + txt_unit.SelectedItem.ToString() + "','" + txt_unit_qty.Text.Trim().ToString() + "','" + amount.ToString() + "','" + txt_remarks.Text.Trim().ToString() + "');";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_genexpense";
                tea.SqlDatatable(StrQuery);
                genexpensegrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(gen_ID),0)+1 from tbl_genexpense";
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
                string StrQry = "SELECT SUM(gen_amount) AS TotalAmount FROM tbl_genexpense;";
                lbl_totalamount.Text = tea.SqlDatatable(StrQry).ToString();
                decimal amount = Convert.ToDecimal(txt_quantity.Text) * Convert.ToDecimal(txt_unit_qty.Text);
                StrQuery = "update tbl_genexpense set gen_Name = '" + txt_con_name.Text.Trim().ToString() + "',gen_quantity = '" + txt_quantity.Text.Trim().ToString() + "',gen_unit = '" + txt_unit.SelectedItem.ToString() + "',gen_unit_quantity = '" + txt_unit_qty.Text.Trim().ToString() + "',gen_amount = '" + amount.ToString() + "',gen_remarks = '" +txt_remarks.Text.Trim().ToString() + "' where gen_ID = '" + txt_id.Text.Trim().ToString() + "'";
                tea.simInsert(StrQuery);
                MessageBox.Show("Successful Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_genexpense";
                tea.SqlDatatable(StrQuery);
                genexpensegrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(gen_ID),0)+1 from tbl_genexpense";
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

        private void genexpensegrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_id.Text = genexpensegrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_con_name.Text = genexpensegrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_quantity.Text = genexpensegrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_unit.Text = genexpensegrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_unit_qty.Text = genexpensegrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_amount.Text = genexpensegrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_remarks.Text = genexpensegrid.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
