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
using static System.Collections.Specialized.BitVector32;

namespace Assignment_London_Underground_Ticketing_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Replace "WillsList" with your Custom List name in 2 places.
        // 1. Replace here
        private SulesList<Rider> Riders;
        //public WillsList<Rider> Riders;

        int numberOfRiders = 250; // Changes this to something higher than 100 to check your list is working

        public MainWindow()
        {
            InitializeComponent();
            InitializeRiders();
            cmbSearchStation.ItemsSource = Enum.GetValues(typeof(Station));

            //lvRiders.ItemsSource = Riders;

        } // MainWindow

        private void OnSearchStation(object sender, RoutedEventArgs e)
        {
            var searchStation = cmbSearchStation.SelectedIndex;

            // Enter code here to show all riders who started there ride from the selected station

            // Create a new list to store the matching riders
            SulesList<Rider> matchingRiders = new SulesList<Rider>();

            // Loop through the riders list
            for (int i = 0; i < Riders.Count; i++)
            {
                // Get the current rider
                Rider rider = Riders[i];
                // Check if the rider's start station matches the search station
                if (rider.StartStation == searchStation)
                {
                    // Add the rider to the matching list
                    matchingRiders.Add(rider);
                }
            }

            // Display the matching riders in the list box
            lvRiders.ItemsSource = matchingRiders.ToArray();

            // lvRiders.ItemsSource = YourReturnedResults;
        } // OnSearchStation

        private void OnShowActive(object sender, RoutedEventArgs e)
        {
            // Enter code here to display all riders currently riding the underground

            // Create a new list to store the active riders
            SulesList<Rider> activeRiders = new SulesList<Rider>();

            // Loop through the riders list
            for (int i = 0; i < Riders.Count; i++)
            {
                // Get the current rider
                Rider rider = Riders[i];
                // Check if the rider is active
                if (rider.IsActive)
                {
                    // Add the rider to the active list
                    activeRiders.Add(rider);
                }
            }

            // Display the active riders in the list box
            lvRiders.ItemsSource = activeRiders.ToArray();

            // lvRiders.ItemsSource = YourReturnedResults;
        } // OnShowActive

        private void OnClearList(object sender, RoutedEventArgs e)
        {
            lvFilteredRiders.Items.Clear();
        }

        private void InitializeRiders()
        {
            // 2. And here
            Riders = new SulesList<Rider>();
            //Riders = new WillsList<Rider>();
            Random rnd = new Random();
            HashSet<int> usedNumbers = new HashSet<int>();

            for (int i = 0; i < numberOfRiders; i++)
            {
                int uniqueNumber;
                do
                {
                    uniqueNumber = rnd.Next(100000000, 1000000000);
                }
                while (usedNumbers.Contains(uniqueNumber));

                usedNumbers.Add(uniqueNumber);

                Station stationOn = (Station)rnd.Next(Enum.GetNames(typeof(Station)).Length);
                Station stationOff = rnd.Next(100) < 30 ? Station.Active : (Station)rnd.Next(1, Enum.GetNames(typeof(Station)).Length);

                Riders.Add(new Rider(uniqueNumber, stationOn, stationOff));
            }

        } // Initialize Riders

    

    } //class

} // namespace