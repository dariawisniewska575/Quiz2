using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace quiz
{
    public class Database
    {
        public string Question { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
        public int Score { get; set; }
        public Database()
        {
            Question = "";
            AnswerA = "";
            AnswerB = "";
            AnswerC = "";
            AnswerD = "";
            CorrectAnswer = "";
            Score = 0;


        }
        public Database(string question, string a, string b, string c, string d, string correct, int score)
        {
            Question = question;
            AnswerA = a;
            AnswerB = b;
            AnswerC = c;
            AnswerD = d;
            CorrectAnswer = correct;
            Score = score;
        }

    }
}
