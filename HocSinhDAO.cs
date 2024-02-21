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
    internal class HocSinhDAO
    {
        //thay doi lan 1
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBConnection dbConnection = new DBConnection();
        public HocSinhDAO()
        {
        }

        public void Add(HocSinh hs)
        {
            string addFormat = string.Format("INSERT INTO  HocSinh(Ten , Diachi, Cmnd) VALUES ('{0}', '{1}', '{2}')", hs.name, hs.address, hs.id);
            dbConnection.Execute(addFormat);
        }

        public void Delete(HocSinh hs)
        {
            string delFormat = string.Format("DELETE FROM HocSinh WHERE Cmnd = {0}", hs.id);
            dbConnection.Execute(delFormat);
        }

        public void Update(HocSinh hs)
        {
            string updateFormat = string.Format("UPDATE Hocsinh SET Ten = '{0}', Diachi = '{1}' WHERE Cmnd = '{2}'", hs.name, hs.address, hs.id);
            dbConnection.Execute(updateFormat);
        }
    }
}
