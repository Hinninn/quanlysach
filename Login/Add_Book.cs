using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Add_Book : Form
    {
        public Add_Book()
        {
            InitializeComponent();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra các ô nhập liệu không rỗng
            if (txtTenSach.Text != "" && txtTacGia.Text != "" && txtTheLoai.Text != "" && txtNamXuatBan.Text != "" && txtGia.Text != "" && txtSoLuong.Text != "")
            {
                string tensach = txtTenSach.Text;
                string tacgia = txtTacGia.Text;
                string theloai = txtTheLoai.Text;
                int namxuatban = int.Parse(txtNamXuatBan.Text);
                long gia = long.Parse(txtGia.Text);
                int soluong = int.Parse(txtSoLuong.Text);

                using (var dataContext = new DataSachDataContext())
                {
                    // Kiểm tra xem sách đã có trong kho chưa
                    var existingBook = dataContext.Saches.FirstOrDefault(s => s.TenSach == tensach && s.TacGia == tacgia);

                    if (existingBook != null)
                    {
                        // Sách đã tồn tại, cập nhật số lượng
                        existingBook.SoLuong += soluong;
                        MessageBox.Show("Sách đã có trong kho. Đã cập nhật số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Tạo đối tượng sách mới
                        Sach newBook = new Sach
                        {
                            TenSach = tensach,
                            TacGia = tacgia,
                            TheLoai = theloai,
                            NamXuatBan = namxuatban,
                            GiaSach = gia,
                            SoLuong = soluong
                        };

                        // Thêm sách mới vào bảng
                        dataContext.Saches.InsertOnSubmit(newBook);
                        MessageBox.Show("Dữ liệu đã được lưu.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dataContext.SubmitChanges();
                }
            }
            else
            {
                MessageBox.Show("Không được để trống các ô nhập liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var home = new Home();
            this.Close();
        }
    }
}
