using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemLibary.Models
{
    public class TeacherModel
    {
        /// <summary>
        /// Teachers firstname
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Teachers lastname
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Unique person identifier
        /// </summary>
        public string PersonId { get; set; }
        /// <summary>
        /// Teachers date of birth
        /// </summary>
        public DateTime DateOfBirthDate { get; set; }
        /// <summary>
        /// Teachers current year grade
        /// </summary>
        public string YearGrade { get; set; }
        /// <summary>
        /// Which students belong to current teacher
        /// </summary>
        public List<StudentModel> students = new List<StudentModel>();
        /// <summary>
        /// What subjects does the teacher teach
        /// </summary>
        public List<SubjectModel> subjects = new List<SubjectModel>();
    }
}
