using PetShopV2.Models;
using PetShopV2.ViewModels;
using Xamarin.Forms;

namespace PetShopV2.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}