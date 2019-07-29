using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace alluberes.NotificationEngine.Client
{
    /// <summary>
    /// Interaction logic for wConfig.xaml
    /// </summary>
    public partial class wConfig : Window
    {

        #region Mis funciones

        /// <summary>
        /// Cargar los valores por defecos para email
        /// </summary>
        private void LoadEmailConfiguration()
        {
            //this.txtEmailServer.Text = SharedFunctions.getRegistryValue("EmailServer", "");
            //this.txtEmailServerPort.Text = SharedFunctions.getIntRegistryValue("EmailPort", 587).ToString();
            //this.txtEmailUser.Text = SharedFunctions.getRegistryValue("EmailUser", "");
            //this.txtEmailPassword.Password = SharedFunctions.getRegistryValue("EmailPassword", "");

            //this.cbEmailUserSSL.IsChecked = (bool)SharedFunctions.getRegistryValue<bool>("EmailUseSSL", true);

            this.txtEmailServer.Text = SharedFunctions.GetEmailServer();
            this.txtEmailUser.Text = SharedFunctions.GetEmailUserName();
            this.txtEmailPassword.Password = SharedFunctions.GetEmailPassword();

            this.txtEmailServerPort.Text = SharedFunctions.GetEmailPort().ToString();
            this.cbEmailUserSSL.IsChecked = SharedFunctions.GetEmailEnableSSL();


        }



        private void SaveEmailConfig()
        {
            SharedFunctions.SetEmailServer(this.txtEmailServer.Text);

            SharedFunctions.SetEmailUserName(this.txtEmailUser.Text);
            SharedFunctions.SetEmailPassword(this.txtEmailPassword.Password);

            SharedFunctions.SetEmailEnableSSL(this.cbEmailUserSSL.IsChecked.Value);
            int emailPort = 587;
            if (int.TryParse(this.txtEmailServerPort.Text, out emailPort))
                SharedFunctions.SetEmailPort(emailPort);

        }


        #endregion


        public wConfig()
        {
            InitializeComponent();
            LoadEmailConfiguration();
        }

        private void CmdClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void CmdEmailSave_Click(object sender, RoutedEventArgs e)
        {
            SaveEmailConfig();
        }
    }
}
