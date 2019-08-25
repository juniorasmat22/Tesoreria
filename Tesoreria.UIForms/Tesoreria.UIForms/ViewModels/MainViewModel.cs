using System;
using System.Collections.Generic;
using System.Text;

namespace Tesoreria.UIForms.ViewModels
{
    //se encargara de controlar las otras view models
   
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public MainViewModel()
        {
           this.Login = new LoginViewModel();
        }
    }
        
}
