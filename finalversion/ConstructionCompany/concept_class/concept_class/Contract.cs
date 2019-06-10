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
    public partial class Contract : Form
    {
        public Contract()
        {
            InitializeComponent();
        }
        pg tea = new pg();
        string StrQuery = string.Empty;
        private void Contract_Load(object sender, EventArgs e)
        {

            try
            {
                //string StrQry = "SELECT SUM(contrac_amount) AS TotalAmount FROM tbl_contract;";
                //lbl_totalamount.Text = StrQry.ToString();
                txt_id.Enabled = false;
                StrQuery = "select * from tbl_contract";
                tea.SqlDatatable(StrQuery);
                contract_grid.DataSource = pg.dt;

                StrQuery = "select ISNull (max(contrac_ID),0)+1 from tbl_contract";
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
                //string StrQry = "SELECT SUM(contrac_amount) AS TotalAmount FROM tbl_contract;";
                //lbl_totalamount.Text = tea.SqlDatatable(StrQry).ToString();
                //lbl_totalamount.Text = StrQry.ToString();
                StrQuery = "select * from tbl_contract";
                tea.SqlDatatable(StrQuery);
                contract_grid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(contrac_ID),0)+1 from tbl_contract";
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "select * from tbl_contract";
                tea.SqlDatatable(StrQuery);
                contract_grid.DataSource = pg.dt;
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {


                StrQuery = "delete tbl_contract where contrac_ID = '" + txt_id.Text.Trim().ToString() + "' ";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_contract";
                tea.SqlDatatable(StrQuery);
                contract_grid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(contrac_ID),0)+1 from tbl_contract";
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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboBox1.Text == "Name")
                {
                    StrQuery = "select * from tbl_contract where contrac_Name = '" + txt_con_name.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    contract_grid.DataSource = pg.dt;

                }

                else if (comboBox1.Text == "Amount")
                {
                    StrQuery = "select * from tbl_contract where contrac_amount = '" + txt_amount.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    contract_grid.DataSource = pg.dt;

                }
                else if (comboBox1.Text == "UnitQuantity")
                {
                    StrQuery = "select * from tbl_contract where contrac_unit_quantity = '" + txt_unit_qty + "'";
                    tea.SqlDatatable(StrQuery);
                    contract_grid.DataSource = pg.dt;
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
                //string StrQry = "SELECT SUM(contrac_amount) AS TotalAmount FROM tbl_contract;";
                //lbl_totalamount.Text = tea.SqlDatatable(StrQry).ToString();
                //lbl_totalamount.Text = StrQry.ToString();
                decimal rem = Convert.ToDecimal(txt_quantity.Text) * Convert.ToDecimal(txt_unit_qty.Text) * Convert.ToDecimal(txt_amount.Text);
                StrQuery = "insert into tbl_contract values('" + txt_con_name.Text.Trim().ToString() + "','" + txt_quantity.Text.Trim().ToString() + "','" + txt_unit.SelectedItem.ToString() + "','" + txt_unit_qty.Text.Trim().ToString() + "','" + txt_amount.Text.Trim().ToString() + "','" + rem.ToString() + "');";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_contract";
                tea.SqlDatatable(StrQuery);
                contract_grid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(contrac_ID),0)+1 from tbl_contract";
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
               // string StrQry = "SELECT SUM(contrac_amount) AS TotalAmount FROM tbl_contract;";
                //lbl_totalamount.Text = tea.SqlDatatable(StrQry).ToString();
                //lbl_totalamount.Text = StrQry.ToString();
                decimal rem = Convert.ToDecimal(txt_quantity.Text) * Convert.ToDecimal(txt_unit_qty.Text) * Convert.ToDecimal(txt_amount.Text);
                StrQuery = "update tbl_contract set contrac_Name = '" + txt_con_name.Text.Trim().ToString() + "',contrac_quantity = '" + txt_quantity.Text.Trim().ToString() + "',contrac_unit = '" + txt_unit.SelectedItem.ToString() + "',contrac_unit_quantity = '" + txt_unit_qty.Text.Trim().ToString() + "',contrac_amount = '" + txt_amount.Text.Trim().ToString() + "',contrac_remarks = '" + rem.ToString() + "' where contrac_ID = '" + txt_id.Text.Trim().ToString() + "'";
                tea.simInsert(StrQuery);
                MessageBox.Show("Successful Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_contract";
                tea.SqlDatatable(StrQuery);
                contract_grid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(contrac_ID),0)+1 from tbl_contract";
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

        private void contract_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_id.Text = contract_grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_con_name.Text = contract_grid.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_quantity.Text = contract_grid.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_unit.Text = contract_grid.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_unit_qty.Text = contract_grid.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_amount.Text = contract_grid.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_remarks.Text = contract_grid.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
