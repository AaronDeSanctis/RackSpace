using RackSpaceWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RackSpaceWPF
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                Globals.CurrentUser.ChooseGuid();
                Globals.CurrentUser.Username = UsernameTextBox.Text;
                Globals.CurrentUser.Password = PasswordTextBox.Password;
                SQLDatabase.CreateUser(Globals.CurrentUser);
                Globals.CurrentUser.IsAuthenticated = true;
                this.Close();
            //}
            //catch
            //{

            //}
            
        }
    }
}
