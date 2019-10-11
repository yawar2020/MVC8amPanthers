using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC8amPanthers.Models
{
    public class Student
    {
        public int StudId { get; set; }
        public string StudName { get; set; }
        public int StudFees { get; set; }
        public string Section { get; set; }
    }
    public class StudentDetail {

        SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=asad;Integrated Security=true");
        public List<Student> GetStudents() {
            SqlCommand cmd = new SqlCommand("spr_getstudentname",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Student> listStudent = new List<Student>();
            foreach (DataRow dr in dt.Rows)
            {
                Student sobj = new Student();
                sobj.StudId =Convert.ToInt32(dr[0]);
                sobj.StudName =Convert.ToString(dr[1]);
                sobj.StudFees = Convert.ToInt32(dr[2]); ;
                sobj.Section = Convert.ToString(dr[3]);

                listStudent.Add(sobj);
            }

            return listStudent;

        }
        public int SaveStudents(Student obj) {
            SqlCommand cmd = new SqlCommand("spr_saveStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@StudentName", obj.StudName);
            cmd.Parameters.AddWithValue("@Fees",obj.StudFees);
            cmd.Parameters.AddWithValue("@Section",obj.Section);
            int i=Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return i;
        }

        public Student GetStudentsById(int? id) {
            SqlCommand cmd = new SqlCommand("spr_getstudentbyId",con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@studentid", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Student sobj = new Student();
            foreach (DataRow dr in dt.Rows)
            {
                sobj.StudId = Convert.ToInt32(dr[0]);
                sobj.StudName = Convert.ToString(dr[1]);
                sobj.StudFees = Convert.ToInt32(dr[2]); ;
                sobj.Section = Convert.ToString(dr[3]);

                
            }

            return sobj;
        }   

        public int UpdateStudents(Student obj)
        {
            SqlCommand cmd = new SqlCommand("spr_updateStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@StudId", obj.StudId);
            cmd.Parameters.AddWithValue("@studName", obj.StudName);
            cmd.Parameters.AddWithValue("@studFees", obj.StudFees);
            cmd.Parameters.AddWithValue("@studSection", obj.Section);
            int i =cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int DeleteStudents(int?id)
        {
            SqlCommand cmd = new SqlCommand("spr_DeleteStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@StudId", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}