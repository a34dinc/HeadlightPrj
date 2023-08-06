using HeadlightPrj.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HeadlightPrj.ViewComponents
{
    public class HeadLightGetList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            HeadLightRepository repository = new HeadLightRepository();
            var headlist = repository.TListele();
            return View(headlist);
        }
    }
}
