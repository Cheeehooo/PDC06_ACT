using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public async Task DeleteStudent(int StudentId, string StudentName, string Course, int Year, string Section)
        {
            var toDeleteStudent = (await client
                  .Child("Student")
                  .OnceAsync<Student>()).FirstOrDefault
                  (a => a.Object.StudentId == StudentId || a.Object.StudentName == StudentName);
            await client.Child("Student").Child(toDeleteStudent.Key).DeleteAsync();

        }

        public async Task UpdateStudent(int StudentId, string StudentName, string Course, int Year, string Section)
        {
            var toUpdateStudent = (await client
                .Child("Student")
                .OnceAsync<Student>()).FirstOrDefault
                (a => a.Object.StudentId == StudentId);

            Student e = new Student() { StudentId = StudentId, StudentName = StudentName, Course = Course, Year = Year, Section = Section };
            await client
                .Child("Student")
                .Child(toUpdateStudent.Key)
                .PutAsync(e);
        }
    }
}
