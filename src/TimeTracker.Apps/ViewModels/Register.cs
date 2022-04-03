using System;
using System.Windows.Input;
using Storm.Mvvm;
using Xamarin.Forms;
using TimeTracker.Apps.Services;
using System.Threading.Tasks;
using TimeTracker.Dtos.Accounts;
using TimeTracker.Dtos;
using System.Diagnostics;
using TimeTracker.Apps.Pages;
using System.Collections.Generic;

namespace TimeTracker.Apps.ViewModels
{
    public class Register : ViewModelBase

    {
        TimeTrackerServices timeTrackerServices=new TimeTrackerServices();
        private string _nom;
        private string _prenom;
        private string _email;
        private string _password;

        public Register()
        {
           Registration= new Command(RegistrationActionAsync);
        }
       

        public string Nom
        {
            get => _nom;

            set => SetProperty(ref _nom, value);
        }
        public string Prenom
        {
            get => _prenom;

            set => SetProperty(ref _prenom, value);
        }
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





        public ICommand Registration { get; }

         CreateUserRequest createUserRequest = new CreateUserRequest();
        private  void RegistrationActionAsync()

        {

            
            createUserRequest.ClientId = "MOBILE";
            createUserRequest.ClientSecret = "COURS";
            createUserRequest.Email = Email;
            createUserRequest.LastName = Nom;
            createUserRequest.FirstName = Prenom;
            createUserRequest.Password = Password;

            _ = timeTrackerServices.Insription(createUserRequest);
            timeTrackerServices.ItemsProjetAsync();
            NavigationService.PushAsync<Projetpage>(new Dictionary<string, object>()
            {
                ["Index"] = 1
            });

        }

    }
}
