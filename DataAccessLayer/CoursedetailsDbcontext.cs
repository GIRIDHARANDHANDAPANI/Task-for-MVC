using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class CourseDetailsDbcontext:DbContext
    {
        public CourseDetailsDbcontext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CourseDetails> coursedetails { get; set; }
    }
}
