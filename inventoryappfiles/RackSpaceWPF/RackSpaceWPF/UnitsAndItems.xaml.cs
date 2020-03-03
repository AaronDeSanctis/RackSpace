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
using Syncfusion.Windows.Controls;

namespace RackSpaceWPF
{
    /// <summary>
    /// Interaction logic for UnitsAndItems.xaml
    /// </summary>
    public partial class UnitsAndItems : Page
    {
        public UnitsAndItems()
        {
            InitializeComponent();
            Globals.InitializeGlobals();
            DisplayItems(Globals.AllItems);
            NormalHeight = ItemImageBox.Height;
            NormalWidth = ItemImageBox.Width;
            if (Globals.CurrentUser.IsAuthenticated == true)
            {
                
            }
        }
        double NormalHeight;
        double NormalWidth;
        private void MainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //SelectedItemBox.Visibility = Visibility.Hidden;
            //if((Item)ItemListGrid.SelectedItem)
        }
        private void ItemsListGrid_MouseDown(object sender, MouseButtonEventArgs e)
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
        private void ItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item item = (Item)ItemListGrid.SelectedItem;
            if (item != null)
            {
                SelectedItemBox.Visibility = Visibility.Visible;
                ItemImageBox.Source = new BitmapImage(new Uri(item.ImageUrl, UriKind.Absolute));
                //var thumb = ItemImageBox;
                //var transform = thumb.RenderTransform as RotateTransform;
                //transform.Angle = item.ImageRotation;

                //if (transform.Angle == 90 || transform.Angle == 270)
                //{
                //    thumb.Width = 190;
                //}
                //else
                //{
                //    thumb.Height = 190;
                //}
                NameTextBox.Text = item.Name;
                SerialNumTextBox.Text = item.SerialNum;
                RackIdTextBox.Text = item.RackId;
            }

        }
        private void CreateItem_Click(object sender, RoutedEventArgs e)
        {
            CreateItem createItem = new CreateItem();
            this.NavigationService.Navigate(createItem);

        }
        private void UnitsAndItems_Click(object sender, RoutedEventArgs e)
        {
            UnitsAndItems unitsAndItems = new UnitsAndItems();
            this.NavigationService.Navigate(unitsAndItems);

        }
        private void ItemImageBox_Loaded(object sender, RoutedEventArgs e)
        {
            ItemImageBox.Width = SelectedItemBox.ActualWidth - 20;
            ItemImageBox.Height = (SelectedItemBox.ActualHeight / 5) * 2;
        }
        private void SelectedItemDetails_Loaded(object sender, RoutedEventArgs e)
        {
            ItemImageBox.Width = SelectedItemBox.ActualWidth - 20;
            ItemImageBox.Height = (SelectedItemBox.ActualHeight / 5) * 3;
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Item varItem = (Item)ItemListGrid.SelectedItem;
            }
            catch
            {
                string messageBoxText = "Please select an an item.";
                string caption = "Item Select Warning";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning; //MessageBoxImage.YesNoCancel; -allows yes, no and cancel button to be displayed on dialog box
                MessageBox.Show(messageBoxText, caption, button, icon);
                return;
            }
            Item item = (Item)ItemListGrid.SelectedItem;
            if (item != null)
            {
                string messageBoxText = "Are you sure you want to delete this item?";
                string caption = "Item Deletion Warning";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning; //MessageBoxImage.YesNoCancel; -allows yes, no and cancel button to be displayed on dialog box
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        // User pressed Yes button
                        // ...
                        SQLDatabase.DeleteItem(item);
                        Globals.InitializeGlobals();
                        DisplayItems(Globals.AllItems);
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

        private void ReadItem_Click(object sender, RoutedEventArgs e)
        {
            Globals.InitializeGlobals();
            DisplayItems(Globals.AllItems);
        }

        private void UpdateItem_Click(object sender, RoutedEventArgs e)
        {
            ViewItem viewItem = new ViewItem((Item)ItemListGrid.SelectedItem);
            this.NavigationService.Navigate(viewItem);
        }
        private void DisplayItems(List<Item> items)
        {

            ItemListGrid.CanUserReorderColumns = true;
            ItemListGrid.CanUserSortColumns = true;
            ItemListGrid.Cursor = Cursors.Hand;
            ItemListGrid.IsReadOnly = true;
            int ColumnCount = 0;
            foreach (var propInfo in typeof(Item).GetProperties())
            {
                ColumnCount += 1;
            }
            /*temListGrid = (ItemListGrid.ActualWidth / ColumnCount);*/
            //ItemListGrid.R = (ItemListGrid.MaxWidth / ColumnCount);
            if (Globals.CurrentUser.IsAuthenticated == true)
            {
                ItemListGrid.ItemsSource = items;
            }
            else
            {
                ItemListGrid.ItemsSource = items;
                ItemListGrid.IsReadOnly = true;
            }
            //foreach (TableRow row in ItemListGrid.ItemsSource.Rows)
            //{
            //    TableCell btnCell = new TableCell();

            //    Button btn = new Button();
            //    btn.Content = "Delete";
            //    btn.Click += new EventHandler(BtnDelete_Click);
            //    btnCell.Controls.Add(btn);

            //    row.Cells.Add(btnCell);
            //}
            //ItemListGrid.Columns[ItemListGrid.Columns.Count - 1].Width = '*';
        }

        private void ItemsListAutoGenerateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //Set properties on the columns during auto-generation
            switch (e.Column.Header.ToString())
            {
                case "Name":
                    e.Column.Visibility = Visibility.Visible;
                    //e.Column.Width = (SearchBarTextBox.ExtentWidth / 6);
                    e.Column.Width = 110;
                    break;
                case "RackId":
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Width = 100;
                    break;
                case "IsUnit":
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Width = 40;
                    break;
                case "SerialNum":
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Width = 100;
                    break;
                case "Volts":
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Width = 80;
                    break;
                case "Phase":
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Width = 80; ;
                    break;
                case "Model":
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Width = 80; ;
                    break;
                default:
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }

        }
        private void ItemsListGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Item item = (Item)ItemListGrid.SelectedItem;
            try
            {
                if (item.IsUnit == true)
                {
                    EditItem editItem = new EditItem(item);
                    this.NavigationService.Navigate(editItem);
                }
                else
                {
                    EditItemNonUnit editItem = new EditItemNonUnit(item);
                    this.NavigationService.Navigate(editItem);
                }
            }
            catch
            {
                return;
            }

        }

        private void CustomizeRacks_Click(object sender, RoutedEventArgs e)
        {
            CustomizeRacks customizeRacks = new CustomizeRacks();
            this.NavigationService.Navigate(customizeRacks);
        }


        private void AdvancedSettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBarTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ItemsListGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Item item = (Item)ItemListGrid.SelectedItem;
                try
                {
                    if (item.IsUnit == true)
                    {
                        EditItem editItem = new EditItem(item);
                        this.NavigationService.Navigate(editItem);
                    }
                    else
                    {
                        EditItemNonUnit editItem = new EditItemNonUnit(item);
                        this.NavigationService.Navigate(editItem);
                    }
                }
                catch
                {
                    return;
                }
            }
        }
        private void ItemsListGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                return;
                //e.Handled = true;
            }
        }
        private void SearchBarTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                DisplayItems(Globals.AllItems);
            }
            else if (Globals.GetMatches(Globals.AllItems, query).ToList().Count > 0)
            {
                DisplayItems(Globals.GetMatches(Globals.AllItems, query).ToList());
            }
            if (Globals.GetMatches(Globals.AllItems, query).ToList().Count == 0)
            {
                DisplayItems(Globals.GetMatches(Globals.AllItems, query).ToList());
            }


        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Globals.InitializeGlobals();
            DisplayItems(Globals.AllItems);
        }
        private void Home_Click(object sender, RoutedEventArgs e)
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

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.ShowDialog();
        }

        private void Authenticate_Click(object sender, RoutedEventArgs e)
        {
            if (Globals.GetVisibility() == Visibility.Visible)
            {
                ItemsListBox.Visibility = Globals.GetVisibility();
                ItemListGrid.Visibility = Globals.GetVisibility();
                Globals.BtnVis = Visibility.Collapsed;
                Globals.CurrentUser.IsAuthenticated = true;
            }
            else
            {
                ItemsListBox.Visibility = Globals.GetVisibility();
                ItemListGrid.Visibility = Globals.GetVisibility();
                Globals.BtnVis = Visibility.Visible;
                Globals.CurrentUser.IsAuthenticated = false;
            }

        }

        private void AltoShaamBorder_MouseEnter(object sender, MouseEventArgs e)
        {

        }
    }
}
