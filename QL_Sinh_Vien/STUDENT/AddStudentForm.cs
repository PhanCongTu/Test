using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sinh_Vien
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

         STUDENT student = new STUDENT();
        private void bt_AddStudentForm_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tb_StudentID.Text);
                string MSSV = tb_MSSV.Text;
                string fname = tb_FirstName.Text;
                string lname = tb_LastName.Text;
                DateTime bdate = dateTimePicker_BirthDate.Value;
                //String.Format("{0:d/M/yyyy}", bdate);
                string phone = tb_Phone.Text;
                string adr = tb_Address.Text;
                string gender = "Male";

                if (radioButton_Female.Checked)
                {
                    gender = "Female";
                }

                MemoryStream pic = new MemoryStream();

                if (verif())
                {
                    pictureBox.Image.Save(pic, pictureBox.Image.RawFormat);
                    if ((student.insertStudent(id, fname, lname, bdate, gender, phone, adr, pic, MSSV)))
                    {
                        MessageBox.Show("Đã thêm student mới!!", "Thêm Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm!!", "Thêm Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Không được bỏ trống", "Thêm Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private bool verif()
        {
            if ((tb_FirstName.Text.Trim() == "")
                    || (tb_LastName.Text.Trim() == "")
                    || (tb_Phone.Text.Trim() == "")
                    || (pictureBox.Image == null)
                    )
            {
                return false;
            }
            else return true;
        }

        private void bt_UploadImage_AddStudentForm_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg; *.png; *.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBox.Image = Image.FromFile(opf.FileName);
            }
        }

        private void AddStudentForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (tb_StudentID.Text != "")
            {
                int ID = Int32.Parse(tb_StudentID.Text);
                if (student.CheckStudentID(ID))
                {
                    MessageBox.Show("Đã có mã sinh viên (ID) này rồi!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //textBox_Add_Gr_ID.Text = "";
                    tb_StudentID.Text = "";
                }
            }
            if (tb_MSSV.Text != "")
            {
                string MSSV = tb_MSSV.Text;
                if (student.CheckStudentMSSV(MSSV))
                {
                    MessageBox.Show("Đã có mã số sinh viên (MSSV) này rồi!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //textBox_Add_Gr_ID.Text = "";
                    tb_MSSV.Text = "";
                }
            }
            if (tb_Phone.Text != "")
            {
                string Phone = tb_Phone.Text.Trim();
                if (student.CheckStudentPhone(Phone))
                {
                    MessageBox.Show("Đã có số điện thoại này rồi!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //textBox_Add_Gr_ID.Text = "";
                    //textBox_MSSV.Text = "";
                    return;
                }
            }
            int born_year = dateTimePicker_BirthDate.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("Student phải lớn hơn 10 và nhỏ hơn 100 tuổi", "Ngày sinh không phù hợp!!!", MessageBoxButtons.OK);
                dateTimePicker_BirthDate.Value = new DateTime(2000, 01, 01);
            }
        }

        private void tb_StudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
