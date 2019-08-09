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
    /// Interaction logic for wLoadFIle.xaml
    /// </summary>
    public partial class wLoadFIle : Window
    {
        public wLoadFIle()
        {
            InitializeComponent();
        }

        private void BtnBuscarArchivo_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "CSV File|*.csv|Text File|*.txt|All File|*.*";
            fileDialog.DefaultExt = "*.csv";

            Nullable<bool> dialogOK = fileDialog.ShowDialog();

            if (dialogOK == true)
            {
                string sFileName = "";
                sFileName = fileDialog.FileName;
                this.txtFilePath.Text = sFileName;
            }
        }
    }
}
