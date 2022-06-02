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

namespace QL_Sinh_Vien.RESULT
{
    public partial class StatisticResult : Form
    {
        public StatisticResult()
        {
            InitializeComponent();
        }
        public int Gioi_Count { get; set; }
        public int Kha_Count { get; set; }
        public int TB_Count { get; set; }
        public int Yeu_Count { get; set; }
        public int Kem_Count { get; set; }
        public StatisticResult(int Gioi_Count, int Kha_Count, int TB_Count, int Yeu_Count, int Kem_Count)
        {
            InitializeComponent();
            this.Gioi_Count = Gioi_Count;
            this.Kha_Count = Kha_Count;
            this.TB_Count = TB_Count;
            this.Yeu_Count = Yeu_Count;
            this.Kem_Count = Kem_Count;
        }
        MY_DB db = new MY_DB();

        private void StatisticResult_Load(object sender, EventArgs e)
        {
            //STUDENT student = new STUDENT();
            //ResultForm RF = new ResultForm();
            double totalGioi = Convert.ToDouble(Gioi_Count);
            double totalKha = Convert.ToDouble(Kha_Count);
            double totalTB = Convert.ToDouble(TB_Count);
            double totalYeu = Convert.ToDouble(Yeu_Count);
            double totalKem = Convert.ToDouble(Kem_Count);
            double total = totalGioi + totalKha + totalTB + totalYeu + totalKem;
            // tinh %, cac ban xem lai phep toan
            // (tong students X 100) / (total students)|
            double GioiStudentsPercentage = (totalGioi * (100 / total));
            double KhaStudentsPercentage = (totalKha * (100 / total));
            double TBStudentsPercentage = (totalTB * (100 / total));
            double YeuStudentsPercentage = (totalYeu * (100 / total));
            double KemStudentsPercentage = (totalKem * (100 / total));
            //LabelTotal.Text = ("Total Students: " + total.ToString());
            label_Gioi.Text = ("Gioi: " + (GioiStudentsPercentage.ToString("0.00") + "%"));
            label_Kha.Text = ("Kha: " + (KhaStudentsPercentage.ToString("0.00") + "%"));
            label_TB.Text = ("Trung bình: " + (TBStudentsPercentage.ToString("0.00") + "%"));
            label_Yeu.Text = ("Yếu: " + (YeuStudentsPercentage.ToString("0.00") + "%"));
            label_Kem.Text = ("Kém: " + (KemStudentsPercentage.ToString("0.00") + "%"));

            //////////////
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable tableCourse = new DataTable();
            SqlCommand command = new SqlCommand("select course_id,Course.label, avg(Score.student_score) as tb from Course inner join score on Course.Id = Score.course_id group by Course_id, label", db.getConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableCourse);
            int x = 15;
            int y = 50;
            foreach (DataRow VARIABLE in tableCourse.Rows)
            {
                y += 30;
                Label mylab = new Label();
                // Set the text in Label
                double dtb = Math.Round(Convert.ToDouble(VARIABLE["tb"].ToString()),2);
                mylab.Text = VARIABLE["label"].ToString() + ": " + dtb.ToString();
                
                // Set the location of the Label
                mylab.Location = new Point(x, y);
                // Set the AutoSize property of the Label control
                mylab.AutoSize = true;
                // Set the font of the content present in the Label Control
                mylab.Font = new Font("Century Gothic", 12);
                // Set the foreground color of the Label control
                //mylab.ForeColor = Color.FromArgb(41, 128, 185);
                mylab.ForeColor = Color.FromArgb(41, 128, 185);
                // Set the padding in the Label control
                mylab.Padding = new Padding(6);
                //dataGridView1.Columns.Add(VARIABLE["id"].ToString(), VARIABLE["label"].ToString());
                //panel2.Controls.Add(mylab);
                //mylab.Show();
                this.Controls.Add(mylab);
            }
        }
    }
}
