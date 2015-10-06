using MediaAirNX.Logic;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace MediaAirNX.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTrackList.xaml
    /// </summary>
    public partial class PageTrackList : Page, IObservable
    {
        public event EventHandler<string> mainwindow1ButtonmediaLoaded;
        private List<IObserver> _observer;
        List<serializableCollections> cats = new List<serializableCollections>();

        public PageTrackList()
        {
            InitializeComponent();
            initializeDataGrid();
       //     mediaElement3.Source = new Uri(@"E:\Music\Death Note OST\Death Note Original Soundtrack I/01. Hideki Taniuchi - Death Note.mp3");
            
        }

        private void тесткнопка_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/MediaAirNX;component/Pages/PageDetailSong.xaml", UriKind.RelativeOrAbsolute));
        }

        void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            object MusicFilePath = ((Button)sender).CommandParameter;
      //      StaticEventsClass.MediaSource = MusicFilePath.ToString();
            mainwindow1ButtonmediaLoaded(this, MusicFilePath.ToString());
       //     notify();


            //       mediaElement3.Source = new Uri(MusicFilePath.ToString());
            //      mediaElement3.Play();
            //  MessageBox.Show(MusicFilePath.ToString());
        }
        private void initializeDataGrid()
        {
           // List<serializableCollections> cats = new List<serializableCollections>
            cats.Add(new serializableCollections() { Artist = "Limb Bizkvit", NameSong = "Sylvester", Patch = "8", Progress = "66", ImageFilePath = Convert.ToString(new Uri("pack://application:,,,/Media/img2.jpg")), MusicFilePath = Convert.ToString(new Uri(@"E:\Music\Death Note OST\Death Note Original Soundtrack I/01. Hideki Taniuchi - Death Note.mp3")) });
            cats.Add(new serializableCollections() { Artist = "fd", NameSong = "Sylvester", Patch = "8", Progress = "66", ImageFilePath = Convert.ToString(new Uri(@"E:\Music\Billy Talent - 2003-2012 - Дискография\Singles\2009 - Rusted From The Rain (Single)/Front.jpg")), MusicFilePath = Convert.ToString(new Uri(@"L:\10.07.2015/Killswitch Engage - My Curse - full acoustic cover.mp4")) });

            cats.Add(new serializableCollections() { Artist = "Limb Bizkvit", NameSong = "Sylvester", Patch = "8", Progress = "66", ImageFilePath = Convert.ToString(new Uri("pack://application:,,,/Media/img2.jpg")), MusicFilePath = Convert.ToString(new Uri(@"E:\Music\Death Note OST\Death Note Original Soundtrack I/01. Hideki Taniuchi - Death Note.mp3")) });
           /*  cats.Add(new serializableCollections("Syl545ester", "545", "25"));
             cats.Add(new serializableCollections("Sylv454545ster", "8", "2454554"));*/

            //   dataGrid.ItemsSource = cats;
            new MetodtSerializable().SerializableCollections(cats);
            dataGrid.ItemsSource = new MetodtSerializable().DeSerializableCollections();
            /*
                        using (Stream fStream = new FileStream("./SuperHumanInfo.xml", FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<serializableCollections>));
                            xmlFormat.Serialize(fStream, cats);
                            fStream.Close();
                        }


                        using (Stream fStream = new FileStream("./SuperHumanInfo.xml", FileMode.Open))
                        {
                            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<serializableCollections>));
                            cats = (List<serializableCollections>)xmlFormat.Deserialize(fStream);
                            fStream.Close();
                        }
                        dataGrid.ItemsSource = cats;
                        /* string xml = XmlUtility.Obj2XmlStr(obj, DataClass.XmlNamespace);
                         Console.WriteLine(xml);*/
            //  XmlSerializer xml = new XmlSerializer(typeof(SuperHuman));
            /* using (var fStream = new FileStream("./SuperHumanInfo.xml", FileMode.Create, FileAccess.Write, FileShare.None))
             {
                 xml.Serialize(fStream, superHuman);
             }*/
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        //реализация паттерна наблюдатель отправка уведомления
        public void registerobs(IObserver obs)
        {
            
            _observer.Add(obs);
        }
        public void notify()
        {
            foreach (var obs in _observer)
            {
                obs.update();
            }
        }

        private void butAddMusic_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;

    //        cats.Add(new serializableCollections() { Artist = "Limb Bizkvit", NameSong = "Sylvester", Patch = "8", Progress = "66", ImageFilePath = Convert.ToString(new Uri("pack://application:,,,/Media/img2.jpg")), MusicFilePath = Convert.ToString(new Uri(@"E:\Music\Death Note OST\Death Note Original Soundtrack I/01. Hideki Taniuchi - Death Note.mp3")) });
   //         dataGrid.ItemsSource= cats;

            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Музыкальные и видео файлы|*.mp3; *.mp2; *.wma; *.m4a; *.flac; *.wav; *.ogg; *.ogm; *.au; *.aif;*.avi; *.mp4; *.mkv; *.m4v; *.wmv;|Музыкальные файлы|*.mp3; *.mp2; *.wma; *.m4a; *.flac; *.wav; *.ogg; *.ogm; *.au; *.aif;|Видео файлы|*.avi; *.mp4; *.mkv; *.m4v; *.wmv; |All Files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            //    bool? result = openFileDialog.ShowDialog(this);
            //    System.Diagnostics.Process.Start("explorer", "C:\\");
            Nullable<bool> result=true;

            //  string[] filePaths = Directory.GetFiles(@"c:\");
            while (result == true)
            {
                result = openFileDialog.ShowDialog();
                if (result == false)
                    break;
                openfoldersAndFilesAdd(openFileDialog.FileNames);
            }
        }
        #region Operations in Explorer
        void openfoldersAndFilesAdd(string[] args)
        {
            foreach (string path in args)
            {
                if (File.Exists(path))
                {
                    // This path is a file
                    ProcessFile(path);
                    dataGrid.ItemsSource = null;
                    cats.Add(new serializableCollections() { Artist = "none", NameSong = "none", Patch = "none", Progress = "none", ImageFilePath = Convert.ToString(new Uri("pack://application:,,,/Media/img2.jpg")), MusicFilePath = path });
                    dataGrid.ItemsSource = cats;
                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    ProcessDirectory(path);
                }
                else
                {
           //         MessageBox.Show("{0} is not a valid file or directory."+ path);
                }
            }
        }
        public static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        // Insert logic for processing found files here.
        public static void ProcessFile(string path)
        {
    //        MessageBox.Show(path);

      //      cats.Add(new serializableCollections() { Artist = "Limb Bizkvit", NameSong = "Sylvester", Patch = "8", Progress = "66", ImageFilePath = Convert.ToString(new Uri("pack://application:,,,/Media/img2.jpg")), MusicFilePath = path });
        }
        #endregion
    }
}
