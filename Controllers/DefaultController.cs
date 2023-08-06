using HeadlightPrj.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace HeadlightPrj.Controllers
{
	
	public class DefaultController : Controller
	{
        [AllowAnonymous]
        public IActionResult Index()
        {

            return View();
        }
    }
}
