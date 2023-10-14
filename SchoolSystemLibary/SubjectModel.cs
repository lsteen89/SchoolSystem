using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemLibary
{
    public class SubjectModel
    {
        /// <summary>
        /// Subject ID
        /// </summary>
        public int SubjectID { get; set; }
        /// <summary>
        /// What grade is currently studying the subject
        /// </summary>
        public string GradeName { get; set; }
        /// <summary>
        /// Subject name
        /// </summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// List of teachers who teach this subject
        /// </summary>
        public List<TeacherModel> Teachers { get; set; } = new List<TeacherModel>();
        /// <summary>
        /// List of students who studies this subject
        /// </summary>
        public List<StudentModel> Students { get; set; } = new List<StudentModel>();
        /// <summary>
        /// Start date subject
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End date subject
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
