using AspNetCoreMvcFormApp.Models;
using AspNetCoreMvcFormApp.Models.PersonelModels;
using AspNetCoreMvcFormApp.ViewModels.PersonelVM;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcFormApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<Personel> personels = new()
            {
                new Personel(){Id = 1,Fullname = "Melih Ömer",Email = "melih@mail.com",IsActive=true},
                new Personel(){Id = 2,Fullname = "Efecan CÖRÜT",Email = "efecan@mail.com",IsActive=false},
                new Personel(){Id = 3,Fullname = "Mustafa BAYÇÖL",Email = "mustafa@mail.com",IsActive=true},
                new Personel(){Id = 4,Fullname = "Berkant YILMAZ",Email = "berkant@mail.com",IsActive=false},
                new Personel(){Id = 5,Fullname = "Selim can TOPAL",Email = "selim@mail.com",IsActive=true},
            };
        public HomeController()
        {


        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (model.Email == "melih@com.tr" && model.Password == "12345")
            {
                return RedirectToAction("Privacy");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Privacy()
        {

            return View(personels);
        }
        [HttpGet]
        public IActionResult AddPersonel()
        {
            return View(new PersonelAddVM());
        }
        [HttpPost]
        public IActionResult AddPersonel(PersonelAddVM personelVm)
        {
            if (!ModelState.IsValid)
            {
                return View(personelVm);  
            }
            int newId = personels.Count + 1;
            Personel personel = new()
            {
                Id = newId,
                Email = personelVm.Email,
                Fullname = personelVm.Fullname,
                IsActive = personelVm.IsActive
            };
            personels.Add(personel);
            return RedirectToAction("Privacy");
        }
        [HttpGet]
        public IActionResult RemovePersonel(int id)
        {
            Personel personel = personels.FirstOrDefault(x => x.Id == id);
            personels.Remove(personel);
            return RedirectToAction(nameof(Privacy));
        }
        [HttpGet]
        public IActionResult UpdatePersonel(int id)
        {
            Personel personel = personels.FirstOrDefault(x => x.Id == id);
            return View(personel);
        }
        [HttpPost]
        public IActionResult UpdatePersonel(Personel personel)
        {
            Personel oldPersonel = personels.FirstOrDefault(x => x.Id == personel.Id);
            oldPersonel.Fullname = personel.Fullname;
            oldPersonel.Email = personel.Email;
            oldPersonel.IsActive = personel.IsActive;
            return RedirectToAction(nameof(Privacy));
        }
    }
}
