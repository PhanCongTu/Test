using QL_Sinh_Vien.COURSE;
using QL_Sinh_Vien.Score;
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

namespace QL_Sinh_Vien
{
    public partial class AddScoreForm : Form
    {
        public AddScoreForm()
        {
            InitializeComponent();
        }
        SCORE score = new SCORE();
        Course course = new Course();
        STUDENT student = new STUDENT();
        private void AddScoreForm_Load(object sender, EventArgs e)
        {
            comboBox_Select_Course.DataSource = course.getAllCourse();
            comboBox_Select_Course.DisplayMember = "Ten_CV";
            comboBox_Select_Course.ValueMember = "ID_CV";

            SqlCommand command = new SqlCommand("SELECT id, fname, lname FROM std");
            dataGridView1.DataSource = student.getStudents(command);
            //for(int i =0;i<3;i++)

            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox_Student_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        // button add score
        private void ButtonAddscore_click(object sender, EventArgs e)
        {
            try
            {
                if(textBox_Student_ID.Text=="" || comboBox_Select_Course.SelectedValue == null || textBox_Select_Score.Text == "")
                {
                    MessageBox.Show("Không được để trống ID Student, Course, Score");
                }
                else
                {
                    int studentID = Convert.ToInt32(textBox_Student_ID.Text);
                    int courseID = Convert.ToInt32(comboBox_Select_Course.SelectedValue);
                    float scorevalue = Convert.ToInt32(textBox_Select_Score.Text);
                    string description = textBox_Description.Text;
                    double diem = Convert.ToDouble(textBox_Select_Score.Text);
                    //check if the score is already set for this student on this score
                    if (diem >= 0 && diem <= 10)
                    {
                        if (score.studentScoreExist(studentID, courseID))
                        {
                            if (score.insertScore(studentID, courseID, scorevalue, description))
                            {
                                MessageBox.Show("Điểm đã được thêm!!", "Thêm điểm!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Không thể thêm điểm!!", "Thêm điểm!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đã có điểm cho môn này rồi!!", "Thêm điểm!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Điểm phải từ 0 đến 10!!", "Thêm điểm!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm điểm!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_Student_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox_Select_Score_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
    }
}
