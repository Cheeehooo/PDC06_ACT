using MvvmHelpers;
using MvvmHelpers.Commands;
using PDC06_ACT.Model;
using PDC06_ACT.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PDC06_ACT.ViewModel
{
    class StudentViewModel : BaseViewModel
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public string Course { get; set; }

        public int Year { get; set; }

        public string Section { get; set; }
        private DBFirebase services;

        public Command AddStudentCommand { get; }
        public ObservableCollection<Student> _students = new ObservableCollection<Student>();

        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public StudentViewModel()
        {
            services = new DBFirebase();
            Students = services.getStudent();
            AddStudentCommand = new Command(async () => await addStudentAsync(StudentId, StudentName, Course, Year, Section));
        }

        public async Task addStudentAsync(int StudentId, string StudentName, string Course, int Year, string Section)
        {
            await services.AddStudent(StudentId, StudentName, Course, Year, Section);
        }
    }
}
