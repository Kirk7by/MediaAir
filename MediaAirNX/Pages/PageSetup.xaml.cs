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

namespace MediaAirNX.Pages  //страница настроек
{
    /// <summary>
    /// Логика взаимодействия для PageSetup.xaml
    /// </summary>
    public partial class PageSetup : Page
    {
        public PageSetup()
        {
            InitializeComponent();
            IntitilizateButtonFullscrean();
            ItitilizateButtonPatch();
        }

        private void ItitilizateButtonPatch()
        {
            ButtonPatch.Content = MediaAirNX.config.Default.PatchMediaXMLFile;
        }
        private void IntitilizateButtonFullscrean()
        {
            if (MediaAirNX.config.Default.FullScreen == true)
            {
                ButtonFullscrean.Background = new SolidColorBrush(Color.FromArgb(100, 13, 172, 57));
            }
            else
            {
                ButtonFullscrean.Background = new SolidColorBrush(Color.FromArgb(21, 71, 18, 50));
            }
        }   /*иницилизация кнопки на весь экран*/

        private void ButtonFullscrean_Click(object sender, RoutedEventArgs e)   /*событие нажатия кнопки на весь экран*/
        {
            if (MediaAirNX.config.Default.FullScreen != true)
            {
                MediaAirNX.config.Default.FullScreen = true;
            }
            else
            {
                MediaAirNX.config.Default.FullScreen = false;
            }   
            IntitilizateButtonFullscrean();
        }

        private void ButtonSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            MediaAirNX.config.Default.Save();
        }   /*событие нажатия кнопки сохранить настроки*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPatch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPatch__mp3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
