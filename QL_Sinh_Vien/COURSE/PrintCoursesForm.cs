using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace QL_Sinh_Vien.COURSE
{
    public partial class PrintCoursesForm : Form
    {
        public PrintCoursesForm()
        {
            InitializeComponent();
        }
        Course course = new Course();
        private void PrintCoursesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet6.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.myDBDataSet6.Course);
            SqlCommand command = new SqlCommand("SELECT * FROM Course");
            fillGrid(command);

        }
        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = course.getCourse(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button_To_File_Click(object sender, EventArgs e)
        {
            /*SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (.docx)|.docx";
            sfd.FileName = "export.docx";
            *//*if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(dataGridView1, sfd.FileName);
            }*/
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Course_list.doc";
            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (j == dataGridView1.Rows.Count - 1)
                        {
                            writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                        }
                    }
                    writer.WriteLine();
                    writer.WriteLine("-----------------------------------------------------------------");
                }
                MessageBox.Show("File Saved");
            }

            
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }

        ///////////////////
        ///
        /*public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int RowCount = dataGridView1.Rows.Count;
                int ColumnCount = dataGridView1.Columns.Count;

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                string oTemp = "";
                Object oMissing = System.Reflection.Missing.Value;
                for (int r = 0; r < RowCount - 1; r++)
                {
                    oTemp = "";
                    for (int c = 0; c < ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + dataGridView1.Rows[r].Cells[c].Value + "\t";
                    }
                    var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    oPara1.Range.Text = oTemp;
                    oPara1.Range.InsertParagraphAfter();
                    //byte[] imgbyte = (byte[])dataGridView1.Rows[r].Cells[7].Value;
                    //MemoryStream ms = new MemoryStream(imgbyte);
                    //System.Drawing.Image sparePicture = System.Drawing.Image.FromStream(ms);
                    //System.Drawing.Image finalPic = (System.Drawing.Image)(new Bitmap(sparePicture, new Size(90, 90)));
                    //Clipboard.SetDataObject(finalPic);
                    //var oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    //oPara2.Range.Paste();
                    //oPara2.Range.InsertParagraphAfter();
                    //oTemp += "\n";
                }
                //save the file
                oDoc.SaveAs2(filename);
            }
        }*/
    }
}
