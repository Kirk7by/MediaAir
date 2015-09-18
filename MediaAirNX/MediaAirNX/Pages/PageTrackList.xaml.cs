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
        public event EventHandler mainwindow1ButtonmediaLoaded;
        private List<IObserver> _observer;
        

        public PageTrackList()
        {
            InitializeComponent();
            initializeDataGrid();
            mediaElement3.Source = new Uri(@"E:\Music\Death Note OST\Death Note Original Soundtrack I/01. Hideki Taniuchi - Death Note.mp3");
            
        }

        private void тесткнопка_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/MediaAirNX;component/Pages/PageDetailSong.xaml", UriKind.RelativeOrAbsolute));
        }

        void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            object MusicFilePath = ((Button)sender).CommandParameter;
            StaticEventsClass.MediaSource = MusicFilePath.ToString();
            mainwindow1ButtonmediaLoaded(this,EventArgs.Empty);
       //     notify();


            //       mediaElement3.Source = new Uri(MusicFilePath.ToString());
            //      mediaElement3.Play();
            //  MessageBox.Show(MusicFilePath.ToString());
        }
        private void initializeDataGrid()
        {
            List<serializableCollections> cats = new List<serializableCollections>
           { new serializableCollections() { Artist = "limb Bizkit", NameSong = "Sylvester", Patch = "8", Progress = "66", ImageFilePath = Convert.ToString(new Uri("pack://application:,,,/Media/img2.jpg")), MusicFilePath = Convert.ToString(new Uri(@"E:\Music\Death Note OST\Death Note Original Soundtrack I/01. Hideki Taniuchi - Death Note.mp3")) },
            new serializableCollections() { Artist = "fd", NameSong = "Sylvester", Patch = "8", Progress = "66", ImageFilePath = Convert.ToString(new Uri(@"E:\Music\Billy Talent - 2003-2012 - Дискография\Singles\2009 - Rusted From The Rain (Single)/Front.jpg")), MusicFilePath = Convert.ToString(new Uri(@"L:\10.07.2015/Killswitch Engage - My Curse - full acoustic cover.mp4")) }};

            /* cats.Add(new serializableCollections("Sylvester", "8", "25"));
             cats.Add(new serializableCollections("Syl545ester", "545", "25"));
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
    }
}
