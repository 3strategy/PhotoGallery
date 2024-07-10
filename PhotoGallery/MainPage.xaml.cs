namespace PhotoGallery
{
    public partial class MainPage : ContentPage
    {
        int ind = 0;
        string[] images = { "dotnet_bot.png", "dotnet_bot2.png" , "dotnet_bot3.png" , "dotnet_bot4.png" };
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnUpBtnClicked(object sender, EventArgs e)
        {
            ind = (ind - 1 + 4) % 4; // overcome % modulus discrepency.
            ChangingCarImg.Source = images[ind];
        }

        private void OnDownBtnClicked(object sender, EventArgs e)
        {
            ChangingCarImg.Source = images[++ind % 4];
        }
    }

}
