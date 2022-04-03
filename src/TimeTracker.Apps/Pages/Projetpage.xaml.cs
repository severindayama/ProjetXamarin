using System;
using System.Text;
using System.Collections.Generic;
using Storm.Mvvm.Forms;
using TimeTracker.Apps.Services;
using TimeTracker.Apps.ViewModels;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using TimeTracker.Dtos.Projects;
using MonkeyCache.LiteDB;
using System.Net.Http.Headers;
using TimeTracker.Dtos.Authentications;
using System.Net.Http;
using TimeTracker.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms.Xaml;

namespace TimeTracker.Apps.Pages
{
    public partial class Projetpage : BaseContentPage
    {
        public Projetpage()
        {

            InitializeComponent();
          
            BindingContext = new Projet();


            
        }

       


    }
}
