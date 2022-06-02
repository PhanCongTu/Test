using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sinh_Vien.Score
{
    internal class SCORE
    {
        MY_DB mydb = new MY_DB();
        public bool insertScore(int studentID, int courseID, float scoreValue, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Score (student_id,course_id,student_score,description)" +
                "VALUES (@id,@cid,@scr,@descr)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = studentID;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@scr", SqlDbType.Float).Value = scoreValue;
            command.Parameters.Add("@descr", SqlDbType.VarChar).Value = description;

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
        public bool studentScoreExist(int StudentID, int CourseID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Score WHERE student_id = @id AND course_id = @cid", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = StudentID;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = CourseID;

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
        
        public bool DeleteScore(int studentID, int courseID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Score WHERE student_id = @sid AND course_id = @cid", mydb.getConnection);
            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;


            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable getStudentScore()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = ("SELECT SCORE.student_id as 'Mã Sinh Viên', std.fname as 'Họ', std.lname as 'Tên', SCORE.course_id as 'Mã Môn Học', COURSE.label as 'Tên Môn Học', " +
                "SCORE.student_score as 'Điểm', score.description FROM std INNER JOIN score on std.id = score.student_id " +
                "INNER JOIN course on score.course_id = course.id");
            SqlDataAdapter adapter  = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getAvgScoreByCourse()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT Course.label as 'Tên Môn Học', AVG(Score.student_score) As 'Điểm Trung Bình' FROM Course, score " +
                "WHERE Course.id = score.course_id GROUP BY Course.label";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getCourseScores(int courseID)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = ("SELECT SCORE.student_id, std.fname, SCORE.course, COURSE.label, SCORE." +
                "student_score FROM std INNER JOIN score on std.id = score.student_id INNER JOIN course ON score.course_id = course.id" +
                "Where score.course_id = " + courseID);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getStudentScore(int studentID)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = ("SELECT SCORE.student_id, std.fname, std.lname, SCORE.course_id, COURSE.label, " +
                "SCORE.student_score FROM std INNER JOIN score on std.id = score.student_id " +
                "INNER JOIN course on score.course_id = course.id WHERE score.student_id = " + studentID    );
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getScore(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
