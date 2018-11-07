using Assignment3Conv.ViewModels;
using System.Windows;

namespace Assignment3Conv.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainVM _vm;
        
        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainVM();
            this.DataContext = _vm;

        }
    }
}
