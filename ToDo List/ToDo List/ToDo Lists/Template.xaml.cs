using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo_List
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Template : ContentPage
    {
        ObservableCollection<TodoTasks> tasks;
        public static String title;
        public Template(String name)
        {
            InitializeComponent();
            Dan.Text = DateTime.Now.ToString("dddd");
            Datum.Text = DateTime.Now.ToString("dd MMMM");
            pageTitle.Text = name;
            title = name;
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var options = new SQLiteConnectionString(App.FilePath, false);
            var conn = new SQLiteConnection(options);

            string query = $"SELECT * FROM TodoTasks WHERE TaskGroup = '"+title+"'";
            var templateTasks = conn.Query<TodoTasks>(query).ToList();
            tasks = new ObservableCollection<TodoTasks>(templateTasks);
            templateTasksListView.ItemsSource = tasks;

            conn.Close();
        }

        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        async void AddTask_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTask(title));
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
            }
            else
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