using QL_Sinh_Vien.COURSE;
using QL_Sinh_Vien.RESULT;
using QL_Sinh_Vien.Score;
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
    public partial class MainForm01 : Form
    {
        public MainForm01()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm addStF = new AddStudentForm();
            addStF.Show(this);
        }
        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            studentsListForm stdList = new studentsListForm();
            stdList.ShowDialog(this);
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatisticForm stdSF = new StatisticForm();
            stdSF.Show(this);
        }

        private void manageStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentForm mSF = new ManageStudentForm();
            mSF.ShowDialog(this);
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm stdUpF = new UpdateDeleteStudentForm();
            stdUpF.ShowDialog(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print_Student_Form psf = new Print_Student_Form();
            psf.ShowDialog(this);
        }

        
        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourse AddCF = new AddCourse();
            AddCF.Show(this);
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCourseForm RemoveCF = new RemoveCourseForm();
            RemoveCF.Show(this);
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCourseForm EditCF = new EditCourseForm();
            EditCF.Show(this);
        }

        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCoursesForm ManageCF = new ManageCoursesForm();
            ManageCF.Show(this);
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintCoursesForm PrintCF = new PrintCoursesForm();
            PrintCF.Show(this);
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScoreForm AddScoreSF = new AddScoreForm();
            AddScoreSF.Show(this);
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveScoreForm removeSF = new RemoveScoreForm();
            removeSF.Show(this);
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageScoreForm  manageSF = new ManageScoreForm();
            manageSF.Show(this);
        }

        private void avgScoreByCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvgScoreByCourseForm avgScoreByCourseForm = new AvgScoreByCourseForm();
            avgScoreByCourseForm.Show(this);
        }

        private void printToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PrintScoreForm printScoreForm = new PrintScoreForm();
            printScoreForm.Show(this);
        }

        private void aVGResultFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_To_File_Click resultForm = new button_To_File_Click();
            resultForm.Show(this);
        }

        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatisticResult statisticResult = new StatisticResult();
            statisticResult.Show(this);
        }
    }
}
