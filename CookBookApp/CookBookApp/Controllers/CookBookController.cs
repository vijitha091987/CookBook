using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookApp.Models;
using CookBookApp.Services;
using CookBookApp.Interfaces.Services;
using Newtonsoft.Json;

namespace CookBookApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookBookController : BaseController
    {
        #region Ctor
        public CookBookController(ICookBookAppService cookBookAppService):base()
        {
            this._cookBookAppService = cookBookAppService;
           
          
        }
        #endregion Ctor

        #region Fields/Properties
        public ICookBookAppService _cookBookAppService;
     
        #endregion Fields/Properties
        [HttpPost]      
        public IActionResult SaveCookBookByItemIDAsync(CookBookRequest cookBookRequest)
        {
           _cookBookAppService.SaveAsync(cookBookRequest);
            return Saved();

        }

        [HttpPatch]
        public  IActionResult UpdateCookBookByItemIDAsync(CookBookRequest cookBookRequest)
        {
             _cookBookAppService.UpdateAsync(cookBookRequest);
            return Updated();
          
        }
        [HttpDelete("{id}")]
        public  IActionResult DeleteCookBookByItemIDAsync(int id)
        {
             _cookBookAppService.DeleteAsync(id);
            return Deleted();
        }

        [HttpGet()]
        public  IActionResult GetCookBookAllAsync()
        {
            string json = JsonConvert.SerializeObject(_cookBookAppService.GetAllAsync(), Formatting.Indented);
            return  Ok(json);
        }

    }
}
