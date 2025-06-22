using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Filtro
{
	public class Logueado : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			if (context.HttpContext.Session.GetString("email") == null)
			{
				context.Result = new RedirectResult("/Home/index");
			}




		}
	}
}



