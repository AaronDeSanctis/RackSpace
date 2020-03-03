using Microsoft.Win32;
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
    /// Interaction logic for CreateItem.xaml
    /// </summary>
    public partial class CreateItem : Page
    {
        Item item = new Item();
        List<ComboBoxPairs> RackBoxPairs = new List<ComboBoxPairs>();
        public CreateItem()
        {
            InitializeComponent();
            DisplayRacksInComboBox();
        }

        private void CreateNewItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsUnitCheckBox.IsChecked == true)
                {
                    item.IsUnit = true;
                }
                else
                {
                    item.IsUnit = false;
                }
                item.Name = NameTextBox.Text;
                item.Volts = VoltsTextBox.Text;
                item.Phase = PhaseTextBox.Text;
                item.SerialNum = SerialNumTextBox.Text;
                item.Model = ModelTextBox.Text;
                item.ChooseGuid();
                var thumb = ItemImageBox;
                var transform = thumb.RenderTransform as RotateTransform;
                item.ImageRotation = transform.Angle;
                SelectRack();
                Globals.CreateNewItem(item);
                Home home = new Home();
                this.NavigationService.Navigate(home);
            }
            catch
            {
                string messageBoxText = "There was an issue creating your Item. Please try again.";
                string caption = "Invalid Item Warning";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning; //MessageBoxImage.YesNoCancel; -allows yes, no and cancel button to be displayed on dialog box
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void IsUnitCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void VoltsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PhaseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SerialNumTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ModelTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            Nullable<bool> result = openFileDlg.ShowDialog();
            //openFileDlg.Multiselect = true;
            openFileDlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (result == true)
            {
                try
                {
                    ImageSource imgsource = new BitmapImage(new Uri(openFileDlg.FileName));
                    ItemImageBox.Source = imgsource;
                    item.SetImageUrl(Globals.CopyFileToFolder(openFileDlg.FileName));
                }
                catch
                {
                    string messageBoxText = "There was an issue rendering your image. Please pick a valid file.";
                    string caption = "Invalid Image Warning";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning; //MessageBoxImage.YesNoCancel; -allows yes, no and cancel button to be displayed on dialog box
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
            
        }

        private void RackComboBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void RackComboBox_DropDownClosed(object sender, EventArgs e)
        {

        }
        private void DisplayRacksInComboBox()
        {           
            RackComboBox.DisplayMemberPath = "_Key";
            RackComboBox.SelectedValuePath = "_Value";
            for (int i = 0; i < Globals.AllRacks.Count(); i++)
            {
                RackBoxPairs.Add(new ComboBoxPairs(Globals.AllRacks[i].Name, Globals.AllRacks[i].guid.ToString()));
                

                
                //ComboBoxItem comboItem = new ComboBoxItem();
                //comboItem.Tag = Globals.AllRacks[i].guid.ToString();
                //comboItem.Content = Globals.AllRacks[i].Name;
                //RackComboBox.Items.Add(comboItem);
            }
            RackComboBox.ItemsSource = RackBoxPairs;
            //RackComboBox.SelectedItem = 
        }
        public void SelectRack()
        {
            //foreach (ComboBoxItem comboItem in RackComboBox.Items)
            //{
            //    if (comboItem.IsSelected == true)
            //    {
                    ComboBoxPairs cbp = (ComboBoxPairs)RackComboBox.SelectedItem;
                    item.RackId = cbp._Key;
                    item.RackGuid = Guid.Parse(cbp._Value);
                    //item.RackId = comboItem.Content.ToString();
                    //item.RackGuid = Guid.Parse(comboItem.Tag.ToString());
            //    }
            //}
        }

        private void ModsButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.NavigationService.Navigate(home);
        }
        private void ItemImageBox_RightClick(object sender, RoutedEventArgs e)
        {
                var thumb = e.Source as UIElement;
                var transform = thumb.RenderTransform as RotateTransform;
                transform.Angle += 90;
                if (transform.Angle > 360)
                {
                    transform.Angle -= 360;
                }
                item.ImageRotation = transform.Angle;
        }
        private void RemoveImageButton_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Are you sure you want to remove this image?" + " " + item.ImageUrl;
            string caption = "Deleting Image Warning";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning; //MessageBoxImage.YesNoCancel; -allows yes, no and cancel button to be displayed on dialog box
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button
                    // ...
                    item.ImageUrl = Globals.DefaultImage;
                    ItemImageBox.Source = new BitmapImage(new Uri(item.ImageUrl, UriKind.Relative));
                    var thumb = ItemImageBox;
                    var transform = thumb.RenderTransform as RotateTransform;
                    transform.Angle = item.ImageRotation;
                    break;
                case MessageBoxResult.No:
                    // User pressed No button
                    // ...
                    break;
            }

        }

        private void DefaultNote_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(DefaultNote.Text != "" || DefaultNote.Text != " " || DefaultNote.Text != null)
            {
                
            }
        }
    }
}
