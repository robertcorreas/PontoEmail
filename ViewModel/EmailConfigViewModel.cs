using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Input;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Model;

namespace ViewModel
{
    public class EmailConfigViewModel : ViewModelBase
    {
        #region Constructors

        public EmailConfigViewModel()
        {
            OnOk = new Command(Ok, CanOk);

            if (Catel.IoC.ServiceLocator.Default.IsTypeRegistered(typeof (EmailConfig)) || Catel.IoC.ServiceLocator.Default.IsTypeRegisteredAsSingleton(typeof (EmailConfig)))
            {
                SuspendValidation = true;

                var emailConfig = Catel.IoC.ServiceLocator.Default.ResolveType<EmailConfig>();
                Login = emailConfig.Login;
                Password = emailConfig.Password;
                Smtp = emailConfig.Smtp;
                Port = emailConfig.Port.ToString();
                IsSSL = emailConfig.IsSSL;

                SuspendValidation = false;
            }

        }

        #endregion Constructors

        #region Properties

        #region Login property

        public static readonly PropertyData LoginProperty = RegisterProperty("Login", typeof (string), string.Empty);

        public string Login
        {
            get { return GetValue<string>(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }

        #endregion Login property

        #region Password property

        public static readonly PropertyData PasswordProperty = RegisterProperty("Password", typeof (string),
            string.Empty);

        public string Password
        {
            get { return GetValue<string>(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        #endregion Password property

        #region SMTP property

        public static readonly PropertyData SmtpProperty = RegisterProperty("SMTP", typeof (string), string.Empty);

        public string Smtp
        {
            get { return GetValue<string>(SmtpProperty); }
            set { SetValue(SmtpProperty, value); }
        }

        #endregion SMTP property

        #region Port property

        public static readonly PropertyData PortProperty = RegisterProperty("Port", typeof (string), string.Empty);

        public string Port
        {
            get { return GetValue<string>(PortProperty); }
            set { SetValue(PortProperty, value); }
        }

        #endregion Port property

        #region IsSSL property

        public static readonly PropertyData IsSSLProperty = RegisterProperty("IsSSL", typeof (bool), true);

        public bool IsSSL
        {
            get { return GetValue<bool>(IsSSLProperty); }
            set { SetValue(IsSSLProperty, value); }
        }

        #endregion IsSSL property

        #endregion Properties

        #region Commands

        #region Ok Command

        public ICommand OnOk { get; private set; }

        private void Ok()
        {
            Catel.IoC.ServiceLocator.Default.RemoveAllTypes(typeof (EmailConfig));
            Catel.IoC.ServiceLocator.Default.RemoveAllInstances(typeof (EmailConfig));
            Catel.IoC.ServiceLocator.Default.RegisterInstance(new EmailConfig(Login, Password, Smtp, Convert.ToInt32(Port), IsSSL));
            CloseViewModel(true);
        }

        private bool CanOk()
        {
            return !HasErrors;
        }

        #endregion Ok Command

        #endregion Commands

        #region Validation

        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            Validate(LoginProperty, Login, validationResults, EmailConfigValidator.ValidateLogin);
            Validate(PasswordProperty, Password, validationResults, EmailConfigValidator.ValidatePassword);
            Validate(SmtpProperty, Smtp, validationResults, EmailConfigValidator.ValidateSmtp);
            Validate(PortProperty, Port, validationResults, EmailConfigValidator.ValidatePort);

            base.ValidateFields(validationResults);
        }

        protected override void ValidateBusinessRules(List<IBusinessRuleValidationResult> validationResults)
        {
            if (!HasErrors)
            {
                try
                {
                    var emailConfig = new EmailConfig(Login, Password, Smtp, Convert.ToInt32(Port), IsSSL);
                    SmtpClient client = emailConfig.GetSmtpClient();
                    client.Send(new MailMessage(Login, Login, "Test email for PontoEmail app", string.Empty));
                }
                catch (Exception)
                {
                    validationResults.Add(BusinessRuleValidationResult.CreateError("Connection test failed."));
                }
            }

            base.ValidateBusinessRules(validationResults);
        }

        #endregion Validation
    }
}