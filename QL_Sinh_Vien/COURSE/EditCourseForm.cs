using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sinh_Vien.COURSE
{
    public partial class EditCourseForm : Form
    {
        public EditCourseForm()
        {
            InitializeComponent();
        }
        Course course = new Course();
        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            comboBox_Select_Course.DataSource = course.getAllCourse();
            comboBox_Select_Course.DisplayMember = "label";
            comboBox_Select_Course.ValueMember = "id";
            comboBox_Select_Course.SelectedItem = null;
        }

        public void fillCombo(int index)
        {

            comboBox_Select_Course.DataSource = course.getAllCourse();
            comboBox_Select_Course.DisplayMember = "label";
            comboBox_Select_Course.ValueMember = "id";
            comboBox_Select_Course.SelectedIndex = index;
        }

        private void comboBox_Select_Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(comboBox_Select_Course.SelectedValue);
                DataTable table = new DataTable();
                table = course.getCourseById(id);
                textBox_Label.Text = table.Rows[0][1].ToString();
                numericUpDown_Period.Value = Int32.Parse(table.Rows[0][2].ToString());
                textBox_Description.Text = table.Rows[0][3].ToString();
            }
            catch { }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox_Label.Text;
                int hrs = (int)numericUpDown_Period.Value;
                string descr = textBox_Description.Text;
                int id = (int)comboBox_Select_Course.SelectedValue;

                if (!course.checkCourseName(name, id))
                {
                    MessageBox.Show("Đã có tên Course này rồi!!", " Sửa Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (course.updateCourse(id, name, hrs, descr))
                {
                    MessageBox.Show("Đã cập nhật Course thành công!!", " Sửa Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillCombo(comboBox_Select_Course.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật Course này!!", " Sửa Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
