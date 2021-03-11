using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo_List
{
    public partial class App : Application
    {
        public static string FilePath;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SplashPage());
        }

        public App(string filePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SplashPage());

            FilePath = filePath;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
