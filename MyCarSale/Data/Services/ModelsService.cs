using MyCarSale.Data.Base;
using MyCarSale.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarSale.Data.Services
{
    public class ModelsService : EntityBaseRepository<Model>, IModelsService
    {
        public ModelsService(AppDbContext context) : base(context) { }
    }
}
