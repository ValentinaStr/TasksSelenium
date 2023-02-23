using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Chromium;

namespace MailGoogle
{
	public class Program
	{
		static void Main(string[] args)
		{
			WebDriver driverGoogle = new ChromeDriver();

			driverGoogle.Navigate().GoToUrl("https://www.google.com/intl/ru/gmail/about/");

			HomePage home00 = new HomePage(driverGoogle);

			LoginPage loginPage001 = home00.OpenLoginPage();
 
			loginPage001.InputEmailInLogin("TSelenium007");

			loginPage001.InputPasswordInLogin("SELenium");

			AccountMail mail001 = new AccountMail(driverGoogle);

			mail001.CreateNewLetter("TSelenium001@gmail.com", "(^_^)");

			mail001.Exit();

			LoginPage loginPage007 = home00.OpenLoginPage();

			loginPage007.InputEmailInLogin("TSelenium001");

			loginPage007.InputPasswordInLogin("SELenium");

			AccountMail mail007 = new AccountMail(driverGoogle);

			mail007.OpenFirstLetter();
			mail007.GetTermLetter();
			mail007.AnswerLetter("Answer");

			mail007.Exit();

			driverGoogle.Close();

			Console.WriteLine("End");

		}
	}
}