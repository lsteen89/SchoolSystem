using Dapper;
using SchoolSystemLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemLibary.DataAccess
{
    public class SqlExecutor
    {
        public List<string> GetStudentInfo(string persoid)
        {
            using (var connection = GlobalConfig.GetConnection())
            {
                var student = connection.QuerySingleOrDefault<StudentModel>("SELECT * FROM Students WHERE Persoid = @Persoid", new { persoid = persoid });

            }
        }
    }
}
