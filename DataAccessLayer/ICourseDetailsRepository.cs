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
        public List<CourseDetails> SelectALLStudent();
        public CourseDetails SelectUserByName(string username);
        public void RegisterUser(CourseDetails reg);
        public void UpdateUser(CourseDetails reg);
        public void DeleteUser(long regId);
    }
}
