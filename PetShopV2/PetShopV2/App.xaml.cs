using PetShopV2.Models;
using PetShopV2.Services;
using Xamarin.Forms;

namespace PetShopV2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<GenericRepo<Product>>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}