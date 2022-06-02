using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_Sinh_Vien.COURSE;
using System.Data.SqlClient;
namespace QL_Sinh_Vien.Score
{
    public partial class ManageScoreForm : Form
    {
        public ManageScoreForm()
        {
            InitializeComponent();
        }
        SCORE score = new SCORE();
        STUDENT student = new STUDENT();
        Course course = new Course();
        string data = "score";

        private void ManageScoreForm_Load(object sender, EventArgs e)
        {
            dataGridView_Student_Score.DataSource = score.getStudentScore();
            dataGridView_Student_Score.Columns["description"].Visible = false;

            comboBox_Select_Course.DataSource = course.getAllCourse();
            comboBox_Select_Course.DisplayMember = "label";
            comboBox_Select_Course.ValueMember = "id";
        }

        private void button_Show_Score_Click(object sender, EventArgs e)
        {
            data = "score";
            dataGridView_Student_Score.DataSource = score.getStudentScore();
            dataGridView_Student_Score.Columns["description"].Visible = false;
        }

        private void button_Show_Student_Click(object sender, EventArgs e)
        {
            data = "std";
            SqlCommand command = new SqlCommand("SELECT id as 'Mã Sinh Viên', fname as 'Họ', lname as 'Tên', bdate as 'Ngày Sinh' FROM std");
            dataGridView_Student_Score.DataSource = student.getStudents(command);
        }

        void getDataFromDatagridView()
        {
            if( data == "std")
            {
                textBox_Student_ID.Text = dataGridView_Student_Score.CurrentRow.Cells[0].Value.ToString();
            }
            else if ( data == "score")
            {
                textBox_Student_ID.Text = dataGridView_Student_Score.CurrentRow.Cells[0].Value.ToString();
                comboBox_Select_Course.SelectedValue = dataGridView_Student_Score.CurrentRow.Cells[3].Value.ToString();
                textBox_Score.Text = dataGridView_Student_Score.CurrentRow.Cells[5].Value.ToString();
                textBox_Description.Text = dataGridView_Student_Score.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void dataGridView_Student_Score_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDatagridView();
        }

        private void button_Avg_Score_By_Course_Click(object sender, EventArgs e)
        {
            AvgScoreByCourseForm avgScoreByCourseForm = new AvgScoreByCourseForm();
            avgScoreByCourseForm.Show(this);
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Student_ID.Text == "" || comboBox_Select_Course.SelectedValue == null || comboBox_Select_Course.Text == "")
                {
                    MessageBox.Show("Không được để trống ID Student, Course, Score");
                }
                else
                {
                    int studentID = Convert.ToInt32(textBox_Student_ID.Text);
                    int courseID = Convert.ToInt32(comboBox_Select_Course.SelectedValue);
                    int scoreValue = Convert.ToInt32(textBox_Score.Text);
                    string Description = textBox_Description.Text;
                    double diem = Convert.ToDouble(textBox_Score.Text);
                    if (diem >= 0 && diem <= 10)
                    {
                        if (score.studentScoreExist(studentID, courseID))
                        {
                            if (score.insertScore(studentID, courseID, scoreValue, Description))
                            {
                                MessageBox.Show("Đã thêm điểm của sinh viên thành công !!!", " Thêm điểm!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dataGridView_Student_Score.DataSource = score.getStudentScore();
                                dataGridView_Student_Score.Columns["description"].Visible = false;

                            }
                            else
                            {
                                MessageBox.Show("Không thể thêm điểm cho sinh viên này!!!", " Thêm điểm!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Môn học này của sinh viên này đã có rồi!!! ", " Thêm điểm!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show(ex.Message, "Thêm đi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (data == "std")
            {
                MessageBox.Show("Không thể xóa điểm của sinh viên từ đây !!", "Xóa điểm!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (data == "score")
            {
                int studentID = int.Parse(dataGridView_Student_Score.CurrentRow.Cells[0].Value.ToString());
                int courstID = int.Parse(dataGridView_Student_Score.CurrentRow.Cells[3].Value.ToString());

                if (MessageBox.Show("Bạn có chắc muốn xóa điểm này chứ ?", "Xóa điểm!! ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (score.DeleteScore(studentID, courstID))
                    {
                        MessageBox.Show("Điểm này đã được xóa!!", "Xóa điểm!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView_Student_Score.DataSource = score.getStudentScore();
                        textBox_Student_ID.Text = "";
                        textBox_Score.Text = "";
                        //comboBox_Select_Course.ValueMember = "";
                        textBox_Description.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa!!", "Xóa điểm!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //Close();
            }

        }

        private void textBox_Student_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox_Score_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
    }
}
