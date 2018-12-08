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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            search.Text = "http://www.google.com";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            try
            {
                KyWeb.Source = new Uri("http://www.google.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                KyWeb.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                KyWeb.GoForward();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string str;

        private void Button_Click_3(object sender, RoutedEventArgs e) {
            try
            {
                KyWeb.Source = new Uri("http://www." + search.Text);
                str = search.Text;
                History.Items.Add(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            str = search.Text;
            Bookmarks.Items.Add(str);
        }

        private void Bookmarks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Bookmarks.SelectedItem != null)
            {
                search.Text = Bookmarks.SelectedItem.ToString();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            dynamic doc = KyWeb.Document;
            dynamic htmlText = doc.documentElement.InnerHtml;
            string htmlstring = htmlText;

            sourceBox.Text = htmlstring;
        }
    }
}
