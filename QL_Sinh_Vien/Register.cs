using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sinh_Vien
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_rg_LoginName.Text == "" || tb_rg_Password.Text == "" || tb_rg_RePassword.Text == "" || textBox_Email.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống!!", "Đăng ký thất bại!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (tb_rg_LoginName.Text != "")
                {
                    MY_DB dbs = new MY_DB();
                    //
                    SqlCommand cmd = new SqlCommand("SELECT username From login WHERE username=@name", dbs.getConnection);
                    SqlConnection db1 = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = myDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = tb_rg_LoginName.Text;
                    db1.Open();
                    dbs.openConnection();
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        MessageBox.Show("Username đã tồn tại!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        db1.Close();
                        tb_rg_LoginName.Text = "";
                        return;
                    }
                }
                if (textBox_Email.Text != "")
                {
                    MY_DB dbs = new MY_DB();
                    //
                    SqlCommand cmd = new SqlCommand("SELECT * From login WHERE email = '@email'", dbs.getConnection);
                    SqlConnection db1 = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = myDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = textBox_Email.Text.Trim();
                    db1.Open();
                    dbs.openConnection();
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        MessageBox.Show("Email đã tồn tại!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        db1.Close();
                        textBox_Email.Text = "";
                        return;
                    }
                } 
                if (tb_rg_Password.Text == tb_rg_RePassword.Text)
                {

                    MY_DB dbs = new MY_DB();
                    SqlCommand commands = new SqlCommand("SELECT MAX(login.Id) as res FROM login", dbs.getConnection);
                    int num_ = 0;
                    try
                    {
                        dbs.openConnection();
                        using (SqlDataReader read = commands.ExecuteReader())
                        {
                            while (read.Read())
                            {
                                num_ = Int32.Parse(read["res"].ToString());
                            }
                        }
                    }
                    finally
                    {
                        dbs.closeConnection();
                    }

                    num_ += 1;
                    SqlConnection db = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = myDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    string register = @"INSERT INTO [myDB].[dbo].[login]"
                        + "([Id],[username],[password],[email]) VALUES ('" + num_ + "','" + tb_rg_LoginName.Text + "','" + tb_rg_Password.Text + "','" + textBox_Email.Text + "')";
                    SqlCommand command = new SqlCommand(register, db);
                    db.Open();
                    command.ExecuteNonQuery();
                    db.Close();

                    MessageBox.Show("Tạo tài khoản thành công!!", "Tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không trùng khớp!!", "Đăng ký thất bại!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_rg_Password.Text = "";
                    tb_rg_RePassword.Text = "";
                    tb_rg_Password.Focus();
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}

        private void bt_rg_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_rg_LoginName_MouseMove(object sender, MouseEventArgs e)
        {
            if (tb_rg_LoginName.Text != "")
            {
                MY_DB dbs = new MY_DB();
                //
                SqlCommand cmd = new SqlCommand("SELECT username From login WHERE username=@name", dbs.getConnection);
                //SqlConnection db1 = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = myDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = tb_rg_LoginName.Text;
                //db1.Open();
                dbs.openConnection();
                SqlDataReader rd = cmd.ExecuteReader();
                dbs.closeConnection();
                if (rd.HasRows)
                {
                    MessageBox.Show("Username đã tồn tại!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    tb_rg_LoginName.Text = "";
                    return;
                }
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(tb_rg_Password.UseSystemPasswordChar == true)
            {
                tb_rg_Password.UseSystemPasswordChar = false;
            }
            else if(tb_rg_Password.UseSystemPasswordChar == false)
            {
                tb_rg_Password.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (tb_rg_RePassword.UseSystemPasswordChar == true)
            {
                tb_rg_RePassword.UseSystemPasswordChar = false;
            }
            else if (tb_rg_RePassword.UseSystemPasswordChar == false)
            {
                tb_rg_RePassword.UseSystemPasswordChar = true;
            }
        }

        private void textBox_Email_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox_Email.Text != "")
            {
                MY_DB dbs = new MY_DB();
                //
                SqlCommand cmd = new SqlCommand("SELECT * From login WHERE email = @email", dbs.getConnection);
                SqlConnection db1 = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = myDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = textBox_Email.Text.Trim();
                db1.Open();
                dbs.openConnection();
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    MessageBox.Show("Email đã tồn tại!!, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    db1.Close();
                    textBox_Email.Text = "";
                    return;
                }
            }
        }
    }
}
