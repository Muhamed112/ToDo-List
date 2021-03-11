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
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }
        private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(checkBox.IsChecked)
            {
                checkBox.Color = Color.FromHex("#006af9");
            } else
            {
                checkBox.Color = Color.Gray;
            }
        }

        public async void SignupButton_Clicked(object sender, EventArgs e)
        {
            if(checkBox.IsChecked)
            {
                if (String.IsNullOrWhiteSpace(EntryUsername.Text))
                {
                    await DisplayAlert("Error", "You must enter a username!", "OK");
                } 
                else if (String.IsNullOrWhiteSpace(EntryEmail.Text))
                {
                    await DisplayAlert("Error", "You must enter an email!", "OK");
                }
                else if (String.IsNullOrWhiteSpace(EntryPassword.Text))
                {
                    await DisplayAlert("Error", "You must enter a password!", "OK");
                }
                else if (String.IsNullOrWhiteSpace(EntryConfirmPassword.Text))
                {
                    await DisplayAlert("Error", "You must confirm your password!", "OK");
                }
                else
                {
                    await DisplayAlert("Registration successful", "You will soon receive an email with the confirmation link", "OK");
                    await Navigation.PushAsync(new ToDoList(EntryUsername.Text));
                }
            } else
            {
                await DisplayAlert("Error", "You must accept the terms of service to proceed!", "OK");
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }
    }
}