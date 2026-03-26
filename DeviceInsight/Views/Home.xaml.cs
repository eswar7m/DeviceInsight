using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DeviceInsight.Views
{
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Battery_Health_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BatteryHealth());
        }
    }
}
