using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sinh_Vien
{
    public partial class ManageStudentForm : Form
    {
        STUDENT student = new STUDENT();
        public ManageStudentForm()
        {
            InitializeComponent();
        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet4.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this.myDBDataSet4.std);
            fillGrid(new SqlCommand("Select * from std"));
        }
        // Copy lai phan truoc de nap data
        public void fillGrid(SqlCommand command)
        {
            DataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            DataGridView1.RowTemplate.Height = 80;
            DataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)DataGridView1.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridView1.AllowUserToAddRows = false;
            // Dem sinh vien
            LabelTotalStudents.Text = ("Total Students: " + DataGridView1.Rows.Count);
        }
        // lay lai tinh namg trong liststudent de click chon
        private void DataGridView1_Click(object sender, EventArgs e)
        {
            TextBoxID.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_MSSV.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            TextBoxFname.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
            TextBoxLname.Text = DataGridView1.CurrentRow.Cells[3].Value.ToString();
            
            DateTimePicker1.Value = (DateTime)DataGridView1.CurrentRow.Cells[4].Value;
            // gender
            if ((DataGridView1.CurrentRow.Cells[5].Value.ToString() == "Female"))
            {
                RadioButtonFemale.Checked = true;
            }
            else
            {
                RadioButtonMale.Checked = true;
            }
            TextBoxPhone.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            TextBoxAddress.Text = DataGridView1.CurrentRow.Cells[7].Value.ToString();
            // image
            byte[] pic;
            pic = (byte[])DataGridView1.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            PictureBoxStudentImage.Image = Image.FromStream(picture);
        }
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM std WHERE CONCAT(fname, lname, address) LIKE'%" + TextBoxSearch.Text + "%'");
            fillGrid(command);
        }
        // lam roi
        private void Buttonupload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jPg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }
        // xoa cac field
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxID.Text = "";
            textBox_MSSV.Text = "";
            TextBoxFname.Text = "";
            TextBoxLname.Text = "";
            TextBoxAddress.Text = "";
            TextBoxPhone.Text = "";
            PictureBoxStudentImage.Image = null;
            RadioButtonMale.Checked = true;
            DateTimePicker1.Value = DateTime.Now;
        }
        // thu chuc nang luu hinh voi SaveFile
        private void ButtonDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = ("student_" + TextBoxID.Text);
            if ((PictureBoxStudentImage.Image == null))
            {
                MessageBox.Show("No Image In The PictureBox");
            }
            else if ((svf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxStudentImage.Image.Save((svf.FileName + ("." + ImageFormat.Jpeg.ToString())));
            }
        }
        bool verif()
        {
            if ((TextBoxID.Text.Trim() == "")
                        || (TextBoxFname.Text.Trim() == "")
                        || (TextBoxLname.Text.Trim() == "")
                        || (TextBoxAddress.Text.Trim() == "")
                        || (TextBoxPhone.Text.Trim() == "")
                        || (PictureBoxStudentImage.Image == null))

            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxID.Text != "")
                {
                    int ID = Int32.Parse(TextBoxID.Text);
                    if (student.CheckStudentID(ID))
                    {
                        MessageBox.Show("Đã có mã sinh viên (ID) này rồi!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //textBox_Add_Gr_ID.Text = "";
                        //TextBoxID.Text = "";
                        return;
                    }
                }
                if (textBox_MSSV.Text != "")
                {
                    string MSSV = textBox_MSSV.Text;
                    if (student.CheckStudentMSSV(MSSV))
                    {
                        MessageBox.Show("Đã có mã số sinh viên (MSSV) này rồi!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //textBox_Add_Gr_ID.Text = "";
                        //textBox_MSSV.Text = "";
                        return;
                    }
                }
                if (TextBoxPhone.Text != "")
                {
                    string Phone = TextBoxPhone.Text.Trim();
                    if (student.CheckStudentPhone(Phone))
                    {
                        MessageBox.Show("Đã có số điện thoại này rồi!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //textBox_Add_Gr_ID.Text = "";
                        //textBox_MSSV.Text = "";
                        return;
                    }
                }

                string gender = "Male";
                if (RadioButtonFemale.Checked)
                {
                    gender = "Female";
                }
                MemoryStream pic = new MemoryStream();
                int born_year = DateTimePicker1.Value.Year;
                int this_year = DateTime.Now.Year;
                // allow only students age between 10 - 100
                if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
                {
                    MessageBox.Show("Tuổi của student phải lớn hơn 10 và nhỏ hơn 100!!", "Ngày sinh không phù hợp!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    STUDENT student = new STUDENT();
                    int id = Convert.ToInt32(TextBoxID.Text);
                    string MSSV = textBox_MSSV.Text;
                    string fname = TextBoxFname.Text;
                    string lname = TextBoxLname.Text;
                    DateTime bdate = DateTimePicker1.Value;
                    string phone = TextBoxPhone.Text;
                    string adrs = TextBoxAddress.Text;
                    PictureBoxStudentImage.Image.Save(pic, PictureBoxStudentImage.Image.RawFormat);
                    if (student.insertStudent(id, fname, lname, bdate, gender, phone, adrs, pic, MSSV))
                    {
                        MessageBox.Show("Đã thêm Student mới!!", "Thêm Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillGrid(new SqlCommand("SELECT * FROM std"));
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm!!!", "Thêm Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không được bỏ trống!!", "Thêm Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        // button update
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = "Male";
                if (RadioButtonFemale.Checked)
                {
                    gender = "Female";
                }
                MemoryStream pic = new MemoryStream();
                int born_year = DateTimePicker1.Value.Year;
                int this_year = DateTime.Now.Year;
                if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
                {
                    MessageBox.Show("Tuổi của student phải lớn hơn 10 và nhỏ hơn 100!!", "Ngày sinh không phù hợp!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (verif())
                {
                    int ID = Convert.ToInt32(TextBoxID.Text.ToString());
                    string MSSV = textBox_MSSV.Text;
                    string fname = TextBoxFname.Text;
                    string lname = TextBoxLname.Text;
                    DateTime bdate = DateTimePicker1.Value;
                    string phone = TextBoxPhone.Text;
                    string adr = TextBoxAddress.Text;
                    PictureBoxStudentImage.Image.Save(pic, PictureBoxStudentImage.Image.RawFormat);
                    if(student.CheckStudentIDnMSSVnPhone(ID, MSSV, phone))
                    {
                        if (student.updateStudentByIDnMSSVnPhone(ID, fname, lname, bdate, gender, phone, adr, pic, MSSV))
                        {
                            MessageBox.Show("Cập nhật thành công Student (theo ID và MSSV và SDT)", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi !!Cập nhật không thành công Student (theo ID và MSSV và SDT)", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }    
                    else if (student.CheckStudentIDnMSSV(ID, MSSV))
                    {
                        if (student.updateStudentByIDnMSSV(ID, fname, lname, bdate, gender, phone, adr, pic, MSSV))
                        {
                            MessageBox.Show("Cập nhật thành công Student (theo ID và MSSV)", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi !!Cập nhật không thành công Student (theo ID và MSSV)", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (student.CheckStudentMSSV(MSSV))
                    {
                        if ((student.updateStudentByID(ID, fname, lname, bdate, gender, phone, adr, pic, MSSV)))
                        {
                            MessageBox.Show("Cập nhật thành công Student (theo ID)", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi !!Cập nhật không thành công Student (theo ID)", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không được bỏ trống!!", "Sửa Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        // xoa theo id, tuong tu phan truoc
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            // delete student
            try
            {
                if(TextBoxID.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống!!");
                }
                else
                {
                    int studentId = Convert.ToInt32(TextBoxID.Text);
                    // display a confirmation message before the delete
                    if ((MessageBox.Show("Bạn có chắc muốn xóa Student này chứ ?", "Xóa Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        if (student.deleteStudent(studentId))
                        {
                            MessageBox.Show("Đã xóa Student!!", "Xóa Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fillGrid(new SqlCommand("SELECT * FROM std"));
                            // clear/reset fields after delete
                            TextBoxID.Text = "";
                            TextBoxFname.Text = "";
                            TextBoxLname.Text = "";
                            TextBoxAddress.Text = "";
                            TextBoxPhone.Text = "";
                            DateTimePicker1.Value = DateTime.Now;
                            PictureBoxStudentImage.Image = null;
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa Student!!", "Xóa Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }    
                
            }
            catch
            {
                MessageBox.Show("ID không chính xác!!", "Xóa Student", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TextBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void Buttonupload_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg; *.png; *.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
