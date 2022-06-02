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
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            try
            {
                STUDENT student = new STUDENT();
                double total = Convert.ToDouble(student.totalStudent());
                double totalMale = Convert.ToDouble(student.totalMaleStudent());
                double totalFemale = Convert.ToDouble(student.totalFemaleStudent());
                double maleStudentsPercentage = total - totalFemale;
                double malePercent = maleStudentsPercentage / total;
                double femaleStudentsPercentage = total - totalMale;
                double femalePercent = femaleStudentsPercentage / total;

                // Biểu đồ cột
                chartBDC.Series["chartBDC"].Points.Add(maleStudentsPercentage);
                chartBDC.Series["chartBDC"].Points[0].Label = maleStudentsPercentage.ToString("0");
                chartBDC.Series["chartBDC"].Points[0].Color = Color.Blue;
                chartBDC.Series["chartBDC"].Points[0].AxisLabel = "Male";

                chartBDC.Series["chartBDC"].Points.Add(femaleStudentsPercentage);
                chartBDC.Series["chartBDC"].Points[1].Label = femaleStudentsPercentage.ToString("0");
                chartBDC.Series["chartBDC"].Points[1].Color = Color.Red;
                chartBDC.Series["chartBDC"].Points[1].AxisLabel = "Female";


                // Biểu đồ tròn
                chartBDT.Series["chartBDT"].Points.Add(maleStudentsPercentage);
                chartBDT.Series["chartBDT"].Points[0].Label = malePercent.ToString("0.00 %");
                chartBDT.Series["chartBDT"].Points[0].Color = Color.Blue;
                chartBDT.Series["chartBDT"].Points[0].AxisLabel = "Male";

                chartBDT.Series["chartBDT"].Points.Add(femaleStudentsPercentage);
                chartBDT.Series["chartBDT"].Points[1].Label = femalePercent.ToString("0.00 %");
                chartBDT.Series["chartBDT"].Points[1].Color = Color.Red;
                chartBDT.Series["chartBDT"].Points[1].AxisLabel = "Female";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
