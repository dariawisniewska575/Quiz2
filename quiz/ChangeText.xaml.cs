using System;
using System.Collections.Generic;
using System.IO;
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

namespace quiz
{
    /// <summary>
    /// Logika interakcji dla klasy ChangeText.xaml
    /// </summary>
    public partial class ChangeText : Page
    {
        Start s = new Start();
        StreamReader read = new StreamReader("data/text.txt");
        public ChangeText()
        {
            InitializeComponent();
            hehe.Text = read.ReadToEnd();
            read.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            StreamWriter text = new StreamWriter("data/text.txt");
            s.cos.Text = hehe.Text;
            text.Write(hehe.Text);
            text.Close();
           
            this.NavigationService.Navigate(s);

        }





    }
}
