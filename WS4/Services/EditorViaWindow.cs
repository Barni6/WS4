using WS3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS3.Services
{
    public class TrooperEditorViaWindow : IEditorService
    {
        public void Edit(Work trooper)
        {
            new TrooperEditorWindow(trooper).ShowDialog();
        }
    }
}
