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
namespace KHOA
{
    public partial class khoa : Form
    {
        public khoa()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=Hi;Initial Catalog=sql;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        DataTable dt;
        private void khoa_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            ketnoi.Open();
            sql = "select* from KHOA";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();

        }
        public void hienthi()
        {



            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulieu);

        }
    }
}
