using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDDemo.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CRUDDemo.DataAccessLayer
{
    public class DataAccessLayer
    {
        public bool InsertData(Student objStudent)
        {
            bool result = false;
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
                {
                    using (var cmd = new SqlCommand("dbo.insertProcedure", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentName", objStudent.StudentName);
                        cmd.Parameters.AddWithValue("@Class", objStudent.StudentClass);
                        cmd.Parameters.AddWithValue("@Age", objStudent.StudentAge);
                        cmd.Parameters.AddWithValue("@Gender", objStudent.StudentGender);
                        cmd.Parameters.AddWithValue("@Phone", objStudent.PhoneNumber);
                        cmd.Parameters.AddWithValue("@HomeCity", objStudent.HomeCity);
                        cmd.Parameters.AddWithValue("@EmailId", objStudent.EmailId);

                        connection.Open();
                        result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool UpdateData(Student objStudent)
        {

            bool result = false;
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
                {
                    using (var cmd = new SqlCommand("dbo.updateStudent", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@StudentId", objStudent.StudentId);
                        cmd.Parameters.AddWithValue("@StudentName", objStudent.StudentName);
                        cmd.Parameters.AddWithValue("@Class", objStudent.StudentClass);
                        cmd.Parameters.AddWithValue("@Age", objStudent.StudentAge);
                        cmd.Parameters.AddWithValue("@Gender", objStudent.StudentGender);
                        cmd.Parameters.AddWithValue("@Phone", objStudent.PhoneNumber);
                        cmd.Parameters.AddWithValue("@HomeCity", objStudent.HomeCity);
                        cmd.Parameters.AddWithValue("@EmailId", objStudent.EmailId);

                        connection.Open();

                        result = Convert.ToBoolean(cmd.ExecuteNonQuery());

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public Student DeleteData(Student objStudent)
        {
            bool result = false;
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
                {
                    using (var cmd = new SqlCommand("dbo.DeleteStudent", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@StudentId", objStudent.StudentId);
                        
                        connection.Open();

                        result = Convert.ToBoolean(cmd.ExecuteNonQuery());

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objStudent;
            
        }

        public List<Student> SelectAllData()
        {
            DataSet ds = null;
            List<Student> listStudents = null;

            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
                {
                    using (var cmd = new SqlCommand("dbo.selectStudent", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        ds = new DataSet();
                        da.Fill(ds);
                        listStudents = new List<Student>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Student objStudent = new Student();
                            objStudent.StudentId = Convert.ToInt32(ds.Tables[0].Rows[i]["StudentId"]);
                            objStudent.StudentName = ds.Tables[0].Rows[i]["StudentName"].ToString();
                            objStudent.StudentClass = Convert.ToInt32(ds.Tables[0].Rows[i]["Class"]);
                            objStudent.StudentAge = Convert.ToInt32(ds.Tables[0].Rows[i]["Age"]);
                            objStudent.StudentGender = ds.Tables[0].Rows[i]["Gender"].ToString();
                            objStudent.PhoneNumber = Convert.ToInt64(ds.Tables[0].Rows[i]["PhoneNumber"].ToString());
                            objStudent.HomeCity = ds.Tables[0].Rows[i]["HomeCity"].ToString();
                            objStudent.EmailId = ds.Tables[0].Rows[i]["EmailId"].ToString();
                            listStudents.Add(objStudent);
                        }                        
                    }
                }                           
            }
            catch(Exception ex)
            {
                
            }
            return listStudents;
        }

        public Student SelectById(int StudentId)
        {
            Student objStudent = new Student();

            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
                {
                    using (var cmd = new SqlCommand("dbo.Selectbyid", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        cmd.Parameters.AddWithValue("@StudentId",StudentId);

                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        objStudent.StudentId = StudentId;
                        objStudent.StudentName = ds.Tables[0].Rows[0]["StudentName"].ToString();
                        objStudent.StudentClass = Convert.ToInt32(ds.Tables[0].Rows[0]["Class"]);
                        objStudent.StudentAge = Convert.ToInt32(ds.Tables[0].Rows[0]["Age"]);
                        objStudent.StudentGender = ds.Tables[0].Rows[0]["Gender"].ToString();
                        objStudent.PhoneNumber = Convert.ToInt64(ds.Tables[0].Rows[0]["PhoneNumber"].ToString());
                        objStudent.HomeCity = ds.Tables[0].Rows[0]["HomeCity"].ToString();
                        objStudent.EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();

                    }
                }
            }
             catch(Exception ex)
            {
                
            }
            return objStudent;
        }
    }
}











