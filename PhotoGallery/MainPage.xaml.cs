namespace PhotoGallery
{
    public partial class MainPage : ContentPage
    {
        int ind = 0;
        string[] images = { "dotnet_bot.png", "dotnet_bot2.png" , "dotnet_bot3.png" , "dotnet_bot4.png" };
        int lenImg;
        public MainPage()
        {
            InitializeComponent();
            lenImg = images.Length;
        }

        private void OnUpBtnClicked(object sender, EventArgs e)
        {
            ind = (ind - 1 + lenImg) % lenImg; // overcome % modulus discrepency.
            ChangingCarImg.Source = images[ind];
        }

        private void OnDownBtnClicked(object sender, EventArgs e)
        {
            ChangingCarImg.Source = images[++ind % lenImg];
        }

        private void OnUpBtn2Clicked(object sender, EventArgs e)
        {
            if(ind >0)
            {  
                OnUpBtnClicked(sender, e); // This implementation relies on the existance 
                // of the side by side buttons. A stand alone code would be a bit differnt.
                if(ind ==0)
                    UpBtn2.IsEnabled = false;
            }
            DownBtn2.IsEnabled = true;

        }

        private void OnDownBtn2Clicked(object sender, EventArgs e)
        {
            if (ind < lenImg-1)
            {
                OnDownBtnClicked(sender, e); // This implementation relies on the existance 
                // of the side by side buttons. A stand alone code would be a bit differnt.
                if (ind == lenImg-1)
                    DownBtn2.IsEnabled = false;
            }
            UpBtn2.IsEnabled = true;
        }
    }

}
