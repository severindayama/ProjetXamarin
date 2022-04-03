using System;
using System.Collections.Generic;
using Storm.Mvvm.Forms;
using TimeTracker.Apps.ViewModels;
using Xamarin.Forms;

namespace TimeTracker.Apps.Pages
{
    public partial class Loginpage :BaseContentPage
    {
        public Loginpage()
        {
            InitializeComponent();
            BindingContext = new Login();
        }

    
    }
}
