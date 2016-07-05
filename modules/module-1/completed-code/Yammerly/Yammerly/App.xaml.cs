﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Yammerly.Helpers;
using Yammerly.Services;
using Yammerly.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Yammerly
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            PresentMainPage(useMock: false);
        }

        void PresentMainPage(bool useMock = true)
        {
            if (useMock)
            {
                DependencyService.Register<IDataService, MockService>();

                MainPage = new EmployeesPage();
            }
            else
            {
                DependencyService.Register<IDataService, AzureService>();

                if (!Settings.IsLoggedIn)
                    DependencyService.Get<IDataService>().Initialize();

                if (Settings.IsLoggedIn)
                {
                    MainPage = new LoginPage();
                }
                else
                {
                    MainPage = new EmployeesPage();
                }
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
