using DeviceInsight.ViewModels;
using System.Windows.Controls;

namespace DeviceInsight.Views
{
    public partial class BatteryHealth : Page
    {
        public BatteryHealth()
        {
            InitializeComponent();
            this.DataContext = new BatteryHealthViewModel();
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
