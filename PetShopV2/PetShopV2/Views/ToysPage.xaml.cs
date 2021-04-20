using PetShopV2.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetShopV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToysPage : ContentPage
    {
        private ToysViewModel _toysViewModel;

        public ToysPage()
        {
            InitializeComponent();
            BindingContext = _toysViewModel = new ToysViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _toysViewModel.OnAppearing();
        }
    }
}