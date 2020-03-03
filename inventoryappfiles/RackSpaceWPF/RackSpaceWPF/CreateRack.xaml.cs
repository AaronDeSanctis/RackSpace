using Microsoft.Win32;
using RackSpaceWPF.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for CreateRack.xaml
    /// </summary>
    public partial class CreateRack : Page
    {
        Rack rack = new Rack();
        
        public CreateRack()
        {
            InitializeComponent();
            ImageSource imgsource = new BitmapImage(new Uri(rack.Image,UriKind.Relative));
            RackImageBox.Source = imgsource;
        }
        private void IsGroundOrCuldesacCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CreateNewRackButton_Click(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text != "")
            {
                rack.Name = IdTextBox.Text;
                rack.ChooseGuid();
                rack.IsVacant = true;
                var thumb = RackImageBox;
                var transform = thumb.RenderTransform as RotateTransform;
                rack.ImageRotation = transform.Angle;
                SQLDatabase.CreateRack(rack);
                CustomizeRacks customRack = new CustomizeRacks();
                this.NavigationService.Navigate(customRack);
            }
            else
            {
                string messageBoxText = "All fields with red dot must be filled out to continue.";
                string caption = "Data Entry Warning";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning; //MessageBoxImage.YesNoCancel; -allows yes, no and cancel button to be displayed on dialog box
                MessageBox.Show(messageBoxText, caption, button, icon);
                //MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                //switch (result)
                //{
                //    case MessageBoxResult.Yes:
                //        // User pressed Yes button
                //        // ...
                //        break;
                //    case MessageBoxResult.No:
                //        // User pressed No button
                //        // ...
                //        break;
                //    case MessageBoxResult.Cancel:
                //        // User pressed Cancel button
                //        // ...
                //        break;
                //}
            }
        }
        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            bool? result = openFileDlg.ShowDialog();
            //openFileDlg.Multiselect = true;
            openFileDlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (result == true)
            {
                ImageSource imgsource = new BitmapImage(new Uri(openFileDlg.FileName));
                RackImageBox.Source = imgsource;
                rack.SetImageUrl(Globals.CopyFileToFolder(openFileDlg.FileName));
            }
            else
            {
                if(rack.Image == null || rack.Image == "")
                {
                    RackImageBox.Source = new BitmapImage(new Uri(Globals.DefaultImage, UriKind.Relative));
                }
                
            }
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
        public void RackImageBox_RightClick(object sender, MouseButtonEventArgs e)
        {
            var thumb = e.Source as UIElement;
            var transform = thumb.RenderTransform as RotateTransform;
            transform.Angle += 90;
            if(transform.Angle > 360)
            {
                transform.Angle -= 360;
            }
            rack.ImageRotation = transform.Angle;
        }
    }
}
