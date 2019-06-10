using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace concept_class
{
    public partial class BillContractWiseRpt : Form
    {
        public ReportDocument RD;
        public string strQuery;
        pg cls = new pg();

        public BillContractWiseRpt()
        {
            InitializeComponent();
        }

        private void BillContractWiseRpt_Load(object sender, EventArgs e)
        {
            cls.methodReport(strQuery);

            RD.SetDataSource(pg.ds.Tables[0]);
            crystalReportViewer1.ReportSource = RD;
            crystalReportViewer1.Refresh();

        }
    }
}
