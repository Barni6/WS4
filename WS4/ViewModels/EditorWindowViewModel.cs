using WS3.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WS3.ViewModels
{
    public class EditorWindowViewModel
    {
        public Work Actual { get; set; }

        public void Setup(Work work)
        {
            this.Actual = work;
        }

        
        public EditorWindowViewModel()
        {
            
        }
    }
}
