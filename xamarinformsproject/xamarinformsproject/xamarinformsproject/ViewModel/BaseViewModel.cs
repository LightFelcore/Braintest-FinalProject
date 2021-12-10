using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using xamarinformsproject.Model;
using xamarinformsproject.Services;

namespace xamarinformsproject.ViewModel
{
    /* https://stackoverflow.com/questions/70080839/clear-entry-text-from-viewmodel-using-relaycommand?noredirect=1#comment123883817_70080839 */

    public class BaseViewModel: INotifyPropertyChanged
    {
        [JsonIgnore]
        public static User LoggedInUser { get; set; } // currently logged in user
        [JsonIgnore]
        public static bool IsLoggedIn { get; set; } = false; // logged in state, if user is logged in this boolean wil be true otherwise false

        // Property that is used to stimulate the state of refreshing the page
        [JsonIgnore]
        private bool isBusy = false;
        [JsonIgnore]
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        // Dependency Service, omdat het opgeslagen is in de baseview model, zullen alle andere afgeleide view models accessen hebben en deze DataStore kunnen gebruiken om api calls te maken
        [JsonIgnore]
        public IDataStore DataStore => DependencyService.Get<IDataStore>();


        // Event handler dat de front-end van de applicatie verwittigd dat een bepaalde property is gewijzigd en dat deze ook moet aangepast worden.
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BaseViewModel()
        {

        }

        // Function to call the Quiz data
        public void LoadItems()
        {
            // Call to db
            IsBusy = false;
        }
    }
}
