using PDC06_ACT.Model;
using PDC06_ACT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC06_ACT.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentDetailPage : ContentPage
    {
        DBFirebase services;
        public StudentDetailPage(Student student)
        {
            InitializeComponent();
            BindingContext = student;

            services = new DBFirebase();
        }
        public async void BtnDelete(object sender, EventArgs e)
        {
            await services.DeleteStudent(
                int.Parse(StudentId.Text), StudentName.Text,
                Course.Text, int.Parse(Year.Text),
                Section.Text);
            await Navigation.PushAsync(new StudentView());
        }
        public async void BtnUpdate(object sender, EventArgs e)
        {
            await services.UpdateStudent(
                int.Parse(StudentId.Text), StudentName.Text,
                Course.Text, int.Parse(Year.Text),
                Section.Text);
            await Navigation.PushAsync(new StudentView());
        }
    }
}