using QL_Sinh_Vien.COURSE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sinh_Vien
{
    public partial class ManageCoursesForm : Form
    {
        public ManageCoursesForm()
        {
            InitializeComponent();
        }
        Course course = new Course();
        int pos;
        static int ID ;
        private void ManageCoursesForm_Load(object sender, EventArgs e)
        {
            reloadListBoxData();
        }
        void reloadListBoxData()
        {
            listBox_Courses.DataSource = course.getAllCourse();
            listBox_Courses.ValueMember = "id";
            listBox_Courses.DisplayMember = "label";
            listBox_Courses.SelectedItem = null;
            label_Total_Courses.Text = ("Total Courses: " + course.totalCourses());
        }
        void ShowData(int index)
        {
            DataRow dr = course.getAllCourse().Rows[index];
            listBox_Courses.SelectedIndex = index;
            textBox_ID.Text = dr.ItemArray[0].ToString();
            ID = Convert.ToInt32(dr.ItemArray[0].ToString());
            textBox_Label.Text = dr.ItemArray[1].ToString();
            numericUpDown_Hours_Number.Value = int.Parse(dr.ItemArray[2].ToString());
            textBox_Description.Text = dr.ItemArray[3].ToString();
        }

        private void listBox_Courses_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)listBox_Courses.SelectedItem;
            pos = listBox_Courses.SelectedIndex;
            ShowData(pos);
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            { 
                
                if (textBox_Label.Text.Trim() == "" || textBox_ID.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống tên và ID!!", " Thêm Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    Course course = new Course();
                    int cid = Convert.ToInt32(textBox_ID.Text);
                    string name = textBox_Label.Text;
                    int hrs = (int)numericUpDown_Hours_Number.Value;
                    string descr = textBox_Description.Text;
                    if (textBox_ID.Text != "")
                    {
                        if (course.CheckCourseID(cid))
                        {
                            MessageBox.Show("Khóa học đã có mã (ID) này rồi!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //textBox_Add_Gr_ID.Text = "";
                            textBox_ID.Text = ID.ToString();
                            return;
                        }
                    }
                    if (course.checkCourseName(name))
                    {
                        if (course.insertCourse(cid, name, hrs, descr))
                        {
                            MessageBox.Show("Đã thêm Course", " Thêm Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm Course", " Thêm Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã có Course này rồi!!", " Thêm Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            

            if (textBox_Label.Text.Trim() == "" || textBox_ID.Text =="")
            {
                MessageBox.Show("Không được bỏ trống tên và ID!!", " Thêm Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string name = textBox_Label.Text;
                int hrs = (int)numericUpDown_Hours_Number.Value;
                string descr = textBox_Description.Text;
                int id = int.Parse(textBox_ID.Text);
                if (textBox_ID.Text != "")
                {
                    //int ID = Convert.ToInt32(textBox_ID.Text);
                    if (course.CheckCourseID(id))
                    {
                        MessageBox.Show("Khóa học đã có mã (ID) này rồi!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //textBox_Add_Gr_ID.Text = "";
                        textBox_ID.Text = ID.ToString();
                        return;
                    }
                }
                if (!course.checkCourseName(name, Convert.ToInt32(textBox_ID.Text)))
                {
                    MessageBox.Show("Đã có tên Course này rồi!!", " Sửa Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (course.updateCourse(id, name, hrs, descr))
                {
                    MessageBox.Show("Đã cập nhật Course", " Sửa Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reloadListBoxData();
                }
                else
                {
                    MessageBox.Show("Không thế cập nhật Course", " Sửa Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                pos = 0;
            }
            
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                //int id = Convert.ToInt32(textBox_ID.Text);

                if (MessageBox.Show("Bạn có chắc muốn xóa Course này chứ ?", "Xóa Course ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (course.deleteCourse(ID))
                    {
                        MessageBox.Show("Đã xóa Course", "Xóa Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_ID.Text = "";
                        textBox_Label.Text = "";
                        numericUpDown_Hours_Number.Value = 10;
                        textBox_Description.Text = "";
                        reloadListBoxData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa", "Xóa Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            pos = 0;
        }

        private void button_First_Click(object sender, EventArgs e)
        {
            pos = 0;
            ShowData(pos);
        }

        private void button_Previous_Click(object sender, EventArgs e)
        {
            if(pos > 0)
            {
                pos = pos - 1;
                ShowData(pos);
            }
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if(pos < (course.getAllCourse().Rows.Count - 1))
            {
                pos = pos + 1;
                ShowData(pos);
            }
        }

        private void button_Last_Click(object sender, EventArgs e)
        {
            pos = course.getAllCourse().Rows.Count - 1;
            ShowData(pos);
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            textBox_ID.Text = "";
            textBox_Label.Text = "";
            numericUpDown_Hours_Number.Value = 10;
            textBox_Description.Text = "";
            reloadListBoxData();
        }

        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
