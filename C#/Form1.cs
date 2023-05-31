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
    using botthao;
namespace C_
{
    public partial class Form1 : Form
    {
        botthao.bot bot;
        public Form1()
        {
            InitializeComponent();
            bot = new botthao.bot();
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
            loadphong();
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
        private void loadphong()
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            ketnoi.Open();
            sql = "select* from PHONG  ";
            hienthi();
            dataGridView3.DataSource = dt;
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
        String masv, mk, mp;


        private void xoasv_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete from SINHVIEN where masosv ='" + masv + "'";

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

            ketnoi.Open();

            sql = @"update SINHVIEN
	     SET
            masosv =N'" + masv + "' ,hoten=  N'" + hoVaTen + "' ,namsinh= N'" + namSinh + "'  ,gioitinh= N'" + gioiTinh + "'  ,dienthoai=N'" + dienThoai + "' , diachi= N'" + diaChi + "' where masosv='" + masv + "'";
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
            //xoa();
            ketnoi.Close();

            loadSV();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            masv = row.Cells[0].Value.ToString();
        }

        private void themk_Click(object sender, EventArgs e)
        {
            string makhoa = txtmak.Text;
            string tenlop = txttenl.Text;
            string tenkhoa = txttenk.Text;


            ketnoi.Open();

            sql = @"insert into KHOA
            values 
               (N'" + makhoa + "' , N'" + tenkhoa + "' , N'" + tenlop + "')";
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            loadKhoa();
        }

        private void suak_Click(object sender, EventArgs e)
        {
            string makhoa = txtmak.Text;
            string tenlop = txttenl.Text;
            string tenkhoa = txttenk.Text;
            // check gia tri nguời dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin:

            ketnoi.Open();

            sql = @"UPDATE [dbo].[KHOA]" +
                @"SET " +
                @"[makhoa] = '{makhoa}' ,[tenkhoa] = '{tenkhoa}',[tenlop] = '{tenlop}' WHERE makhoa ='{makhoa}'  ";
            Console.WriteLine(sql);
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();

            loadKhoa();

        }

        private void xoaak_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoakhoa = "delete from KHOA where makhoa ='" + mk + "'";

            thuchien = new SqlCommand(lenhxoakhoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            loadKhoa();
        }

        string mphong;
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
            mphong = row.Cells[0].Value.ToString();
        }

        private void themp_Click(object sender, EventArgs e)
        {

          
            string maphong= txtmaphong.Text;
            string tenphong= txtsophong.Text;
            string loaiphong= txtloaiphong.Text;
            ketnoi.Open();

            // ketnoi.Open();
        

            sql = @"insert into PHONG
            values 
               (N'" + maphong + "' , N'" + tenphong + "' , N'" +loaiphong  + "')";
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            loadKhoa();
            loadphong();
        }

        private void suap_Click(object sender, EventArgs e)
        {

            string maphong = txtmaphong.Text;
            string sophong = txtsophong.Text;
            string loaiphong = txtloaiphong.Text;
          

            ketnoi.Open();

            sql = $"UPDATE [dbo].[PHONG]" +
                 $"SET " +
                 $"[maphong] = '{maphong}' ,[sophong] = '{sophong}',[loaiphong] = '{loaiphong}' WHERE maphong ='{maphong}'";
            Console.WriteLine(sql);
            MessageBox.Show(sql);
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();

            loadphong();
        }


        private void xoap_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string maPhongXoa = "";
            if(dataGridView3.SelectedRows.Count < 0)
            {
                return;
            }
            else
            {
                maPhongXoa = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            }
            string lenhxoaphong = "delete from PHONG where maphong ='" + maPhongXoa + "'";
            Console.WriteLine(lenhxoaphong);
            thuchien = new SqlCommand(lenhxoaphong, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            loadphong() ;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            mk = row.Cells[0].Value.ToString();
        }
    }
}


       
