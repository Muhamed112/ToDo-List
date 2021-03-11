using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDo_List.Classes;
using SQLite;
using System.Collections.ObjectModel;

namespace ToDo_List
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTask : ContentPage
    {
        public AddTask(String title)
        {
            InitializeComponent();
            taskGroup.ItemsSource = new List<String>
            {
               "Personal Errands",
               "Grocery List",
               "School Projects",
               "Work Projects"
            };

            taskGroup.SelectedItem = title;

            taskDate.MinimumDate = DateTime.Now;
            taskDate.Date = DateTime.Now;

        }

        
        async void AddTask_Clicked(object sender, EventArgs e)
        {
           TodoTasks todoTasks = new TodoTasks()
            {
                    TaskName = taskName.Text,
                    TaskGroup = (string)taskGroup.SelectedItem,
                    TaskDate = taskDate.Date.ToString("dd / MM / yyyy"),
                    TaskChecked = false,
                    TextColor = "#AA111111"
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<TodoTasks>();
                int rowsAdded = conn.Insert(todoTasks);
            }

            await DisplayAlert("Adding Sucessfull","Task has been added!", "OK");
            await Navigation.PopAsync();
        }

        async void BackImage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}