using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUANLYQUANAO.Class;

namespace QUANLYQUANAO
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Class.Fuctions.Connect(); //Mở kết nối
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Class.Fuctions.Disconnect(); //Đóng kết nối
            Application.Exit(); //Thoát
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
           frmNhanVien frmNhanVien = new frmNhanVien(); //Khởi tạo đối tượng
           //frmNhanVien.MdiParent = this;
            frmNhanVien.ShowDialog(); //Hiển thị
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            frmDMKhachHang frmDMKhachHang = new frmDMKhachHang(); //Khởi tạo đối tượng
            //frmDMKhachHang.MdiParent = this;
            frmDMKhachHang.ShowDialog(); //Hiển thị
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            frmDMHangHoa frmDMHangHoa = new frmDMHangHoa(); //Khởi tạo đối tượng
            //frmDMHangHoa.MdiParent = this;
            frmDMHangHoa.ShowDialog(); //Hiển thị
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            frmHoaDonBan frmHoaDonBan = new frmHoaDonBan();
            //frmHoaDonBan.MdiParent = this;
            frmHoaDonBan.ShowDialog();
        }

        private void mnuFindHoaDon_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            frmTimKiemHD frmTimKiemHD = new frmTimKiemHD();
            frmTimKiemHD.Show();
        }

        private void mnuBaoCao_Click(object sender, EventArgs e)
        {

        }
    }
}
