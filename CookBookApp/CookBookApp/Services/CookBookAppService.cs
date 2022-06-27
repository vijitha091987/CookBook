using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookApp.Interfaces.Services;
using CookBookApp.Models;
using CookBookApp.Repository;
using CookBookApp.Interfaces.Repository;
using System.Data;

namespace CookBookApp.Services
{
    public class CookBookAppService : ICookBookAppService
    {
        #region Ctor
        public CookBookAppService(ICookBookAppRepository cookBookAppRepository) 
        {
            this._cookBookAppRepository = cookBookAppRepository;
          

        }
        #endregion Ctor

        #region Fields/Properties
       
        public ICookBookAppRepository _cookBookAppRepository;

        #endregion Fields/Properties
        public void DeleteAsync(int ItemID)
        {
             _cookBookAppRepository.DeleteAsync(ItemID);
        }

        public DataTable GetAllAsync()
        {
            return _cookBookAppRepository.GetAllAsync();
        }

        public void SaveAsync(CookBookRequest cookBookRequest)
        {
             _cookBookAppRepository.SaveAsync(cookBookRequest);
        }

        public void UpdateAsync(CookBookRequest cookBookRequest)
        {
             _cookBookAppRepository.UpdateAsync(cookBookRequest);
        }
    }
}
