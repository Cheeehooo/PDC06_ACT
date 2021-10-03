using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using PDC06_ACT.Model;

namespace PDC06_ACT.Services
{
    
    public class DBFirebase
    {
        FirebaseClient client;
        public DBFirebase()
        {
            client = new FirebaseClient("https://pdc-act-default-rtdb.firebaseio.com/");
        }
        public ObservableCollection<Student> getStudent()
        {
            var studentData = client
                .Child("Student")
                .AsObservable<Student>()
                .AsObservableCollection();

            return studentData;
        }
        public async Task AddStudent(int StudentId, string StudentName, string Course, int Year, string Section)
        {
            Student em = new Student() { StudentId = StudentId, StudentName = StudentName, Course = Course, Year = Year, Section = Section };
            await client
                .Child("Student")
                .PostAsync(em);
        }
    }
}
