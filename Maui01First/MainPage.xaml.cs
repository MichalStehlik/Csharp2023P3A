namespace Maui01First
{
    public partial class MainPage : ContentPage
    {
        private int _value = 7;
        public MainPage()
        {
            InitializeComponent();
            lblCounter.Text = _value.ToString();
        }

        private void btnDown_Clicked(object sender, EventArgs e)
        {
            lblCounter.Text = (--_value).ToString();
            RedrawUI();
        }

        private void btnUp_Clicked(object sender, EventArgs e)
        {
            lblCounter.Text = (++_value).ToString();
            RedrawUI();
        }

        private void btnSet0_Clicked(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                _value = Convert.ToInt32((sender as Button).Text);
                lblCounter.Text = _value.ToString();
                RedrawUI();
            }
        }

        private void RedrawUI()
        {
            if (_value <= 0)
            {
                btnDown.IsEnabled = false;
            }
            else
            {
                btnDown.IsEnabled = true;
            }
            if (_value >= 100)
            {
                btnUp.IsEnabled = false;
            }
            else
            {
                btnUp.IsEnabled = true;
            }
        }
    }
}