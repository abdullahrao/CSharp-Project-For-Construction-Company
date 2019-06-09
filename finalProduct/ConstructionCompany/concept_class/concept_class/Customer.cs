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
    public partial class Customer : Form
    {

        pg tea = new pg();
        string StrQuery = string.Empty;


        public Customer()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "select * from tbl_customer";
                tea.SqlDatatable(StrQuery);
                gridCustomer.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(cust_ID),0)+1 from tbl_customer";
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
        public void Ref()
        {
            txt_id.Enabled = false;
            txt_name.Enabled = true;
            txt_email.Enabled = true;
            txt_contact.Enabled = true;
            txt_address.Enabled = true;
            txt_cnic.Enabled = true;
            dateTimePicker1.Enabled = true;
            radiomale.Enabled = true;
            radiofemale.Enabled = true;

        }
        public void id()
        {
            txt_id.Enabled = true;
            txt_name.Enabled = false;
            txt_email.Enabled = false;
            txt_contact.Enabled = false;
            txt_address.Enabled = false;
            txt_cnic.Enabled = false;
            dateTimePicker1.Enabled = false;
            radiomale.Enabled = false;
            radiofemale.Enabled = false;

        }
        public void name()
        {
            txt_name.Enabled = true;
            txt_id.Enabled = false;
            txt_email.Enabled = false;
            txt_contact.Enabled = false;
            txt_address.Enabled = false;
            txt_cnic.Enabled = false;
            dateTimePicker1.Enabled = false;
            radiomale.Enabled = false;
            radiofemale.Enabled = false;

        }
        public void cnic()
        {
            txt_cnic.Enabled = true;
            txt_name.Enabled = false;
            txt_email.Enabled = false;
            txt_contact.Enabled = false;
            txt_address.Enabled = false;
            txt_id.Enabled = false;
            dateTimePicker1.Enabled = false;
            radiomale.Enabled = false;
            radiofemale.Enabled = false;

        }

        public void clr()
        {
            txt_id.Text = "";
            txt_name.Text = "";
            txt_email.Text = "";
            txt_contact.Text = "";
            txt_cnic.Text = "";
            txt_address.Text = "";
            radiomale.Enabled = false;
            radiofemale.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            try
            {
                txt_id.Enabled = false;
                StrQuery = "select * from tbl_customer";
                tea.SqlDatatable(StrQuery);
                gridCustomer.DataSource = pg.dt;

                StrQuery = "select ISNull (max(cust_ID),0)+1 from tbl_customer";
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
                if (radiomale.Checked == true)
                {
                    StrQuery = "insert into tbl_customer values('" + txt_name.Text.Trim().ToString() + "','" + txt_email.Text.Trim().ToString() + "', '" + txt_contact.Text.Trim().ToString() + "','" + txt_address.Text + "','" + txt_cnic.Text.Trim().ToString() + "', '" + radiomale.Text + "', '" + dateTimePicker1.Text + "')";
                    tea.simInsert(StrQuery);
                }
                if (radiofemale.Checked == true)
                {
                    StrQuery = "insert into tbl_customer values('" + txt_name.Text.Trim().ToString() + "','" + txt_email.Text.Trim().ToString() + "', '" + txt_contact.Text.Trim().ToString() + "','" + txt_address.Text + "','" + txt_cnic.Text.Trim().ToString() + "', '" + radiofemale.Text + "', '" + dateTimePicker1.Text + "');";
                    tea.simInsert(StrQuery);
                }
                MessageBox.Show("Successful Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from teacher";
                tea.SqlDatatable(StrQuery);
                gridCustomer.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(cust_ID),0)+1 from tbl_customer";
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
                if (radiomale.Checked == true)
                {
                    StrQuery = "update tbl_customer set cust_Name = '" + txt_name.Text.Trim().ToString() + "',cust_email = '" + txt_email.Text.Trim().ToString() + "',cust_contactno = '" + txt_contact.Text.Trim().ToString() + "',cust_address = '" + txt_address.Text + "',cust_cnic = '" + txt_cnic.Text.Trim().ToString() + "',cust_gender = '" + radiomale.Text + "',Date = '" + dateTimePicker1.Text + "' where cust_ID = '" + txt_id.Text.Trim().ToString() + "'";
                    tea.simInsert(StrQuery);
                }
                if (radiofemale.Checked == true)
                {
                    StrQuery = "update tbl_customer set cust_Name = '" + txt_name.Text.Trim().ToString() + "',cust_email = '" + txt_email.Text.Trim().ToString() + "',cust_contactno = '" + txt_contact.Text.Trim().ToString() + "',cust_address = '" + txt_address.Text + "',cust_cnic = '" + txt_cnic.Text.Trim().ToString() + "',cust_gender = '" + radiofemale.Text + "',Date = '" + dateTimePicker1.Text + "' where cust_ID = '" + txt_id.Text.Trim().ToString() + "'";
                    tea.simInsert(StrQuery);
                }
                MessageBox.Show("Successful Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from teacher";
                tea.SqlDatatable(StrQuery);
                gridCustomer.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(cust_ID),0)+1 from tbl_customer";
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


                StrQuery = "delete tbl_customer where cust_ID = '" + txt_id.Text.Trim().ToString() + "' ";
                tea.simInsert(StrQuery);

                MessageBox.Show("Successful Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from tbl_customer";
                tea.SqlDatatable(StrQuery);
                gridCustomer.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(cust_ID),0)+1 from tbl_customer";
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

                if (comboBox1.Text == "ID")
                {
                    StrQuery = "select * from tbl_customer where cust_ID = '" + txt_id.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    gridCustomer.DataSource = pg.dt;

                }

                else if (comboBox1.Text == "Name")
                {
                    StrQuery = "select * from tbl_customer where cust_Name = '" + txt_name.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    gridCustomer.DataSource = pg.dt;

                }
                else if (comboBox1.Text == "CNIC")
                {
                    StrQuery = "select * from tbl_customer where cust_cnic = '" + txt_cnic.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    gridCustomer.DataSource = pg.dt;

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
                StrQuery = "select * from tbl_customer";
                tea.SqlDatatable(StrQuery);
                gridCustomer.DataSource = pg.dt;
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



        private void gridCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void gridCustomer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                txt_id.Text = gridCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_name.Text = gridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_email.Text = gridCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_contact.Text = gridCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_address.Text = gridCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_cnic.Text = gridCustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
            
                dateTimePicker1.Text = gridCustomer.Rows[e.RowIndex].Cells[7].Value.ToString();
                if (gridCustomer.Rows[e.RowIndex].Cells[6].Value.ToString() == "Male")
                {
                    radiomale.Checked = true;
                }
                else
                {
                    radiofemale.Checked = true;
                }
                dateTimePicker1.Value = Convert.ToDateTime(gridCustomer.Rows[e.RowIndex].Cells[7].Value);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void gridCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
