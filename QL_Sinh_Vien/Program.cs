using QL_Sinh_Vien.CONTACT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sinh_Vien
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            AddStudentForm add = new AddStudentForm();
            Login_Form flogin = new Login_Form();
            //Application.Run(new MainForm01());
            //Application.Run(new HumanResource());
            if (flogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Login_Form());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
