using System.Windows;

namespace UI.UiWindow.MainWindow
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