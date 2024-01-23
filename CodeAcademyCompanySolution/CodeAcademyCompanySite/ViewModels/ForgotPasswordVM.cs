using System.ComponentModel.DataAnnotations;

namespace CodeAcademyCompany.PL.ViewModels
{
	public class ForgotPasswordVM
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
