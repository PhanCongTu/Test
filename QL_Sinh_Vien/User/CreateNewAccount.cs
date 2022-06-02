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

namespace QL_Sinh_Vien.User
{
    public partial class CreateNewAccount : Form
    {
        public CreateNewAccount()
        {
            InitializeComponent();
        }
        User user = new User();
        MY_DB mydb = new MY_DB();
        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                int userID = Convert.ToInt32(textBox_ID.Text);
                string First_Name = textBox_First_Name.Text;
                string Last_Name = textBox_Last_Name.Text;
                string UserName = textBox_UserName.Text;
                string Password = textBox_Password.Text;
                MemoryStream pic = new MemoryStream();
                pictureBox_Account.Image.Save(pic, pictureBox_Account.Image.RawFormat);
                //check if the score is already set for this student on this score
                if (verif())
                {
                        if (user.insertUser(userID, First_Name, Last_Name, UserName, Password, pic))
                        {
                            MessageBox.Show("Account Human Resource Inserted", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Account Human Resource Not Inserted", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool verif()
        {
            if ((textBox_ID.Text.Trim() == "")
                    || (textBox_First_Name.Text.Trim() == "")
                    || (textBox_Last_Name.Text.Trim() == "")
                    || (textBox_UserName.Text.Trim() == "")
                    || (textBox_Password.Text.Trim() == "")
                    || (pictureBox_Account.Image == null)
                    )
            {
                return false;
            }
            else return true;
        }

        private void textBox_ID_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox_ID.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = myDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True"))
                {

                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT id From hr WHERE id=@id", connection))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = textBox_ID.Text;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                MessageBox.Show("ID user đã tồn tại!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //db1.Close();
                                textBox_ID.Text = "";
                                return;
                            }
                        } // reader closed and disposed up here

                    } // command disposed here

                }
            }
        }

        private void textBox_UserName_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox_UserName.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = myDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True"))
                {

                    connection.Open();

                    using (SqlCommand cmdd = new SqlCommand("SELECT * From hr WHERE uname = @uname", connection))
                    {
                        cmdd.Parameters.Add("@uname", SqlDbType.VarChar).Value = textBox_UserName.Text;
                        using (SqlDataReader reader1 = cmdd.ExecuteReader())
                        {
                            if (reader1.HasRows)
                            {
                                MessageBox.Show("(HR) Username đã tồn tại!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //db1.Close();
                                textBox_UserName.Text = "";
                                return;
                            }
                        } 

                    } 

                }
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Upload_Pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg; *.png; *.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBox_Account.Image = Image.FromFile(opf.FileName);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            if (textBox_Password.UseSystemPasswordChar == true)
            {
                textBox_Password.UseSystemPasswordChar = false;
            }
            else if (textBox_Password.UseSystemPasswordChar == false)
            {
                textBox_Password.UseSystemPasswordChar = true;
            }
        }

        private void textBox_Email_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox_Email.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = myDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True"))
                {

                    connection.Open();

                    using (SqlCommand cmdd = new SqlCommand("SELECT uname From hr WHERE email = @email", connection))
                    {
                        cmdd.Parameters.Add("@email", SqlDbType.VarChar).Value = textBox_Email.Text;
                        using (SqlDataReader reader1 = cmdd.ExecuteReader())
                        {
                            if (reader1.HasRows)
                            {
                                MessageBox.Show("Email đã tồn tại!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //db1.Close();
                                textBox_Email.Text = "";
                                return;
                            }
                        } // reader closed and disposed up here

                    } // command disposed here

                }
            }
        }

        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
