using Aspose.Words;//Thêm thư viện này (file Dll\Aspose.Word.dll)
using Aspose.Words.Tables;
using ThuVienWinform.Report.AsposeWordExtension;//thêm thư viện này (File Lib\ReportExtentionMethod.cs)
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
using Spire.Doc;
using Spire.Doc.Documents;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace QL_Sinh_Vien
{
    public partial class Print_Student_Form : Form
    {
        public Print_Student_Form()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();
        private void Print_Student_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet5.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this.myDBDataSet5.std);
            SqlCommand command = new SqlCommand("SELECT * FROM std");
            fillGrid(command);

            if (radioButton_No.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }
        public void fillGrid(SqlCommand command)
        {
            DataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            DataGridView1.RowTemplate.Height = 80;
            DataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)DataGridView1.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridView1.AllowUserToAddRows = false;
        }

        private void radioButton_Yes_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }

        private void radioButton_No_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void button_Check_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            String query;
            if (radioButton_Yes.Checked)
            {
                string date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                if(radioButton_Male.Checked)
                {
                    query = "SELECT * FROM std WHERE gender = 'Male' and bdate BETWEEN '" + date1 
                        + "' AND '" + date2 + "'";
                }
                else if (radioButton_Female.Checked)
                {
                    query = "SELECT * FROM std WHERE gender = 'Female' and bdate BETWEEN '" + date1
                        + "' AND '" + date2 + "'";
                }
                else
                {
                    query = "SELECT * FROM std WHERE bdate BETWEEN '" + date1 + "' AND '" + date2 + "'";
                }
                command = new SqlCommand(query);
                fillGrid(command);
            }
            else
            {
                if (radioButton_Male.Checked)
                {
                    query = "SELECT * FROM std WHERE gender = 'Male' ";
                }
                else if (radioButton_Female.Checked)
                {
                    query = "SELECT * FROM std WHERE gender = 'Female' ";
                }
                else
                {
                    query = "SELECT * FROM std";
                }
                command = new SqlCommand(query);
                fillGrid(command);
            }
        }

        private void button_Save_To_Text_File_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (.docx)|.docx";
            sfd.FileName = "export.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(DataGridView1, sfd.FileName);
            }

        }

        private void button_To_Printer_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }
        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;
                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }
                //table format
                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                    Type.Missing, Type.Missing, ref ApplyBorders,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();


                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                //table style 
                //oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].AutoFormat();
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oDoc.Tables[1].Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorWhite;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Color = Word.WdColor.wdColorBlack;

                //header text
                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Danh Sách Sinh Viên";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
                int n = DGV.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    byte[] imgbyte = (byte[])DGV.Rows[i].Cells[8].Value;
                    Object oMissing = System.Reflection.Missing.Value;
                    MemoryStream ms = new MemoryStream(imgbyte);
                    System.Drawing.Image sparePicture = System.Drawing.Image.FromStream(ms);
                    System.Drawing.Image finalPic = (System.Drawing.Image)(new Bitmap(sparePicture, new
                        Size(90, 90)));
                    Clipboard.SetDataObject(finalPic);
                    var oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    oDoc.Tables[1].Cell(2 + i, 9).Range.Paste();
                }

                //save the file
                oDoc.SaveAs2(filename);
            }
        }
    }
}
