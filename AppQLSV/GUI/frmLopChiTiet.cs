﻿using AppQLSV.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppQLSV.GUI
{
    public partial class frmLopChiTiet : Form
    {
        Classroom lopHoc;
        public frmLopChiTiet()
        {
            //Thêm mới
            InitializeComponent();
            
            this.Text = "Thêm mới lớp học";
        }
        public frmLopChiTiet(Classroom lopHoc)
        {
            //Chỉnh sửa
            InitializeComponent();
            this.Text = "Chỉnh sửa lớp học";
            this.lopHoc = lopHoc;
            txtTenLop.Text = this.lopHoc.Name;
            txtPhongHoc.Text = this.lopHoc.Room;
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var tenLop = txtTenLop.Text;
            var phongHoc = txtPhongHoc.Text;
           
            
            if (this.lopHoc == null) {
                //Thêm lớp ở đây
                var lop = new Classroom
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = tenLop.ToString(),
                    Room = phongHoc.ToString()

                };
                var db = new AppQLSVDBContext();
                db.Classrooms.Add(lop);
                db.SaveChanges();

                //Nếu thêm lớp thì trả về kết quả là OK
                DialogResult = DialogResult.OK;
            }
            else
            {
                var db = new AppQLSVDBContext();
                var lop = db.Classrooms.Where(t => t.ID == lopHoc.ID).FirstOrDefault();
                lop.Name = tenLop;
                lop.Room = phongHoc;
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }

        private void txtTenLop_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
