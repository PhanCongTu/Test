using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sinh_Vien.Group
{
    public class Group
    {
        MY_DB mydb = new MY_DB();
        bool check_command(SqlCommand command)
        {
            mydb.openConnection();
            bool result = (command.ExecuteNonQuery() == 1);
            mydb.closeConnection();
            return result;
        }
        public bool insertGroup(int Id, string gname, int userid)
        {
            SqlCommand command = new SqlCommand("INSERT INTO mygroups (id, name, userid)" +
                "VALUES (@id, @name, @userid)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = gname;
            command.Parameters.Add("@userid", SqlDbType.Int).Value = userid;
            return check_command(command);
        }
        public bool updateGroup(int Id, string gname)
        {
            SqlCommand command = new SqlCommand("UPDATE mygroups SET name = @name WHERE id =@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = gname;

            return check_command(command);
        }
        public bool deleteGroup(int Id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM mygroups WHERE id =@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            return check_command(command);
        }
        public DataTable getGroups(int userId)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM mygroups WHERE userid =@userid", mydb.getConnection);
            command.Parameters.Add("@userid", SqlDbType.Int).Value = userId;
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getGroupsByID(int groupId)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM mygroups WHERE Id =@groupid", mydb.getConnection);
            command.Parameters.Add("@groupid", SqlDbType.Int).Value = groupId;
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool groupExist(string name, string operation,int userid = 0, int groupid = 0)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            if(operation == "add")
            {
                query = "SELECT * FROM mygroups WHERE name = @name AND userid = @userid";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@userid", SqlDbType.Int).Value = userid;
            }
            else if (operation == "edit")
            {
                query = "SELECT * FROM mygroups WHERE name = @name AND userid = @userid AND id <> @gid";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@userid", SqlDbType.Int).Value = userid;
                command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            }
            command.Connection = mydb.getConnection;
            command.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckGroupID(int ID)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            query = "SELECT * From mygroups WHERE Id=@id";
            command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            command.Connection = mydb.getConnection;
            command.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable getAllGroup()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM mygroups", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable selectGroupList(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
