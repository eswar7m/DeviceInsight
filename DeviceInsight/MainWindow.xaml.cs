using System.Windows;

namespace DeviceInsight
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Views.Home());
        }
    }
}