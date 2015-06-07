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

namespace MediaAirNX
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            elementMedia.Play();
        }
        bool tmp, tmp1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAutostartmusic_Click(object sender, RoutedEventArgs e)
        {
            if (!tmp)
            {
                elementMedia.Pause();
                tmp = true;

            }
            else
            {
                elementMedia.Play();
                tmp = false;
            }
        }

        private void ButtonAutostartmusic_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            elementMedia.Stop();
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //-----------------------------
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
            //переход в полноэкранный режим
        }

        private void button_setup_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
