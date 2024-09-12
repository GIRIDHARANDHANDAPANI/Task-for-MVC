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
    public class CourseDetailsRepository : ICourseDetailsRepository
    {
        CourseDetailsDbcontext Dbcontext = null;
        public CourseDetailsRepository(CourseDetailsDbcontext context)
        {
            Dbcontext = context;
        }
        public void InsertUser(CourseDetails loc)
        {
            try
            {
                Dbcontext.Add(loc);
                Dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public CourseDetails GetUserByName(string name)
        {
            try
            {
                return Dbcontext.coursedetails.FirstOrDefault(X => X.Name == name);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<CourseDetails> GetAllUsers()
        {
            try
            {
                return Dbcontext.coursedetails.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void UpdateUser(CourseDetails loc)
        {
            try
            {
                Dbcontext.Update(loc);
                Dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteUser(long id)
        {
            try
            {
                var count = Dbcontext.coursedetails.Find(id);
                Dbcontext.Remove(count);
                Dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
