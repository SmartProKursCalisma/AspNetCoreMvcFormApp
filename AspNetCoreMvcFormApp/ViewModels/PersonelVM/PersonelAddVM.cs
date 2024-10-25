using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvcFormApp.ViewModels.PersonelVM
{
    public class PersonelAddVM
    {
        [Required(ErrorMessage ="Bu Alan Zorunludur.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage ="Alan Zorunludur.")]
        [MinLength(12,ErrorMessage =" 5 Karakterden fazla Giriniz.")]
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
