using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemLibary
{
    public class GradingModel
    {
        /// <summary>
        /// Unique person ID
        /// </summary>
        public string PersonId { get; set; }
        /// <summary>
        /// Grading for what subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Date of data entry
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Name of data entry
        /// </summary>
        public string regsign { get; set; }
        /// <summary>
        /// Grade
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// Comments, if any
        /// </summary>
        public string Comments { get; set; }
    }
}
