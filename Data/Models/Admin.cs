using System.ComponentModel.DataAnnotations;

namespace HeadlightPrj.Data.Models
{
	public class Admin
	{
        [Key]
        public int AdminID { get; set; }

        [Required]
        [StringLength(20,MinimumLength =4,ErrorMessage ="Kullanıcı ismi 4-20 karakter arası olmalıdır.")]
        public string UserName { get; set; }

		[Required]
		[StringLength(8, MinimumLength = 4, ErrorMessage = "Şifre 4-8 karakter arası olmalıdır.")]
		public string Password { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }
    }
}
