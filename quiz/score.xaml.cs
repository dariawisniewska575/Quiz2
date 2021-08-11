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
using System.Windows.Shapes;

namespace quiz
{
    /// <summary>
    /// Logika interakcji dla klasy score.xaml
    /// </summary>
    public partial class score : Page
    {
            

        public score()
        {
            InitializeComponent();
        }
        public score(int pkt, int max)
        {
            InitializeComponent();
            Score.Text = "To już koniec quizu. Twój wynik to: " + pkt.ToString() + "/" + max.ToString() ;
            StreamWriter SW;
            SW = File.AppendText(@"data\score.txt");
            SW.WriteLine("pkt");
            SW.WriteLine(pkt.ToString());
            SW.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter SW;
            SW = File.AppendText(@"data\score.txt");
            SW.WriteLine("imie");
            SW.WriteLine(name.Text);
            SW.Close();
            Application.Current.Shutdown();

        }
    }
}
