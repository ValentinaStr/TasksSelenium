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
			var textAnswer = "RE !";

			WebDriver driverGoogle = new ChromeDriver();

			driverGoogle.Navigate().GoToUrl("https://www.google.com/intl/ru/gmail/about/");

			HomePage home00 = new HomePage(driverGoogle);
			//1
			LoginPage loginPage001 = home00.OpenLoginPage();
			loginPage001.InputEmailInLogin(firstMail);
			loginPage001.InputPasswordInLogin(password);
			AccountMail mail001 = new AccountMail(driverGoogle);
			Letter newLetter = mail001.OpenNewLetter();
			newLetter.CreateNewLetter(seccondMail, termNewLetter, textNewLetter);
			mail001.Exit();

			//2
			Thread.Sleep(500);
			LoginPage loginPage002 = home00.OpenLoginPage();
			loginPage002.InputEmailInLogin(seccondMail);
			loginPage002.InputPasswordInLogin(password);

			AccountMail mail002 = new AccountMail(driverGoogle);
			mail002.WaitLetterWithTermAndText(termNewLetter, textNewLetter);
			mail002.OpenFirstLetter();
			Letter answerLetter = mail002.OpenAnswerLetter();
			answerLetter.CreateAnswerLetter(textAnswer);	
			mail002.Exit();

			//3
			loginPage001.InputEmailInLogin(firstMail);
			loginPage001.InputPasswordInLogin(password);
			mail001.WaitLetterWithTerm(termNewLetter);
			mail001.OpenFirstLetter();
			var textAnswerFor1 =  answerLetter.GetTextLetter();

			driverGoogle.Close();

		}
	}
}