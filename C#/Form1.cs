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
namespace C_
{
    public partial class Form1 : Form
    {
        public Form1()
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
        private void Form1_Load(object sender, EventArgs e)
        {
            loadKhoa();
            loadSV();
        }

        private void loadKhoa()
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            ketnoi.Open();
            sql = "select* from KHOA  ";
            hienthi();
            dataGridView2.DataSource = dt;
            ketnoi.Close();
        }

        private void loadSV()
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            ketnoi.Open();
            sql = "select* from SINHVIEN ";
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
        public void xoa()
        {
            txtmasv.Clear();
            txtten.Clear();
            txtdiachi.Clear();
            txtdienthoai.Clear();
            txtgioitinh.Clear();
            txtnamsinh.Clear();
        }
        String ma;

        

        private void xoasv_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete from SINHVIEN where masosv ='" + ma + "'";

            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            loadSV();

        }

        private void suasv_Click(object sender, EventArgs e)
        {
            // Lấy tất cả thông tin muốn thêm
            string masv = txtmasv.Text;
            string hoVaTen = txtten.Text;
            string namSinh = txtnamsinh.Text;
            string gioiTinh = txtgioitinh.Text;
            string dienThoai = txtdienthoai.Text;
            string diaChi = txtdiachi.Text;

            // check gia tri nguời dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin:

            ketnoi.Open();




            sql = @"update SINHVIEN
	     SET
            masosv =N'" + masv + "' ,hoten=  N'" + hoVaTen + "' ,namsinh= N'" + namSinh + "'  ,gioitinh= N'" + gioiTinh + "'  ,dienthoai=N'" + dienThoai + "' , diachi= N'" + diaChi + "' where masosv='" + ma + "'";
            MessageBox.Show(sql);

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();

            loadSV();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void themsv_Click(object sender, EventArgs e)
        {

            // Lấy tất cả thông tin muốn thêm
            string masv = txtmasv.Text;
            string hoVaTen = txtten.Text;
            string namSinh = txtnamsinh.Text;
            string gioiTinh = txtgioitinh.Text;
            string dienThoai = txtdienthoai.Text;
            string diaChi = txtdiachi.Text;

            // check gia tri nguời dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin:

            ketnoi.Open();




            sql = @"insert into SINHVIEN
	        values 
            (N'" + masv + "' , N'" + hoVaTen + "' , N'" + namSinh + "'  , N'" + gioiTinh + "'  , N'" + dienThoai + "' , N'" + diaChi + "')";
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();

            loadSV();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }

        private void themk_Click(object sender, EventArgs e)
        {

        }

       
    }
}


       
