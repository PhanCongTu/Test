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
    public partial class UpdateDeleteStudentForm : Form
    {
        STUDENT student = new STUDENT();

        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }

        private void button_Edit_Student_Click(object sender, EventArgs e)
        {
            string gender = "Male";

            if (RadioButtonFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = dateTimePicker_BirthDate.Value.Year;
            int this_year = DateTime.Now.Year;

            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK);
            }
            else if (verif())
            {
                try
                {
                    int ID = Convert.ToInt32(TextBoxID.Text.ToString());
                    string MSSV = textBox_MSSV.Text;
                    string fname = TextBoxFname.Text;
                    string lname = TextBoxLname.Text;
                    dateTimePicker_BirthDate.CustomFormat = "dd/MM/yyyy";
                    DateTime bdate = dateTimePicker_BirthDate.Value;
                    //String.Format("{0:d/M/yyyy}", bdate);
                    string phone = TextBoxPhone.Text;
                    string adr = TextBoxAddress.Text;
                    PictureBoxStudentImage.Image.Save(pic, PictureBoxStudentImage.Image.RawFormat);
                    if (student.CheckStudentIDnMSSV(ID, MSSV))
                    {
                        if(student.updateStudentByIDnMSSV(ID, fname, lname, bdate, gender, phone, adr, pic, MSSV))
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Không được bỏ trống!!", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool verif()
        {
            if ((TextBoxFname.Text.Trim() == "")
                    || (TextBoxID.Text.Trim() == "")
                    || (textBox_MSSV.Text.Trim() == "")
                    || (TextBoxLname.Text.Trim() == "")
                    || (TextBoxPhone.Text.Trim() == "")
                    || (PictureBoxStudentImage.Image == null)
                    )
            {
                return false;
            }
            else return true;
        }

        private void button_Remove_Student_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = Convert.ToInt32(TextBoxID.Text);

                if(MessageBox.Show("Are you sure You Want to Delete this Student ?","Delete Student",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(student.deleteStudent(studentID))
                    {
                        MessageBox.Show("Student Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TextBoxID.Text = "";
                        TextBoxFname.Text = "";
                        TextBoxLname.Text = "";
                        TextBoxAddress.Text = "";
                        TextBoxPhone.Text = "";
                        dateTimePicker_BirthDate.Value = DateTime.Now;
                        PictureBoxStudentImage.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Student not Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Close();

            }
            catch
            {
                MessageBox.Show("Please enter A valid ID", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        private void UpdateDeleteStudentForm_Load(object sender, EventArgs e)
        {
            comboBox_Select_Column_Name.DisplayMember = "Text";
            comboBox_Select_Column_Name.ValueMember = "Value";

            comboBox_Select_Column_Name.Items.Add(new { Text = "ID", Value = "id" });
            comboBox_Select_Column_Name.Items.Add(new { Text = "MSSV", Value = "mssv" });
            comboBox_Select_Column_Name.Items.Add(new { Text = "fname", Value = "fname" });
            comboBox_Select_Column_Name.Items.Add(new { Text = "lname", Value = "lname" });
            comboBox_Select_Column_Name.Items.Add(new { Text = "Phone", Value = "phone" });

        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            if (comboBox_Select_Column_Name.Text != "ID"
                    && comboBox_Select_Column_Name.Text != "MSSV"
                    && comboBox_Select_Column_Name.Text != "fname"
                    && comboBox_Select_Column_Name.Text != "lname"
                    && comboBox_Select_Column_Name.Text != "Phone"
                )
            {
                MessageBox.Show("Sai mục tìm kiếm!!");
                return;
            }
 /*           if (textBox_Search.Text == null || textBox_Search.Text == "")
            {
                MessageBox.Show("Không được để trống!!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }*/
            string name = comboBox_Select_Column_Name.Text;
            string Find = textBox_Search.Text.ToString();
            DataTable table = new DataTable();
            SqlCommand command;
            if (name == "ID")
            {
                try
                {
                    command = new SqlCommand("SELECT * FROM std WHERE " + name + " = " + Find);
                    table = student.getStudents(command);
                }
                catch
                {
                    MessageBox.Show("ID không hợp lệ!!");
                    return;

                }
            }
            else if (name == "MSSV" || name == "fname"||name == "lname"||name == "phone")
            {
                try
                {
                    command = new SqlCommand("SELECT * FROM std WHERE " + name + " = " + "'" + Find + "'");
                    table = student.getStudents(command);
                }
                catch
                {
                    MessageBox.Show("Không hợp lệ!!");
                    return;
                }
            }
            if (table.Rows.Count > 0)
            {
                TextBoxID.Text = table.Rows[0]["id"].ToString();
                textBox_MSSV.Text = table.Rows[0]["MSSV"].ToString();
                TextBoxFname.Text = table.Rows[0]["fname"].ToString();
                TextBoxLname.Text = table.Rows[0]["lname"].ToString();
                DateTime bdate = (DateTime)table.Rows[0]["bdate"];
                String.Format("{0:d/M/yyyy}", bdate);
                dateTimePicker_BirthDate.Value = bdate;
                // gender
                if (table.Rows[0]["gender"].ToString() == "Female")
                {
                    RadioButtonFemale.Checked = true;
                }
                else
                {
                    RadioButtonMale.Checked = true;
                }
                TextBoxPhone.Text = table.Rows[0]["phone"].ToString();
                TextBoxAddress.Text = table.Rows[0]["address"].ToString();
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                PictureBoxStudentImage.Image = Image.FromStream(picture);
            }
            else
                MessageBox.Show("Không tìm thấy!!", "Tìm Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void button4_Click(object sender, EventArgs e)
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
