using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logika interakcji dla klasy start.xaml
    /// </summary>
    public partial class Start : Page
    {
        public List<Database> db;
        
            StreamReader text = new StreamReader(@"data\text.txt");
        public Start()
        {
            InitializeComponent();
            
            try
            {
                var sr = new StreamReader(@"data\plik.txt");


                db = new List<Database>();

                Database d = null;

                while (!sr.EndOfStream)
                {

                    var ln = sr.ReadLine();
                    if (ln == "Pytanie")
                        d = new Database();

                    else if (ln == "Tresc")
                    {
                        ln = sr.ReadLine();

                        d.Question = ln;
                        if (ln == null)
                            break;
                    }
                    else if (ln == "Odpa")
                    {
                        ln = sr.ReadLine();
                        d.AnswerA = ln;
                    }
                    else if (ln == "Odpb")
                    {
                        ln = sr.ReadLine();
                        d.AnswerB = ln;
                    }
                    else if (ln == "Odpc")
                    {
                        ln = sr.ReadLine();
                        d.AnswerC = ln;
                    }
                    else if (ln == "Odpd")
                    {
                        ln = sr.ReadLine();
                        d.AnswerD = ln;
                    }
                    else if (ln == "Poprawna")
                    {
                        ln = sr.ReadLine();
                        d.CorrectAnswer = ln;
                    }
                    else if (ln == "eoq")
                    {
                        db.Add(d);
                        d = new Database();
                    }
                }

                sr.Close();

            }
            catch
            {
                MessageBox.Show("Wystąpił problem z uruchomieniem aplikacji," +
                    " skontaktuj się z administratorem programu");
                Application.Current.Shutdown();
            }
            string line = text.ReadToEnd();
            cos.Text = line;
            text.Close();
           
        }

       

        private void start(object sender, RoutedEventArgs e)
        {
            try
            {
                Quiz quiz = new Quiz(db);
                this.NavigationService.Navigate(quiz);
            }
            catch
            {
                MessageBox.Show("Baza pytań jest pusta!");
                
            }

        }

        private void Database(object sender, RoutedEventArgs e)
        {
            DatabaseOfQuestions Base = new DatabaseOfQuestions(db);
            this.NavigationService.Navigate(Base);

        }
    }
}
