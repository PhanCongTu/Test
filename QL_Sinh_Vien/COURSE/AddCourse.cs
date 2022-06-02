using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sinh_Vien.COURSE
{
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }
        Course course = new Course();
        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                int cid = Convert.ToInt32(textBox_Course_ID.Text);
                string name = textBox_Label.Text;
                int hrs = Convert.ToInt32(textBox_Period.Text);
                string descr = textBox_Description.Text;

                if (name.Trim() == "")
                {
                    MessageBox.Show("Add a Course Name", " Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (course.checkCourseName(name))
                {
                    if (course.insertCourse(cid, name, hrs, descr))
                    {
                        MessageBox.Show("New course inserted", " Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Course not Inserted", " Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("This Course Name already Exists ", " Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                textBox_Course_ID.Text = "";
                textBox_Period.Text = "";
                textBox_Label.Text = "";
                textBox_Description.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddCourse_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (textBox_Course_ID.Text != "")
                {
                    int ID = Convert.ToInt32(textBox_Course_ID.Text);
                    if (course.CheckCourseID(ID))
                    {
                        MessageBox.Show("Khóa học đã có mã (ID) này rồi!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //textBox_Add_Gr_ID.Text = "";
                        textBox_Course_ID.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không được nhập chữ!");
            }
            
        }

        private void textBox_Course_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox_Period_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
