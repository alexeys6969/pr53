using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGeneration_Shashin.Classes.Common;
using ReportGeneration_Shashin.Models;

namespace ReportGeneration_Shashin.Classes
{
    public class WorkContext : Work
    {
        public WorkContext(int id, int idDiscipline, int idType, DateTime date, string name, int semestr) : base(id, idDiscipline, idType, date, name, semestr)
        {
        }
        public static List<WorkContext> AllWorks()
        {
            List<WorkContext> allWorks = new List<WorkContext>();
            MySql.Data.MySqlClient.MySqlConnection connection = Connection.OpenConnection();
            MySql.Data.MySqlClient.MySqlDataReader BDWorks = Connection.Query("SELECT * FROM work ORDER BY Date;", connection);
            while (BDWorks.Read())
            {
                allWorks.Add(new WorkContext(
                    BDWorks.GetInt32(0),
                    BDWorks.GetInt32(1),
                    BDWorks.GetInt32(2),
                    BDWorks.GetDateTime(3),
                    BDWorks.GetString(4),
                    BDWorks.GetInt32(5)));
            }
            Connection.CloseConnection(connection);
            return allWorks;
        }
    }
}
