using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sinh_Vien
{
    public partial class studentsListForm : Form
    {
        public studentsListForm()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();
        private void studentsListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet3.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter2.Fill(this.myDBDataSet3.std);
            // TODO: This line of code loads data into the 'myDBDataSet2.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter1.Fill(this.myDBDataSet2.std);
            // TODO: This line of code loads data into the 'myDBDataSet1.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this.myDBDataSet1.std);
            /*// TODO: This line of code loads data into the 'myDBDataSet.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this.myDBDataSet.std);*/

            SqlCommand command = new SqlCommand("SELECT * FROM std");
            DataGridView1.ReadOnly = true;
            // xu ly hinh anh, code co tham khao msdn
            DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // doi tuong lam viec voi dang picture cua datagridview
            DataGridView1.RowTemplate.Height = 80; // dong nay tham khao tren MSDN ngay 10/03/2019, co gian de pic dep, dang tim auto-size
            DataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)DataGridView1.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridView1.AllowUserToAddRows = false;
        }

        private void bt_Refresh_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM std");
            DataGridView1.ReadOnly = true;
            // xu ly hinh anh, code co tham khao msdn
            DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // doi tuong lam viec voi dang picture cua datagridview
            DataGridView1.RowTemplate.Height = 80; // dong nay tham khao tren MSDN ngay 10/03/2019, co gian de pic dep, dang tim auto-size
            DataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)DataGridView1.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridView1.AllowUserToAddRows = false;
        }
      
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDeleteStudentForm updateDeletStdF = new UpdateDeleteStudentForm();
            // thu tu cua cac cot: id - fname - Inane - bd - gdr - phn - adrs - pic
            updateDeletStdF.TextBoxID.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateDeletStdF.textBox_MSSV.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateDeletStdF.TextBoxFname.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateDeletStdF.TextBoxLname.Text = DataGridView1.CurrentRow.Cells[3].Value.ToString();
            updateDeletStdF.dateTimePicker_BirthDate.Value = (DateTime)DataGridView1.CurrentRow.Cells[4].Value;

            // gender
            if ((DataGridView1.CurrentRow.Cells[5].Value.ToString().Trim() == "Female"))
            {
                updateDeletStdF.RadioButtonFemale.Checked = true;
            }
            else
            {
                updateDeletStdF.RadioButtonMale.Checked = true;
            }

            updateDeletStdF.TextBoxPhone.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            updateDeletStdF.TextBoxAddress.Text = DataGridView1.CurrentRow.Cells[7].Value.ToString();
            // code xu ly hinh anh up len, version 01, chay OK, tim hieu them de code nhe hon
            byte[] pic;
            pic = (byte[])DataGridView1.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            updateDeletStdF.PictureBoxStudentImage.Image = Image.FromStream(picture);
            this.Show();
            updateDeletStdF.Show();

        }

    }
}
