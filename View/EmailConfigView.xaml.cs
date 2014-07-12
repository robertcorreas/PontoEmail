using Catel.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for EmailConfigView.xaml
    /// </summary>
    public partial class EmailConfigView : DataWindow
    {
        public EmailConfigView()
            : base(new EmailConfigViewModel(), DataWindowMode.Custom)
        {
            InitializeComponent();
        }
    }
}