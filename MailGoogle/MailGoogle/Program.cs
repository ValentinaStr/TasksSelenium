using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace MailGoogle
{
	public class Program
	{
		static void Main(string[] args)
		{
			var firstMail = "TSelenium101@gmail.com";
			var password = "_SeLeNiuM_";
			var seccondMail = "TSelenium102@gmail.com";
			var termNewLetter = "(^_^)";
			var textNewLetter = "wait you";
			var textAnswer = "RE !";

			WebDriver driverGoogle = new ChromeDriver();

			HomePage home = new HomePage(driverGoogle);

			//1
			LoginPage loginPage001 = home.OpenLoginPage();
			loginPage001.InputEmailInLogin(firstMail);
			loginPage001.InputPasswordInLogin(password);
			AccountMail mail001 = new AccountMail(driverGoogle);
			mail001.SwithToFrame();
			var r = mail001.GetUserName();
			Letter newLetter = mail001.OpenNewLetter();
			newLetter.CreateNewLetterAndSend(seccondMail, termNewLetter, textNewLetter);
			mail001.Exit();

			//2
			Thread.Sleep(500);
			LoginPage loginPage002 = home.OpenLoginPage();
			loginPage002.InputEmailInLogin(seccondMail);
			loginPage002.InputPasswordInLogin(password);

			AccountMail mail002 = new AccountMail(driverGoogle);
			mail002.WaitLetterWithTermAndText(termNewLetter, textNewLetter);
			mail002.OpenFirstLetter();
			Letter answerLetter = mail002.OpenAnswerLetter();
			answerLetter.CreateAnswerLetter(textAnswer);	
			mail002.Exit();

			//3
			Thread.Sleep(500);
			loginPage001.InputEmailInLogin(firstMail);
			loginPage001.InputPasswordInLogin(password);
			mail001.WaitLetterWithTerm(termNewLetter);
			mail001.OpenFirstLetter();
			var textAnswerFor1 =  answerLetter.GetTextLetter();
			Console.WriteLine(textAnswerFor1);

			driverGoogle.Close();

		}
	}
}