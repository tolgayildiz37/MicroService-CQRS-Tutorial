using System.ComponentModel.DataAnnotations;

namespace Tutorial.UI.ViewModel
{
    public class AppUserViewModel
    {
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Is Buyer")]
        [Required(ErrorMessage = "Buyer is required")]
        public bool IsBuyer { get; set; }

        [Display(Name = "Is Seller")]
        [Required(ErrorMessage = "Seller is required")]
        public bool IsSeller { get; set; }
    }
}
