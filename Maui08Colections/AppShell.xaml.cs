using Maui08Colections.ViewModels;
using Maui08Colections.Views;

namespace Maui08Colections
{
    public partial class AppShell : Shell
    {
        public MainViewModel MVM { get; set; } = new MainViewModel();
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CreatePage), typeof(CreatePage));
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        }
    }
}