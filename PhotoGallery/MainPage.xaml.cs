namespace PhotoGallery
{
    public partial class MainPage : ContentPage
    {
        private int ind;

        public int Ind
        {
            get { return ind; }
            set
            {   // link UI logic to the lowest common denominator which is Ind property
                if (value >= 0 && value < lenImg)
                {
                    if (value > ind)
                        UpBtn2.IsEnabled = true;
                    else if (value < ind)
                        DownBtn2.IsEnabled = true;

                    if (value == 0)
                        UpBtn2.IsEnabled = false;
                    else if (value == lenImg - 1)
                        DownBtn2.IsEnabled = false;

                    ind = value;
                    ChangingCarImg.Source = images[ind];
                }
                // in all other cases ignoring the set.
            }
        }

        string[] images = { "dotnet_bot.png", "dotnet_bot2.png", "dotnet_bot3.png", "dotnet_bot4.png" };
        int lenImg;
        public MainPage()
        {
            InitializeComponent();
            lenImg = images.Length;
        }

        private void OnUpBtnClicked(object sender, EventArgs e) => 
            Ind = (Ind - 1 + lenImg) % lenImg; // overcome % modulus discrepency.

        private void OnDownBtnClicked(object sender, EventArgs e) => Ind = (Ind + 1) % lenImg;

        private void OnUpBtn2Clicked(object sender, EventArgs e)
        {
            OnUpBtnClicked(sender, e); // This implementation relies on the existance 
                                       // of the side by side buttons. A stand alone code would be a bit differnt.
        }

        private void OnDownBtn2Clicked(object sender, EventArgs e)
        {
            OnDownBtnClicked(sender, e);
        }
    }

}
