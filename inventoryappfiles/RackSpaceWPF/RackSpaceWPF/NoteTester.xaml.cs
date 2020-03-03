using RackSpaceWPF.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RackSpaceWPF
{
    /// <summary>
    /// Interaction logic for NoteTester.xaml
    /// </summary>
    public partial class NoteTester : Page
    {
        List<Note> Notes = new List<Note>();
        public NoteTester()
        {
            InitializeComponent();
            CreateDefaultNote();
        }
        public void CreateDefaultNote()
        {
            TextBox defaultBox = new TextBox();
            defaultBox.MinLines = 2;
            defaultBox.Tag = "0";
            defaultBox.Text = "Enter text here...";
            defaultBox.Margin = new Thickness(10);
            defaultBox.Background = new SolidColorBrush(Colors.LightGray);
            defaultBox.AcceptsTab = true;
            defaultBox.AcceptsReturn = true;
            defaultBox.FontSize = 16;
            defaultBox.Foreground = new SolidColorBrush(Colors.SlateGray);
            defaultBox.MaxLength = 8000;
            defaultBox.TextWrapping = TextWrapping.Wrap;
            defaultBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            defaultBox.SpellCheck.IsEnabled = true;
            defaultBox.MaxLines = 4;
            defaultBox.GotFocus += RemoveText;
            defaultBox.LostFocus += AddText;
            defaultBox.TextChanged += ChangeText;
            //defaultBox.GotFocus += GotFocus.EventHandle(RemoveText);
            //defaultBox.LostFocus += LostFocus.EventHandle(AddText);
            NotePanel.Children.Add(defaultBox);
            Button reply = new Button();
            reply.Tag = "1";
            reply.Content = "Reply";
            reply.FontSize = 22;
            reply.Foreground = new SolidColorBrush(Colors.White);
            reply.Click += new RoutedEventHandler(Reply_Click);
            reply.Background = new SolidColorBrush(Colors.Transparent);
            reply.Width = 60;
            reply.HorizontalAlignment = HorizontalAlignment.Right;
            reply.Visibility = Visibility.Collapsed;
            NotePanel.Children.Insert(int.Parse(reply.Tag.ToString()), reply);
            Button save = new Button();
            save.Tag = "2";
            save.Content = "Save";
            save.FontSize = 22;
            save.Foreground = new SolidColorBrush(Colors.White);
            save.Click += new RoutedEventHandler(Save_Click);
            save.Background = new SolidColorBrush(Colors.Transparent);
            save.Width = 60;
            save.HorizontalAlignment = HorizontalAlignment.Right;
            save.Visibility = Visibility.Collapsed;
            NotePanel.Children.Insert(int.Parse(save.Tag.ToString()), save);
            Label time = new Label();
            time.Tag = "3";
            time.Content = "Date";
            time.FontSize = 22;
            time.Foreground = new SolidColorBrush(Colors.White);
            time.Background = new SolidColorBrush(Colors.Transparent);
            time.Width = 250;
            time.HorizontalAlignment = HorizontalAlignment.Right;
            time.Visibility = Visibility.Collapsed;
            NotePanel.Children.Insert(int.Parse(time.Tag.ToString()), time);
            Button cancel = new Button();
            cancel.Tag = "4";
            cancel.Content = "Cancel";
            cancel.FontSize = 22;
            cancel.Foreground = new SolidColorBrush(Colors.White);
            cancel.Click += new RoutedEventHandler(Cancel_Click);
            cancel.Background = new SolidColorBrush(Colors.Transparent);
            cancel.Width = 60;
            cancel.HorizontalAlignment = HorizontalAlignment.Right;
            cancel.Visibility = Visibility.Collapsed;
            NotePanel.Children.Insert(int.Parse(save.Tag.ToString()), cancel);
        }
        void Reply_Click(object sender, RoutedEventArgs e)
        {
            Button sourceBox = e.Source as Button;
            TextBox targetBox = NotePanel.Children.OfType<TextBox>().Where(x => x.Tag.ToString() == (int.Parse(sourceBox.Tag.ToString()) - 1).ToString()).FirstOrDefault();
            TextBox defaultBox = new TextBox();
            defaultBox.Tag = int.Parse(targetBox.Tag.ToString()) + 5;
            defaultBox.Text = "Enter text here...";
            defaultBox.Margin = new Thickness(50, 10, 10, 10);
            defaultBox.Background = new SolidColorBrush(Colors.LightGray);
            defaultBox.AcceptsTab = true;
            defaultBox.AcceptsReturn = true;
            defaultBox.FontSize = 16;
            defaultBox.Foreground = new SolidColorBrush(Colors.SlateGray);
            defaultBox.MaxLength = 8000;
            defaultBox.TextWrapping = TextWrapping.Wrap;
            defaultBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            defaultBox.SpellCheck.IsEnabled = true;
            defaultBox.MinLines = 1;
            defaultBox.MaxLines = 4;
            defaultBox.GotFocus += RemoveText;
            defaultBox.LostFocus += AddText;
            defaultBox.TextChanged += ChangeText;
            NotePanel.Children.Insert(int.Parse(defaultBox.Tag.ToString()), defaultBox);
            Button reply = new Button();
            reply.Tag = (int.Parse(defaultBox.Tag.ToString()) + 1).ToString();
            reply.Content = "Reply";
            reply.FontSize = 22;
            reply.Foreground = new SolidColorBrush(Colors.White);
            reply.Click += new RoutedEventHandler(Reply_Click);
            reply.Background = new SolidColorBrush(Colors.Transparent);
            reply.Width = 60;
            reply.HorizontalAlignment = HorizontalAlignment.Right;
            reply.Visibility = Visibility.Collapsed;
            NotePanel.Children.Insert(int.Parse(reply.Tag.ToString()), reply);
            Button save = new Button();
            save.Tag = (int.Parse(defaultBox.Tag.ToString()) + 2).ToString();
            save.Content = "Save";
            save.FontSize = 22;
            save.Foreground = new SolidColorBrush(Colors.White);
            save.Click += new RoutedEventHandler(Save_Click);
            save.Background = new SolidColorBrush(Colors.Transparent);
            save.Width = 60;
            save.HorizontalAlignment = HorizontalAlignment.Right;
            save.Visibility = Visibility.Collapsed;
            NotePanel.Children.Insert(int.Parse(save.Tag.ToString()), save);
            Label time = new Label();
            time.Tag = (int.Parse(defaultBox.Tag.ToString()) + 3).ToString();
            time.Content = "Date";
            time.FontSize = 22;
            time.Foreground = new SolidColorBrush(Colors.White);
            time.Background = new SolidColorBrush(Colors.Transparent);
            time.Width = 250;
            time.HorizontalAlignment = HorizontalAlignment.Right;
            time.Visibility = Visibility.Collapsed;
            NotePanel.Children.Insert(int.Parse(time.Tag.ToString()), time);
            Button cancel = new Button();
            cancel.Tag = (int.Parse(defaultBox.Tag.ToString()) + 4).ToString();
            cancel.Content = "Cancel";
            cancel.FontSize = 22;
            cancel.Foreground = new SolidColorBrush(Colors.White);
            cancel.Click += new RoutedEventHandler(Cancel_Click);
            cancel.Background = new SolidColorBrush(Colors.Transparent);
            cancel.Width = 60;
            cancel.HorizontalAlignment = HorizontalAlignment.Right;
            cancel.Visibility = Visibility.Collapsed;
            NotePanel.Children.Insert(int.Parse(cancel.Tag.ToString()), cancel);
        }
        void Save_Click(object sender, RoutedEventArgs e)
        {
            Button save = e.Source as Button;
            TextBox targetBox = NotePanel.Children.OfType<TextBox>().Where(x => x.Tag.ToString() == (int.Parse(save.Tag.ToString()) - 2).ToString()).FirstOrDefault();
            Label time = NotePanel.Children.OfType<Label>().Where(x => x.Tag.ToString() == (int.Parse(save.Tag.ToString()) + 1).ToString()).FirstOrDefault();
            Button reply = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(save.Tag.ToString()) - 1).ToString()).FirstOrDefault();
            Button cancel = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(save.Tag.ToString()) + 2).ToString()).FirstOrDefault();
            time.Visibility = Visibility.Visible;
            reply.Visibility = Visibility.Visible;
            save.Visibility = Visibility.Collapsed;
            cancel.Visibility = Visibility.Collapsed;
            targetBox.IsReadOnly = true;
            Note note = new Note();
            note.Text = targetBox.Text;
            note.TimeStamp = DateTime.Now;
            time.Content = note.TimeStamp.ToString();
            Notes.Add(note);
            //note.guid = 

        }
        void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Button cancel = e.Source as Button;           
            Label time = NotePanel.Children.OfType<Label>().Where(x => x.Tag.ToString() == (int.Parse(cancel.Tag.ToString()) - 1).ToString()).FirstOrDefault();
            Button reply = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(cancel.Tag.ToString()) - 3).ToString()).FirstOrDefault();
            Button save = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(cancel.Tag.ToString()) - 2).ToString()).FirstOrDefault();
            TextBox targetBox = NotePanel.Children.OfType<TextBox>().Where(x => x.Tag.ToString() == (int.Parse(cancel.Tag.ToString()) - 4).ToString()).FirstOrDefault();
            cancel.Visibility = Visibility.Collapsed;
            time.Visibility = Visibility.Collapsed;
            reply.Visibility = Visibility.Collapsed;
            save.Visibility = Visibility.Collapsed;
            targetBox.Text = "Enter text here...";

        }

        public void RemoveText(object sender, RoutedEventArgs e)
        {
            TextBox myTxtbx = e.Source as TextBox;
            //Button reply = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(myTxtbx.Tag.ToString()) + 1).ToString()).FirstOrDefault();
            //Button save = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(myTxtbx.Tag.ToString()) + 2).ToString()).FirstOrDefault();
            //Label time = NotePanel.Children.OfType<Label>().Where(x => x.Tag.ToString() == (int.Parse(myTxtbx.Tag.ToString()) + 3).ToString()).FirstOrDefault();
            //Button cancel = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(myTxtbx.Tag.ToString()) + 4).ToString()).FirstOrDefault();
            if (myTxtbx.Text == "Enter text here...")
            {
                myTxtbx.Text = "";
            }
        }

        public void AddText(object sender, RoutedEventArgs e)
        {
            TextBox myTxtbx = e.Source as TextBox;            
            //Button reply = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(myTxtbx.Tag.ToString()) + 1).ToString()).FirstOrDefault();
            //Button save = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(myTxtbx.Tag.ToString()) + 2).ToString()).FirstOrDefault();
            //Label time = NotePanel.Children.OfType<Label>().Where(x => x.Tag.ToString() == (int.Parse(myTxtbx.Tag.ToString()) + 3).ToString()).FirstOrDefault();
            //Button cancel = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(myTxtbx.Tag.ToString()) + 4).ToString()).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(myTxtbx.Text))
                myTxtbx.Text = "Enter text here...";
        }
        public void ChangeText(object sender, RoutedEventArgs e)
        {
            TextBox myTxtbx = e.Source as TextBox;
            //Button reply = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(myTxtbx.Tag.ToString()) + 1).ToString()).FirstOrDefault();
            Button save = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(myTxtbx.Tag.ToString()) + 2).ToString()).FirstOrDefault();
            //Label time = NotePanel.Children.OfType<Label>().Where(x => x.Tag.ToString() == (int.Parse(myTxtbx.Tag.ToString()) + 3).ToString()).FirstOrDefault();
            Button cancel = NotePanel.Children.OfType<Button>().Where(x => x.Tag.ToString() == (int.Parse(myTxtbx.Tag.ToString()) + 4).ToString()).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(myTxtbx.Text) != true && myTxtbx.Text != "Enter text here...")
            {
                cancel.Visibility = Visibility.Visible;
                save.Visibility = Visibility.Visible;
            }
            else
            {
                cancel.Visibility = Visibility.Collapsed;
                save.Visibility = Visibility.Collapsed;
            }               
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.NavigationService.Navigate(home);
        }
    }
}
