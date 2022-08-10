namespace ShoppingUI;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        this.BindingContext = new LoginViewModel(this.Navigation);
    }
}