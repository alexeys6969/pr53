using MySql.Data.MySqlClient;
using ReportGeneration_Shashin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGeneration_Shashin.Classes.Common;

namespace ReportGeneration_Shashin.Classes
{
    public class DisciplineContext : Discipline
    {
        public DisciplineContext(int id, string name, int idGroup) : base(id, name, idGroup)
        {
        }
        public static List<DisciplineContext> AllDisciplines()
        {
            List<DisciplineContext> allDisciplines = new List<DisciplineContext>();
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader BDDisciplines = Connection.Query("SELECT * FROM discipline ORDER BY Name;", connection);
            while (BDDisciplines.Read())
            {
                allDisciplines.Add(new DisciplineContext(
                    BDDisciplines.GetInt32(0), 
                    BDDisciplines.GetString(1), 
                    BDDisciplines.GetInt32(2)));
            }
            Connection.CloseConnection(connection);
            return allDisciplines;
        }
    }
}
