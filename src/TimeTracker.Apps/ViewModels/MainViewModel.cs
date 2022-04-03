using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Storm.Mvvm;
using Xamarin.Forms;
using Storm.Mvvm.Navigation;
using Xamarin.Forms.Xaml;
using TimeTracker.Apps.Pages;
using Storm.Mvvm.Services;
using System.Collections.Generic;

namespace TimeTracker.Apps.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        
        public ICommand InscriptionCommand { get; }

        public ICommand Connect { get; }

        public MainViewModel()
        {
            Connect = new Command(ConnexionAction);
            InscriptionCommand = new Command(InscriptionAction);
        }

        private void ConnexionAction(object obj)
        {
            NavigationService.PushAsync<Loginpage>(new Dictionary<string, object>()
            {
                ["Index"] =2
            });
        }

        private  void InscriptionAction(object obj)
        {
            int index = 1;

            NavigationService.PushAsync<Registerpage>(new Dictionary<string, object>()
            {
                ["Index"] = index
            });
        }

       
       

       
    }

        
       
    
}