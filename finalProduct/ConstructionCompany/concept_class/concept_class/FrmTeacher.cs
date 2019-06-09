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
    public partial class FrmTeacher : Form
    {

        pg tea = new pg();
        string StrQuery = string.Empty;

        public FrmTeacher()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    StrQuery = "insert into teacher values( '" + txt_name.Text.Trim().ToString() + "','" + txt_Father.Text.Trim().ToString() + "','" + radioButton1.Text + "','" + txt_contact.Text.Trim().ToString() + "','" + txt_address.Text.Trim().ToString() + "','" + txt_cnic.Text.Trim().ToString() + "','" + dateTimePicker1.Text + "');";
                    tea.simInsert(StrQuery);
                }
                if (radioButton2.Checked == true)
                {
                    StrQuery = "insert into teacher values( '" + txt_name.Text.Trim().ToString() + "','" + txt_Father.Text.Trim().ToString() + "','" + radioButton2.Text + "','" + txt_contact.Text.Trim().ToString() + "','" + txt_address.Text.Trim().ToString() + "','" + txt_cnic.Text.Trim().ToString() + "','" + dateTimePicker1.Text + "');";
                    tea.simInsert(StrQuery);
                }
                MessageBox.Show("Successful Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from teacher";
                tea.SqlDatatable(StrQuery);
                dataGridView1.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(teacherID),0)+1 from teacher";
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
                if (radioButton1.Checked == true)
                {
                    StrQuery = "update teacher set tea_Name = '" + txt_name.Text.Trim().ToString() + "',tea_fatherName = '" + txt_Father.Text.Trim().ToString() + "',tea_Gender = '" + radioButton1.Text + "',tea_contactNo = '" + txt_contact.Text.Trim().ToString() + "',tea_address = '" + txt_address.Text.Trim().ToString() + "',tea_cnic = '" + txt_cnic.Text.Trim().ToString() + "',Date = '" + dateTimePicker1.Text + "' where teacherID = '"+txt_id.Text.Trim().ToString() + "'";
                    tea.simInsert(StrQuery);
                }
                if (radioButton2.Checked == true)
                {
                    StrQuery = "update teacher set tea_Name = '" + txt_name.Text.Trim().ToString() + "',tea_fatherName = '" + txt_Father.Text.Trim().ToString() + "',tea_Gender = '" + radioButton2.Text + "',tea_contactNo = '" + txt_contact.Text.Trim().ToString() + "',tea_address = '" + txt_address.Text.Trim().ToString() + "',tea_cnic = '" + txt_cnic.Text.Trim().ToString() + "',Date = '" + dateTimePicker1.Text + "'where teacherID = '" + txt_id.Text.Trim().ToString() + "' ";
                    tea.simInsert(StrQuery);
                }
                MessageBox.Show("Successful Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from teacher";
                tea.SqlDatatable(StrQuery);
                dataGridView1.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(teacherID),0)+1 from teacher";
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


                StrQuery = "delete teacher where teacherID = '" + txt_id.Text.Trim().ToString() + "' ";
                tea.simInsert(StrQuery);
                
                MessageBox.Show("Successful Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StrQuery = "select * from teacher";
                tea.SqlDatatable(StrQuery);
                dataGridView1.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(teacherID),0)+1 from teacher";
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
                StrQuery = "select * from teacher";
                tea.SqlDatatable(StrQuery);
                dataGridView1.DataSource = pg.dt;
                clr();

                StrQuery = "select ISNull (max(teacherID),0)+1 from teacher";
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

        private void FrmTeacher_Load(object sender, EventArgs e)
        {
            try
            {
                txt_id.Enabled = false;
                StrQuery = "select * from teacher";
                tea.SqlDatatable(StrQuery);
                dataGridView1.DataSource = pg.dt;

                StrQuery = "select ISNull (max(teacherID),0)+1 from teacher";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                

                    txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txt_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txt_Father.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txt_contact.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txt_cnic.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    txt_address.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                
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
                    StrQuery = "select * from teacher where teacherID = '" + txt_id.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    dataGridView1.DataSource = pg.dt;

                }

                else if (comboBox1.Text == "Name")
                {
                    StrQuery = "select * from teacher where tea_Name = '" + txt_name.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    dataGridView1.DataSource = pg.dt;

                }
                else if (comboBox1.Text == "CNIC")
                {
                    StrQuery = "select * from teacher where tea_cnic = '" + txt_cnic.Text + "'";
                    tea.SqlDatatable(StrQuery);
                    dataGridView1.DataSource = pg.dt;

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


        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "ID")
                {
                    id();
                }
                if (comboBox1.Text == "Name")
                {
                    name();
                }
                if (comboBox1.Text == "CNIC")
                {
                    cnic();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void id() {
            txt_id.Enabled = true;
            txt_name.Enabled = false;
            txt_Father.Enabled = false;
            txt_contact.Enabled = false;
            txt_address.Enabled = false;
            txt_cnic.Enabled = false;
            dateTimePicker1.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;

        }
        public void name() {
            txt_name.Enabled = true;
            txt_id.Enabled = false;
            txt_Father.Enabled = false;
            txt_contact.Enabled = false;
            txt_address.Enabled = false;
            txt_cnic.Enabled = false;
            dateTimePicker1.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;

        }
        public void cnic() {
            txt_cnic.Enabled = true;
            txt_name.Enabled = false;
            txt_Father.Enabled = false;
            txt_contact.Enabled = false;
            txt_address.Enabled = false;
            txt_id.Enabled = false;
            dateTimePicker1.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;

        }

        public void Ref()
        {
            txt_id.Enabled = false;
            txt_name.Enabled = true;
            txt_Father.Enabled = true;
            txt_contact.Enabled = true;
            txt_address.Enabled = true;
            txt_cnic.Enabled = true;
            dateTimePicker1.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                StrQuery = "select * from teacher";
                tea.SqlDatatable(StrQuery);
                dataGridView1.DataSource = pg.dt;
                MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clr() {
            txt_id.Text = "";
            txt_name.Text = "";
            txt_Father.Text = "";
            txt_contact.Text = "";
            txt_cnic.Text = "";
            txt_address.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
        }

        
    }
}
