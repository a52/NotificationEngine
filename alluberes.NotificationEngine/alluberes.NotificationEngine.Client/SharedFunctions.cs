using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alluberes.NotificationEngine.Client
{
    static class SharedFunctions
    {

        #region Constants and Variables

        // const string REGISTRY_USER_ROOT = @"HKEY_CURRENT_USER\Software\NotificationEngine";
        //const string REGISTRY_USER_ROOT = "HKEY_CURRENT_USER";
        const string REGISTRY_USER_ROOT = "HKEY_CURRENT_USER\\Software\\alluberes\\NotificationEngine\\";
        const string KN_EMAIL_SERVER = "EmailServer";
        const string KN_EMAIL_PORT = "EmailPort";
        const string KN_EMAIL_USERNAME = "EmailUserName";
        const string KN_EMAIL_PASSWORD = "EmailUserPassword";
        const string KN_EMAIL_ENABLESSL = "EmailEnableSSL";

        #endregion

        #region Send Email

        public static bool SendEmail(EmailModel emailModel)
        {
            var result = false;

            var userName = string.Empty;
            var password = string.Empty;
            var host = string.Empty;
            var port = 587;
            var enableSSL = true;

            
            userName = GetEmailUserName();
            password = GetEmailPassword();
            host = GetEmailServer();
            port = GetEmailPort();
            enableSSL = GetEmailEnableSSL();



            var emailClient = new System.Net.Mail.SmtpClient();

            // emailClient.DeliveryFormat = System.Net.Mail.SmtpDeliveryFormat.International;
            emailClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            emailClient.EnableSsl = enableSSL;
            emailClient.Host = host;
            emailClient.Port = port;
            emailClient.UseDefaultCredentials = false;

            emailClient.Credentials = new System.Net.NetworkCredential(userName, password);

            var mailFrom = new System.Net.Mail.MailAddress("alluberes@itla.edu.do", "Abnel Lluberes (Itla)");
            var mailTo = new System.Net.Mail.MailAddress("alluberes@alluberes.com", "Abnel Lluberes (personal)");
            var mailCC = new System.Net.Mail.MailAddress("alluberes@rightcodetechnologies.com", "Right Code Technologies");


            var message = new System.Net.Mail.MailMessage();
            message.From = mailFrom;
            message.To.Add(mailTo);
            message.CC.Add(mailCC);
            message.Subject = emailModel.Subject;
            message.Body = emailModel.Message;

            emailClient.Send(message);

            result = true;

            return result;
        }

        #endregion


        #region Registry

        #region get values

        public static string GetEmailServer()
        {
            var result = string.Empty;

            result = getRegistryValue<string>(KN_EMAIL_SERVER, "");

            return result;
        }

        public static int GetEmailPort()
        {
            var result = 587;

            result = getRegistryValue<int>(KN_EMAIL_PORT, result);



            return result;
        }


        public static string GetEmailUserName()
        {
            var result = string.Empty;

            result = getRegistryValue<string>(KN_EMAIL_USERNAME, "");

            return result;
        }


        public static string GetEmailPassword()
        {
            var result = string.Empty;

            result = getRegistryValue<string>(KN_EMAIL_PASSWORD, "");

            return result;
        }


        public static bool GetEmailEnableSSL()
        {
            var result = true;

            var response = getRegistryValue<int>(KN_EMAIL_ENABLESSL, 1);

            if (response.Equals(0))
                result = false;

            return result;
        }



        /// <summary>
        /// Read value from registry
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T getRegistryValue<T>(string keyName, T defaultValue)
        {
            T result = defaultValue;

            var response = Microsoft.Win32.Registry.GetValue(REGISTRY_USER_ROOT, keyName, defaultValue);
            if (response != null)
                result = (T)response;

            return result;
        }


        #endregion

        #region set values

        public static void SetEmailServer(string value)
        {
            setRegistryValue(KN_EMAIL_SERVER, value, Microsoft.Win32.RegistryValueKind.String);
        }

        public static void SetEmailPort(int value)
        {
            setRegistryValue(KN_EMAIL_PORT, value, Microsoft.Win32.RegistryValueKind.DWord);
        }

        public static void SetEmailUserName(string value)
        {
            setRegistryValue(KN_EMAIL_USERNAME, value, Microsoft.Win32.RegistryValueKind.String);
        }

        public static void SetEmailPassword(string value)
        {
            setRegistryValue(KN_EMAIL_PASSWORD, value, Microsoft.Win32.RegistryValueKind.String);
        }

        public static void SetEmailEnableSSL(bool value)
        {
            var intValue= 1;
            if (!value)
                intValue = 0;

            setRegistryValue(KN_EMAIL_ENABLESSL, intValue, Microsoft.Win32.RegistryValueKind.DWord);
        }

        public static bool setRegistryValue(string keyName, object value, Microsoft.Win32.RegistryValueKind registryValueKind)
        {
            var result = false;

            Microsoft.Win32.Registry.SetValue(REGISTRY_USER_ROOT, keyName, value, registryValueKind);

            result = true;

            return result;
        }



        #endregion



        public static bool setIntRegistryValue(string keyName, object value)
        {
            var result = setRegistryValue(keyName, value, Microsoft.Win32.RegistryValueKind.None);

            return result;
        }

        public static bool setStrRegistryValue(string keyName, object value)
        {
            var result = setRegistryValue(keyName, value, Microsoft.Win32.RegistryValueKind.ExpandString);

            return result;
        }


        public static int getIntRegistryValue(string keyName, int defaultValue = -1)
        {
            var result = getRegistryValue<int>(keyName, defaultValue);
            return result;
        }


        public static string getRegistryValue(string keyName, string defaultValue = "")
        {
            var result = getRegistryValue<string>(keyName, defaultValue);
            return result;
        }

        #endregion


    }
}
