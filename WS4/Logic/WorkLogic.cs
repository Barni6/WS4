using WS3.Models;
using WS3.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

namespace WS3.Logic
{
    public class WorkLogic : IWorkLogic
    {
        IList<Work> left;
        IList<Work> right;
        IMessenger messenger;
        IEditorService editorService;

        public WorkLogic(IMessenger messenger, IEditorService editorService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
        }

        public int AllCost
        {
            get
            {
                return right.Count == 0 ? 0 : right.Select(t => (t.Cost * t.Unit) * t.DB).Sum();
            }
        }


        public void SetupCollections(IList<Work> left, IList<Work> right)
        {
            this.left = left;
            this.right = right;
        }

        public void AddToRight(Work work)
        {
            right.Add(work.GetCopy());
            messenger.Send("Work added", "WorkInfo");
        }

        public void RemoveFromRight(Work work)
        {
            right.Remove(work);
            messenger.Send("Work removed", "WorkInfo");
        }

        public void EditWork(Work work)
        {
            editorService.Edit(work);
        }

        public void LoadWorks(ObservableCollection<Work> Left)
        {
            List<Work> works = File.ReadAllLines("works.txt")
               .Select(t => new Work(t.Split(',')[0], int.Parse(t.Split(',')[1]), int.Parse(t.Split(',')[2]), int.Parse(t.Split(',')[3]))).ToList();
           

            foreach (var work in works)
            {
                Left.Add(work);
            }
        }

        public void AddWork(Work work)
        {
            editorService.Edit(work);
        }

    }
}
