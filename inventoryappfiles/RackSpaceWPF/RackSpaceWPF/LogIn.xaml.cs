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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            List<User> Users = SQLDatabase.GetUsers();
            foreach(User user in Users)
            {
                if (user.Username == UsernameTextBox.Text && user.Password == PasswordTextBox.Password)
                {
                    Globals.CurrentUser.guid = user.guid;
                    Globals.CurrentUser.Username = user.Username;
                    Globals.CurrentUser.Password = user.Password;

                    Globals.CurrentUser.IsAuthenticated = true;
                    this.Close();
                }
            }
            
        }
    }
}
