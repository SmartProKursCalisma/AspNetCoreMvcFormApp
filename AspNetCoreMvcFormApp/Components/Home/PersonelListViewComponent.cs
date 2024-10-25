using AspNetCoreMvcFormApp.Models.PersonelModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcFormApp.Components.Home
{
    public class PersonelListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Personel> personels)
        {
          
            return View(personels);
        }
    }
}
