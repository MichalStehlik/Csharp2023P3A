using Maui08Colections.Models;
using Maui08Colections.ViewModels;

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
            var selectedItem = lstList.SelectedItem as ShoppingItem;
            if (selectedItem != null)
            {
                Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object> { ["Item"] = selectedItem });
            }
            
        }

        private void lstList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as ShoppingItem;
            if (selectedItem != null)
            {
                Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object> { ["Item"] = selectedItem });
            }
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (BindingContext is MainViewModel)
            {
                var vm = BindingContext as MainViewModel;
                if (vm.Selected != null) 
                {
                    vm.UpdateCommand.Execute(vm.Selected);
                }
            }
        }
    }
}