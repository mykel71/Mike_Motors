using MyCarSale.Data.Base;
using MyCarSale.Data.ViewModels;
using MyCarSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarSale.Data.Services
{
    public interface ICarsService:IEntityBaseRepository<Cars>
    {
        Task<Cars> GetCarByIdAsync(int id);
        Task<NewCarDropdownsVM> GetNewCarDropdownsValues();
        Task AddNewCarAsync(NewCarVM data);
        Task UpdateCarAsync(NewCarVM data);
    }
}
