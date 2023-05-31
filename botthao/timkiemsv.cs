using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace botthao
{
    public class timkiemsv
    {
        string chuoikn = @"Data Source=Hi;Initial Catalog=sql;Integrated Security=True";
        public string timSV(string v)
        {
            string query = "TimKiemSinhVien"; // ten Store proceduce 
            string kq = "";
            using(SqlConnection con = new SqlConnection(chuoikn))
            {
                con.Open();
                try
                {
                    using(SqlCommand cmd = new SqlCommand(query,con))
                    {
                        cmd.Parameters.Add("@tenSV", System.Data.SqlDbType.NVarChar, 50).Value = v;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        object kqtrave = cmd.ExecuteScalar();
                        // truyen bien cho proceduce 
                        kq = (string) kqtrave; // ep kieu
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show("co loi khi tim kiem SV" + ex.Message);
                }
                return kq;
            }
        }
    }
}
