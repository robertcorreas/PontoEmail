using System.Windows.Input;
using Catel.IoC;
using Catel.MVVM;
using Model;

namespace ViewModel
{
    public class EmailConfigViewModel : ViewModelBase
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string SMPT { get; set; }

        public int? Port { get; set; }

        public bool IsSSL { get; set; }

        public ICommand OnOk { get; private set; }

        public EmailConfigViewModel()
        {
            OnOk = new Command(Ok);
        }

        private void Ok()
        {
            Catel.IoC.ServiceLocator.Default.RemoveAllTypes(typeof(EmailConfig));
            Catel.IoC.ServiceLocator.Default.RemoveAllInstances(typeof(EmailConfig));
            Catel.IoC.ServiceLocator.Default.RegisterInstance(new EmailConfig(Login,Password,SMPT,Port.Value,IsSSL));
        }
    }
}