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
    public partial class AvgScoreByCourseForm : Form
    {
        public AvgScoreByCourseForm()
        {
            InitializeComponent();
        }
        SCORE score = new SCORE();
        private void AvgScoreByCourseForm_Load(object sender, EventArgs e)
        {
            dataGridView_Avg_Score_By_Course.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            dataGridView_Avg_Score_By_Course.DataSource = score.getAvgScoreByCourse();
        }
    }
}
