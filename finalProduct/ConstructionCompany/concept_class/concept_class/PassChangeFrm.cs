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
    public partial class PassChangeFrm : Form
    {
        pg Obj = new pg();
        enMethod clspass = new enMethod();
        string strQuery = string.Empty;
        string strQuery1 = string.Empty;
        string strQuery2 = string.Empty;
        string strQuery3 = string.Empty;
        string strQuery4 = string.Empty;
        public PassChangeFrm()
        {
            InitializeComponent();
        }

        private void btn_Change_Click(object sender, EventArgs e)
        {
            try
            {
                strQuery3 = Form1._txtName + txt_CurrentPass.Text.Trim().ToString() + "abdullah";
                strQuery4 = clspass.MD5Encrypt(strQuery3);
                if (strQuery4 == Form1.val2)
                {
                    if (txt_newPass.Text.Trim().ToString() == txt_confirmPass.Text.Trim().ToString())
                    {
                       // label4.Text = "Match";
                        strQuery = Form1._txtName + txt_newPass.Text.Trim().ToString() + "abdullah";
                        strQuery1 = clspass.MD5Encrypt(strQuery);
                        strQuery2 = "update users set Field2 = '" + strQuery1 + "' where Users_name = '" + Form1._txtName + "'  And IsStatus='A' ";
                        Obj.simInsert(strQuery2);
                        Obj.simInsert("update users set FirstLogin = 0 where Users_name = '" + Form1._txtName + "' ");
                        MessageBox.Show("Password Updated");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please Write Password");
                    }




                }
                else
                {
                    MessageBox.Show("Current Password is Wrong!!!!");
                    clrs();
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        void clr() {
            txt_newPass.Text = "";
            txt_confirmPass.Text = "";
        }
        void clrs()
        {
            txt_CurrentPass.Text = "";
            txt_newPass.Text = "";
            txt_confirmPass.Text = "";
        }

      

        private void txt_confirmPass_TextChanged(object sender, EventArgs e)
        {
            if (txt_newPass.Text.Trim().ToString() == txt_confirmPass.Text.Trim().ToString())
            {
                label4.Text = "Match";
            }
            else
            {
                label4.Text = "Not Match";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
