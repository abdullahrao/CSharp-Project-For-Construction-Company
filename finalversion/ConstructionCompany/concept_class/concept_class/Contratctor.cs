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
    public partial class Contratctor : Form
    {
        public Contratctor()
        {
            InitializeComponent();
        }
        pg tea = new pg();
        string StrQuery = string.Empty;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Contratctor_Load(object sender, EventArgs e)
        {
            try
            {
                txt_id.Enabled = false;
                StrQuery = "select * from tbl_contractor";
                tea.SqlDatatable(StrQuery);
                congrid.DataSource = pg.dt;

                StrQuery = "select ISNull (max(con_ID),0)+1 from tbl_contractor";
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
                StrQuery = "insert into tbl_contractor values('" + txt_name.Text.Trim().ToString() + "','" + txt_email.Text.Trim().ToString() + "', '" + txt_address.Text.Trim().ToString() + "','" + txt_postal.Text.Trim().ToString() + "','" + txt_cnic.Text.Trim().ToString() + "','" + txt_contact.Text.Trim().ToString() + "','" + txt_fair.Text.Trim().ToString() + "');";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_contractor";
                tea.SqlDatatable(StrQuery);
                congrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(con_ID),0)+1 from tbl_contractor";
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
            txt_cnic.Text = "";
            txt_postal.Text = "";
            txt_contact.Text = "";
            txt_email.Text = "";
            txt_fair.Text = "";
        }
        public void Ref()
        {
            txt_id.Enabled = false;
            txt_name.Enabled = true;
            txt_address.Enabled = true;
            txt_cnic.Enabled =true;
            txt_postal.Enabled = true;
            txt_contact.Enabled =true;
            txt_email.Enabled =true;
            txt_fair.Enabled = true;
        }
        public void id()
        {
            txt_id.Enabled = true;
            txt_name.Enabled = false;
            txt_address.Enabled = false;
            txt_cnic.Enabled = false;
            txt_postal.Enabled = false;
            txt_contact.Enabled = false;
            txt_email.Enabled = false;
            txt_fair.Enabled = false;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "update tbl_contractor set con_Name = '" + txt_name.Text.Trim().ToString() + "',con_email = '" + txt_email.Text.Trim().ToString() + "',con_address = '" + txt_address.Text.Trim().ToString() + "',con_postalcode = '" + txt_postal.Text.Trim().ToString() + "',con_cnic = '" + txt_cnic.Text.Trim().ToString() + "',con_contactno = '" + txt_contact.Text.Trim().ToString() + "',con_fair_base = '" + txt_fair.Text.Trim().ToString() + "' where con_ID = '" + txt_id.Text.Trim().ToString() + "'";
                tea.simInsert(StrQuery);
                MessageBox.Show("Successful Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_contractor";
                tea.SqlDatatable(StrQuery);
                congrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(con_ID),0)+1 from tbl_contractor";
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
                StrQuery = "delete tbl_contractor where con_ID = '" + txt_id.Text.Trim().ToString() + "' ";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_contractor";
                tea.SqlDatatable(StrQuery);
                congrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(con_ID),0)+1 from tbl_contractor";
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
                StrQuery = "select * from tbl_contractor";
                tea.SqlDatatable(StrQuery);
                congrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(con_ID),0)+1 from tbl_contractor";
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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboBox1.Text == "Name")
                {
                    StrQuery = "select * from tbl_contractor where con_Name = '" + txt_name.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    congrid.DataSource = pg.dt;

                }

                else if (comboBox1.Text == "Email")
                {
                    StrQuery = "select * from tbl_contractor where con_code = '" + txt_email.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    congrid.DataSource = pg.dt;

                }
                else if (comboBox1.Text == "PostalCode")
                {
                    StrQuery = "select * from tbl_contractor where con_postalcode = '" + txt_postal.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    congrid.DataSource = pg.dt;
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
                StrQuery = "select * from tbl_contractor";
                tea.SqlDatatable(StrQuery);
                congrid.DataSource = pg.dt;
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
        private void congrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txt_id.Text = congrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_name.Text = congrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_email.Text = congrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_address.Text = congrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_postal.Text = congrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_cnic.Text = congrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_contact.Text = congrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                txt_fair.Text = congrid.Rows[e.RowIndex].Cells[7].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
