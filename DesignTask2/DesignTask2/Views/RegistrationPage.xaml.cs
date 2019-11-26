﻿using DesignTask2.Database;
using DesignTask2.Helper;
using System;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesignTask2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage//, Behavior<Entry>
    {
        User users = new User();
        UserDB userDB = new UserDB();

        public RegistrationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            emailEntry.ReturnCommand = new Command(() => userNameEntry.Focus());
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            passwordEntry.ReturnCommand = new Command(() => confirmpasswordEntry.Focus());
        }
        private async void SignupValidation_ButtonClicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(userNameEntry.Text)) || (string.IsNullOrWhiteSpace(emailEntry.Text)) ||
                (string.IsNullOrEmpty(userNameEntry.Text)) || (string.IsNullOrEmpty(emailEntry.Text)))

            {
                await DisplayAlert("Preencha os dados", "Preencha com um dado válido", "OK");
            }
            else if (!string.Equals(passwordEntry.Text,confirmpasswordEntry.Text) )
            {
                warningLabel.Text = "Preencha a mesma senha";
                passwordEntry.Text = string.Empty;
                confirmpasswordEntry.Text = string.Empty;
                warningLabel.TextColor = Color.IndianRed;
                warningLabel.IsVisible = true;
            }
            else
            {
                users.name = emailEntry.Text;
                users.userName = userNameEntry.Text;
                users.password = passwordEntry.Text;
                try
                {
                    var retrunvalue = userDB.AddUser(users);
                    if (retrunvalue == "Adicionado com Sucesso")
                    {
                        await DisplayAlert("Usuário Adicionado", retrunvalue, "OK");
                        
                        await Navigation.PushAsync(new LoginPage());

                    }
                    else
                    {
                        await DisplayAlert("Usuário Adicionado", retrunvalue, "OK");
                        warningLabel.IsVisible = false;
                        emailEntry.Text = string.Empty;
                        userNameEntry.Text = string.Empty;
                        passwordEntry.Text = string.Empty;
                        confirmpasswordEntry.Text = string.Empty;
                    }                                        
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            //users.name = fullNameEntry.Text;
            //users.userName = userNameEntry.Text;
            //users.password = passwordEntry.Text;
            //users.phone = phoneEntry.Text.ToString();

        }
        private async void login_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        
        }
}