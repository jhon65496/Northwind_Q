using System.Windows;
using System.Windows.Input;
using Northwind.ViewModel;

namespace Northwind.UI.WPF
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

        /// <summary>
        /// This is not great as it breaks the no code behind approach aka Pure MVVM
        /// </summary>
        //private void OnCustomerDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    ((MainWindowViewModel)DataContext).ShowDetailsCommand.Execute(null);
        //}
    }
}
