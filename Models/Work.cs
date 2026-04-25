using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration_Shashin.Models
{
    public class Work
    {
        public int Id { get; set; }
        public int IdDiscipline { get; set; }
        public int IdType { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Semestr { get; set; }
        public Work(int id, int idDiscipline, int idType, DateTime date, string name, int semestr)
        {
            Id = id;
            IdDiscipline = idDiscipline;
            IdType = idType;
            Date = date;
            Name = name;
            Semestr = semestr;
        }
    }
}
