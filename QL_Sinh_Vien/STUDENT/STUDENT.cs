using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;

namespace QL_Sinh_Vien
{
    class STUDENT
    {
        MY_DB mydb = new MY_DB();
        
        
        public bool insertStudent(int Id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture,String MSSV)
        {
            SqlCommand command = new SqlCommand("INSERT INTO std (id,fname,lname,bdate,gender,phone,address,picture,mssv)" +
                "VALUES (@id,@fname,@lname,@bdate,@gender,@phone,@address,@picture,@mssv)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@mssv", SqlDbType.Int).Value = MSSV;
            command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@bdate", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool updateStudentByIDnMSSVnPhone(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture, string MSSV)
        {
            SqlCommand command = new SqlCommand("UPDATE std SET fname=@fn,lname=@ln, bdate=@bdt, gender=@gdr, address=@adrs, picture=@pic WHERE id=@ID and mssv=@mssv and phone=@phn", mydb.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@mssv", SqlDbType.Int).Value = MSSV;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateStudentByIDnMSSV(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture, string MSSV)
        {
            SqlCommand command = new SqlCommand("UPDATE std SET fname=@fn,lname=@ln, bdate=@bdt, gender=@gdr, phone=@phn, address=@adrs, picture=@pic WHERE id=@ID and mssv=@mssv", mydb.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@mssv", SqlDbType.Int).Value = MSSV;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateStudentByID (int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture,string MSSV)
        {
            SqlCommand command = new SqlCommand("UPDATE std SET fname=@fn,lname=@ln, bdate=@bdt, gender=@gdr, phone=@phn, address=@adrs, picture=@pic,mssv=@mssv WHERE id=@ID", mydb.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@mssv", SqlDbType.Int).Value = MSSV;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        // delete student by id
        public bool deleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM std WHERE id = @id", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        string execCount(string query)
        {
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            mydb.openConnection();
            var count = command.ExecuteScalar();
            
            mydb.closeConnection();
            return count.ToString();
        }
        public string totalStudent()
        {
            return execCount("SELECT COUNT(*) FROM STD");

        }
        public string totalMaleStudent()
        {
            return execCount("SELECT COUNT(*) FROM STD WHERE gender ='Male' ");

        }
        public string totalFemaleStudent()
        {
            return execCount("SELECT COUNT(*) FROM STD WHERE gender ='Female'");
        }
        public bool CheckStudentIDnMSSVnPhone(int ID, string MSSV, string Phone)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            //query = "SELECT * From std WHERE Id=@id";
            query = "SELECT * FROM std WHERE id = @ID and MSSV LIKE @mssv and phone = @phone ";
            command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            command.Parameters.Add("@mssv", SqlDbType.NVarChar).Value = MSSV;
            command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone;
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
        public bool CheckStudentIDnMSSV(int ID, string MSSV)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            //query = "SELECT * From std WHERE Id=@id";
            query = "SELECT * FROM std WHERE id = @ID and MSSV LIKE @mssv ";
            command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            command.Parameters.Add("@mssv", SqlDbType.NVarChar).Value = MSSV;
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
        public bool CheckStudentID(int ID)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            query = "SELECT * From std WHERE Id=@id";
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
        public bool CheckStudentMSSV(string MSSV)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            //query = "SELECT * From std WHERE Id=@id";
            query = "SELECT * FROM std WHERE MSSV LIKE @mssv ";
            command.Parameters.Add("@mssv", SqlDbType.NVarChar).Value = MSSV;
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
        public bool CheckStudentPhone(string phone)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            query = "SELECT * From std WHERE phone like @phone";
            command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
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
        public DataTable getColumnName()
        {
            SqlCommand command = new SqlCommand("SELECT column_name FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'std'", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }

}
