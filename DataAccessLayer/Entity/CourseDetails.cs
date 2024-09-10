using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
   public class CourseDetails
    {
        public long CourseDetailsID { get; set; }
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        public string InstitutionName { get; set; }
        [Required]
        public long EnquiryNumber { get; set; }
        public int DurationInMonths 
        {
            get
            {
                return ((Enddate.Year - Startdate.Year) * 12) + Enddate.Month - Startdate.Month;

            }
        }
        [Required]
        public DateTime Startdate { get; set; }
        [Required]
        public DateTime Enddate { get; set; }
        [Required]
        public int Fees { get; set; }
    }
}
