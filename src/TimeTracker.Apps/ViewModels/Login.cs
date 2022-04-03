using System;
using System.Collections.Generic;
using System.Windows.Input;
using Storm.Mvvm;
using TimeTracker.Apps.Pages;
using TimeTracker.Apps.Services;
using TimeTracker.Dtos.Accounts;
using TimeTracker.Dtos.Authentications;
using TimeTracker.Dtos.Authentications.Credentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TimeTracker.Apps.ViewModels
{
    public class Login : ViewModelBase
    {

        LoginWithCredentialsRequest loginWithCredentialsRequest = new LoginWithCredentialsRequest();
        TimeTrackerServices timeTrackerServices = new TimeTrackerServices();

        public Login()
        {
            Connexion = new Command(ConnexionAction);
        }
        public ICommand Connexion { get; }

       
        public string Email
        {
            get => _email;

            set => SetProperty(ref _email, value);
        }
        public string Password
        {
            get => _password;

            set => SetProperty(ref _password, value);
        }

        private string _email;
        private string _password;

        private void ConnexionAction()
        {
            loginWithCredentialsRequest.ClientId = "MOBILE";
            loginWithCredentialsRequest.ClientSecret = "COURS";
            loginWithCredentialsRequest.Login = Email;
            loginWithCredentialsRequest.Password = Password;
            _ = timeTrackerServices.Connexion(loginWithCredentialsRequest);
            timeTrackerServices.ItemsProjetAsync();


        }
    }
}