using System;
using System.Collections.Generic;
using System.IO;
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
using WS3.ViewModels;

namespace WS3
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

        private void Window_Closed(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("offer.txt");
            foreach (var item in MainWindowViewModel.Right)
            {
                sw.WriteLine($"{item.Type},{item.Unit},{item.Cost},{item.DB}");
            }
            sw.Close();
        }      
    }
}
