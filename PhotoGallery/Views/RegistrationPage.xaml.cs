using PhotoGallery.ViewModels;

namespace PhotoGallery.Views;
public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
        BindingContext = new RegistrationPageViewModel();
    }
}