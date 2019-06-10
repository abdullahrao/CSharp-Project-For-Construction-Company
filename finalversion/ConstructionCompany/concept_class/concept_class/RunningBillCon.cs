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
    public partial class RunningBillCon : Form
    {
        public RunningBillCon()
        {
            InitializeComponent();
            FillComboContrac();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        pg tea = new pg();
        string StrQuery = string.Empty;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_id.Enabled = false;
                //contract_grid.DataSource = pg.dt;
                StrQuery = "select * from tbl_contract where contrac_Name='" + txt_ConName.Text + "'";
                tea.connection_Opener();
                tea.data_fetchCmd(StrQuery);
                if (pg.dr.Read())
                {
                    txt_id.Text = pg.dr[0].ToString();
                    string amount = (string)pg.dr["contrac_amount"].ToString();
                    lbl_totalamount.Text = amount;

                    string quan = (string)pg.dr["contrac_quantity"].ToString();
                    lbl_quantity.Text = quan;

                    string unitquantity = (string)pg.dr["contrac_unit_quantity"].ToString();
                    lbl_unitquan.Text = unitquantity;

                    string unit = (string)pg.dr["contrac_unit"].ToString();
                    lbl_unit.Text = unit;

                    string name = (string)pg.dr["contrac_Name"].ToString();
                    lbl_name.Text = name;

                    string remarks = (string)pg.dr["contrac_remarks"].ToString();
                    lbl_remarks.Text = remarks;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void FillComboContrac()
        {
            try
            {
                StrQuery = "select * from tbl_contract";// where contrac_Name='" + txt_ConName.Text + "'";
                tea.SqlDatatable(StrQuery);// da = new SqlDataAdapter("Select * from tbl_customer", Connection);
                for (int i = 0; i < pg.dt.Rows.Count; i++)
                {
                    txt_ConName.Items.Add(pg.dt.Rows[i]["contrac_Name"]);

                }
                txt_ConName.DisplayMember = "contrac_Name";
                txt_ConName.ValueMember = "contrac_ID";
            }
            catch (Exception ex)
            {

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void Ref()
        {
            txt_id.Enabled = false;
            txt_ConName.Enabled = true;
            txt_quantity.Enabled = true;
        }
        public void id()
        {
            txt_id.Enabled = true;
            txt_ConName.Enabled = false;
            txt_quantity.Enabled = false;

        }
        public void clr()
        {
            txt_id.Text = "";
            txt_quantity.Text = "";
            txt_ConName.SelectedText = "";
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //string StrQry = "SELECT SUM(contrac_amount) AS TotalAmount FROM tbl_contract;";
                //lbl_totalamount.Text = StrQry.ToString();
                if (Convert.ToDecimal(txt_quantity.Text) < Convert.ToDecimal(lbl_quantity.Text))
                {
                    decimal rem = Convert.ToDecimal(txt_quantity.Text) * Convert.ToDecimal(lbl_unitquan.Text) * Convert.ToDecimal(lbl_totalamount.Text);
                    StrQuery = "insert into tbl_bill values('" + lbl_name.Text.Trim().ToString() + "','" + txt_quantity.Text.Trim().ToString() + "','" + lbl_unit.Text.Trim().ToString() + "','" + lbl_unitquan.Text.Trim().ToString() + "','" + lbl_totalamount.Text.Trim().ToString() + "','" + rem.ToString() + "');";
                    tea.simInsert(StrQuery);

                    MessageBox.Show("Successful Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StrQuery = "select * from tbl_bill";
                    tea.SqlDatatable(StrQuery);
                    contract_grid.DataSource = pg.dt;
                    clr();

                    StrQuery = "select ISNull (max(bill_ID),0)+1 from tbl_bill";
                    tea.connection_Opener();
                    tea.data_fetchCmd(StrQuery);
                    if (pg.dr.Read())
                    {
                        txt_id.Text = pg.dr[0].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Quantity", "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //string StrQry = "SELECT SUM(contrac_amount) AS TotalAmount FROM tbl_bill;";
                //lbl_totalamount.Text = StrQry.ToString();
                decimal rem = Convert.ToDecimal(txt_quantity.Text) * Convert.ToDecimal(lbl_unitquan.Text) * Convert.ToDecimal(lbl_totalamount.Text);
                StrQuery = "update tbl_bill set cont_quantity = '" + txt_quantity.Text.Trim().ToString() + "' where bill_ID = '" + txt_id.Text.Trim().ToString() + "'";
                tea.simInsert(StrQuery);
                //string StrQry = "insert into tbl_bill values('" + lbl_name.Text.Trim().ToString() + "','" + txt_quantity.Text.Trim().ToString() + "','" + lbl_unit.Text.Trim().ToString() + "','" + lbl_unitquan.Text.Trim().ToString() + "','" + lbl_totalamount.Text.Trim().ToString() + "','" + rem.ToString() + "');";
                //tea.simInsert(StrQry);
                MessageBox.Show("Successful Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_bill";
                tea.SqlDatatable(StrQuery);
                contract_grid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(bill_ID),0)+1 from tbl_bill";
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
                StrQuery = "delete tbl_bill where bill_ID = '" + txt_id.Text.Trim().ToString() + "' ";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_bill";
                tea.SqlDatatable(StrQuery);
                contract_grid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(bill_ID),0)+1 from tbl_bill";
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
                //string StrQry = "SELECT SUM(contrac_amount) AS TotalAmount FROM tbl_bill;";
                //lbl_totalamount.Text = StrQry.ToString();
                StrQuery = "select * from tbl_bill";
                tea.SqlDatatable(StrQuery);
                contract_grid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(bill_ID),0)+1 from tbl_bill";
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
                StrQuery = "select * from tbl_bill";
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

        private void contract_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_id.Text = contract_grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_quantity.Text = contract_grid.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_ConName.SelectedItem= contract_grid.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
