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
    /// Logika interakcji dla klasy scoreWindow.xaml
    /// </summary>
    public partial class scoreWindow : Page
    {
        public List<scoreClass> db;
        
        
        public scoreWindow()
        {
            InitializeComponent();

            var sr = new StreamReader(@"data\score.txt");


            db = new List<scoreClass>();

            scoreClass d = null;

            while (!sr.EndOfStream)
            {

                var ln = sr.ReadLine();
                if (ln == "pkt")
                {
                    d = new scoreClass();
                    ln = sr.ReadLine();

                    d.Points = ln;
                }

                else if (ln == "imie")
                {
                    ln = sr.ReadLine();

                    d.Name = ln;
                    if (ln == null)
                        break;



                    db.Add(d);
                    d = new scoreClass();
                }
                
            }

            sr.Close();

            

            dg.Columns.Add(new DataGridTextColumn() { Header = "Imie                     ", Binding = new Binding("Name") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Punkty      ", Binding = new Binding("Points") });

            dg.AutoGenerateColumns = false;
            dg.ItemsSource = this.db;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Start s = new Start();
            this.NavigationService.Navigate(s);
        }
    }
}
