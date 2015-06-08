using MediaAirNX.Pages;
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
            MediaAirNX.config.Default.SettingsSaving+= InitializeFullscreanWindow;  /*подписка на событие сохранения настроек*/
            InitializeFullscreanWindow(this, EventArgs.Empty);  //вызов иницилизации параметров раскрытия на весь экран
        }

       
        bool tmp;   /*отвечает за воспроизедение*/
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


        
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //-----------------------------
            
            //переход в полноэкранный режим //ну ну)))
        }


        public void InitializeFullscreanWindow(object sender, EventArgs e)
        {
            if (MediaAirNX.config.Default.FullScreen == true)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowStyle = WindowStyle.ThreeDBorderWindow;
                this.WindowState = WindowState.Normal;
            }
        } //иницилизация перехода в полноэкранный режим и обратно
        private void button_setup_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = null;
            Frame.NavigationService.RemoveBackEntry();
            Frame.Source = new Uri("/MediaAirNX;component/Pages/PageSetup.xaml", UriKind.RelativeOrAbsolute);
        }   //нажатие на кнопку настроек
        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }   //нажатие на кнопку выход
    }
}
