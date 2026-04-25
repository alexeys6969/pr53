using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGeneration_Shashin.Classes.Common;
using ReportGeneration_Shashin.Models;

namespace ReportGeneration_Shashin.Classes
{
    public class EvaluationContext : Evaluation
    {
        public EvaluationContext(int id, int idWork, int idStudent, string value, string lateness) : base(id, idWork, idStudent, value, lateness)
        {
        }
        public static List<EvaluationContext> AllEvaluations()
        {
            List<EvaluationContext> allEvaluations = new List<EvaluationContext>();
            MySql.Data.MySqlClient.MySqlConnection connection = Connection.OpenConnection();
            MySql.Data.MySqlClient.MySqlDataReader BDEval = Connection.Query("SELECT * FROM evaluations;", connection);
            while (BDEval.Read())
            {
                allEvaluations.Add(new EvaluationContext(
                    BDEval.GetInt32(0),
                    BDEval.GetInt32(1),
                    BDEval.GetInt32(2),
                    BDEval.GetString(3),
                    BDEval.GetString(4)));
            }
            Connection.CloseConnection(connection);
            return allEvaluations;
        }
    }
}
