using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab_week_1
{
    public partial class FStudent : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        HocSinhDAO hsDao = new HocSinhDAO();

        public FStudent()
        {
            InitializeComponent();
        }

        private void FStudent_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format(" SELECT * FROM Student ");
                
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtSinhVien = new DataTable();
                adapter.Fill(dtSinhVien);
                gvStudent.DataSource = dtSinhVien; /// gvStudent = name cua data gridview
            }
            catch (Exception exc) 
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HocSinh hs = new HocSinh(tbName.Text, tbAddress.Text, tbID.Text);
            hsDao.Add(hs);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HocSinh hs = new HocSinh(tbName.Text, tbAddress.Text, tbID.Text);
            hsDao.Delete(hs);
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            HocSinh hs = new HocSinh(tbName.Text, tbAddress.Text, tbID.Text);
            hsDao.Update(hs);
        }
    }
}
