using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace concept_class
{
    class pg
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static SqlDataAdapter adt;
        public static DataTable dt;
        public static DataSet ds;
        public static string pa = @"D:\Connection.txt";
       // public static string pa = @"C:\Users\MUHAMMAD IRFAN\Desktop\ConstructionCompany\Connection.txt";

        public void connection_Opener()
        {
            try
            {
                con = new SqlConnection(File.ReadAllText(pa));
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public void data_fetchCmd(string qry)
        {
            try
            {
                cmd = new SqlCommand(qry, con);
                dr = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void ConnectionOpenFillDt(string StrQuery, DataSet ds)
        {

            try
            {
                connection_Opener();
                adt = new SqlDataAdapter(StrQuery, con);
                adt.Fill(ds);
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message.ToString());

            }

        }
        public void simInsert(string qry)
        {
            try
            {
                connection_Opener();
                cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        public DataTable SqlDatatable(string Qry)
        {
           
            try
            {
                connection_Opener();
                adt = new SqlDataAdapter(Qry, con);
                dt = new DataTable();
                adt.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return dt;
            }


        }
        public bool ExecuteQuery(string Qry)
        {
            try
            {
                connection_Opener();
                cmd = new SqlCommand(Qry, con);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                return false;
            }
        }

        public string GetRecord(string Qry)
        {
            try
            {
                connection_Opener();
                cmd = new SqlCommand(Qry, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr[0].ToString();
                }
                else
                {
                    return "";
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                return "";
            }
        }
        public void methodReport(string qry)
        {
            try
            {
                connection_Opener();
                adt = new SqlDataAdapter(qry, con);
                ds = new DataSet();
                adt.Fill(ds);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);

            }
        }
    }

}