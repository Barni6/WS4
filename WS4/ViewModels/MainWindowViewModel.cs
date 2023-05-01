using WS3.Logic;
using WS3.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WS3.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IWorkLogic logic;
        public static ObservableCollection<Work> Left { get; set; }
        public static ObservableCollection<Work> Right { get; set; }

        private Work selectedFromLeft;
        public Work SelectedFromLeft
        {
            get { return selectedFromLeft; }
            set
            {
                SetProperty(ref selectedFromLeft, value);
                (AddToWorkCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditWorkCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private Work selectedFromRight;
        public Work SelectedFromRight
        {
            get { return selectedFromRight; }
            set
            {
                SetProperty(ref selectedFromRight, value);
                (RemoveFromWorkCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand LoadWorksCommand { get; set; }
        public ICommand AddToWorkCommand { get; set; }
        public ICommand RemoveFromWorkCommand { get; set; }
        public ICommand EditWorkCommand { get; set; }
        public ICommand AddWorkCommand { get; set; }

        public int AllCost
        {
            get
            {
                return logic.AllCost;
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<IWorkLogic>())
        {

        }

        public MainWindowViewModel(IWorkLogic logic)
        {
            this.logic = logic;
            Left = new ObservableCollection<Work>();
            Right = new ObservableCollection<Work>();
          
            logic.SetupCollections(Left, Right);


            LoadWorksCommand = new RelayCommand(
                () => logic.LoadWorks(Left)
                );

            AddToWorkCommand = new RelayCommand(
                () => logic.AddToRight(SelectedFromLeft),
                () => SelectedFromLeft != null
                );

            RemoveFromWorkCommand = new RelayCommand(
                () => logic.RemoveFromRight(SelectedFromRight),
                () => SelectedFromRight != null
                );

            EditWorkCommand = new RelayCommand(
                () => logic.EditWork(SelectedFromLeft),
                () => SelectedFromLeft != null
                );


            AddWorkCommand = new RelayCommand(
                () => logic.AddWork(SelectedFromLeft)
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "WorkInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AllCost");
            });
        }
    }
}
