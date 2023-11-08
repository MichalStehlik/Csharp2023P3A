namespace Maui05Binding
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void sliValue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblValue.Text = e.NewValue.ToString();
        }
    }
}