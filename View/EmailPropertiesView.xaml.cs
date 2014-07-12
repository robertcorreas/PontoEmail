using Catel.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    ///     Interaction logic for EmailPropertiesView.xaml
    /// </summary>
    public partial class EmailPropertiesView : DataWindow
    {
        public EmailPropertiesView() : base(new EmailPropertiesViewModel(), DataWindowMode.Custom)
        {
            InitializeComponent();
        }
    }
}