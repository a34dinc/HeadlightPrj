using HeadlightPrj.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HeadlightPrj.ViewComponents
{
    public class CategoryGetList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var categoryList = categoryRepository.TListele();
            return View(categoryList);
        }
    }
}
