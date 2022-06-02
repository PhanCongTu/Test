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


namespace QL_Sinh_Vien.CONTACT
{
    public partial class HumanResource : Form
    {
        public HumanResource()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        QL_Sinh_Vien.Group.Group group = new QL_Sinh_Vien.Group.Group();
        int id = Globals.GlobalsContactId;
        int useid = Globals.GlobalsUserId;
        private void button_Add_Contact_Click(object sender, EventArgs e)
        {
            AddContact addContact = new AddContact();
            addContact.Show(this);
        }
        MY_DB mydb = new MY_DB();
        private void button_Edit_Contact_Click(object sender, EventArgs e)
        {
            EditContact editContact = new EditContact();
            editContact.Show(this);
        }
        public void getImageAndUserName()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT * FROM hr WHERE id = @id", mydb.getConnection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Globals.GlobalsUserId;
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                if ((table.Rows.Count > 0))
                {
                    byte[] pic;
                    pic = (byte[])table.Rows[0]["fig"];
                    MemoryStream picture = new MemoryStream(pic);
                    pictureBox_User.Image = Image.FromStream(picture);
                    label_Welcome_User.Text = "Welcome (" + table.Rows[0]["f_name"].ToString() + " "
                        + table.Rows[0]["l_name"].ToString() + " )";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void HumanResource_Load(object sender, EventArgs e)
        {
            getImageAndUserName();
            /*int id = Globals.GlobalsContactId;
            int useid = Globals.GlobalsUserId;*/
            if (textBox_Remove_Enter_Contact_ID.Text != id.ToString())
                try
                {

                    DataTable table = new DataTable();
                    table = contact.getContactById(id);
                    textBox_Remove_Enter_Contact_ID.Text = table.Rows[0][0].ToString();
                }
                catch { }

            comboBox_Edit_Select_Gr.DataSource = group.getGroups(useid);
            comboBox_Edit_Select_Gr.DisplayMember = "name";
            comboBox_Edit_Select_Gr.ValueMember = "id";
            comboBox_Edit_Select_Gr.SelectedItem = null;

            comboBox_Remove_Select_Rroup.DataSource = group.getGroups(useid);
            comboBox_Remove_Select_Rroup.DisplayMember = "name";
            comboBox_Remove_Select_Rroup.ValueMember = "id";
            comboBox_Remove_Select_Rroup.SelectedItem = null;
        }

        private void button_Show_Full_Contact_Click(object sender, EventArgs e)
        {
            ShowFullList showFullList = new ShowFullList();
            showFullList.Show(this);
        }

        private void button_Select_Contact_Click(object sender, EventArgs e)
        {
            SelectContact selectContact = new SelectContact();
            selectContact.Show(this);
        }

        private void button_Remove_Contact_Click(object sender, EventArgs e)
        {          
            try
            {
                int id = Convert.ToInt32(textBox_Remove_Enter_Contact_ID.Text);

                if (MessageBox.Show("Are you sure You Want to Delete this Contact ?", "Remove Contact ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (contact.deleteContact(id))
                    {
                        MessageBox.Show("Contact Deleted", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Contact not Deleted", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Close();

            }
            catch
            {
                MessageBox.Show("Please enter A valid ID", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_Add_Group_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox_Add_Gr_ID.Text);
                string gname = textBox_Add_Enter_Gr_Name.Text;
                int userid = Globals.GlobalsUserId;
                if ((textBox_Add_Gr_ID.Text != "") && (textBox_Add_Enter_Gr_Name.Text != ""))
                {
                    if ((group.insertGroup(id, gname, userid)))
                    {
                        MessageBox.Show("Group Added", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    textBox_Add_Gr_ID.Text = "";
                    textBox_Add_Enter_Gr_Name.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {

            
            if (textBox_Add_Enter_Gr_Name.Text != "")
            {
                if (IsText(textBox_Add_Enter_Gr_Name.Text) == false)
                {
                    MessageBox.Show("Không được nhập số !!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //textBox_Add_Gr_ID.Text = "";
                    textBox_Add_Enter_Gr_Name.Text = "";
                }
                else
                {
                    string gname = textBox_Add_Enter_Gr_Name.Text;
                    int userid = Globals.GlobalsUserId;
                    if (group.groupExist(gname, "add", userid, 0))
                    {
                        MessageBox.Show("Người dùng đã có nhóm này rồi!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //textBox_Add_Gr_ID.Text = "";
                        textBox_Add_Enter_Gr_Name.Text = "";
                    }
                }
                

            }
            if (textBox_Add_Gr_ID.Text != "")
            {
                if (IsNumber(textBox_Add_Gr_ID.Text)==false)
                {
                    MessageBox.Show("Chỉ được nhập số !!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //textBox_Add_Gr_ID.Text = "";
                    textBox_Add_Gr_ID.Text = "";
                }
                else
                {
                    int ID = Int32.Parse(textBox_Add_Gr_ID.Text);
                    if (group.CheckGroupID(ID))
                    {
                        MessageBox.Show("Đã có mã nhóm (ID) này rồi!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //textBox_Add_Gr_ID.Text = "";
                        textBox_Add_Gr_ID.Text = "";
                    }
                }
            }
            

        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool IsText(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            int id = Globals.GlobalsContactId;
            if (textBox_Remove_Enter_Contact_ID.Text != id.ToString())
                try
                {

                    DataTable table = new DataTable();
                    table = contact.getContactById(id);
                    textBox_Remove_Enter_Contact_ID.Text = table.Rows[0][0].ToString();

                }
                catch { }
        }

        private void comboBox_Edit_Select_Gr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(comboBox_Edit_Select_Gr.SelectedValue);
                DataTable table = new DataTable();
                table = group.getGroupsByID(id);
                textBox_Edit_Enter_Gr_Name.Text = table.Rows[0][1].ToString();
            }
            catch { }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                int gid = (int)comboBox_Edit_Select_Gr.SelectedValue;
                string gname = textBox_Edit_Enter_Gr_Name.Text;
                if (group.updateGroup(gid, gname))
                {
                    MessageBox.Show("Group updated", " Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Group not updated", " Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void textBox_Edit_Enter_Gr_Name_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Edit_Enter_Gr_Name.Text != "")
                {
                    int gid = (int)comboBox_Edit_Select_Gr.SelectedValue;
                    string gname = textBox_Edit_Enter_Gr_Name.Text;
                    int userid = Globals.GlobalsUserId;
                    if (group.groupExist(gname, "edit", userid, gid))
                    {
                        MessageBox.Show("Người dùng đã có nhóm này rồi!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox_Edit_Enter_Gr_Name.Text = "";
                    }
                }
            }
            catch { }
            
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Remove_Select_Rroup.SelectedValue != null)
                {
                    int gid = (int)comboBox_Remove_Select_Rroup.SelectedValue;
                    if (group.deleteGroup(gid))
                    {
                        MessageBox.Show("Group Deleted", " Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Edit_Enter_Gr_Name.Text = "";
                    }
                    else
                        MessageBox.Show("Group not Deleted", " Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void linkLabel_Refresh_Click(object sender, EventArgs e)
        {
            comboBox_Edit_Select_Gr.DataSource = group.getGroups(useid);
            comboBox_Edit_Select_Gr.DisplayMember = "label";
            comboBox_Edit_Select_Gr.ValueMember = "id";
            comboBox_Edit_Select_Gr.SelectedItem = null;

            comboBox_Remove_Select_Rroup.DataSource = group.getGroups(useid);
            comboBox_Remove_Select_Rroup.DisplayMember = "label";
            comboBox_Remove_Select_Rroup.ValueMember = "id";
            comboBox_Remove_Select_Rroup.SelectedItem = null;

            textBox_Add_Gr_ID.Text = "";
            textBox_Add_Enter_Gr_Name.Text = "";
            textBox_Edit_Enter_Gr_Name.Text = "";
            textBox_Remove_Enter_Contact_ID.Text = "";
            comboBox_Edit_Select_Gr.Text = "";
            comboBox_Remove_Select_Rroup.Text = "";
        }
    }
}
