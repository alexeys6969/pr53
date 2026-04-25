using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ReportGeneration_Shashin.Classes.Common;
using ReportGeneration_Shashin.Models;

namespace ReportGeneration_Shashin.Classes
{
    public class GroupContext : Group
    {
        public GroupContext(int id, string name) : base(id, name)
        {
        }
        public static List<GroupContext> AllGroups()
        {
            List<GroupContext> allGroups = new List<GroupContext>();
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader BDGroups = Connection.Query("SELECT * FROM group ORDER BY Name;", connection);
            while (BDGroups.Read())
            {
                allGroups.Add(new GroupContext(
                    BDGroups.GetInt32(0),
                    BDGroups.GetString(1)));
            }
            Connection.CloseConnection(connection);
            return allGroups;
        }
    }
}
