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
using System.Globalization;
using QUANLYQUANAO.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QUANLYQUANAO
{
    public partial class frmDMHangHoa : Form
    {
        DataTable tblH; //Bảng hàng
        public frmDMHangHoa()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void frmDMHangHoa_Load(object sender, EventArgs e)
        {
           //string sql;
           //sql = "SELECT* FROM [dbo].[Hang]";
            txtMaHang.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();


            ResetValues();
        }
        private void ResetValues()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtAnh.Text = "";
            picAnh.Image = null;
            txtGhiChu.Text = "";
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT* FROM [dbo].[Hang]";
            tblH = Fuctions.GetDataToTable(sql);
            dgvHangHoa.DataSource = tblH;
            dgvHangHoa.Columns[0].HeaderText = "Mã hàng";
            dgvHangHoa.Columns[1].HeaderText = "Tên hàng";
            dgvHangHoa.Columns[2].HeaderText = "Số lượng";
            dgvHangHoa.Columns[3].HeaderText = "Đơn giá nhập(VND)";
            dgvHangHoa.Columns[4].HeaderText = "Đơn giá bán (VND)";
         //   dgvHangHoa.Columns[5].HeaderText = "Ảnh";
           // dgvHangHoa.Columns[6].HeaderText = "Ghi chú";
            dgvHangHoa.Columns[0].Width = 80;
            dgvHangHoa.Columns[1].Width = 140;
            dgvHangHoa.Columns[2].Width = 80;
            dgvHangHoa.Columns[3].Width = 100;
            dgvHangHoa.Columns[4].Width = 100;
            dgvHangHoa.Columns[5].Width = 200;
            dgvHangHoa.Columns[6].Width = 300;
            dgvHangHoa.AllowUserToAddRows = false;
            dgvHangHoa.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaHang.Text = dgvHangHoa.CurrentRow.Cells["MaHang"].Value.ToString();
            txtTenHang.Text = dgvHangHoa.CurrentRow.Cells["TenHang"].Value.ToString();
            txtSoLuong.Text = dgvHangHoa.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGiaNhap.Text = dgvHangHoa.CurrentRow.Cells["DonGiaNhap "].Value.ToString();
            txtDonGiaBan.Text = dgvHangHoa.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            sql = "SELECT Anh FROM Hang WHERE MaHang=N'" + txtMaHang.Text + "'";
            txtAnh.Text = Fuctions.GetFieldValues(sql);
            picAnh.Image = Image.FromFile(txtAnh.Text);
            sql = "SELECT GhiChu FROM Hang WHERE MaHang = N'" + txtMaHang.Text + "'";
            txtGhiChu.Text = Fuctions.GetFieldValues(sql);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHang.Enabled = true;
            txtMaHang.Focus();
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Hang WHERE MaHang=N'" + txtMaHang.Text + "'";
                Fuctions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }

        /*    if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            } */
            sql = "SELECT MaHang FROM Hang WHERE MaHang=N'" + txtMaHang.Text.Trim() + "'";
            if (Fuctions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            sql = "INSERT INTO Hang(MaHang,TenHang,SoLuong,DonGiaNhap, DonGiaBan,Anh,Ghichu) VALUES(N'"
                + txtMaHang.Text.Trim() + "',N'" + txtTenHang.Text.Trim() +
                "'," + txtSoLuong.Text.Trim() + "," + txtDonGiaNhap.Text +
                "," + txtDonGiaBan.Text + ",'" + txtAnh.Text + "',N'" + txtGhiChu.Text.Trim() + "')";

            Fuctions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaHang.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnh.Focus();
                return;
            }
            sql = "UPDATE Hang SET TenHang=N'" + txtTenHang.Text.Trim().ToString() +
                "',SoLuong=" + txtSoLuong.Text +
                ",Anh='" + txtAnh.Text + "',GhiChu=N'" + txtGhiChu.Text + "' WHERE MaHang=N'" + txtMaHang.Text + "'";
            Fuctions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaHang.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHang.Text == "") && (txtTenHang.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from Hang WHERE 1=1";
            if (txtMaHang.Text != "")
                sql += " AND MaHang LIKE N'%" + txtMaHang.Text + "%'";
            if (txtTenHang.Text != "")
                sql += " AND TenHang LIKE N'%" + txtTenHang.Text + "%'";
            tblH = Fuctions.GetDataToTable(sql);
            if (tblH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvHangHoa.DataSource = tblH;
            ResetValues();
        }


        private void btnHienThiDS_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaHang,TenHang,SoLuong,DonGiaNhap,DonGiaBan,Anh,GhiChu FROM Hang";
            tblH = Fuctions.GetDataToTable(sql);
            dgvHangHoa.DataSource = tblH;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void txtDonGiaNhap_TextChanged(object sender, EventArgs e)
        {
       
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(txtDonGiaNhap.Text, System.Globalization.NumberStyles.AllowThousands);
            txtDonGiaNhap.Text = String.Format(culture, "{0:N0}", value);
            txtDonGiaNhap.Select(txtDonGiaNhap.Text.Length, 0);
            //int a = 0;
           //txtDonGiaNhap.Text = a.ToString("c");
        }

        private void txtDonGiaBan_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(txtDonGiaBan.Text, System.Globalization.NumberStyles.AllowThousands);
            txtDonGiaBan.Text = String.Format(culture, "{0:N0}", value);
            txtDonGiaBan.Select(txtDonGiaBan.Text.Length, 0);
        }
    }
}
