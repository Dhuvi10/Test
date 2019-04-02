using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REZCores
{
   public class Account
    {
    }
    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public int RoleID { get; set; }
        public int userId { get; set; }
    }

    public class LoginResponseModel
    {
        public string UserName { get; set; }
        public string AuthToken { get; set; }
        public int RoleID { get; set; }
        public int UserId { get; set; }
        public string DbUserName { get; set; }
        public string Password { get; set; }
        public string ServerName { get; set; }
        public string DbName { get; set; }
    }
    public class RegisterModel
    {

        //[Required]
        public string UserName { get; set; }
        //[Required]
        public string BrandId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string EncryptedPassword { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public Int64 UserId { get; set; }
    }
}
