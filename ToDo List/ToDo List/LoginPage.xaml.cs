using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo_List
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Error", "The service is currently unavailable", "OK");
        }

        public async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await DisplayAlert("Error", "The service is currently unavailable", "OK");
        }

        async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(EntryName.Text))
            {
                await DisplayAlert("Error", "You must enter a username!", "OK");
            } else if(String.IsNullOrWhiteSpace(EntryPassword.Text))
            {
                await DisplayAlert("Error", "You must enter a password!", "OK");
            } else
            {
                await Navigation.PushAsync(new ToDoList(EntryName.Text));
            }
        }
    }
}