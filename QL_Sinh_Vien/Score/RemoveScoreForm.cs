using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sinh_Vien.Score
{
    public partial class RemoveScoreForm : Form
    {
        public RemoveScoreForm()
        {
            InitializeComponent();
        }
        SCORE score = new SCORE();

        private void RemoveScoreForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet8.Score' table. You can move, or remove it, as needed.
           // this.scoreTableAdapter.Fill(this.myDBDataSet8.Score);
            dataGridView1.DataSource = score.getStudentScore();
            dataGridView1.Columns["description"].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);


        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                int idst = Convert.ToInt32(textBox_Student_ID.Text);
                int idc = Convert.ToInt32(textBox_Course_ID.Text);

                if (MessageBox.Show("Are you sure You Want to Delete this Score ?", "Remove Score ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (score.DeleteScore(idst, idc))
                    {
                        MessageBox.Show("Score Deleted", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Score not Deleted", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                dataGridView1.DataSource = score.getStudentScore();
                dataGridView1.Columns["description"].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);


            }
            catch
            {
                MessageBox.Show("Error", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox_Student_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_Course_ID.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void textBox_Student_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox_Course_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
