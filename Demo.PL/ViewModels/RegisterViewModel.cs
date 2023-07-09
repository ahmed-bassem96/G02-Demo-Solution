using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
	public class RegisterViewModel
	{
		public string Fname { get; set; }

		public string Lname { get; set; }
		[Required(ErrorMessage = "Email is Required")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Confirm Password is Required")]
		[DataType(DataType.Password)]
		[Compare("Password",ErrorMessage = "Confirm Password is Required")]
		public string ConfirmPassword { get; set; }

		public bool IsAgree { get; set; }

	}
}
