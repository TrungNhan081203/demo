﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUANLYQUANAO.Class;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QUANLYQUANAO
{
    public partial class frmHoaDonBan : Form
    {
        public frmHoaDonBan()
        {
            InitializeComponent();
        }

        private DataTable ChiTietHDBan; //Bảng chi tiết hoá đơn bán

       
        private void frmHoaDonBan_Load(object sender, EventArgs e)
        { 

          // string sql;
          // sql = "SELECT* FROM [dbo].[HoaDonBan]";
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtTenNhanVien.ReadOnly = true;
            txtTenKhach.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtDienThoai.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGiaBan.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            Fuctions.FillCombo("SELECT MaKhach, TenKhach FROM Khach", cbMaKhachHang, "MaKhach", "MaKhach");
            cbMaKhachHang.SelectedIndex = -1;
            Fuctions.FillCombo("SELECT MaNhanVien, TenNhanVien FROM NhanVien", cbMaNhanVien, "MaNhanVien", "TenKhach");
            cbMaNhanVien.SelectedIndex = -1;
            Fuctions.FillCombo("SELECT MaHang, TenHang FROM Hang", cbMaHang, "MaHang", "MaHang");
            cbMaHang.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHDBan.Text != "")
            {
                LoadInfoHoaDon();
                btnHuy.Enabled = true;
                btnIn.Enabled = true;
            }
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
           
            string sql;
            sql = "SELECT* FROM [dbo].[HoaDonBan]";
            sql = "SELECT a.MaHang, b.TenHang, a.SoLuong, b.DonGiaBan, a.GiamGia,a.ThanhTien FROM ChiTietHDBan AS a, Hang AS b WHERE a.MaHDBan = N'" + txtMaHDBan.Text + "' AND a.MaHang=b.MaHang";
            ChiTietHDBan = Fuctions.GetDataToTable(sql);
            dgvHoaDonBanHang.DataSource = ChiTietHDBan;
            dgvHoaDonBanHang.Columns[0].HeaderText = "Mã hàng";
            dgvHoaDonBanHang.Columns[1].HeaderText = "Tên hàng";
            dgvHoaDonBanHang.Columns[2].HeaderText = "Số lượng";
            dgvHoaDonBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvHoaDonBanHang.Columns[4].HeaderText = "Giảm giá %";
            dgvHoaDonBanHang.Columns[5].HeaderText = "Thành tiền";
            dgvHoaDonBanHang.Columns[0].Width = 80;
            dgvHoaDonBanHang.Columns[1].Width = 130;
            dgvHoaDonBanHang.Columns[2].Width = 80;
            dgvHoaDonBanHang.Columns[3].Width = 90;
            dgvHoaDonBanHang.Columns[4].Width = 90;
            dgvHoaDonBanHang.Columns[5].Width = 90;
            dgvHoaDonBanHang.AllowUserToAddRows = false;
            dgvHoaDonBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayBan FROM HoaDonBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
            dtpNgayBan.Text = Fuctions.ConvertDateTime(Fuctions.GetFieldValues(str));
            str = "SELECT MaNhanVien FROM HoaDonBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
            cbMaNhanVien.Text = Fuctions.GetFieldValues(str);
            str = "SELECT MaKhach FROM HoaDonBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
            cbMaKhachHang.Text = Fuctions.GetFieldValues(str);
            str = "SELECT TongTien FROM HoaDonBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
            txtTongTien.Text = Fuctions.GetFieldValues(str);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHDBan.Text = Fuctions.CreateKey("HDB");
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            dtpNgayBan.Text = DateTime.Now.ToShortDateString();
            cbMaNhanVien.Text = "";
            cbMaKhachHang.Text = "";
            txtTongTien.Text = "0";
            cbMaHang.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }
        private void ResetValuesHang()
        {
            cbMaHang.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHDBan FROM HoaDonBan WHERE MaHDBan=N'" + txtMaHDBan.Text + "'";
            if (!Fuctions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (dtpNgayBan.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpNgayBan.Focus();
                    return;
                }
                if (cbMaNhanVien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaNhanVien.Focus();
                    return;
                }
                if (cbMaKhachHang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaKhachHang.Focus();
                    return;
                }
                sql = "INSERT INTO HoaDonBan(MaHDBan, NgayBan, MaNhanVien, MaKhach, TongTien) VALUES (N'" + txtMaHDBan.Text.Trim() + "','" +
                        Fuctions.ConvertDateTime(dtpNgayBan.Text.Trim()) + "',N'" + cbMaNhanVien.SelectedValue + "',N'" +
                        cbMaKhachHang.SelectedValue + "'," + txtTongTien.Text + ")";
                Fuctions.RunSQL(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (cbMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaHang.Focus();
                return;
            }
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            sql = "SELECT MaHang FROM ChiTietHDBan WHERE MaHang=N'" + cbMaHang.SelectedValue + "' AND MaHDBan = N'" + txtMaHDBan.Text.Trim() + "'";
            if (Fuctions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbMaHang.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Fuctions.GetFieldValues("SELECT SoLuong FROM Hang WHERE MaHang = N'" + cbMaHang.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoLuong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            sql = "INSERT INTO ChiTietHDBan (MaHDBan,MaHang,SoLuong,DonGia, GiamGia,ThanhTien) VALUES(N'" + txtMaHDBan.Text.Trim() + "',N'" + cbMaHang.SelectedValue + "'," + txtSoLuong.Text + "," + txtDonGiaBan.Text + "," + txtGiamGia.Text + "," + txtThanhTien.Text + ")";
            Fuctions.RunSQL(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoLuong.Text);
            sql = "UPDATE Hang SET SoLuong =" + SLcon + " WHERE MaHang= N'" + cbMaHang.SelectedValue + "'";
            Fuctions.RunSQL(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Fuctions.GetFieldValues("SELECT TongTien FROM HoaDonBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
            sql = "UPDATE HoaDonBan SET TongTien =" + Tongmoi + " WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
            Fuctions.RunSQL(sql);
            txtTongTien.Text = Tongmoi.ToString();
            ResetValuesHang();
            btnHuy.Enabled = true;
            btnThem.Enabled = true;
            btnIn.Enabled = true;
        }

        private void dgvHoaDonBanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaHangxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (ChiTietHDBan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dgvHoaDonBanHang.CurrentRow.Cells["MaHang"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(dgvHoaDonBanHang.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dgvHoaDonBanHang.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE ChiTietHDBan WHERE MaHDBan=N'" + txtMaHDBan.Text + "' AND MaHang = N'" + MaHangxoa + "'";
                Fuctions.RunSQL(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(Fuctions.GetFieldValues("SELECT SoLuong FROM Hang WHERE MaHang = N'" + MaHangxoa + "'"));
                slcon = sl + SoLuongxoa;
                sql = "UPDATE Hang SET SoLuong =" + slcon + " WHERE MaHang= N'" + MaHangxoa + "'";
                Fuctions.RunSQL(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(Fuctions.GetFieldValues("SELECT TongTien FROM HoaDonBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE HoaDonBan SET TongTien =" + tongmoi + " WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
                Fuctions.RunSQL(sql);
                txtTongTien.Text = tongmoi.ToString();
                LoadDataGridView();
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaHang,SoLuong FROM ChiTietHDBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
                DataTable tblHang = Fuctions.GetDataToTable(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Fuctions.GetFieldValues("SELECT SoLuong FROM Hang WHERE MaHang = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE Hang SET SoLuong =" + slcon + " WHERE MaHang= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    Fuctions.RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE ChiTietHDBan WHERE MaHDBan=N'" + txtMaHDBan.Text + "'";
                Fuctions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE HoaDonBan WHERE MaHDBan=N'" + txtMaHDBan.Text + "'";
                Fuctions.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                btnHuy.Enabled = false;
                btnIn.Enabled = false;
            }
        }

        private void cbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbMaNhanVien.Text == "")
                txtTenNhanVien.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select TenNhanVien from NhanVien where MaNhanVien =N'" + cbMaNhanVien.SelectedValue + "'";
            txtTenNhanVien.Text = Fuctions.GetFieldValues(str);
        }

        private void cbMaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbMaKhachHang.Text == "")
            {
                txtTenKhach.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select TenKhach from Khach where MaKhach = N'" + cbMaKhachHang.SelectedValue + "'";
            txtTenKhach.Text = Fuctions.GetFieldValues(str);
            str = "Select DiaChi from Khach where MaKhach = N'" + cbMaKhachHang.SelectedValue + "'";
            txtDiaChi.Text = Fuctions.GetFieldValues(str);
            str = "Select DienThoai from Khach where MaKhach= N'" + cbMaKhachHang.SelectedValue + "'";
            txtDienThoai.Text = Fuctions.GetFieldValues(str);
        }

        private void cbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbMaHang.Text == "")
            {
                txtTenHang.Text = "";
                txtDonGiaBan.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenHang FROM Hang WHERE MaHang =N'" + cbMaHang.SelectedValue + "'";
            txtTenHang.Text = Fuctions.GetFieldValues(str);
            str = "SELECT DonGiaBan FROM Hang WHERE MaHang =N'" + cbMaHang.SelectedValue + "'";
            txtDonGiaBan.Text = Fuctions.GetFieldValues(str);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {// Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop QA.";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "141 Điện Biên Phủ-TP Hồ Chí Minh";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)38526419";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHDBan, a.NgayBan, a.TongTien, b.TenKhach, b.DiaChi, b.DienThoai, c.TenNhanVien FROM HoaDonBan AS a, Khach AS b, NhanVien AS c WHERE a.MaHDBan = N'" + txtMaHDBan.Text + "' AND a.MaKhach = b.MaKhach AND a.MaNhanVien = c.MaNhanVien";
            tblThongtinHD = Fuctions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenHang, a.SoLuong, b.DonGiaBan, a.GiamGia, a.ThanhTien " +
                  "FROM ChiTietHoaDonBan AS a , Hang AS b WHERE a.MaHDBan = N'" +
                  txtMaHDBan.Text + "' AND a.MaHang = b.MaHang";
            tblThongtinHang = Fuctions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Fuctions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hồ Chí Minh, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHDBan.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHDBan.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            cboMaHDBan.SelectedIndex = -1;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void cboMaHDBan_DropDown(object sender, EventArgs e)
        {
            Fuctions.FillCombo("SELECT MaHDBan FROM HoaDonBan", cboMaHDBan, "MaHDBan", "MaHDBan");
            cboMaHDBan.SelectedIndex = -1;
        }
      

        private void frmHoaDonBan_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    } 
}


