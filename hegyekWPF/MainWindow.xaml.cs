using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using hegyekCLI;

namespace hegyekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Hegycsucs> hegycsucsok = new List<Hegycsucs>();
        public MainWindow()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("hegyek.csv"); // fájl beolvasása
            sr.ReadLine(); // fejléc átugrása
            while (!sr.EndOfStream)
            {
                hegycsucsok.Add(new Hegycsucs(sr.ReadLine()));
            }
            sr.Close();
            DataGrid1.ItemsSource = hegycsucsok;
            DataGrid1.Items.Refresh();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           
            int magassag = Convert.ToInt32(TextBox3.Text);
            if (magassag > 0 && magassag < 2000)
            {
                hegycsucsok.Add(new Hegycsucs($"{TextBox1.Text};{TextBox2.Text};{TextBox3.Text}"));
                DataGrid1.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nem megfelelő értékek!");
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("hegycsucsok2.csv");
                sw.WriteLine("Hegycsúcs neve; Hegység; Magasság;");
                for (int i = 0; i < hegycsucsok.Count; i++)
                {
                    sw.WriteLine(hegycsucsok[i].ToString());
                }
                sw.Close();
                MessageBox.Show("A mentés sikeresen megtörtént!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}