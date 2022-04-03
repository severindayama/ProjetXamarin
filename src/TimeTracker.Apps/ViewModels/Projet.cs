 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using MonkeyCache.LiteDB;
using Storm.Mvvm;
using Storm.Mvvm.Navigation;
using TimeTracker.Apps.Pages;
using TimeTracker.Apps.Services;
using TimeTracker.Dtos.Authentications;
using TimeTracker.Dtos.Projects;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class Projet : ViewModelBase
    {
        private ObservableCollection<Projet> _list;
        private string _name;
        private string _descripton;
        private List<ProjectItem> _listfinal;

        
        TimeTrackerServices timeTrackerServices = new TimeTrackerServices();

        [NavigationParameter]
        public List<ProjectItem> Listfinal
        {
            get => _listfinal;

            set => SetProperty(ref _listfinal, value);
        }
        public Projet()
        {

            
            ValidateCommand = new Command(AddprojetAction);
            EditProfil = new Command(EditprofilAction);
            EditPassword = new Command(EditpasswordAction);
            List = new ObservableCollection<Projet>();
            Listfinal = new List<ProjectItem>();

            Barrel.ApplicationId = "cacheIdLogin";
            Listfinal = Barrel.Current.Get<List<ProjectItem>>(key: "GestionList");


            foreach (var x in Listfinal)
            {
                
                
                Projet projet = new Projet(x);
                List.Add(projet);
            }
        }


        public Projet(ProjectItem projectItem)
        {
         
            this.Id = projectItem.Id;
            this.Name = projectItem.Name;
            this.Description = projectItem.Description;
            this.TotalSeconds = projectItem.TotalSeconds;

        }




       


        public string Name


        {
            get => _name;

            set => SetProperty(ref _name, value);
        }

        public string Description
        {
            get => _descripton;

            set => SetProperty(ref _descripton, value);
        }
        public ObservableCollection<Projet> List
        {
            get => _list;

            set => SetProperty(ref _list, value);
        }
        public long Id { get; set; }

        public long TotalSeconds { get; set; }


        private void EditpasswordAction()
        {
            NavigationService.PushAsync<Registerpage>(new Dictionary<string, object>()
            {
               
            });
        }

        private void EditprofilAction()
        {

            NavigationService.PushAsync<AddProjetpage>(new Dictionary<string, object>()
            {
                
            });
        }

        public ICommand ValidateCommand { get; }
        public ICommand EditProfil { get; }
        public ICommand EditPassword { get; }

        private void AddprojetAction()
        {
            NavigationService.PushAsync<AddProjetpage>(new Dictionary<string, object>()
            {
                ["Index"] = 0
            });

        }


}
}
