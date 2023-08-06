using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HeadlightPrj.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Bu Alan Boş Geçilemez!")]
        [StringLength(20,ErrorMessage ="Lütfen 3-20 Karakter Aralığında Giriş Yapınız",MinimumLength=3)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }

        public List<HeadLight> HeadLights { get; set; }
    }
}
