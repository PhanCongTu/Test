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

namespace QL_Sinh_Vien.CONTACT
{
    public partial class SelectContact : Form
    {
        public SelectContact()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        private void SelectContact_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM contact");
            fillGrid(command);
        }
        public void fillGrid(SqlCommand command)
        {
            dataGridView_Select_Contact.ReadOnly = true;
            dataGridView_Select_Contact.RowTemplate.Height = 80;
            dataGridView_Select_Contact.DataSource = contact.selectContactList(command);
            dataGridView_Select_Contact.AllowUserToAddRows = false;
            //imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //dataGridView_Select_Contact.ImeMode =
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)dataGridView_Select_Contact.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

        }

        private void dataGridView_Select_Contact_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView_Select_Contact.CurrentRow.Cells[0].Value.ToString());
            Globals.SetGlobalsContactId(id);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
