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

namespace SZTGUI3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = "Legyen ön is milliomos";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Worker w = new Worker();
            List<KeyValuePair<string, List<KeyValuePair<string, bool>>>> questions = w.GetQuestions();
            foreach (var item in questions)
            {
                Label l = new Label();
                l.Tag = new Quiz(item);
                l.Margin = new Thickness(20);
                l.Height = this.ActualHeight / 8;
                l.Width = this.ActualWidth / 8;
                l.Background = Brushes.LightBlue;
                l.MouseLeftButtonDown += L_Mouse;
                linuxMasterRace.Children.Add(l);
            }
            
        }
        private void L_Mouse(object sender, MouseButtonEventArgs e)
        {
            Label l = (sender as Label);
            Quiz q = (Quiz)l.Tag;
            TotoChecker tc = new TotoChecker(q);
            if (tc.ShowDialog() == true)
            {
                l.Background = Brushes.Green;
            }
            else
            {
                l.Background = Brushes.LightPink;
            }
            l.IsEnabled = false;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OurTimer.StopTimer();
        }
    }
}
