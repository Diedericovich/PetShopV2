﻿namespace PetShopV2.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new PetShopV2.App());
        }
    }
}