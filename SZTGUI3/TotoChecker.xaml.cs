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
using System.Windows.Shapes;

namespace SZTGUI3
{
    /// <summary>
    /// Interaction logic for TotoChecker.xaml
    /// </summary>
    public partial class TotoChecker : Window
    {
        Quiz quiz;
        public TotoChecker(Quiz quiz)
        {
            InitializeComponent();
            this.quiz = quiz;
            question.Content = this.quiz.Question;
            answerA.Content = this.quiz.Answers[0];
            answerB.Content = this.quiz.Answers[1];
            answerC.Content = this.quiz.Answers[2];
            answerD.Content = this.quiz.Answers[3];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (quiz.CorrectAnswer)
            {
                case 0:
                    this.DialogResult = rButtonA.IsChecked;
                    break;
                case 1:
                    this.DialogResult = rButtonB.IsChecked;
                    break;
                case 2:
                    this.DialogResult = rButtonC.IsChecked;
                    break;
                case 3:
                    this.DialogResult = rButtonD.IsChecked;
                    break;
                default:
                    this.DialogResult = false;
                    break;
            }
        }
    }
}
