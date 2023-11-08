using Dapper;
using SchoolSystemLibary.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using System.Data;
using Serilog;


namespace SchoolSystemLibary.DataAccess
{

    public class SqlExecutor
    {
        private readonly DapperLogger logger;

        public SqlExecutor(string connectionString)
        {
            logger = new DapperLogger(connectionString);
        }

        public List<StudentModel> GetStudentInfo(string persoid, string yeargrade)
        {
            using (var connection = GlobalConfig.GetConnection())
            {
                string sqlQuery = @"
                SELECT Students.*
                FROM Students
                JOIN Yeargrade ON Students.Persoid = Yeargrade.Persoid
                WHERE Yeargrade.TeacherPersoid = @Persoid
                AND Yeargrade.YearGradeName = @Yeargrade 
            ";

                var students = connection.Query<StudentModel>(sqlQuery, new { Persoid = persoid, Yeargrade = yeargrade}).ToList();
                return students;
            }
        }
        //Loggin enabled for this query
        public IEnumerable<string> GetAvailableYearGrades(string persoid)
        {
            string sqlQuery = @"
            SELECT DISTINCT YearGradeName       
            FROM YearGrade 
            WHERE Persoid = @Persoid
            ";

            return logger.ExecuteCustomQuery<string>(sqlQuery, new { Persoid = persoid });
        }
    }
}
