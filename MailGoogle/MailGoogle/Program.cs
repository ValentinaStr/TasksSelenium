using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Chromium;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
			var textAnswer = "RE";

			WebDriver driverGoogle = new ChromeDriver();

			driverGoogle.Navigate().GoToUrl("https://www.google.com/intl/ru/gmail/about/");

			HomePage home00 = new HomePage(driverGoogle);

			LoginPage loginPage001 = home00.OpenLoginPage();
			loginPage001.InputEmailInLogin(firstMail);
			loginPage001.InputPasswordInLogin(password);
			AccountMail mail001 = new AccountMail(driverGoogle);
			mail001.CreateNewLetter(seccondMail, termNewLetter, textNewLetter);
			mail001.Exit();

			Thread.Sleep(500);

			LoginPage loginPage002 = home00.OpenLoginPage();
			loginPage002.InputEmailInLogin(seccondMail);
			loginPage002.InputPasswordInLogin(password);

			AccountMail mail002 = new AccountMail(driverGoogle);
			mail002.WaitLetter(termNewLetter, textNewLetter);
			mail002.OpenFirstLetter();
			mail002.CreateAnswerLetter(textAnswer);	
			mail002.Exit();
			
			loginPage001.InputEmailInLogin(firstMail);
			loginPage001.InputPasswordInLogin(password);
			mail001.OpenFirstLetter();
			var textAnswerFor1 =  mail001.GetTextLetter();
			Console.WriteLine(textAnswerFor1);

			driverGoogle.Close();

		}
	}
}