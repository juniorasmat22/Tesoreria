using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Tesoreria.Common.Models;
using Tesoreria.Common.Services;
using Xamarin.Forms;

namespace Tesoreria.UIForms.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private ApiServices apiServices;
        private ObservableCollection<Product> products;
        private bool cargando;
        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
        }//lista de productoa para el list view

        public bool Cargando
        {
            get { return this.cargando; }
            set { this.SetValue(ref this.cargando, value); }
        }//lista de productoa para el list view

        public ProductsViewModel()
        {
            this.apiServices = new ApiServices();
            this.CargarProductos();

        }

        private async void CargarProductos()
        {
            this.Cargando=true;
            var response = await this.apiServices.GetListAsync<Product>(
                "https://secret-woodland-25862.herokuapp.com",
                "listarProductos.php");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Mensaje,
                    "Aceptar");
                return;
            }
            var MisProductos = (List<Product>)response.Resultado;
            this.Products = new ObservableCollection<Product>(MisProductos.OrderBy(p=>p.Descripcion));
            this.Cargando = false;
        }
    }
}
