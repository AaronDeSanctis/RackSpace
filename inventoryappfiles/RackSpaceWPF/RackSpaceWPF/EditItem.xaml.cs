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
    /// Interaction logic for EditItem.xaml
    /// </summary>
    public partial class EditItem : Page
    {
        private Item item = new Item();
        private int rackListIndex;
        public EditItem(Item ParamaterItem)
        {
            InitializeComponent();
            if (Globals.AllItems.Contains(ParamaterItem))
            {
                for (int i = 0; i < Globals.AllItems.Count; i++)
                {
                    if (ParamaterItem == Globals.AllItems[i])
                    {
                        item = ParamaterItem;
                        rackListIndex = i;
                    }
                }
                NameTextBox.Text = item.Name;
                ModelTextBox.Text = item.Model;
                SerialNumTextBox.Text = item.SerialNum;
                IsUnitCheckBox.IsChecked = item.IsUnit;
                VoltsTextBox.Text = item.Volts;
                PhaseTextBox.Text = item.Phase;
                if (item.GetImageUrl() != null)
                {
                    try
                    {
                        ImageSource imgsource = new BitmapImage(new Uri(item.GetImageUrl(), UriKind.Absolute));
                        //ImageSource imgsource = new BitmapImage(new Uri(item.GetImageUrl()));
                        ItemImageBox.Source = imgsource;
                    }
                    catch
                    {
                        ImageSource imgsource = new BitmapImage(new Uri(Globals.DefaultImage, UriKind.Relative));
                        ItemImageBox.Source = imgsource;
                    }
                }
                var thumb = ItemImageBox;
                var transform = thumb.RenderTransform as RotateTransform;
                transform.Angle = item.ImageRotation;

                DisplayRackComboBoxText();
            }
            DisplayRacksInComboBox();
            DisplayRackComboBoxText();
        }
        public void DisplayRackComboBoxText()
        {
            if (item.RackId != null || item.RackId != "")
            {
                foreach(Rack rack in Globals.AllRacks)
                {
                    if(rack.Name == item.RackId)
                    {
                        RackComboBox.SelectedItem = rack;
                    }
                }
            }
            else
            {
                RackComboBox.Text = "---Select Rack---";
            }
        }
        private void DisplayRacksInComboBox()
        {
            for (int i = 0; i < Globals.AllRacks.Count(); i++)
            {
                ComboBoxItem comboItem = new ComboBoxItem();
                comboItem.Tag = Globals.AllRacks[i].guid.ToString();
                comboItem.Content = Globals.AllRacks[i].Name;
                RackComboBox.Items.Add(comboItem);
            }
        }
        private void IsUnitCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (IsUnitCheckBox.IsChecked == false)
            {
                item.Model = ModelTextBox.Text;
                item.SerialNum = SerialNumTextBox.Text;
                item.Volts = VoltsTextBox.Text;
                item.Phase = PhaseTextBox.Text;
                item.Name = NameTextBox.Text;
                item.IsUnit = false;
                SelectRack();
                Globals.SaveItem(item);
                EditItemNonUnit eItemNonunit = new EditItemNonUnit(item);
                this.NavigationService.Navigate(eItemNonunit);
            }
        }
        public void SelectRack()
        {
            foreach (ComboBoxItem comboItem in RackComboBox.Items)
            {
                if (comboItem.IsSelected == true)
                {
                    item.RackId = comboItem.Content.ToString();
                    item.RackGuid = Guid.Parse(comboItem.Tag.ToString());
                }
            }
        }
        private void ModelTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SerialNumTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void VoltsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PhaseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EditImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            bool? result = openFileDlg.ShowDialog();
            //openFileDlg.Multiselect = true;
            openFileDlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (result == true)
            {
                ImageSource imgsource = new BitmapImage(new Uri(openFileDlg.FileName, UriKind.Absolute));
                ItemImageBox.Source = imgsource;
                item.SetImageUrl(Globals.CopyFileToFolder(openFileDlg.FileName));
            }
        }

        private void EditItemButton_Click(object sender, RoutedEventArgs e)
        {
            item.Model = ModelTextBox.Text;
            item.Volts = VoltsTextBox.Text;
            item.Phase = PhaseTextBox.Text;
            item.Name = NameTextBox.Text;
            item.SerialNum = SerialNumTextBox.Text;
            if (IsUnitCheckBox.IsChecked == true)
            {
                item.IsUnit = true;
            }
            else
            {
                item.IsUnit = false;
            }
            var thumb = ItemImageBox;
            var transform = thumb.RenderTransform as RotateTransform;
            item.ImageRotation = transform.Angle;
            SelectRack();
            Globals.SaveItem(item);
            UnitsAndItems unitsAndItems = new UnitsAndItems();
            this.NavigationService.Navigate(unitsAndItems);
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
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.NavigationService.Navigate(home);
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
        //public void ItemCompleteBar_ValueChanged(object sender, RoutedEventArgs e)
        //    {
        //    }
        public void RackComboBox_DropDownClosed(object sender, EventArgs e)
        {

        }
        public void RackComboBox_MouseDoubleClick(object sender, RoutedEventArgs e)
        {

        }
        private void ModsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RackComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
