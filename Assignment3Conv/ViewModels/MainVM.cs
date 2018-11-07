using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Assignment3Conv.BL;
using Assignment3Conv.Models;
using Assignment3Conv.Views;

namespace Assignment3Conv.ViewModels
{
    public class MainVM : ObservableObject
    {
        private ObservableCollection<object> _childVMs;

        public ObservableCollection<object> ChildVMs
        {
            get => _childVMs;
            set => _childVMs = value;
        }

       //private static MainVM _instance = new MainVM();
       //public static MainVM Instance { get { return _instance; } }

        public MainVM()
        {
            _childVMs = new ObservableCollection<object>
            {
                new AddressVM(),
                new ClientVM(),
                new CompanyVM()
                //Instance,
                //((MainWindow)System.Windows.Application.Current.MainWindow)._vm
            };

        }
    }
}