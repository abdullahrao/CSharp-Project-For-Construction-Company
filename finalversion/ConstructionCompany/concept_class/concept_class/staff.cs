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
    public partial class staff : Form
    {
        public staff()
        {
            InitializeComponent();
        }

        pg tea = new pg();
        string StrQuery = string.Empty;

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void staff_Load(object sender, EventArgs e)
        {
            try
            {
                txt_id.Enabled = false;
                StrQuery = "select * from tbl_staff";
                tea.SqlDatatable(StrQuery);
                staffgrid.DataSource = pg.dt;

                StrQuery = "select ISNull (max(staff_ID),0)+1 from tbl_staff";
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
                StrQuery = "insert into tbl_staff values('" + txt_name.Text.Trim().ToString() + "','" + txt_address.Text.Trim().ToString() + "', '" + txt_cnic.Text.Trim().ToString() + "','" + txt_contact.Text.Trim().ToString() + "','" + txt_position.Text.Trim().ToString()+ "');";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_staff";
                tea.SqlDatatable(StrQuery);
                staffgrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(staff_ID),0)+1 from tbl_staff";
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
            txt_contact.Text = "";
            txt_position.Text = "";
        }
        public void Ref()
        {
            txt_id.Enabled = false;
            txt_name.Enabled = true;
            txt_address.Enabled = true;
            txt_cnic.Enabled = true;
            txt_position.Enabled = true;
            txt_contact.Enabled = true;
        }
        public void id()
        {
            txt_id.Enabled = true;
            txt_name.Enabled = false;
            txt_address.Enabled = false;
            txt_cnic.Enabled = false;
            txt_contact.Enabled = false;
            txt_position.Enabled = false;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "update tbl_staff set staff_Name = '" + txt_name.Text.Trim().ToString() + "',staff_address = '" + txt_address.Text.Trim().ToString() + "',staff_cnic = '" + txt_cnic.Text.Trim().ToString() + "',staff_contactno = '" + txt_contact.Text.Trim().ToString() + "',staff_position = '" + txt_position.Text.Trim().ToString() + "' where staff_ID = '" + txt_id.Text.Trim().ToString() + "'";
                tea.simInsert(StrQuery);
                MessageBox.Show("Successful Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_staff";
                tea.SqlDatatable(StrQuery);
                staffgrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(staff_ID),0)+1 from tbl_staff";
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


                StrQuery = "delete tbl_staff where staff_ID = '" + txt_id.Text.Trim().ToString() + "' ";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_staff";
                tea.SqlDatatable(StrQuery);
                staffgrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(staff_ID),0)+1 from tbl_staff";
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
                StrQuery = "select * from tbl_staff";
                tea.SqlDatatable(StrQuery);
                staffgrid.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(staff_ID),0)+1 from tbl_staff";
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
                    StrQuery = "select * from tbl_staff where staff_Name = '" + txt_name.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    staffgrid.DataSource = pg.dt;

                }

                else if (comboBox1.Text == "Contact")
                {
                    StrQuery = "select * from tbl_staff where staff_contactno = '" + txt_contact.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    staffgrid.DataSource = pg.dt;

                }
                else if (comboBox1.Text == "Position")
                {
                    StrQuery = "select * from tbl_staff where staff_position = '" + txt_position.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    staffgrid.DataSource = pg.dt;
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
                StrQuery = "select * from tbl_staff";
                tea.SqlDatatable(StrQuery);
                staffgrid.DataSource = pg.dt;
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

        private void staffgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_id.Text = staffgrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_name.Text = staffgrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_address.Text = staffgrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_cnic.Text = staffgrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_contact.Text = staffgrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_position.Text = staffgrid.Rows[e.RowIndex].Cells[5].Value.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
