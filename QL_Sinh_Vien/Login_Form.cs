using QL_Sinh_Vien.CONTACT;
using QL_Sinh_Vien.Mail;
using QL_Sinh_Vien.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sinh_Vien
{
     public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
            progressBar1.Hide();
        }

        private void bt_Login_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            try
            {
                if (radioButton_Student.Checked == true)
                {
                    SqlCommand command = new SqlCommand("SELECT *FROM Login WHERE username = @User AND password = @Password", db.getConnection);

                    command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxUsername.Text;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = TextBoxPassword.Text;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    if ((table.Rows.Count > 0))
                    {
                        //int GlobalID = Convert.ToInt32(table.Rows[0][0].ToString());
                        //Globals.SetGlobalsUserId(GlobalID);
                        progressBar1.Show();
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = 100;
                        progressBar1.Step = 20;
                        for (int i = 0; i < 100; i += 5)
                        {
                            Thread.Sleep(30);
                            progressBar1.PerformStep();
                            progressBar1.Update();
                        }
                        //this.DialogResult = DialogResult.OK;
                        MainForm01 mainForm01 = new MainForm01();
                        mainForm01.Show(this);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (radioButton_Human_Resource.Checked == true)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM hr WHERE uname = @User AND pwd = @Password", db.getConnection);

                    command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxUsername.Text;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = TextBoxPassword.Text;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    if ((table.Rows.Count > 0))
                    {
                        int GlobalID = Convert.ToInt32(table.Rows[0][0].ToString());
                        Globals.SetGlobalsUserId(GlobalID);
                        progressBar1.Show();
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = 100;
                        progressBar1.Step = 5;
                        for (int i = 0; i < 100; i += 5)
                        {
                            Thread.Sleep(30);
                            progressBar1.PerformStep();
                            progressBar1.Update();
                        }
                        //this.DialogResult = DialogResult.OK;
                        HumanResource humanResource = new HumanResource();
                        humanResource.Show(this);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
        }

        /*private void Login_Form_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../../Resources/login.png");
        }*/

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void linkLabel_Register_Click(object sender, EventArgs e)
        {
            if (radioButton_Student.Checked == true)
            {
                Register register = new Register();
                register.Show(this);
            }
            else if (radioButton_Human_Resource.Checked == true)
            {
                CreateNewAccount createNewAccount = new CreateNewAccount();
                createNewAccount.Show(this);
            }
            
        }
        private void Login_Form_Load(object sender, EventArgs e)
        {
            radioButton_Student.Checked = true;
        }

        private void linkLabel_Reset_Password_Click(object sender, EventArgs e)
        {
            ForgotPassword FP = new ForgotPassword();
            FP.Show(this);
        }
    }
}
