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
    /// Interaction logic for EditRack.xaml
    /// </summary>
    public partial class EditRack : Page
    {
        private Rack rack = new Rack();
        private int rackListIndex;
        public EditRack(Rack ParamaterRack)
        {
            InitializeComponent();

            if (Globals.AllRacks.Contains(ParamaterRack))
            {
                for (int i = 0; i < Globals.AllRacks.Count; i++)
                {
                    if (ParamaterRack == Globals.AllRacks[i])
                    {
                        rack = ParamaterRack;
                        rackListIndex = i;
                    }
                }
                IdTextBox.Text = rack.Name;
                if (rack.GetImageUrl() != null)
                {
                    //try
                    //{
                    ImageSource imgsource = new BitmapImage(new Uri(rack.GetImageUrl()));
                    RackImageBox.Source = imgsource;
                    var thumb = RackImageBox;
                        var transform = thumb.RenderTransform as RotateTransform;
                        transform.Angle = rack.ImageRotation;
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("Issue with uploading Image.");
                    //}
                    
                }
                

                //ItemCompleteBar.Value = DetermineProgress();
                //DisplayRackComboBoxText();
            }
        }
        //public void DisplayRackComboBoxText()
        //{
        //if (item.RackId != null || item.RackId != "")
        //{
        //RackComboBox.Text = item.RackId;
        //}
        //else
        //{
        //RackComboBox.Text = "---Select Rack---";
        //}
        //}




        private void EditImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            Nullable<bool> result = openFileDlg.ShowDialog();
            //openFileDlg.Multiselect = true;
            openFileDlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (result == true)
            {
                ImageSource imgsource = new BitmapImage(new Uri(openFileDlg.FileName));
                RackImageBox.Source = imgsource;
                rack.SetImageUrl(Globals.CopyFileToFolder(openFileDlg.FileName));
                string VarString = rack.Image;
            }
        }

        private void EditRackButton_Click(object sender, RoutedEventArgs e)
        {
            rack.Name = IdTextBox.Text;
            if (SQLDatabase.UpdateRack(rack))
            {
                SQLDatabase.UpdateRack(rack);
                CustomizeRacks customizeRacks = new CustomizeRacks();
                this.NavigationService.Navigate(customizeRacks);
            }
            else
            {
                MessageBox.Show("Error");
            }
            
            
        }
        private void RackComboBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void RackComboBox_DropDownClosed(object sender, EventArgs e)
        {

        }
        private void RackImageBox_RightClick(object sender, RoutedEventArgs e)
        {
            var thumb = e.Source as UIElement;
            var transform = thumb.RenderTransform as RotateTransform;
            transform.Angle += 90;
            if (transform.Angle > 360)
            {
                transform.Angle -= 360;
            }
            rack.ImageRotation = transform.Angle;
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.NavigationService.Navigate(home);
        }
        private void RemoveImageButton_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Are you sure you want to remove this image?" + " " + rack.Image;
            string caption = "Deleting Image Warning";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning; //MessageBoxImage.YesNoCancel; -allows yes, no and cancel button to be displayed on dialog box
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button
                    // ...
                    rack.Image = Globals.DefaultImage;
                    RackImageBox.Source = new BitmapImage(new Uri(rack.Image, UriKind.Relative));
                    var thumb = RackImageBox;
                    var transform = thumb.RenderTransform as RotateTransform;
                    transform.Angle = rack.ImageRotation;
                    break;
                case MessageBoxResult.No:
                    // User pressed No button
                    // ...
                    break;
            }

        }
        private void ModsButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
