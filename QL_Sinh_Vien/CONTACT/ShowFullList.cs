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
using QL_Sinh_Vien.CONTACT;

namespace QL_Sinh_Vien
{
    public partial class ShowFullList : Form
    {
        public ShowFullList()
        {
            InitializeComponent();
        }
        private void ShowFullList_Load(object sender, EventArgs e)
        {
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView_Show_All.RowTemplate.Height = 80;
            Contact contact = new Contact();
            SqlCommand command = new SqlCommand("SELECT fname as 'First Name', lname as 'Last Name', mygroups.name as 'Group'," +
                "phone, email, address, picture FROM contact INNER JOIN mygroups on contact.group_id = mygroups.id" +
                " WHERE contact.userid = @userid");
            command.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.GlobalsUserId;
            dataGridView_Show_All.DataSource = contact.selectContactList(command);
            picCol = (DataGridViewImageColumn)dataGridView_Show_All.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            for  (int i = 0; i < dataGridView_Show_All.Rows.Count; i++)
            {
                if(IsOdd(i))
                {
                    dataGridView_Show_All.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
            QL_Sinh_Vien.Group.Group group = new Group.Group();
            listBox_Group.DataSource = group.getGroups(Globals.GlobalsUserId);
            listBox_Group.DisplayMember = "Name";
            listBox_Group.ValueMember = "id";
            listBox_Group.SelectedItem = null;
            dataGridView_Show_All.ClearSelection();
        }
        public static bool IsOdd(int value)
        {
            return (value % 2 == 0);
        }

        private void dataGridView_Show_All_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i =0; i < dataGridView_Show_All.Rows.Count; i++ )
            {
                if(IsOdd(i))
                {
                    dataGridView_Show_All.Rows[i].DefaultCellStyle.BackColor=Color.WhiteSmoke;
                }
            }
        }

        private void listBox_Group_Click(object sender, EventArgs e)
        {
            try
            {
                Contact contact = new Contact();
                int groupid = (Int32)listBox_Group.SelectedValue;
                SqlCommand command = new SqlCommand("SELECT fname as 'First Name', lname as 'Last Name', mygroups.name as 'Group'," +
                "phone, email, address, picture FROM contact INNER JOIN mygroups on contact.group_id = mygroups.id" +
                " WHERE contact.userid = @userid AND contact.group_id = @groupid");
                command.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.GlobalsUserId;
                command.Parameters.Add("@groupid", SqlDbType.Int).Value = groupid;
                dataGridView_Show_All.DataSource = contact.selectContactList(command);  
                for (int i = 0; i < dataGridView_Show_All.Rows.Count; i++)
                {
                    if (IsOdd(i))
                    {
                        dataGridView_Show_All.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dataGridView_Show_All.ClearSelection();
        }

        private void dataGridView_Show_All_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_Full_Address.Text = dataGridView_Show_All.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void label_Show_All_Click(object sender, EventArgs e)
        {
            ShowFullList_Load(null, null);
        }

        private void button_Show_Full_Click(object sender, EventArgs e)
        {
            dataGridView_Show_All.RowTemplate.Height = 80;

            Contact contact = new Contact();
            SqlCommand command = new SqlCommand("SELECT fname as 'First Name', lname as 'Last Name', mygroups.name as 'Group'," +
                "phone, email, address, picture FROM contact INNER JOIN mygroups on contact.group_id = mygroups.id" +
                " WHERE contact.userid = @userid");
            command.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.GlobalsUserId;
            dataGridView_Show_All.DataSource = contact.selectContactList(command);
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)dataGridView_Show_All.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            for (int i = 0; i < dataGridView_Show_All.Rows.Count; i++)
            {
                if (IsOdd(i))
                {
                    dataGridView_Show_All.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
            QL_Sinh_Vien.Group.Group group = new Group.Group();
            listBox_Group.DataSource = group.getGroups(Globals.GlobalsUserId);
            listBox_Group.DisplayMember = "Name";
            listBox_Group.ValueMember = "id";
            listBox_Group.SelectedItem = null;
            dataGridView_Show_All.ClearSelection();
        }
    }
}
