using MediaAirNX.Logic;
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
using System.Windows.Media.Animation;
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

        Image image = new Image();
        ImageBrush myBrush = new ImageBrush();
        


        public MainWindow()
        {
            InitializeComponent();

            elementMedia.Play();
            MediaAirNX.config.Default.SettingsSaving += InitializeFullscreanWindow;  /*подписка на событие сохранения настроек*/
            InitializeFullscreanWindow(this, EventArgs.Empty);  //вызов иницилизации параметров раскрытия на весь экран
            InitializeImage();
        }

        private void InitializeImage()
        {
            image.Source = new BitmapImage(new Uri("pack://application:,,,/Media/anime_girl.jpg"));
            myBrush.ImageSource = image.Source;
            myBrush.Stretch = Stretch.UniformToFill;
            MaineWindow.Background = myBrush;
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
            //swap Image

            image.Source = new BitmapImage(new Uri("pack://application:,,,/Media/optionsGirlsSmoke.jpg"));
            myBrush.ImageSource = image.Source;
            MaineWindow.Background = myBrush;
            
            
            Frame.Content = null;
            Frame.NavigationService.RemoveBackEntry();
            Frame.Source = new Uri("/MediaAirNX;component/Pages/PageSetup.xaml", UriKind.RelativeOrAbsolute);
        }   //нажатие на кнопку настроек
        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }   //нажатие на кнопку выход

        private void buttonHideMenu_Click(object sender, RoutedEventArgs e)
        {
            if (col1.Width != new GridLength(0, GridUnitType.Star))
            {
                col1.Width = new GridLength(0, GridUnitType.Star);
                buttonHideMenu.Opacity = 100;
                buttonHideMenu.Foreground.Opacity = 100;
                buttonHideMenu.Background.Opacity = 100;
                buttonHideMenu.Width = 38;
                buttonHideMenu.Background = new SolidColorBrush(Color.FromArgb(100, 85, 57, 103));
                
                
            }
            else
            {
                buttonHideMenu.Background = new SolidColorBrush(Color.FromArgb(5, 13, 172, 57));
                col1.Width = new GridLength(180, GridUnitType.Auto);
                buttonHideMenu.Opacity = 0.5;
                buttonHideMenu.Foreground.Opacity = 0.5;
                buttonHideMenu.Background.Opacity = 0.1;
                buttonHideMenu.Width = 33;
            }
        }

        private void button_Tracklist_Click(object sender, RoutedEventArgs e)
        {
            image.Source = new BitmapImage(new Uri("pack://application:,,,/Media/img1.jpg"));
            myBrush.ImageSource = image.Source;
            MaineWindow.Background = myBrush;
            Frame.Content = null;
            Frame.NavigationService.RemoveBackEntry();
            Frame.Source = new Uri("/MediaAirNX;component/Pages/PageTrackList.xaml", UriKind.RelativeOrAbsolute);
            // new serializableCollections().Save();
           //  serializableCollections.Save();
        }

        private void button_Add_new_Click(object sender, RoutedEventArgs e)
        {
            image.Source = new BitmapImage(new Uri("pack://application:,,,/Media/img2.jpg"));
            myBrush.ImageSource = image.Source;
            MaineWindow.Background = myBrush;

            Frame.Content = null;
            Frame.NavigationService.RemoveBackEntry();
            Frame.Source = new Uri("/MediaAirNX;component/Pages/PageAddSongs.xaml", UriKind.RelativeOrAbsolute);
        }

        private void button_profile_Click(object sender, RoutedEventArgs e)
        {
            image.Source = new BitmapImage(new Uri("pack://application:,,,/Media/anime_girl.jpg"));
            myBrush.ImageSource = image.Source;
            MaineWindow.Background = myBrush;

            Frame.Content = null;
            Frame.NavigationService.RemoveBackEntry();
            Frame.Source = new Uri("/MediaAirNX;component/Pages/PageProfile.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
