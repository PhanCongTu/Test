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

namespace QL_Sinh_Vien.Score
{
    public partial class PrintScoreForm : Form
    {
        public PrintScoreForm()
        {
            InitializeComponent();
        }
        SCORE score = new SCORE();
       MY_DB mydb = new MY_DB();
        private void PrintScoreForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Score");
            fillGrid(command);

        }
        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = score.getScore(command);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button_To_File_Click(object sender, EventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\score_list.doc";
            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {  
                    if (j == dataGridView1.Columns.Count - 1)
                    {
                        writer.Write(dataGridView1.Columns[j].HeaderText);
                        writer.WriteLine();
                        writer.WriteLine("-----------------------------------------------------------------");
                    }
                    else
                    {
                        writer.Write(dataGridView1.Columns[j].HeaderText + "\t\t" + "|");
                    }
                    
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
 
                        if (j == dataGridView1.Rows.Count - 1)
                        {
                            writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\n");
                        }
                        else
                        {
                            writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t\t" + "|");
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
            printDoc.DocumentName = "Print Score Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }
    }
}
