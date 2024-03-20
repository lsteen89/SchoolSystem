using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolSystemLibary.Helper
{
    public class StudentPopUpHelper
    {
        private string studentPersoid;
        public void SetStudentPnumID(string input)
        {
            studentPersoid = string.Concat(Regex.Matches(input, @"\d+").OfType<Match>().Select(m => m.Value));
        }
        public string GetStudentPnumID()
            { return studentPersoid; }
    }
}
