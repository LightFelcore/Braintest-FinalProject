using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xamarin.Forms;
using xamarinformsproject.Model;

namespace xamarinformsproject.ViewModel
{
    internal class LoginPageViewModel : BaseViewModel
    {
        // Input email from user
        private String username = "";
        public String UsernameInput 
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        // Input Password from user
        private String passwordInput = "";
        public String PasswordInput
        {
            get { return passwordInput; }
            set { passwordInput = value; OnPropertyChanged(); }
        }

        // Command when user clicks the Login Button
        public Command LoginCommand { get; set; }
        // Command when user wants to move from LoginPage to RegisterPage
        public Command ToRegisterPageCommand { get; set; } 

        // Ctor
        public LoginPageViewModel()
        {
            // Declaring a new command, giving the OnLoginClick to the delegate
            LoginCommand = new Command(OnLoginClick);
            ToRegisterPageCommand = new Command(OnToRegisterPageClick);
        }

        // When user clicks the login button
        public void OnLoginClick()
        {
            TrimEntries();
            ValidateEntries();
        }

        private async void ValidateEntries()
        {
            bool allFilledUp = true;

            /* Email Validation */
            if (string.IsNullOrEmpty(UsernameInput) && string.IsNullOrWhiteSpace(UsernameInput))
            {
                await App.Current.MainPage.DisplayAlert("Username is empty", "Please, fill in your username", "OK");
                allFilledUp = false;
            } else
            {
                /* Password Validation */
                if (string.IsNullOrEmpty(PasswordInput) && string.IsNullOrWhiteSpace(PasswordInput))
                {
                    await App.Current.MainPage.DisplayAlert("Password is empty", "Please, fill in your password", "OK");
                    allFilledUp = false;
                } 
                
            }
            if(allFilledUp)
            {
                User u = await DataStore.checkAuthentication(UsernameInput, PasswordInput); // if user = null (not logged in) else logged in
                if (u != null)
                {
                    ClearAllEntries();
                    LoggedInUser = u; // slaag de gebruiker op in de baseview model als ingelogde gebruiker
                    IsLoggedIn = true; // user is logged in
                    await App.Current.MainPage.Navigation.PopAsync();
                } else
                {
                    ClearAllEntries();
                    await App.Current.MainPage.DisplayAlert("Incorrect Credentials", "Your username or password is incorrect.", "Ok");
                }
                
            }
        }


        private void ClearAllEntries()
        {
            UsernameInput = "";
            PasswordInput = "";
        }

        private void TrimEntries()
        {
            UsernameInput = UsernameInput.Trim();
            PasswordInput = PasswordInput.Trim();
        }

        public void OnToRegisterPageClick()
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
