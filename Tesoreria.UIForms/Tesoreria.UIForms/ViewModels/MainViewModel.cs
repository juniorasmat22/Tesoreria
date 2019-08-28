using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Tesoreria.Common.Models;
using Tesoreria.UIForms.Views;

namespace Tesoreria.UIForms.ViewModels
{
    //se encargara de controlar las otras view models
   
    public class MainViewModel
    {
        private static MainViewModel instancia;
        public LoginViewModel Login { get; set; }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        public string UserEmail { get; set; }

        public string UserPassword { get; set; }
        public AlumnosViewModel Alumnos { get; set; }
        public ProductsViewModel Products { get; set; }
        public AddProductViewModel AddProduct { get; set; }
        public AddAlumnoViewModel AddAlumno { get; set; }
        public EditAlumnoViewModel EditAlumno { get; set; }
        public ICommand AddProductCommand { get { return new RelayCommand(this.GoAddProduct); } }
        public ICommand AddAlumnoCommand { get { return new RelayCommand(this.GoAddAlumno); } }

        private async void GoAddAlumno()
        {
            this.AddAlumno = new AddAlumnoViewModel();
            await App.Navigator.PushAsync(new AddAlumnoPage());
        }

        private async void GoAddProduct()
        {
            this.AddProduct = new AddProductViewModel();
            await App.Navigator.PushAsync(new AddProductPage());
        }

        public MainViewModel()
        {
            instancia = this;
            this.CargaMenus();
        }

       

        public static MainViewModel obtenerInstancia()
        {
            if (instancia==null)
            {
                return new MainViewModel();
            }
            return instancia;
        }
        private void CargaMenus()
        {
            var menus = new List<Menu>
        {
            
            new Menu
            {
                Icon = "ic_payment",
                PageName = "PagosPage",
                Title = "Mis pagos"
            },
            new Menu
            {
                Icon = "ic_queue",
                PageName = "NewPagosPage",
                Title = "Nuevo Pago"
            },
            new Menu
            {
                Icon = "ic_supervised_user_circle",
                PageName = "AlumnosPage",
                Title = "Alumnos"
            },
            new Menu
            {
                Icon = "ic_person",
                PageName = "DatosPage",
                Title = "Mis Datos"
            },
            new Menu
            {
                Icon = "ic_info",
                PageName = "AboutPage",
                Title = "About"
            },

           

            new Menu
            {
                Icon = "ic_phonelink_setup",
                PageName = "SetupPage",
                Title = "Cofiguracion"
            },

            new Menu
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = "Cerrar session"
            }

        };

            this.Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }

    }
        
}
