using System;
using System.Collections.Generic;
using System.Text;
using Tesoreria.UIForms.ViewModels;

namespace Tesoreria.UIForms.Infraestructure
{
    //dentro de esta clase se va a creoa un propiedad mainviewmodel y asi crear una sola
    //instancia de la main view model
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }
        public InstanceLocator()
        {
            this.Main = new MainViewModel(); 
        }
    }
}
