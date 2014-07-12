using Catel.IoC;
using Catel.MVVM;
using Model;
using System.Windows.Input;

namespace ViewModel
{
    public class EmailPropertiesViewModel : ViewModelBase
    {
        public EmailPropertiesViewModel()
        {
            OnOk = new Command(Ok);
        }

        public string SenderEmail { get; set; }

        public string SenderName { get; set; }

        public string ReceiverEmail { get; set; }

        public string ReceiverName { get; set; }

        public string Subject { get; set; }

        public ICommand OnOk { get; private set; }

        private void Ok()
        {
            Catel.IoC.ServiceLocator.Default.RemoveAllTypes(typeof(EmailProperties));
            Catel.IoC.ServiceLocator.Default.RemoveAllInstances(typeof(EmailProperties));
            Catel.IoC.ServiceLocator.Default.RegisterInstance(new EmailProperties(SenderEmail, SenderName, ReceiverEmail,
                ReceiverName, Subject));
            CloseViewModel(true);
        }
    }
}