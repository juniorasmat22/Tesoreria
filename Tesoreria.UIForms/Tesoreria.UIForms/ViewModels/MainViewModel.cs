using System;
using System.Collections.Generic;
using System.Text;

namespace Tesoreria.UIForms.ViewModels
{
    //se encargara de controlar las otras view models
   
    public class MainViewModel
    {
        private static MainViewModel instancia;
        public LoginViewModel Login { get; set; }
        public ProductsViewModel Products { get; set; }
        public MainViewModel()
        {
            instancia = this;
        }
        public static MainViewModel obtenerInstancia()
        {
            if (instancia==null)
            {
                return new MainViewModel();
            }
            return instancia;
        }

    }
        
}
