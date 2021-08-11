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
    /// Logika interakcji dla klasy DatabaseOfQuestions.xaml
    /// </summary>
    public partial class DatabaseOfQuestions : Page
    {
        public List<Database> db;
        public Database dba;
        

        public DatabaseOfQuestions()
        {
            InitializeComponent();
            
        }        
        public DatabaseOfQuestions(List<Database> db)
        {
            InitializeComponent();
            this.db = db;

            dg.Columns.Add(new DataGridTextColumn() { Header = "Pytanie", Binding = new Binding("Question") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Odpowiedź A", Binding = new Binding("AnswerA") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Odpowiedź B", Binding = new Binding("AnswerB") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Odpowiedź C", Binding = new Binding("AnswerC") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Odpowiedź D", Binding = new Binding("AnswerD") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Poprawna", Binding = new Binding("CorrectAnswer") });

            dg.AutoGenerateColumns = false;
            dg.ItemsSource = this.db;
        }

        public DatabaseOfQuestions(object data) : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            
            var AddQue = new AddQuestion();
            if (AddQue.ShowDialog() == true)
            {
                db.Add(AddQue.dba);
                
                dg.Items.Refresh();
            }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {

            var path2 = @"data\pliki.txt";
                StreamWriter SW= new StreamWriter(path2);
            
            string[] lines = File.ReadAllLines(@"data\plik.txt");
            if (dg.SelectedItem is Database)
            {


                
                for (int i = 0; i < db.Count(); i++)
                {
                    if (i==dg.SelectedIndex)
                    {
                        for(int j=0; j<lines.Length; j++)
                        {
                            if(lines[j]==db[i].Question)
                            {
                               // lines[j] = j.ToString();
                               
                                for (int k = j - 2; k< ((i+1)*14); k++)
                                {
                                    lines[k] = null;
                                }
                                    
                            }
                        }
                        /*var ln = SR.ReadLine();
                        while (!SR.EndOfStream)
                        {
                            if (ln == db[i].Question)
                            {
                                

                                while (ln != "eoq")
                                {
                                    ln = " ";
                                }
                                
                            }
                        }*/
                    }
                }
                //   var path = @"plik.txt";
                //  File.Delete(path);
                var path = @"data\plik.txt";
                File.Delete(path);
                foreach (var k in lines)
                {
                    SW.WriteLine(k);
                }
                SW.Close();
                 File.Move(path2, path);
                db.Remove((Database)dg.SelectedItem);
                dg.Items.Refresh();
                


            }

            }

        private void Instruction_Click(object sender, RoutedEventArgs e)
        {
            Instruction instruction = new Instruction();
            this.NavigationService.Navigate(instruction);
        }

        private void ChangeText_Click(object sender, RoutedEventArgs e)
        {
            ChangeText changeText = new ChangeText();
            this.NavigationService.Navigate(changeText);
        }

        private void Ready_Click(object sender, RoutedEventArgs e)
        {
            Start start = new Start();
            this.NavigationService.Navigate(start);
        }

        private void scoreWindow_Click(object sender, RoutedEventArgs e)
        {
            scoreWindow sWindow = new scoreWindow();
            this.NavigationService.Navigate(sWindow);
        }
    }
    }

