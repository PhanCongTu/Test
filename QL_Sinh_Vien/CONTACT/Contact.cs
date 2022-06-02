using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sinh_Vien.CONTACT
{
    internal class Contact
    {
        MY_DB mydb = new MY_DB();

        bool check_command(SqlCommand command)
        {
            mydb.openConnection();
            bool result = (command.ExecuteNonQuery() == 1);
            mydb.closeConnection();
            return result;
        }
        public bool insertContact(int Id, string fname, string lname, int GroupID, string phone, string Email, string address,int userID, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Contact (id,fname,lname,group_id,phone,email,address,userid,picture)" +
                "VALUES (@id,@fname,@lname,@group_id,@phone,@email,@Address,@userid,@picture)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@group_id", SqlDbType.Int).Value = GroupID;
            command.Parameters.Add("@phone", SqlDbType.NChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.NChar).Value = Email;
            command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@userid", SqlDbType.NVarChar).Value = userID;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();

            return check_command(command);
        }
        public bool updateContact(int Id, string fname, string lname, int GroupID, string phone, string Email, string address, int userID, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE Contact SET fname=@fname,lname=@lname, group_id=@group_id, phone=@phone, Email=@email, address=@Address, userID=@userid,picture=@picture WHERE Id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@group_id", SqlDbType.Int).Value = GroupID;
            command.Parameters.Add("@phone", SqlDbType.NChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.NChar).Value = Email;
            command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@userid", SqlDbType.NVarChar).Value = userID;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();

            return check_command(command);
        }
        public bool deleteContact(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Contact WHERE id = @id", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            return check_command(command);
        }
        public DataTable selectContactList(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getContactById(int contactId)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Contact WHERE id=@cid", mydb.getConnection);

            command.Parameters.Add("@cid", SqlDbType.NVarChar).Value = contactId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}