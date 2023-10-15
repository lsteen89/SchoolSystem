using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystemLibary.Models;

namespace SchoolSystemLibary
{
    internal class YearGradeModel
    {
        /// <summary>
        /// What the grade(klass) is called.
        /// </summary>
        public string GradeName { get; set; }
        /// <summary>
        /// A description of the grade
        /// </summary>
        public string GradeDesc { get; set; }
        /// <summary>
        /// How many students are currently in the grade
        /// </summary>
        public int StudentsEnrolled { get; set; }
        /// <summary>
        /// What teachers teach the grade
        /// </summary>
        public List<TeacherModel> Teachers { get; set; } = new List<TeacherModel>();
        /// <summary>
        /// List of active students the grade
        /// </summary>
        public List<StudentModel> Students { get; set; } = new List<StudentModel>();
        /// <summary>
        /// What subjects are taught in the grade
        /// </summary>
        public List<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
        /// <summary>
        /// How many teachers
        /// </summary>
        public int TeachersCount { get; set; }
        /// <summary>
        /// Start date grade
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End date grade
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
