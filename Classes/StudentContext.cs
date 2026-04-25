using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGeneration_Shashin.Classes.Common;
using ReportGeneration_Shashin.Models;

namespace ReportGeneration_Shashin.Classes
{
    public class StudentContext : Student
    {
        public StudentContext(int id, string firstname, string lastname, int idGroup, bool expelled, DateTime dateExpelled) : base(id, firstname, lastname, idGroup, expelled, dateExpelled)
        {
        }
        public static List<StudentContext> AllStudents()
        {
            List<StudentContext> allStudents = new List<StudentContext>();
            MySql.Data.MySqlClient.MySqlConnection connection = Connection.OpenConnection();
            MySql.Data.MySqlClient.MySqlDataReader BDStudents = Connection.Query("SELECT * FROM student ORDER BY Lastname;", connection);
            while (BDStudents.Read())
            {
                allStudents.Add(new StudentContext(
                    BDStudents.GetInt32(0),
                    BDStudents.GetString(1),
                    BDStudents.GetString(2),
                    BDStudents.GetInt32(3),
                    BDStudents.GetBoolean(4),
                    BDStudents.GetDateTime(5)));
            }
            Connection.CloseConnection(connection);
            return allStudents;
        }
    }
}
