using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Login
{
    public partial class View_Book : Form
    {
        public View_Book()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            DataSachDataContext data = new DataSachDataContext();
            DataGr.DataSource = from i in data.Saches
                              select i;

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string TenSach = txtTenSach.Text.Trim();  
            DataSachDataContext data = new DataSachDataContext();
            var books = from s in data.Saches
                        where s.TenSach.Contains(TenSach)  
                        select s;

            DataGr.DataSource = books.ToList();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenSach.Clear();
            LoadData();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenSach = txtTenSach2.Text.Trim();  
            DataSachDataContext data = new DataSachDataContext();

            var sachToDelete = data.Saches.FirstOrDefault(s => s.TenSach == tenSach);

            if (sachToDelete != null)
            {
                var lichSuToDelete = data.LichSuMuonTraSaches.Where(ls => ls.MaSach == sachToDelete.MaSach);

                data.LichSuMuonTraSaches.DeleteAllOnSubmit(lichSuToDelete);

                data.Saches.DeleteOnSubmit(sachToDelete);

                data.SubmitChanges();

                LoadData();

                MessageBox.Show("Sách và các bản ghi lịch sử mượn trả đã được xóa thành công!");
            }
            else
            {
                MessageBox.Show("Không tồn tại sách với tên này!");
            }
        }

        

        private void txtTenSach_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTenSach.Text.Trim(); 
            DataSachDataContext data = new DataSachDataContext();

            var books = from b in data.Saches
                        where b.TenSach.Contains(searchTerm) 
                        select b;

            DataGr.DataSource = books.ToList(); 
        }
        int bid;
        Int64 rowid;
        private void DataGr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGr.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                int bookId = int.Parse(DataGr.Rows[e.RowIndex].Cells[0].Value.ToString());
                LoadSelectedBookDetails(bookId);
            }
        }
        private void LoadSelectedBookDetails(int bookId)
        {
            using (var dataContext = new DataSachDataContext())
            {
                var bookDetails = dataContext.Saches.FirstOrDefault(s => s.MaSach == bookId);

                if (bookDetails != null)
                {
                    txtTenSach2.Text = bookDetails.TenSach;
                    txtTacGia.Text = bookDetails.TacGia;
                    txtTheLoai.Text = bookDetails.TheLoai;
                    txtNamXuatBan.Text = bookDetails.NamXuatBan.ToString();
                    txtGiaSach.Text = bookDetails.GiaSach.ToString();
                    txtSoLuong.Text = bookDetails.SoLuong.ToString();

                    panel2.Visible = true;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e) 
        {
        if (MessageBox.Show("Dữ liệu sẽ được cập nhật. Xác nhận?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
        {
        string TenSach = txtTenSach2.Text.Trim();  
        string TacGia = txtTacGia.Text.Trim();
        string TheLoai = txtTheLoai.Text.Trim();
        int NamXuatBan = int.Parse(txtNamXuatBan.Text.Trim());
        long GiaSach = long.Parse(txtGiaSach.Text.Trim());
        int SoLuong = int.Parse(txtSoLuong.Text.Trim());

        using (var dataContext = new DataSachDataContext())
        {
            // Tìm sách theo TenSach2 (tên sách nhập vào TextBox)
            var sachToUpdate = dataContext.Saches.FirstOrDefault();

            if (sachToUpdate != null)
            {
                // Cập nhật các thông tin của sách
                sachToUpdate.TenSach = TenSach;
                sachToUpdate.TacGia = TacGia;
                sachToUpdate.TheLoai = TheLoai;
                sachToUpdate.NamXuatBan = NamXuatBan;
                sachToUpdate.GiaSach = GiaSach;
                sachToUpdate.SoLuong = SoLuong;

                dataContext.SubmitChanges();
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sách này.");
            }
        }
    }
}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var home = new Home();
            this.Close();
        }
    }
}
