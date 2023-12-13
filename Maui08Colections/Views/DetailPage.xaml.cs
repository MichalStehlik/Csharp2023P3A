namespace Maui08Colections.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage()
	{
		InitializeComponent();
        BindingContext = (Application.Current.MainPage! as AppShell).MVM;
    }

    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..", true, new Dictionary<string, object> { });
    }
}