namespace Maui08Colections.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = (Application.Current.MainPage! as AppShell).MVM;
        }

        private void btnCreate_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(CreatePage), true, new Dictionary<string, object>{ });
        }

        private void btnDetail_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object> { });
        }
    }
}