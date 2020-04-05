namespace App.API.Models
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    /// <summary>
    /// BaseController
    /// </summary>
    [Produces("application/json")]
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// GetClaim
        /// </summary>
        protected string GetClaim(string type)
          => Request.HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == type)?.Value;

        /// <summary>
        /// Set Paged Header
        /// </summary>
        /// <param name="pagedResult"></param>
        protected virtual void SetPaged<TResult>(PagedResult<TResult> pagedResult)
        {
            Request.HttpContext.Response.Headers.Add("_offset", pagedResult.Offset.ToString());
            Request.HttpContext.Response.Headers.Add("_limit", pagedResult.Limit.ToString());
            Request.HttpContext.Response.Headers.Add("_total", pagedResult.Total.ToString());
        }

        /// <summary>
        /// Set Paged Header
        /// </summary>
        /// <param name="pagedResult"></param>
        protected virtual void SetPaged(int Offset,int Limit,int Total)
        {
            Request.HttpContext.Response.Headers.Add("_offset", Offset.ToString());
            Request.HttpContext.Response.Headers.Add("_limit", Limit.ToString());
            Request.HttpContext.Response.Headers.Add("_total", Total.ToString());
        }
    }
}
