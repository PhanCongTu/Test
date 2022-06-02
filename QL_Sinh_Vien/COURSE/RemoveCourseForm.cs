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
    public partial class RemoveCourseForm : Form
    {
        public RemoveCourseForm()
        {
            InitializeComponent();
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            Course course = new Course();
            try
            {
                int id = Convert.ToInt32(textBox_Course_ID.Text);

                if (MessageBox.Show("Bạn có chắc là muốn xóa môn học này chứ ?", "Xóa môn học!! ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (course.deleteCourse(id))
                    {
                        MessageBox.Show("Đã xóa môn học này!!", "Xóa môn học!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thế xóa môn học này!!", "Xóa môn học!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Close();

            }
            catch
            {
                MessageBox.Show("Không có ID môn học hợp lệ!!", "Xóa môn học!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox_Course_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
