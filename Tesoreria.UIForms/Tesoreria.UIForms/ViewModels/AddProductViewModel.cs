using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tesoreria.Common.Models;
using Tesoreria.Common.Services;
using Xamarin.Forms;

namespace Tesoreria.UIForms.ViewModels
{
   public  class AddProductViewModel:BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        private readonly ApiServices apiService;
        

        public bool IsRunning
        {
            get => this.isRunning;
            set => this.SetValue(ref this.isRunning, value);
        }

        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetValue(ref this.isEnabled, value);
        }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Categoria { get; set; }

        public ICommand SaveCommand => new RelayCommand(this.Save);

        public AddProductViewModel()
        {
            this.apiService = new ApiServices();
            this.IsEnabled = true;
        }

        private async void Save()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a product name.",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Price))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a product price.",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Categoria))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a product Categoria.",
                    "Accept");
                return;
            }

            var price = decimal.Parse(this.Price);
            if (price <= 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "The price must be a number greather than zero.",
                    "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var product = new Product
            {

                Descripcion = this.Name,
                Precio = price,
                Categoria = this.Categoria
              
            };

            var url = "https://secret-woodland-25862.herokuapp.com";
            var response = await this.apiService.PostAsync(
                url,
                "addProducto.php",
                product
                );

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Mensaje,
                    "Accept");
                return;
            }

            var newProduct = (Product)response.Resultado;
            MainViewModel.obtenerInstancia().Products.Products.Add(newProduct);

            this.IsRunning = false;
            this.IsEnabled = true;
            await App.Navigator.PopAsync();
        }

        
    }
}
