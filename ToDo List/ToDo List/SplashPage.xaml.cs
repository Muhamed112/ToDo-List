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
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        private async void StartAnimation()
        {
            
        }
        async void LoginButton(object sender, EventArgs e)
        {
            StartAnimation();
            await Navigation.PushAsync(new LoginPage());
        }

        async void SignupButton(object sender, EventArgs e)
        {
            StartAnimation();
            await Navigation.PushAsync(new SignupPage());
        }
    }
}