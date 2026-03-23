using System.Windows;

namespace DeviceInsight
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Battery_Health_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.BatteryHealth());
        }
    }
}