using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace QL_Sinh_Vien.Mail
{
    public partial class ForgotPassword : Form
    {
        string randomCode;
        public static string ID_Email;
        public ForgotPassword()
        {
            InitializeComponent();
        }
        MY_DB db = new MY_DB();
        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            radioButton_Student.Checked = true;
            label_Check_Email.Hide();
            panel2.Hide();
            label_Verify_Code.Hide();
            panel3.Hide();
            label_Re_Password.Hide();
        }
        private void button_Send_Click(object sender, EventArgs e)
        {
            try
            {
                string mail = textBox_Email.Text.Trim().ToString();
                SqlCommand cmd = new SqlCommand();
                if (radioButton_Student.Checked == true)
                {
                    cmd = new SqlCommand("SELECT *  FROM login where email = @mail", db.getConnection);
                }
                else if (radioButton_Human_Resource.Checked == true)
                {
                    cmd = new SqlCommand("SELECT *  FROM hr where email = @mail", db.getConnection);
                }

                if (textBox_Email.Text.Trim() == "")
                {
                    MessageBox.Show("Hãy nhập email!");
                    return;
                }
                cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = mail;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                if (dt.Rows.Count < 1)
                {                    
                    label_Check_Email.Show();
                    label_Check_Email.Text = "Email không chính xác";
                    label_Check_Email.ForeColor = Color.Red;
                    return;
                }
                else
                {

                    if (radioButton_Student.Checked == true)
                    {
                        label_Account.Text = "Your account is:" + dt.Rows[0][1].ToString();
                    }
                    else if (radioButton_Human_Resource.Checked == true)
                    {
                        label_Account.Text = "Your account is: " + dt.Rows[0][3].ToString();
                    }
                    ID_Email = dt.Rows[0][0].ToString();
                    label_Check_Email.Show();
                    label_Check_Email.Text = "Code đã được gửi";
                    label_Check_Email.ForeColor = Color.Lime;
                    panel2.Show();
                    Random rnd = new Random();
                    randomCode = rnd.Next(100000, 999999).ToString();
                    string content = "Mã của bạn là: " + randomCode;
                    Mail.Send(mail, "Đặt lại mật khẩu!!", content);
                    //MessageBox.Show(Mail.Send(mail, "Đặt lại mật khẩu!!", content));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          }

        private void button_Verify_Code_Click(object sender, EventArgs e)
        {
            try
            {
                if (randomCode == textBox_Code.Text.ToString())
                {
                    panel3.Show();
                    label_Verify_Code.Text = "Chính xác";
                    label_Verify_Code.ForeColor = Color.Lime;
                    label_Verify_Code.Show();
                }
                else
                {
                    label_Verify_Code.Text = "Sai";
                    label_Verify_Code.ForeColor = Color.Red;
                    label_Verify_Code.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
                
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_New_Pass.Text.Trim() == textBox_Re_Pass.Text.Trim())
                {
                    SqlCommand cmd = new SqlCommand();
                    if (radioButton_Student.Checked == true)
                    {
                        cmd = new SqlCommand("UPDATE login SET password = '" + textBox_New_Pass.Text + "' where ID = @ID", db.getConnection);
                    }
                    else if (radioButton_Human_Resource.Checked == true)
                    {
                        cmd = new SqlCommand("UPDATE hr SET pwd = '" + textBox_New_Pass.Text + "' where ID = @ID", db.getConnection);
                    }

                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID_Email;
                    db.openConnection();
                    cmd.ExecuteNonQuery();
                    db.closeConnection();
                    MessageBox.Show("Đặt lại mật khẩu thành công!!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không khớp!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void textBox_Email_TextChanged(object sender, EventArgs e)
        {
            label_Check_Email.Hide();
        }

        private void textBox_Code_TextChanged(object sender, EventArgs e)
        {
            label_Verify_Code.Hide();
        }

        private void textBox_Re_Pass_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox_New_Pass.Text.Trim() != textBox_Re_Pass.Text.Trim())
            {
                label_Re_Password.Text = "Không khớp";
                label_Re_Password.ForeColor = Color.Red;
                label_Re_Password.Show();
            }
            else
            {
                label_Re_Password.Text = "Trùng khớp";
                label_Re_Password.ForeColor = Color.Lime;
                label_Re_Password.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(textBox_New_Pass.UseSystemPasswordChar == false)
            {
                textBox_New_Pass.UseSystemPasswordChar = true;
            }
            else
            {
                textBox_New_Pass.UseSystemPasswordChar = false;
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox_Re_Pass.UseSystemPasswordChar == false)
            {
                textBox_Re_Pass.UseSystemPasswordChar = true;
            }
            else
            {
                textBox_Re_Pass.UseSystemPasswordChar = false;
            }
        }

        private void button_Cancel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
