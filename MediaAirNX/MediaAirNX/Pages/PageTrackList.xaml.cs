using MediaAirNX.Logic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace MediaAirNX.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTrackList.xaml
    /// </summary>
    public partial class PageTrackList : Page
    {
        public PageTrackList()
        {
            InitializeComponent();
            initializeDataGrid();
        }

        private void тесткнопка_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/MediaAirNX;component/Pages/PageDetailSong.xaml", UriKind.RelativeOrAbsolute));
        }

        void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility =
                      row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
        }
        private void initializeDataGrid()
        {
            List<serializableCollections> cats = new List<serializableCollections>
           { new serializableCollections() { Artist = "limb Bizkit", NameSong = "Sylvester", Patch = "8", Progress = "66", ImageFilePath = Convert.ToString(new Uri("pack://application:,,,/Media/optionsGirlsSmoke.jpg")) }};
            
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
    }
}
