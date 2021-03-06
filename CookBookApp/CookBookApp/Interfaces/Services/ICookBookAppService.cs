using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CookBookApp.Models;

namespace CookBookApp.Interfaces.Services
{
   public interface ICookBookAppService
    {
        DataTable GetAllAsync();
      
        void SaveAsync(CookBookRequest cookBookRequest);

        void UpdateAsync(CookBookRequest cookBookRequest);

        void DeleteAsync(int ItemID);   

    }
}
