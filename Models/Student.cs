using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration_Shashin.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int IdGroup { get; set; }
        public bool Expelled { get; set; }
        public DateTime DateExpelled { get; set; }
        public Student(int id, string firstname, string lastname, int idGroup, bool expelled, DateTime dateExpelled)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            IdGroup = idGroup;
            Expelled = expelled;
            DateExpelled = dateExpelled;
        }
    }
}
