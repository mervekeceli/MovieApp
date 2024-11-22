using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Model
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(10, ErrorMessage ="Kullanıcı adı 10 karakterden fazla olamaz!")]
        public string UserName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage ="{0} karakter uzunluğu {2}-{1} arasında olmalıdır!", MinimumLength =3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }

        [Url]
        public string Url { get; set; }

        [Range(1900,2010)]
        public int BirthYear { get; set; }
    }
}
