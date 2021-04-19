using PetShopV2.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PetShopV2.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}