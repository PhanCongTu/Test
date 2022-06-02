using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sinh_Vien.CONTACT
{
    public partial class EditContact : Form
    {
        public EditContact()
        {
            InitializeComponent();
        }
        
        Contact contact = new Contact();
        QL_Sinh_Vien.Group.Group group = new QL_Sinh_Vien.Group.Group();
        int uid = Globals.GlobalsUserId;
        private void button_Edit_Contact_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                string fname = textBox_First_Name.Text;
                string lname = textBox_Last_Name.Text;
                int GroupID = Convert.ToInt32(comboBox_Group.SelectedValue);
                string email = textBox_Email.Text;
                string phone = textBox_Phone.Text;
                string adr = textBox_Address.Text;
                int UserID = Convert.ToInt32(textBox_UserID.Text);
                MemoryStream pic = new MemoryStream();

                if (verif())
                {
                    id = Convert.ToInt32(textBox_ID.Text);
                    pictureBox.Image.Save(pic, pictureBox.Image.RawFormat);
                    if ((contact.updateContact(id, fname, lname, GroupID, phone, email, adr, UserID, pic)))
                    {
                        MessageBox.Show("Contact Updated", "Updated Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Updated Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Empty Fields", "Updated Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private bool verif()
        {
            if ((textBox_First_Name.Text.Trim() == "")
                    || (textBox_Last_Name.Text.Trim() == "")
                    || (textBox_Phone.Text.Trim() == "")
                    || (pictureBox.Image == null)
                    )
            {
                return false;
            }
            else return true;
        }

        private void button_Select_Contact_Click(object sender, EventArgs e)
        {
            SelectContact selectContact = new SelectContact();
            selectContact.Show();
        }
        
        private void EditContact_MouseMove(object sender, MouseEventArgs e)
        {
            
            int cid = Globals.GlobalsContactId;
            if (textBox_ID.Text  != cid.ToString())
                try
                {
                    DataTable table = new DataTable();
                    table = contact.getContactById(cid);
                    textBox_ID.Text = table.Rows[0][0].ToString();
                    textBox_First_Name.Text = table.Rows[0][1].ToString();
                    textBox_Last_Name.Text = table.Rows[0][2].ToString();
                    comboBox_Group.Text = table.Rows[0][3].ToString();
                    textBox_Phone.Text = table.Rows[0][4].ToString();
                    textBox_Email.Text = table.Rows[0][5].ToString();
                    textBox_Address.Text = table.Rows[0][6].ToString();
                    textBox_UserID.Text = table.Rows[0][8].ToString();
                    // image
                    byte[] pic;
                    pic = (byte[])table.Rows[0][7];
                    MemoryStream picture = new MemoryStream(pic);
                    pictureBox.Image = Image.FromStream(picture);
                }
                catch{}   
        }

        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Can not change ID!!!", "Change ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox_ID.Text = Globals.GlobalsContactId.ToString();
        }

        private void comboBox_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //int id = Convert.ToInt32(comboBox_Group.SelectedValue);
                DataTable table = new DataTable();
                table = group.getGroups(uid);
                comboBox_Group.Text = table.Rows[0][1].ToString();
            }
            catch { }
        }

        private void EditContact_Load(object sender, EventArgs e)
        {
            comboBox_Group.DataSource = group.getGroups(uid);
            comboBox_Group.DisplayMember = "label";
            comboBox_Group.ValueMember = "id";
            comboBox_Group.SelectedItem = null;
        }

        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button_Upload_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg; *.png; *.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBox.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
