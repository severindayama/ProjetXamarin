using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Storm.Mvvm;
using TimeTracker.Apps.Pages;
using TimeTracker.Apps.Services;
using TimeTracker.Dtos.Projects;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class AddProjet : ViewModelBase
        
    {
        private string _projetName;
        private string _projetDescription;
        AddProjectRequest addProjectRequest = new AddProjectRequest();
        TimeTrackerServices timeTrackerServices = new TimeTrackerServices();
        public AddProjet()
        {
        
            CreatProjet = new Command(CreatProjetAction);
            Annuler = new Command(AnnulerAction);
        }
        public string ProjetDescription
        {
            get => _projetDescription;

            set => SetProperty(ref _projetDescription, value);
        }
        public string ProjetName
        {
            get => _projetName;

            set => SetProperty(ref _projetName, value);
        }
        public ICommand CreatProjet { get; }
        public ICommand Annuler { get; }

        private void AnnulerAction()
        {
            NavigationService.PopAsync();
            
        }

        private void CreatProjetAction()
        {
            
            addProjectRequest.Name = ProjetName;
            addProjectRequest.Description = ProjetDescription;

             timeTrackerServices.AddProjetAsync(addProjectRequest);

            NavigationService.PushAsync<Projetpage>(new Dictionary<string, object>()
            {
                ["Index"] = 1
            });

        }

        
    }
}
