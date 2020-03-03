using RackSpaceWPF.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace RackSpaceWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            //Show the login view
            Globals.InitializeGlobals();
            User user = new User();
            Globals.CurrentUser = user;
            Globals.CurrentUser.IsAuthenticated = false;

            //AuthenticationViewModel viewModel = new AuthenticationViewModel(new AuthenticationService());
            //IView loginWindow = new LoginWindow(viewModel);
            //loginWindow.Show();

        }
    }
}
