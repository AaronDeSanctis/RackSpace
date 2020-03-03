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
    /// Interaction logic for ViewItem.xaml
    /// </summary>
    public partial class ViewItem : Page
    {
        public ViewItem(Item item)
        {
            InitializeComponent();
            NameTextBox.Text = item.Name;
            SerialNumTextBox.Text = item.SerialNum;
            IsUnitCheckBox.IsChecked = item.IsUnit;
            VoltsTextBox.Text = item.Volts;
            PhaseTextBox.Text = item.Phase;
            ImageSource imgsource = new BitmapImage(new Uri(item.GetImageUrl()));
            ItemImageBox.Source = imgsource;
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
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

        private void IsUnitCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
