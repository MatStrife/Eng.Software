using DesignTask2.Database;
using DesignTask2.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DesignTask2
{
    public partial class App : Application
    {
        public static User SelectedUser { get; set; }

        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new UsersListPage());
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#cc33ff")
            };
        }

        public static async void NavigatiPage(Page name)
        {
            Application.Current.MainPage = new NavigationPage(new UsersListPage());            
            // new NavigationPage(new UsersListPage());
            //Application.Current.MainPage = navPage;
            await name.Navigation.PushAsync(new UsersListPage());
        }
        public static void MainPageList()
        {
            //MainPage = new NavigationPage(new )
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

        internal static async Task NavigatiPageAsync(Page name)
        {
            Application.Current.MainPage = new NavigationPage(new MasterDetailPage1());
            // new NavigationPage(new UsersListPage());
            //Application.Current.MainPage = navPage;
            await name.Navigation.PushAsync(new MasterDetailPage1());
        }
    }
}
