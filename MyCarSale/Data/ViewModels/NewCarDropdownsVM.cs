using MyCarSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarSale.Data.ViewModels
{
    public class NewCarDropdownsVM
    {
        public NewCarDropdownsVM()
        {
            Makes = new List<Make>();
            Models = new List<Model>();
        }

        public List<Make> Makes { get; set; }
        public List<Model> Models { get; set; }
    }
}
