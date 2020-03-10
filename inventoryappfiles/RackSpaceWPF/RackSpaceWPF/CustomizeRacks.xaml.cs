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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RackSpaceWPF
{
    /// <summary>
    /// Interaction logic for CustomizeRacks.xaml
    /// </summary>
    public partial class CustomizeRacks : Page
    {
        public CustomizeRacks()
        {
            InitializeComponent();
            Globals.InitializeGlobals();
            DisplayRacks(Globals.AllRacks);
        }
        private void MainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //SelectedItemBox.Visibility = Visibility.Hidden;
            //if((Item)ItemListGrid.SelectedItem)
        }
        private void RacksListGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //try
            //{
            //    Item item = (Item)ItemListGrid.SelectedItem;
            //    SelectedItemBox.Visibility = Visibility.Visible;
            //    ItemImageBox.Source = new BitmapImage(new Uri(item.ImageUrl, UriKind.Absolute));
            //    NameTextBox.Text = item.Name;
            //    SerialNumTextBox.Text = item.SerialNum;
            //    RackIdTextBox.Text = item.RackId;
            //}
            //catch
            //{
            //    SelectedItemBox.Visibility = Visibility.Collapsed;
            //}
        }
        private void AltoShaamBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void AltoShaamBorder_MouseEnter(object sender, MouseEventArgs e)
        {

        }
        private void RacksListGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                return;
                //e.Handled = true;
            }
        }
        private void RacksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rack rack = (Rack)RackListGrid.SelectedItem;
            if (rack != null)
            {
                SelectedRackBox.Visibility = Visibility.Visible;
                try
                {
                    RackImageBox.Source = new BitmapImage(new Uri(rack.Image, UriKind.Absolute));
                }
                catch
                {

                }
                NameTextBox.Text = rack.Name;
            }

        }
        private void RackImageBox_Loaded(object sender, RoutedEventArgs e)
        {
            RackImageBox.Width = SelectedRackBox.ActualWidth - 20;
            RackImageBox.Height = (SelectedRackBox.ActualHeight / 5) * 2;
        }
        private void SelectedRackDetails_Loaded(object sender, RoutedEventArgs e)
        {
            RackImageBox.Width = SelectedRackBox.ActualWidth - 20;
            RackImageBox.Height = (SelectedRackBox.ActualHeight / 5) * 3;
        }
        private void CreateRack_Click(object sender, RoutedEventArgs e)
        {
            CreateRack createRack = new CreateRack();
            this.NavigationService.Navigate(createRack);
        }

        private void RemoveRack_Click(object sender, RoutedEventArgs e)
        {
            //string value = "";
            //try
            //{
            //    value = RacksListBox.SelectedItem.ToString();
            //}
            //catch
            //{
            //    return;
            //}

            //if (value != null)
            //{

            //    Guid tempGuid = Guid.Parse(((ListBoxItem)RacksListBox.SelectedItem).Tag.ToString());
            //    for (int i = 0; i < Globals.AllRacks.Count; i++)
            //    {
            //        Rack rack = Globals.AllRacks[i];
            //        if (rack.guid == tempGuid)
            //        {
            //            SQLDatabase.DeleteRack(rack);
            //            Globals.InitializeGlobals();
            //            DisplayRacks();
            //            return;
            //        }
            //    }

            //}
            //else
            //{
            //    return;
            //}
            try
            {
                Rack varRack = (Rack)RackListGrid.SelectedItem;
            }
            catch
            {
                string messageBoxText = "Please select a rack.";
                string caption = "Rack Select Warning";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning; //MessageBoxImage.YesNoCancel; -allows yes, no and cancel button to be displayed on dialog box
                MessageBox.Show(messageBoxText, caption, button, icon);
                return;
            }
            Rack rack = (Rack)RackListGrid.SelectedItem;
            if (rack != null)
            {
                string messageBoxText = "Are you sure you want to delete this rack?";
                string caption = "Rack Deletion Warning";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning; //MessageBoxImage.YesNoCancel; -allows yes, no and cancel button to be displayed on dialog box
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        // User pressed Yes button
                        // ...
                        SQLDatabase.DeleteRack(rack);
                        Globals.InitializeGlobals();
                        DisplayRacks(Globals.AllRacks);
                        break;
                    case MessageBoxResult.No:
                        // User pressed No button
                        // ...
                        break;
                }
            }
            else
            {
                return;
            }
        }

        private void ReadRack_Click(object sender, RoutedEventArgs e)
        {
            Globals.InitializeGlobals();
            DisplayRacks(Globals.AllRacks);
        }

        private void UpdateRack_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DisplayRacks(List<Rack> racks)
        {
            //RacksListBox.Items.Clear();
            //for (int i = 0; i < Globals.AllRacks.Count; i++)
            //{
            //    Rack rack = Globals.AllRacks[i];
            //    ListBoxItem listItem = new ListBoxItem();
            //    listItem.Content = Globals.FormatListBoxRackString(rack);
            //    listItem.Tag = rack.guid.ToString();
            //    RacksListBox.Items.Add(listItem);
            //}
            RackListGrid.ItemsSource = racks;
            RackListGrid.CanUserReorderColumns = true;
            RackListGrid.CanUserSortColumns = true;
            RackListGrid.Cursor = Cursors.Hand;
            RackListGrid.IsReadOnly = true;
        }
        private void RacksListGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Rack rack = (Rack)RackListGrid.SelectedItem;
            try
            {
                EditRack editRack = new EditRack(rack);
                this.NavigationService.Navigate(editRack);
            }
            catch
            {
                return;
            }

        }
        private void SearchBarTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchBarTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                Globals.InitializeGlobals();
                DisplayRacks(Globals.AllRacks);
            }
            else if (Globals.GetMatches(Globals.AllRacks, query).ToList().Count > 0)
            {
                DisplayRacks(Globals.GetMatches(Globals.AllRacks, query).ToList());
            }
            if (Globals.GetMatches(Globals.AllRacks, query).ToList().Count == 0)
            {
                DisplayRacks(Globals.GetMatches(Globals.AllRacks, query).ToList());
            }


        }
        //private void RacksListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    for (int i = 0; i < Globals.AllRacks.Count; i++)
        //    {
        //        if (i == RacksListBox.SelectedIndex)
        //        {
        //            Rack rack = Globals.AllRacks[i];
        //            EditRack editRack = new EditRack(rack);
        //            this.NavigationService.Navigate(editRack);

        //        }
        //    }
        //}

        //private void RacksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Globals.SaveRacksToDB();
            Home home = new Home();
            this.NavigationService.Navigate(home);
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.NavigationService.Navigate(home);
        }
        private void AltoShaamButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow AltoShaamSite = new NavigationWindow();
            AltoShaamSite.Source = new Uri("https://www.alto-shaam.com/en", UriKind.Absolute);
            AltoShaamSite.ShowDialog();
        }
        private void RacksListGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Rack rack = (Rack)RackListGrid.SelectedItem;
                try
                {
                        EditRack editRack = new EditRack(rack);
                        this.NavigationService.Navigate(editRack);
                }
                catch
                {
                    return;
                }
            }
        }
        private void RacksListAutoGenerateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //Set properties on the columns during auto-generation
            switch (e.Column.Header.ToString())
            {
                case "Name":
                    e.Column.Visibility = Visibility.Visible;
                    //e.Column.Width = (SearchBarTextBox.ExtentWidth / 6);
                    e.Column.Width = 120;
                    break;
                case "Location":
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Width = 120;
                    break;
                case "IsVacant":
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Width = 120;
                    break;
                case "IsGroundOrCulDeSac":
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Width = 120;
                    break;
                default:
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }

        }

        private void CustomizeRacks_Click(object sender, RoutedEventArgs e)
        {
            CustomizeRacks custRack = new CustomizeRacks();
            this.NavigationService.Navigate(custRack);
        }

        private void UnitsAndItems_Click(object sender, RoutedEventArgs e)
        {
            UnitsAndItems unitsAndItems = new UnitsAndItems();
            this.NavigationService.Navigate(unitsAndItems);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.NavigationService.Navigate(home);
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NoteTester_Click(object sender, RoutedEventArgs e)
        {
            NoteTester note = new NoteTester();
            this.NavigationService.Navigate(note);
        }
    }
}
