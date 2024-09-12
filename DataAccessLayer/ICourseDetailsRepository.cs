using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
  public  interface ICourseDetailsRepository
    {
        public void InsertUser(CourseDetails loc);
        public CourseDetails GetUserByName(string name);
        public List<CourseDetails> GetAllUsers();
        public void UpdateUser(CourseDetails loc);
        public void DeleteUser(long id);
    }
}
