using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemLibary.Models
{
    public class StudentModel
    {
        /// <summary>
        /// Firstname of Student
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Lastname of student
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Unique person ID
        /// </summary>
        public string PersonId { get; set; }
        /// <summary>
        /// Person date of birth
        /// </summary>
        public DateTime DateOfBirthDate { get; set; }
        /// <summary>
        /// Students current year grade
        /// </summary>
        public string YearGrade { get; set; }
        /// <summary>
        /// Students calculated total score from grades
        /// </summary>
        public float GradeTotal { get; set; }
        /// <summary>
        /// Students desingated teacher
        /// </summary>
        public string Teacher { get; set; }
        /// <summary>
        /// When student enrolled at school
        /// </summary>
        public DateTime Enrolled { get; set; }
        /// <summary>
        /// What subjects the student study
        /// </summary>
        public List<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
    
    }
}
