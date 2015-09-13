﻿using MediaAirNX.Logic;
using MediaAirNX.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace MediaAirNX
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public event EventHandler med;

        Image image = new Image();
        ImageBrush myBrush = new ImageBrush();
        string mediaUri=null;
        TimeSpan _position;
        DispatcherTimer _timer = new DispatcherTimer();

        public event PropertyChangedEventHandler PropertyChanged; // событие для проверки изменения свойства

        


        public MainWindow()
        {
            InitializeComponent();

            MediaAirNX.config.Default.SettingsSaving += InitializeFullscreanWindow;  /*подписка на событие сохранения настроек*/
            med += updMusicc;  /*подписка на событие обновления содержимого медиаэлемента и последующего его запуска*/

            InitializeFullscreanWindow(this, EventArgs.Empty);  //вызов иницилизации параметров раскрытия на весь экран
            InitializeImage();
            InitializeMediaelement();
            InitializeTimerForSlider();
        }

        



        #region Медиакнопка
        bool tmp;   /*отвечает за воспроизедение*/
        private void ButtonAutostartmusic_Click(object sender, RoutedEventArgs e)
        {
            //med(sender, e);
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
        #endregion

        #region Методы для иницилизации и подписки на события
        private void updMusicc(object sender, EventArgs e)
        {
            elementMedia.Source = new Uri(StaticEventsClass.MediaSource);
            elementMedia.Play();

        }   //обновление содержимого медиаэлемента (STRING URI)
        private void InitializeFullscreanWindow(object sender, EventArgs e)
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
        private void InitializeImage()
        {
            image.Source = new BitmapImage(new Uri("pack://application:,,,/Media/anime_girl.jpg"));
            myBrush.ImageSource = image.Source;
            myBrush.Stretch = Stretch.UniformToFill;
            MaineWindow.Background = myBrush;
        }// иницилизация картинки фона главной формы
        private void InitializeMediaelement()
        {
            elementMedia.Source = new Uri(@"E:\Music\Death Note OST\Death Note Original Soundtrack I/01. Hideki Taniuchi - Death Note.mp3");
            elementMedia.Play();
        }
        private void InitializeTimerForSlider()
        {
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += new EventHandler(ticktock);
            _timer.Start();
        }
        #endregion

        #region Кнопки меню
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
            //  if (col1.Width != new GridLength(0, GridUnitType.Star) || GridMenu.Visibility == Visibility.Visible)
            if (GridMenu.Visibility == Visibility.Visible)
            {
                col1.Width = new GridLength(0, GridUnitType.Star);
                buttonHideMenu.Opacity = 100;
                buttonHideMenu.Foreground.Opacity = 100;
                buttonHideMenu.Background.Opacity = 100;
                buttonHideMenu.Width = 38;
                buttonHideMenu.Background = new SolidColorBrush(Color.FromArgb(100, 85, 57, 103));
                GridMenu.Visibility = Visibility.Collapsed;

            }
            else
            {
                buttonHideMenu.Background = new SolidColorBrush(Color.FromArgb(5, 13, 172, 57));
                col1.Width = new GridLength(180, GridUnitType.Auto);
                buttonHideMenu.Opacity = 0.5;
                buttonHideMenu.Foreground.Opacity = 0.5;
                buttonHideMenu.Background.Opacity = 0.1;
                buttonHideMenu.Width = 33;
                GridMenu.Visibility = Visibility.Visible;
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
        #endregion


        #region Для слайдера (прогрессбара проигрывания)
        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            _position = elementMedia.NaturalDuration.TimeSpan;
            sliderSeek.Minimum = 0;
            sliderSeek.Maximum = _position.TotalSeconds;
        }
        private void sliderSeek_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
                     
        //    MessageBox.Show("ssa");
            int pos = Convert.ToInt32(sliderSeek.Value);
            elementMedia.Position = new TimeSpan(0, 0, 0, pos, 0);
        }

        void ticktock(object sender, EventArgs e)
        {
            sliderSeek.Value = elementMedia.Position.TotalSeconds;
        }
        #endregion

        #region Что-то временное и ненужное
        private void buttonAllHide_Click(object sender, RoutedEventArgs e)
        {
            if (GridMenu.Visibility == Visibility.Visible) { GridMenu.Visibility = Visibility.Collapsed; Frame.Visibility = Visibility.Collapsed; }
            else { GridMenu.Visibility = Visibility.Visible; Frame.Visibility = Visibility.Visible; }
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //-----------------------------

            //переход в полноэкранный режим //ну ну)))
        }   //Ненужные методы
        private void sliderSeek_LostMouseCapture(object sender, MouseEventArgs e)
        {
            TimeSpan time = new TimeSpan(0, 0, Convert.ToInt32(Math.Round(sliderSeek.Value))); //отлавливаем позицию на которую нужно перемотать трек, для двойного щелчка
            elementMedia.Position = time; //устанавливаем новую позицию для трека
        }
        #endregion


    }


}
