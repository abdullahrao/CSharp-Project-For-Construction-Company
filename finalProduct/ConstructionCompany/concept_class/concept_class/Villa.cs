using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace concept_class
{
    public partial class Villa : Form
    {
        public Villa()
        {
            InitializeComponent();
            Fill_combo();
        }
        pg tea = new pg();
        string StrQuery = string.Empty;

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cust_names_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void Villa_Load(object sender, EventArgs e)
        {
            try
            {
                txt_id.Enabled = false;
                StrQuery = "select * from tbl_villa";
                tea.SqlDatatable(StrQuery);
                villagridview.DataSource = pg.dt;

                StrQuery = "select ISNull (max(villa_ID),0)+1 from tbl_villa";
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

        public void Fill_combo()
        {
            try
            {
                StrQuery = "select * from tbl_customer";
                tea.SqlDatatable(StrQuery);// da = new SqlDataAdapter("Select * from tbl_customer", Connection);
                for (int i = 0; i < pg.dt.Rows.Count; i++)
                {
                    cust_names.Items.Add(pg.dt.Rows[i]["cust_Name"]);

                }
                cust_names.DisplayMember = "cust_Name";
                cust_names.ValueMember = "cust_ID";
            }
            catch(Exception ex)
            {

            }
            
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                long a = Convert.ToInt64(txt_bud.Text.Trim().ToString());
                StrQuery = "insert into tbl_villa values('" + txt_name.Text.Trim().ToString() + "','" + txt_address.Text.Trim().ToString() + "', '" + txt_Code.Text.Trim().ToString() + "','" + txt_desc.Text + "','" + cust_names.SelectedItem + "','" + a + "');";
                tea.simInsert(StrQuery);
               
                MessageBox.Show("Successful Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_villa";
                tea.SqlDatatable(StrQuery);
                villagridview.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(villa_ID),0)+1 from tbl_villa";
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
            txt_name.Text = "";
            txt_address.Text = "";
            txt_Code.Text = "";
            txt_desc.Text = "";
            txt_bud.Text = "";
        }
        public void Ref()
        {
            txt_id.Enabled = false;
            txt_name.Enabled = true;
            txt_address.Enabled = true;
            txt_Code.Enabled = true;
            txt_desc.Enabled = true;
            txt_bud.Enabled = true;
        }
        public void id()
        {
            txt_id.Enabled = true;
            txt_name.Enabled = false;
            txt_address.Enabled = false;
            txt_Code.Enabled = false;
            txt_desc.Enabled = false;
            txt_bud.Enabled = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "select * from tbl_villa";
                tea.SqlDatatable(StrQuery);
                villagridview.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(villa_ID),0)+1 from tbl_villa";
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
                StrQuery = "select * from tbl_villa";
                tea.SqlDatatable(StrQuery);
                villagridview.DataSource = pg.dt;
                MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                long a = Convert.ToInt64(txt_bud.Text.Trim().ToString());
                StrQuery = "update tbl_villa set villa_Name = '" + txt_name.Text.Trim().ToString() + "',villa_address = '" + txt_address.Text.Trim().ToString() + "',villa_code = '" + txt_Code.Text.Trim().ToString() + "',villa_desc = '" + txt_desc.Text.Trim().ToString() + "',cust_name = '" + cust_names.SelectedItem.ToString() + "',vill_bud = '" + a + "' where villa_ID = '" + txt_id.Text.Trim().ToString() + "'";
                tea.simInsert(StrQuery);
                MessageBox.Show("Successful Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_villa";
                tea.SqlDatatable(StrQuery);
                villagridview.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(villa_ID),0)+1 from tbl_villa";
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


                StrQuery = "delete tbl_villa where villa_ID = '" + txt_id.Text.Trim().ToString() + "' ";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_villa";
                tea.SqlDatatable(StrQuery);
                villagridview.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(villa_ID),0)+1 from tbl_villa";
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
                    StrQuery = "select * from tbl_villa where villa_Name = '" + txt_name.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    villagridview.DataSource = pg.dt;

                }

                else if (comboBox1.Text == "Code")
                {
                    StrQuery = "select * from tbl_villa where villa_code = '" + txt_Code.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    villagridview.DataSource = pg.dt;

                }
                else if (comboBox1.Text == "Customer")
                {
                    StrQuery = "select * from tbl_villa where cust_name = '" + comboBox1.SelectedItem + "'";
                    tea.SqlDatatable(StrQuery);
                    villagridview.DataSource = pg.dt;
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

        private void villagridview_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                txt_id.Text = villagridview.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_name.Text = villagridview.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_address.Text = villagridview.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_Code.Text = villagridview.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_desc.Text = villagridview.Rows[e.RowIndex].Cells[4].Value.ToString();
                cust_names.SelectedItem = villagridview.Rows[e.RowIndex].Cells[5].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void villagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

