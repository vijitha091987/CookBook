using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookApp.Models;
using Newtonsoft.Json;
using DevExpress.Xpo.Metadata;

namespace CookBookApp.Controllers
{

    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        #region Ctor

        public BaseController()
        {
          
        }

        #endregion Ctor

      
        #region Public Members

        [NonAction]
        protected IActionResult OkCollectionResult<TEntity, TEntityCollection>(IEnumerable<TEntity> entities)           
        {
          
                return Ok(entities);
            
        }

        [NonAction]
        protected IActionResult Updated()
        {
            return Ok(new
            {
                message = "Update successfully."
            });
        }

        [NonAction]
        protected IActionResult Deleted()
        {
            return Ok(new
            {
                message = "Deleted successfully"
            });
        }



        [NonAction]
        protected IActionResult Saved()
        {
            return Ok(new
            {
                message = "Saved successfully"
            });
        }

        [NonAction]
        protected IActionResult AcceptedResult(string customeMessage)
        {
            return Accepted(new { message = customeMessage });
        }

        #endregion Public Members
    }
}
