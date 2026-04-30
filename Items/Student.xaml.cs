using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReportGeneration_Shashin.Classes;
using ReportGeneration_Shashin.Pages;

namespace ReportGeneration_Shashin.Items
{
    /// <summary>
    /// Логика взаимодействия для Student.xaml
    /// </summary>
    public partial class Student : UserControl
    {
        StudentContext student;
        Main main;
        public Student(StudentContext student, Main main)
        {
            InitializeComponent();
            this.student = student;
            this.main = main;

            TBFio.Text = $"{student.Lastname} {student.Firstname}";
            CBExpelled.IsChecked = student.Expelled;
            List<DisciplineContext> StudentDisciplines = main.AllDisciplines.FindAll(x => x.IdGroup == student.IdGroup);
            int NecessarilyCount = 0;
            int WorksCount = 0;
            int DoneCount = 0;
            int MissedCount = 0;

            foreach (DisciplineContext StudentDiscipline in StudentDisciplines)
            {
                List<WorkContext> StudentWorks = main.AllWorks.FindAll(x => 
                (x.IdType == 1 || x.IdType == 2 || x.IdType == 3) &&
                x.IdDiscipline == StudentDiscipline.Id);
                NecessarilyCount += StudentWorks.Count;
                foreach(WorkContext StudentWork in StudentWorks)
                {
                    EvaluationContext Eval = main.AllEvaluations.Find(x =>
                    x.IdWork == StudentWork.Id &&
                    x.IdStudent == student.Id);
                    if(Eval != null && Eval.Value.Trim() != "" && Eval.Value.Trim() != "2")
                        DoneCount++;
                }
                StudentWorks = main.AllWorks.FindAll(x =>
                x.IdType != 4 && x.IdType != 3);
                WorksCount += StudentWorks.Count;
                foreach(WorkContext StudentWork in StudentWorks)
                {
                    EvaluationContext Eval = main.AllEvaluations.Find(x =>
                    x.IdWork == StudentWork.Id && 
                    x.IdStudent == student.Id);
                    if (Eval != null && Eval.Lateness.Trim() != "")
                        MissedCount += Convert.ToInt32(Eval.Lateness);
                }
            }
            doneWorks.Value = (100f/(float)NecessarilyCount * (float)DoneCount);
            missedCount.Value = (100f / ((float)WorksCount * 90f)) * ((float)MissedCount);
            TBGroup.Text = main.AllGroups.Find(x => x.Id == student.IdGroup).Name;
        }
    }
}
