using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lab_week_1
{
    internal class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        private System.Windows.Forms.DataGridView gvStudent;
        HocSinhDAO hsDao = new HocSinhDAO();

        public void Execute(string format)
        {
            try
            {
                // Ket noi
                conn.Open();
                string sqlStr = format;
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Faile" + ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
