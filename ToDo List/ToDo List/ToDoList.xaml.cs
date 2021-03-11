using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo_List
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoList : ContentPage
    {
        public ToDoList(String name)
        {
            InitializeComponent();
            Username.Text = name;
            DateTime today = DateTime.Today;
            string dan = today.ToString("dddd,");
            Dan.Text = dan;
            string datum = today.ToString("dd MMMM");
            Datum.Text = datum;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Upit
            var options = new SQLiteConnectionString(App.FilePath, false);
            var conn = new SQLiteConnection(options);
            conn.CreateTable<TodoTasks>();

            string query1 = $"SELECT * FROM TodoTasks";
            var FullList = conn.Query<TodoTasks>(query1).ToList();
            int fullInt = FullList.Count;

            string query2 = $"SELECT * FROM TodoTasks WHERE TaskChecked = true";
            var CompletedList = conn.Query<TodoTasks>(query2).ToList();
            int completedInt = CompletedList.Count;

            string queryPersonal = $"SELECT * FROM TodoTasks WHERE TaskGroup = 'Personal Errands'";
            var personalList = conn.Query<TodoTasks>(queryPersonal).ToList();
            int personalint = personalList.Count;

            string queryGrocery = $"SELECT * FROM TodoTasks WHERE TaskGroup = 'Grocery List'";
            var groceryList = conn.Query<TodoTasks>(queryGrocery).ToList();
            int groceryint = groceryList.Count;

            string querySchoolProjects = $"SELECT * FROM TodoTasks WHERE TaskGroup = 'School Projects'";
            var schoolprojectsList = conn.Query<TodoTasks>(querySchoolProjects).ToList();
            int schoolprojectsint = schoolprojectsList.Count;

            string queryWorkProjects = $"SELECT * FROM TodoTasks WHERE TaskGroup = 'Work Projects'";
            var workprojectsList = conn.Query<TodoTasks>(queryWorkProjects).ToList();
            int workrprojectsint = workprojectsList.Count;

            conn.Close();

            numCreated.Text = Convert.ToString(fullInt);
            numCompleted.Text = Convert.ToString(completedInt);

            allTasksNum.Text = Convert.ToString(fullInt) + " Tasks";
            personalTasksNum.Text = Convert.ToString(personalint) + " Tasks";
            groceryTasksNum.Text = Convert.ToString(groceryint) + " Tasks";
            schoolTasksNum.Text = Convert.ToString(schoolprojectsint) + " Tasks";
            workTasksNum.Text = Convert.ToString(workrprojectsint) + " Tasks";
        }

        async void AllSchedule_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllSchedules());
        }

        async void PersonalErrands_Tapped(object sender, EventArgs e)
        {
            string name = "Personal Errands";
            await Navigation.PushAsync(new Template(name));
        }

        async void WorkProjects_Tapped(object sender, EventArgs e)
        {
            string name = "Work Projects";
            await Navigation.PushAsync(new Template(name));
        }

        async void GroceryList_Tapped(object sender, EventArgs e)
        {
            string name = "Grocery List";
            await Navigation.PushAsync(new Template(name));
        }

        async void SchoolProjects_Tapped(object sender, EventArgs e)
        {
            string name = "School Projects";
            await Navigation.PushAsync(new Template(name));
        }
    }
}