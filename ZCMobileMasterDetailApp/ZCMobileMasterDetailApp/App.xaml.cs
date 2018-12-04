using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileMasterDetailApp;
using ZCMobileMasterDetailApp.MasterDetailPages;
using ZCMobileMasterDetailApp.ViewModel;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ZCMobileMasterDetailApp
{
    public partial class App : Application
    {
        public static MasterDetailControlViewModel MasterDetailVM { get; set; }
        public static bool IsUSerLoggedIn { get; set; }
        public App()
        {

            InitializeComponent();
            App.IsUSerLoggedIn = false;
            MainPage = MasterDetailControl.Create<MasterDetailControl, MasterDetailControlViewModel>(App.IsUSerLoggedIn, new Detail1());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
