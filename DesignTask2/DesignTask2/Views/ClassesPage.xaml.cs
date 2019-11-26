using DesignTask2.Database;
using DesignTask2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesignTask2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassesPage : ContentPage
    {
        UserDB userData = new UserDB();

        public ClassesPage()
        {
            InitializeComponent();
        }

        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            var C = new Class() { Name = nameEntry.Text, Hour = new DateTime(1, 1, 1) + timePicker.Time };

            userData.AddClass(App.SelectedUser, C);

            await Navigation.PushAsync(new NavigationPage(new UsersListPage()));
        }
    }
}