using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        public Database dba;
        public AddQuestion()
        {
            InitializeComponent();
            if (dba != null)
            {
                AddedQuestion.Text = dba.Question;
                AddedAnswerA.Text = dba.AnswerA;
                AddedAnswerB.Text = dba.AnswerB;
                AddedAnswerC.Text = dba.AnswerC;
                AddedAnswerD.Text = dba.AnswerD;
                AddedCorrect.Text = dba.CorrectAnswer;              
            }
            this.dba = dba ?? new Database();
           
        }
        public AddQuestion(object data) : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(AddedCorrect.Text, @"^[a-d]$"))
            {
                MessageBox.Show("Poprawna odpowiedz z zakresu a-d");
                return;
            }
            if(AddedQuestion.Text == ""|| AddedAnswerA.Text == "" || AddedAnswerB.Text == "" || AddedAnswerC.Text == "" || AddedAnswerD.Text == "" || AddedCorrect.Text == "")
            {
                MessageBox.Show("Należy wprowadzić dane");
                return;
            }
            dba.Question = AddedQuestion.Text;
            dba.AnswerA = AddedAnswerA.Text;
            dba.AnswerB = AddedAnswerB.Text;
            dba.AnswerC = AddedAnswerC.Text;
            dba.AnswerD = AddedAnswerD.Text;
            dba.CorrectAnswer = AddedCorrect.Text;

            StreamWriter SW;
            SW = File.AppendText(@"data\plik.txt");
            SW.WriteLine("Pytanie");
            SW.WriteLine("Tresc");
            SW.WriteLine(dba.Question);
            SW.WriteLine("Odpa");
            SW.WriteLine(dba.AnswerA);
            SW.WriteLine("Odpb");
            SW.WriteLine(dba.AnswerB);
            SW.WriteLine("Odpc");
            SW.WriteLine(dba.AnswerC);
            SW.WriteLine("Odpd");
            SW.WriteLine(dba.AnswerD);
            SW.WriteLine("Poprawna");
            SW.WriteLine(dba.CorrectAnswer);
            SW.WriteLine("eoq");
            SW.Close();
            this.DialogResult = true;

        }
    }
}
