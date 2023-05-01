using WS3.Models;
using WS3.ViewModels;
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
using System.IO;

namespace WS3
{
    /// <summary>
    /// Interaction logic for TrooperEditorWindow.xaml
    /// </summary>
    public partial class TrooperEditorWindow : Window
    {
        public TrooperEditorWindow(Work work)
        {
            InitializeComponent();
            var vm = new EditorWindowViewModel();
            vm.Setup(work);
            this.DataContext = vm;
        }

        private void Vm_EditedDone(object? sender, EventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {       
            Work work = new Work(tb_name.Text,int.Parse(tb_unit.Text),int.Parse(tb_cost.Text),int.Parse(tb_db.Text));
            MainWindowViewModel.Left.Add(work);
            string line = $"\n{tb_name.Text},{tb_unit.Text},{tb_cost.Text},{tb_db.Text}";
            File.AppendAllText("works.txt", line);           
        }

       
    }
}
