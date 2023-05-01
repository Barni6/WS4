using WS3.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WS3.Logic
{
    public interface IWorkLogic
    {
        int AllCost { get; }

        public void LoadWorks(ObservableCollection<Work> Left);
        void AddToRight(Work work);
        void EditWork(Work work);
        void RemoveFromRight(Work work);
        void SetupCollections(IList<Work> left, IList<Work> right);
        void AddWork(Work work);
    }
}