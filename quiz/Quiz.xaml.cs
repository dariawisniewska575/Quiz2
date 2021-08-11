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
    /// Logika interakcji dla klasy questions.xaml
    /// </summary>
    public partial class Quiz : Page
    {

        public List<Database> db;
        public string poprawna;
        private int pkt=0;
        int i = 0;
        public Quiz()
        {

            InitializeComponent();

        }
        public Quiz(List<Database> databases)
        {
            InitializeComponent();
            db = databases;
            q.Text = db[i].Question;
            a.Text = db[i].AnswerA;
            b.Text = db[i].AnswerB;
            c.Text = db[i].AnswerC;
            d.Text = db[i].AnswerD;
            poprawna = db[i].CorrectAnswer;
        }
        public Quiz(object data) : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if ((rba.IsChecked == true && poprawna == "a") || (rbb.IsChecked == true && poprawna == "b")
                            || (rbc.IsChecked == true && poprawna == "c") || (rbd.IsChecked == true && poprawna == "d"))
            {
                pkt++;
                 
            }
            i++;
            Pb.Value += 100/db.Count;
            
            
            if (i == db.Count)
            {
                score Base = new score(pkt, db.Count);
                this.NavigationService.Navigate(Base);

            }
            else
            {
                q.Text = db[i].Question;
                a.Text = db[i].AnswerA;
                b.Text = db[i].AnswerB;
                c.Text = db[i].AnswerC;
                d.Text = db[i].AnswerD;
                poprawna = db[i].CorrectAnswer;
                rba.IsChecked = false;
                rbb.IsChecked = false;
                rbc.IsChecked = false;
                rbd.IsChecked = false;
            }
        }
        
            

        
    }
}
