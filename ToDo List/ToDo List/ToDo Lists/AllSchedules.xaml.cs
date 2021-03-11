using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace ToDo_List
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AllSchedules : ContentPage
    {
        ObservableCollection<TodoTasks> tasksColl;
        public AllSchedules()
        {
            InitializeComponent();
            Dan.Text = DateTime.Now.ToString("dddd");
            Datum.Text = DateTime.Now.ToString("dd MMMM");
        }
        async void AddTask_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTask("Personal Errands"));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<TodoTasks>();
                var tasks = conn.Table<TodoTasks>().ToList();
                tasksColl = new ObservableCollection<TodoTasks>(tasks);

                allTasksListView.ItemsSource = tasksColl;
                
            }
        }

        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        public void TaskCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var ck = (CheckBox)sender;
            int id = Convert.ToInt32(ck.AutomationId);
            var parentLayout = ck.Parent;

            var options = new SQLiteConnectionString(App.FilePath, false);
            var conn = new SQLiteConnection(options);

            if (ck.IsChecked)
            {               
                conn.Execute("UPDATE TodoTasks SET TaskChecked = ?, TextColor = ? WHERE id = ?", true, "#20111111", id);
                parentLayout.FindByName<Label>("lblName").TextColor = Color.FromHex("#20111111");
                parentLayout.FindByName<Label>("lblGroup").TextColor = Color.FromHex("#20111111");
                Console.WriteLine("Executed Querry True");
            } else
            {
                conn.Execute("UPDATE TodoTasks SET TaskChecked = ?, TextColor = ? WHERE id = ?", false, "#AA111111", id);
                parentLayout.FindByName<Label>("lblName").TextColor = Color.FromHex("#AA111111");
                parentLayout.FindByName<Label>("lblGroup").TextColor = Color.FromHex("#AA111111");
                Console.WriteLine("Executed Querry False");
            }          
            conn.Close();

            
            
        }

        public void Delete_Clicked(object sender, EventArgs e)
        {
            var del = (ImageButton)sender;
            string id = del.AutomationId;

            var options = new SQLiteConnectionString(App.FilePath, false);
            var conn = new SQLiteConnection(options);

            conn.Delete<TodoTasks>(id);
            conn.Close();

            OnAppearing();
        }

    }
}