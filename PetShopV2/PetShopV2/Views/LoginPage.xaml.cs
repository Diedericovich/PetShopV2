using PetShopV2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetShopV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        //private void OnLoginClick(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrWhiteSpace(TxtMail.Text) && !string.IsNullOrWhiteSpace(TxtPass.Text))
        //    {
        //        Navigation.PushAsync(new LoginPage());
        //    }
        //}
    }
}