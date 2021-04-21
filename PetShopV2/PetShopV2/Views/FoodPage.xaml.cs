using PetShopV2.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetShopV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodPage : ContentPage
    {
        private FoodViewModel _foodViewModel;

        public FoodPage()
        {
            InitializeComponent();

            BindingContext = _foodViewModel = new FoodViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _foodViewModel.OnAppearing();
        }
    }
}