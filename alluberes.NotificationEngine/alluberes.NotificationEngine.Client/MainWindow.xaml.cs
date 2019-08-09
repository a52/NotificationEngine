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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace alluberes.NotificationEngine.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var emailModel = new EmailModel();

                emailModel.From = this.txtFrom.Text;
                emailModel.To = this.txtTo.Text;
                emailModel.Subject = this.txtSubject.Text;
                emailModel.Message = this.txtBody.Text;


                var result = SharedFunctions.SendEmail(emailModel);


                if (result)
                    MessageBox.Show("Mensaje enviaddo satisfactoriamente");
                else
                    MessageBox.Show("No fue posible enviar mensaje");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error enviado correo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CmdConfig_Click(object sender, RoutedEventArgs e)
        {
            var frmConfig = new wConfig();
            frmConfig.ShowDialog();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtFrom.Text = SharedFunctions.GetEmailUserName();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnLoadFile_Click(object sender, RoutedEventArgs e)
        {
            var frmLoadFile = new wLoadFIle();
            frmLoadFile.ShowDialog();
        }
    }
}
