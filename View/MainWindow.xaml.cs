using System.Windows;

namespace View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowEmailConfigView_OnClick(object sender, RoutedEventArgs e)
        {
            new EmailConfigView().ShowDialog();
        }

        private void ShowEmailPropertiesView_OnClick(object sender, RoutedEventArgs e)
        {
            new EmailPropertiesView().ShowDialog();
        }
    }
}