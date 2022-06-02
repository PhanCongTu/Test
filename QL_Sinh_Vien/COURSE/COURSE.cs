using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sinh_Vien.COURSE
{
    internal class Course
    {
        MY_DB mydb = new MY_DB();

        public bool insertCourse(int Id, string courseName, int hoursNumber , string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Course (id, label, period, description)" +
                "VALUES (@id, @name, @hrs, @desc)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = courseName;
            command.Parameters.Add("@hrs", SqlDbType.Int).Value = hoursNumber;
            command.Parameters.Add("@desc", SqlDbType.NVarChar).Value = description;

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

        public bool updateCourse(int CourseID, string courseName, int hoursNumber, string description)
        {
            SqlCommand command = new SqlCommand("UPDATE course SET label=@name, period=@hrs, description=@desc " +
                "WHERE id=@cid", mydb.getConnection);
            command.Parameters.Add("@cid", SqlDbType.NVarChar).Value = CourseID;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = courseName;
            command.Parameters.Add("@hrs", SqlDbType.Int).Value = hoursNumber;
            command.Parameters.Add("@desc", SqlDbType.NVarChar).Value = description;


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
        public bool deleteCourse(int CourseID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Course WHERE id=@cid", mydb.getConnection);

            command.Parameters.Add("@cid", SqlDbType.NVarChar).Value = CourseID;
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

        public DataTable getAllCourse()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getCourseById(int id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE id=@cid", mydb.getConnection);

            command.Parameters.Add("@cid", SqlDbType.NVarChar).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool checkCourseName(String courseName, int id = 0)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE label=@cName AND id <> @cID", mydb.getConnection);
            command.Parameters.Add("@cName", SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@cID", SqlDbType.Int).Value = id;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                // Nếu phát hiện có 1 dòng tồn tại trùng tên
                return false;
            }
            else
            {
                return true;
            }

        }
        string execCount(string query)
        {
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            mydb.openConnection();
            String count = command.ExecuteScalar().ToString();
            mydb.closeConnection();
            return count;
        }
        public string totalCourses()
        {
            return execCount("Select  COUNT(*) FROM Course");
        }
        public DataTable getCourse(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool CheckCourseID(int ID)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            query = "SELECT * From Course WHERE Id=@id";
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
    }
}
