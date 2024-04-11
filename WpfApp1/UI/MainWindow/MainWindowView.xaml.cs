
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Windows;

namespace UI.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {

        public MainWindowView(Model model)
        {
            MainWindowViewModel(model);

            InitializeComponent();
        }
    }
}