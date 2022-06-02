using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Words;
using Aspose.Words.Tables;
using ThuVienWinform.Report.AsposeWordExtension;
namespace QL_Sinh_Vien.RESULT
{
    public partial class button_To_File_Click : Form
    {
        public button_To_File_Click()
        {
            InitializeComponent();
        }
        //STUDENT student = new STUDENT();
        MY_DB db = new MY_DB();
        public int Gioi_Count { get; set; }
        public int Kha_Count { get; set; }
        public int TB_Count { get; set; }
        public int Yeu_Count { get; set; }
        public int Kem_Count { get; set; }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            Gioi_Count = 0;
            Kha_Count = 0;
            TB_Count = 0;
            Yeu_Count = 0;
            Kem_Count = 0;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable tableUser = new DataTable();
            SqlCommand command = new SqlCommand("select * from (select std.id as stdid, mssv, fname, lname, COURSE.id as courseid, LABEL  from std, course ) as q left join score on stdid = student_id and courseid = course_id order by stdid asc", db.getConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableUser);

            DataTable tableCourse = new DataTable();
            command = new SqlCommand("select * from course", db.getConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableCourse);

            int nCourse = tableCourse.Rows.Count;
            int nUser = tableUser.Rows.Count;
            int total = nUser / nCourse;
            dataGridView1.Columns.Add("id", "Student ID");
            dataGridView1.Columns.Add("mssv", "MSSV");
            dataGridView1.Columns.Add("fname", "First Name");
            dataGridView1.Columns.Add("lname", "Last Name");
            foreach (DataRow VARIABLE in tableCourse.Rows)
            {
                dataGridView1.Columns.Add(VARIABLE["id"].ToString(), VARIABLE["label"].ToString());
            }
            dataGridView1.Columns.Add("av", "Average Score");
            dataGridView1.Columns.Add("res", "Results");
            double tong = 0;
            int dem = 1;
            for (int i = 0; i < total; i++)
            {
                dataGridView1.Rows.Add((DataGridViewRow)dataGridView1.Rows[0].Clone());
                dataGridView1.Rows[i].Cells[0].Value = tableUser.Rows[i * nCourse][0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = tableUser.Rows[i * nCourse][1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = tableUser.Rows[i * nCourse][2].ToString();
                dataGridView1.Rows[i].Cells[3].Value = tableUser.Rows[i * nCourse][3].ToString();
                tong = dem = 0;
                for (int j = 0; j < nCourse; j++)
                {
                    if (tableUser.Rows[j + i * nCourse][8].ToString().Trim() != "")
                    {
                        tong += Convert.ToDouble(tableUser.Rows[j + i * nCourse][8].ToString());
                        dem += 1;
                    }
                    dataGridView1.Rows[i].Cells[4 + j].Value = tableUser.Rows[j + i * nCourse][8].ToString();
                }

                if (dem != 0)
                {
                    double diem = (tong * 1.0 / dem);
                    dataGridView1.Rows[i].Cells[4 + nCourse].Value = Math.Round(diem, 2);
                    //dataGridView1.Rows[i].Cells[4 + nCourse].Value = diem > 5 ? "Đạt" : "Rớt";
                    if (diem >= 8)
                    {
                        Gioi_Count++;
                        dataGridView1.Rows[i].Cells[5 + nCourse].Value = "Giỏi";
                    }
                    else if (diem >= 6.5)
                    {
                        Kha_Count++;
                        dataGridView1.Rows[i].Cells[5 + nCourse].Value = "Khá";
                    }
                    else if (diem >= 5)
                    {
                        TB_Count++;
                        dataGridView1.Rows[i].Cells[5 + nCourse].Value = "Trung Bình";
                    }
                    else if (diem >= 3.5)
                    {
                        Yeu_Count++;
                        dataGridView1.Rows[i].Cells[5 + nCourse].Value = "Yếu";
                    }
                    else
                    {
                        Kem_Count++;
                        dataGridView1.Rows[i].Cells[5 + nCourse].Value = "Kém";
                    }
                }
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox_Student_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_First_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_Last_Name.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable tableUser = new DataTable();
            //SqlCommand command = new SqlCommand("select * from (select std.id as stdid,fname, lname, COURSE.id as courseid, LABEL  from std, course ) as q left join score on stdid = student_id and courseid = course_id order by stdid asc", db.getConnection);
            SqlCommand command = new SqlCommand("select * from (select std.id as stdid, mssv, fname, lname, COURSE.id as courseid, LABEL  from std, course WHERE CONCAT(fname, std.id) LIKE '%" + textBox_Search.Text + "%' ) as q left join score on stdid = student_id and courseid = course_id order by stdid asc ", db.getConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableUser);

            DataTable tableCourse = new DataTable();
            command = new SqlCommand("select * from course", db.getConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableCourse);
            
            int nCourse = tableCourse.Rows.Count;
            int nUser = tableUser.Rows.Count;
            int total = nUser / nCourse;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "Student ID");
            dataGridView1.Columns.Add("mssv", "MSSV");
            dataGridView1.Columns.Add("fname", "First Name");
            dataGridView1.Columns.Add("lname", "Last Name");
            foreach (DataRow VARIABLE in tableCourse.Rows)
            {
                dataGridView1.Columns.Add(VARIABLE["id"].ToString(), VARIABLE["label"].ToString());
            }
            dataGridView1.Columns.Add("av", "Average Score");
            dataGridView1.Columns.Add("res", "Results");
            double tong = 0;
            int dem = 1;
            for (int i = 0; i < total; i++)
            {
                dataGridView1.Rows.Add((DataGridViewRow)dataGridView1.Rows[0].Clone());
                dataGridView1.Rows[i].Cells[0].Value = tableUser.Rows[i * nCourse][0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = tableUser.Rows[i * nCourse][1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = tableUser.Rows[i * nCourse][2].ToString();
                dataGridView1.Rows[i].Cells[3].Value = tableUser.Rows[i * nCourse][3].ToString();
                tong = dem = 0;
                for (int j = 0; j < nCourse; j++)
                {
                    if (tableUser.Rows[j + i * nCourse][8].ToString().Trim() != "")
                    {
                        tong += Convert.ToDouble(tableUser.Rows[j + i * nCourse][8].ToString());
                        dem += 1;
                    }
                    dataGridView1.Rows[i].Cells[4 + j].Value = tableUser.Rows[j + i * nCourse][8].ToString();
                }

                if (dem != 0)
                {
                    double diem = (tong * 1.0 / dem);
                    dataGridView1.Rows[i].Cells[4 + nCourse].Value = Math.Round(diem, 2);
                    //dataGridView1.Rows[i].Cells[4 + nCourse].Value = diem > 5 ? "Đạt" : "Rớt";
                    if(diem >=8)
                    {
                        dataGridView1.Rows[i].Cells[5 + nCourse].Value = "Giỏi";
                    }
                    else if (diem >= 6.5)
                    {
                        dataGridView1.Rows[i].Cells[5 + nCourse].Value = "Khá";
                    }
                    else if (diem >= 5)
                    {
                        dataGridView1.Rows[i].Cells[5 + nCourse].Value = "Trung Bình";
                    }
                    else if (diem >= 3.5)
                    {
                        dataGridView1.Rows[i].Cells[5 + nCourse].Value = "Yếu";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[5 + nCourse].Value = "Kém";
                    }
                }
            }
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Result Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }

        private void button_Statistic_Click(object sender, EventArgs e)
        {
            StatisticResult statisticResult = new StatisticResult(Gioi_Count, Kha_Count, TB_Count, Yeu_Count, Kem_Count);
            statisticResult.Show();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_To_File_Click_1(object sender, EventArgs e)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable tableUser = new DataTable();
            string stid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlCommand command = new SqlCommand("select * from std where id = " +stid, db.getConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableUser);

            DataTable tableCourse = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from Course order by id asc", db.getConnection);
            adapter.SelectCommand = cmd;
            adapter.Fill(tableCourse);
            int SoMonHoc = Convert.ToInt32(tableCourse.Rows.Count);

            var homNay = DateTime.Now;
            //Bước 1: Nạp file mẫu
            Document baoCao = new Document("Template\\Result.doc");
            //Bước 2: Điền các thông tin cố định
            //int x =  Convert.ToInt32(tableUser.Rows[1][2].ToString());
            baoCao.MailMerge.Execute(new[] { "Ngay_Thang_Nam_BC" }, new[] { string.Format("Thủ Đức, ngày {0} tháng {1} năm {2}", homNay.Day, homNay.Month, homNay.Year) });
            baoCao.MailMerge.Execute(new[] { "MSSV" }, new[] { dataGridView1.CurrentRow.Cells[1].Value.ToString() });
            baoCao.MailMerge.Execute(new[] { "HO" }, new[] { tableUser.Rows[0][1].ToString() });
            baoCao.MailMerge.Execute(new[] { "TEN" }, new[] { tableUser.Rows[0][2].ToString() });
            baoCao.MailMerge.Execute(new[] { "Ngay_Sinh" }, new[] { tableUser.Rows[0][3].ToString() });
            baoCao.MailMerge.Execute(new[] { "Gioi_Tinh" }, new[] { tableUser.Rows[0][4].ToString() });
            baoCao.MailMerge.Execute(new[] { "SDT" }, new[] { tableUser.Rows[0][5].ToString() });
            baoCao.MailMerge.Execute(new[] { "Dia_Chi" }, new[] { tableUser.Rows[0][6].ToString() });
            baoCao.MailMerge.Execute(new[] { "Diem_TB" }, new[] { dataGridView1.CurrentRow.Cells[4 + SoMonHoc].Value.ToString() });
            baoCao.MailMerge.Execute(new[] { "Ket_Qua" }, new[] { dataGridView1.CurrentRow.Cells[5 + SoMonHoc].Value.ToString() });
            //Bước 3: Điền thông tin lên bảng
            
            Table bangThongTinGiaDinh = baoCao.GetChild(NodeType.Table, 1, true) as Table;//Lấy bảng thứ 2 trong file mẫu
            int hangHienTai = 1;
            bangThongTinGiaDinh.InsertRows(hangHienTai, hangHienTai, SoMonHoc - 1);
            for (int i = 1; i <= SoMonHoc; i++)
            {
                bangThongTinGiaDinh.PutValue(i, 0, tableCourse.Rows[-1 + i][1].ToString());//Cột Tên Môn Học
                bangThongTinGiaDinh.PutValue(i, 1, dataGridView1.CurrentRow.Cells[3 + i].Value.ToString());//Cột Điểm
            }

            string namefile = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //Bước 4: Lưu và mở file
            baoCao.SaveAndOpenFile(namefile + ".doc");
        }

        private void textBox_Student_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
