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
    public partial class StatisticForm : Form
    {
        public StatisticForm()
        {
            InitializeComponent();
        }
        // dat mau neu muon
        Color panTotalColor;
        Color panMaleColor;
        Color panFemaleColor;
        private void StatisticForm_Load(object sender, EventArgs e)
        {
            // get panels color
            panTotalColor = PanelTotal.BackColor;
            panMaleColor = PanelMale.BackColor;
            panFemaleColor = PanelFemale.BackColor;
            // display the values
            STUDENT student = new STUDENT();
            double total = Convert.ToDouble(student.totalStudent());
            double totalMale = Convert.ToDouble(student.totalMaleStudent());
            double totalFemale = Convert.ToDouble(student.totalFemaleStudent());
            // tinh %, cac ban xem lai phep toan
            // (tong students X 100) / (total students)|
            double malestudentsPercentage = (totalMale * (100 / total));
            double femalestudentsPercentage = (totalFemale * (100 / total));
            LabelTotal.Text = ("Total Students: " + total.ToString());
            LabelMale.Text = ("Male " + (malestudentsPercentage.ToString("0.00") + "%"));
            LabelFemale.Text = ("Female : " + (femalestudentsPercentage.ToString("0.00") + "%"));
        }
        // thu cac event lam viec voi Mouse
        private void LabelTotal_MouseEnter(object sender, EventArgs e)
        {
            LabelTotal.ForeColor = panTotalColor;
            PanelTotal.BackColor = Color.White;
        }
        private void LabelTotal_MouseLeave(object sender, EventArgs e)
        {
            LabelTotal.ForeColor = Color.White;
            PanelTotal.BackColor = panTotalColor;
        }
        private void LabelMale_MouseEnter(object sender, EventArgs e)
        {
            LabelMale.ForeColor = panMaleColor;
            PanelMale.BackColor = Color.White;
        }
        private void LabelMale_MouseLeave(object sender, EventArgs e)
        {
            LabelMale.ForeColor = Color.White;
            PanelMale.BackColor = panMaleColor;
        }
        private void LabelFemale_MouseEnter(object sender, EventArgs e)
        {
            LabelFemale.ForeColor = panFemaleColor;
            PanelFemale.BackColor = Color.White;
        }
        private void LabelFemale_Mouseleave(object sender, EventArgs e)
        {
            LabelFemale.ForeColor = Color.White;
            PanelFemale.BackColor = panFemaleColor;
        }

        private void button_Chart_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart(); 
            chart.Show();
        }
    }
}
