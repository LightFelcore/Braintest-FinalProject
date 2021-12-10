using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using xamarinformsproject.Model;

namespace xamarinformsproject.ViewModel
{
    internal class RegisterPageViewModel: BaseViewModel
    {
        public ObservableCollection<User> UserCollection { get; set; } = new ObservableCollection<User>();
        private IEnumerable<User> EUser { get; set; }


        // Input email from user
        private string usernameInput = "";
        public String UsernameInput 
        {  
            get { return usernameInput; }
            set { usernameInput = value; OnPropertyChanged(); }
        }

        // Input Password from user
        private string passwordInput = "";
        public String PasswordInput 
        {
            get { return passwordInput; }
            set { passwordInput = value; OnPropertyChanged(); }
        }

        // Input Repeated Password
        private String passwordRepeatInput = "";
        public String PasswordRepeatInput
        {
            get { return passwordRepeatInput; }
            set { passwordRepeatInput = value; OnPropertyChanged(); }
        }

        // Command when user clicks the Login Button
        public Command RegisterCommand { get; set; }

        // Command when user wants to move from RegisterPage to LoginPage
        public Command ToLoginPageCommand { get; set; }

        // Ctor
        public RegisterPageViewModel()
        {
            // Declaring a new command, giving the OnLoginClick to the delegate
            RegisterCommand = new Command(OnRegisterClick);
            ToLoginPageCommand = new Command(OnToLoginPageClick);
        }

        // When user clicks the login button
        public void OnRegisterClick()
        {
            TrimEntries();
            ValidateEntries();
        }

        // Write user to database async
        private async void SaveUser()
        {
            // Store new User in database
            bool IsValidStatusCode = await DataStore.AddUserAsync(new User() { Username = UsernameInput, Password = PasswordInput });
            Console.WriteLine(IsValidStatusCode);
            if (IsValidStatusCode)
            {
                // Get all users and store them in UserCollection
                LoadUserData();
                await App.Current.MainPage.Navigation.PopAsync();
            } else
            {
                await App.Current.MainPage.DisplayAlert("User already exists", "User with this username already exists. Choose another username!", "Ok");
            }


        }

        // opvragen van alle gebruikers
        async public void LoadUserData()
        {
            UserCollection.Clear();

            EUser = await DataStore.GetAllUserAsync();

            foreach (var item in EUser)
            {
                UserCollection.Add(item);
            }
        }

        private async void ValidateEntries()
        {
            bool valid = true;

            /* Email Validation */
            if (string.IsNullOrEmpty(UsernameInput) && string.IsNullOrWhiteSpace(UsernameInput))
            {
                await App.Current.MainPage.DisplayAlert("Username is empty", "Please, fill in your username", "OK");
                valid = false;
            }
            else
            {
                if(UsernameInput.Length < 6)
                {
                    await App.Current.MainPage.DisplayAlert("Username to short", "Please, enter at least 6 characters", "OK");
                    valid = false;
                } else
                {
                    /* Password Validation */
                    if (string.IsNullOrEmpty(PasswordInput) && string.IsNullOrWhiteSpace(PasswordInput))
                    {
                        await App.Current.MainPage.DisplayAlert("Password is empty", "Please, fill in your password", "OK");
                        valid = false;
                    }
                    else
                    {
                        if(PasswordInput.Length < 6)
                        {
                            await App.Current.MainPage.DisplayAlert("Password to short", "Please, enter at least 6 characters", "OK");
                            valid = false;
                        } else
                        {
                            if (string.IsNullOrEmpty(PasswordRepeatInput) && string.IsNullOrWhiteSpace(PasswordRepeatInput))
                            {
                                await App.Current.MainPage.DisplayAlert("Password Repeat is empty", "Please, fill in your password", "OK");
                                valid = false;
                            }
                            else
                            {
                                if(!passwordInput.Equals(PasswordRepeatInput))
                                {
                                    await App.Current.MainPage.DisplayAlert("Password mismatch", "Please, make sure your passwods do match with each other", "OK");
                                    valid = false;
                                }
                            }
                        }
                        
                    }
                }
                

            }
            if (valid)
            {
                //Save user to db
                SaveUser();
            }
        }

        private void ClearAllEntries()
        {
            UsernameInput = "";
            PasswordInput = "";
            PasswordRepeatInput = "";
        }

        private void TrimEntries()
        {
            UsernameInput = UsernameInput.Trim();
            PasswordInput = PasswordInput.Trim();
            PasswordRepeatInput = PasswordRepeatInput.Trim();
        }

        public void OnToLoginPageClick()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
