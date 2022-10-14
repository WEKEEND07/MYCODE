using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sqlmvcconnection.Models
{
    public class StudentLayer
    {
        public IEnumerable<Student> St
        {
            get
            {
                string dbString = ConfigurationManager.ConnectionStrings["Mvcappdb"].ConnectionString;
                List<Student> st = new List<Student>();
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    SqlCommand cmd = new SqlCommand("Selectst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.Id = Convert.ToInt32(reader["ID"]);
                        student.Name = reader["Name"].ToString();
                        student.Email = reader["email"].ToString();
                        st.Add(student);
                    }
                }
                return st;
            }
        }
        public void AddStudent(Student St1)
        {
            string dbString = ConfigurationManager.ConnectionStrings["Mvcappdb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(dbString))
            {
                SqlCommand cmd = new SqlCommand("Insertst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter stName = new SqlParameter();
                stName.ParameterName = "@Name";
                stName.Value = St1.Name;
                cmd.Parameters.Add(stName);
                SqlParameter stEmail = new SqlParameter();
                stEmail.ParameterName = "@Email";
                stEmail.Value = St1.Email;
                cmd.Parameters.Add(stEmail);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void SaveStudent(Student St1)
        {
            string dbString = ConfigurationManager.ConnectionStrings["Mvcappdb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(dbString))
            {
                SqlCommand cmd = new SqlCommand("UpdateSt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter stId = new SqlParameter();
                stId.ParameterName = "@Id";
                stId.Value = St1.Id;
                cmd.Parameters.Add(stId);
                SqlParameter stName = new SqlParameter();
                stName.ParameterName = "@Name";
                stName.Value = St1.Name;
                cmd.Parameters.Add(stName);
                SqlParameter stEmail = new SqlParameter();
                stEmail.ParameterName = "@Email";
                stEmail.Value = St1.Email;
                cmd.Parameters.Add(stEmail);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteStudent(int id)
        {
            string dbString = ConfigurationManager.ConnectionStrings["Mvcappdb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(dbString))
            {
                SqlCommand cmd = new SqlCommand("DeleteSt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter stId = new SqlParameter();
                stId.ParameterName = "@Id";
                stId.Value = id;
                cmd.Parameters.Add(stId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}