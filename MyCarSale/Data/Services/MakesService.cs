using MyCarSale.Data.Base;
using MyCarSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarSale.Data.Services
{
    public class MakesService: EntityBaseRepository<Make>, IMakesService
    {
        public MakesService(AppDbContext context) : base(context)
        {
        }
    }
}
