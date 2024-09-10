using DataAccessLayer.Entity;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
  public  class CourseDetailsRepository:ICourseDetailsRepository
    {
        string connectionString = string.Empty; //"server=DESKTOP-UCPA9BN;database=Course;user Id =sa;password=Anaiyaan@123;";
        SqlConnection con = null;
        public CourseDetailsRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConnection");
            con = new SqlConnection(connectionString);
        }

        public List<CourseDetails> SelectALLStudent()
        {
            try
            {
                var selectQuery = $"exec SelectAllStudents";
                con.Open();
                List<CourseDetails> result = con.Query<CourseDetails>(selectQuery).ToList();
                con.Close();

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CourseDetails SelectUserByName(string username)
        {
            try
            {
                var selectQuery = $"exec SelectByName '{username}'";
                con.Open();
                CourseDetails result = con.QueryFirstOrDefault<CourseDetails>(selectQuery);
                con.Close();

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void RegisterUser(CourseDetails reg)
        {
            try
            {
                var insertQuery = $"exec InsertUser '{reg.Name}','{reg.InstitutionName}',{reg.EnquiryNumber},'{reg.Startdate.ToString("yyyy-MM-dd")}','{reg.Enddate.ToString("yyyy-MM-dd")}',{reg.Fees}";
                con.Open();
                con.Execute(insertQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateUser(CourseDetails reg)
        {
            try
            {
                var updateQuery = $"exec UpdateUser {reg.CourseDetailsID},'{reg.Name}','{reg.InstitutionName}',{reg.EnquiryNumber},'{reg.Startdate}','{reg.Enddate}',{reg.Fees}";
                //var connectionString = "server=DESKTOP-8VD1A1F\\SQLEXPRESS;database=batch9;user Id =sa;password=Anaiyaan@123;";

                con.Open();
                con.Execute(updateQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void DeleteUser(long regId)
        {
            try
            {
                var updateQuery = $"exec DeleteUser {regId}";
                con.Open();
                con.Execute(updateQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
