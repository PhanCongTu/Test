using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sinh_Vien.User
{
    internal class User
    {
        MY_DB mydb = new MY_DB();
        bool check_command(SqlCommand command)
        {
            mydb.openConnection();
            bool result = (command.ExecuteNonQuery() == 1);
            mydb.closeConnection();
            return result;
        }
        public bool insertUser(int Id, string fname, string lname, string uanme, string pwd , MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO hr (id, f_name, l_name, uname, pwd , fig)" +
                "VALUES (@id, @f_name, @l_name, @uname, @pwd , @fig)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@f_name", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@l_name", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@uname", SqlDbType.NVarChar).Value = uanme;
            command.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = pwd;
            command.Parameters.Add("@fig", SqlDbType.Image).Value = picture.ToArray();
            return check_command(command);
        }
        public bool updateUser(int Id, string fname, string lname, string uanme, string pwd, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE hr SET f_name=@f_name,l_name=@l_name, uname=@uname,pwd = @pwd  ,fig=@fig WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@f_name", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@l_name", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@uname", SqlDbType.NVarChar).Value = uanme;
            command.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = pwd;
            command.Parameters.Add("@fig", SqlDbType.Image).Value = picture.ToArray();

            return check_command(command);
        }
        public DataTable getUserById(int Id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM hr WHERE id=@id", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = Id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool usernameExist(int ID, string userName)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM hr WHERE id = @id OR uname = @uname", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            command.Parameters.Add("@uname", SqlDbType.NVarChar).Value = userName;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
