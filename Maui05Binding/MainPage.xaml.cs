using Maui05Binding.Models;

namespace Maui05Binding
{
    public partial class MainPage : ContentPage
    {
        private Models.Person _borivoj;
        public Models.Person Borivoj { get; set; }
        public MainPage()
        {
            Borivoj = new Models.Person { Firstname = "Bořivoj", Age=10};
            InitializeComponent();
            lblPersonName.BindingContext = Borivoj;
            lblPersonName.SetBinding(Label.TextProperty, nameof(Models.Person.Firstname));
            lblPersonAge.BindingContext = Borivoj;
            lblPersonAge.SetBinding(Label.TextProperty, nameof(Models.Person.Age));
            entPersonName.BindingContext = Borivoj;
            entPersonName.SetBinding(Entry.TextProperty, nameof(Models.Person.Firstname));
        }

        private void sliValue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblValue.Text = e.NewValue.ToString();
        }
    }
}