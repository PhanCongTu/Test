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
    public partial class AddContact : Form
    {
        public AddContact()
        {
            InitializeComponent();
        }
        QL_Sinh_Vien.Group.Group group = new QL_Sinh_Vien.Group.Group();
        private void button_Add_Contact_Click(object sender, EventArgs e)
        {
            try
            {
                Contact contact = new Contact();
                int id = Convert.ToInt32(textBox_ID.Text);
                string fname = textBox_First_Name.Text;
                string lname = textBox_Last_Name.Text;
                int GroupID = Convert.ToInt32(comboBox_Group.SelectedValue);
                string email = textBox_Email.Text;
                string phone = textBox_Phone.Text;
                string adr = textBox_Address.Text;
                int UserID = Globals.GlobalsUserId;
                MemoryStream pic = new MemoryStream();            
                if (verif())
                {
                    pictureBox.Image.Save(pic, pictureBox.Image.RawFormat);
                    if ((contact.insertContact(id, fname, lname, GroupID, phone, email, adr, UserID, pic)))
                    {
                        MessageBox.Show("Contact mới đã được thêm!!", "Thêm Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm!!!", "Thêm Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Không được bỏ trống", "Thêm Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            Close();
        }

        private void AddContact_Load(object sender, EventArgs e)
        {
            int userid = Globals.GlobalsUserId;
            comboBox_Group.DataSource = group.getGroups(userid);
            comboBox_Group.DisplayMember = "name";
            comboBox_Group.ValueMember = "id";
            comboBox_Group.SelectedItem = null;
            textBox_UserID.Text = userid.ToString();
        }

        private void AddContact_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox_ID.Text != "")
            {
                MY_DB dbs = new MY_DB();
                //
                SqlCommand cmd = new SqlCommand("SELECT Id From Contact WHERE Id=@id", dbs.getConnection);
                //SqlConnection db1 = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = myDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = textBox_ID.Text;
                //db1.Open();
                dbs.openConnection();
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    MessageBox.Show("ID đã tồn tại!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //db1.Close();
                    foreach (Control i in this.Controls)
                    {
                        if (i is TextBox)
                        {
                            i.Text = "";
                        }
                    }
                    return;
                }
                dbs.closeConnection();
                //db1.Close();
            }
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
    }
}
