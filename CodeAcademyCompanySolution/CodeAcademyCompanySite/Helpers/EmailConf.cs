using CodeAcademyCompany.DAL.Model;
using System.Net;
using System.Net.Mail;

namespace CodeAcademyCompany.PL.Helpers
{
	public class EmailConf
	{
		public static void ResetPasswordEmil(Email em)
		{
			var client = new SmtpClient("smtp.gamil.com", 465);
			client.EnableSsl = true;
			client.Credentials = new NetworkCredential("hamedKhaloud71@gmail.com", "1234kha");
			client.Send("hamedKhaloud71@gmail.com", em.To ,em.Title ,em.Body);

		}
	}
}
