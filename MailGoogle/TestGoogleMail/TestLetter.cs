using MailGoogle;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;

namespace TestGoogleMail
{
	[TestClass]
	public class TestLetter
	{
		[TestMethod]
		public void TestMail()
		{
			var firstMail = "TSelenium101@gmail.com";
			var password = "_SeLeNiuM_";
			var seccondMail = "TSelenium102@gmail.com";
			var termNewLetter = "**summer*";
			var textNewLetter = "**sun*";
			var textAnswer = "**worm*";

			WebDriver driverGoogle = new ChromeDriver();

			driverGoogle.Navigate().GoToUrl("https://www.google.com/intl/ru/gmail/about/");

			HomePage home00 = new HomePage(driverGoogle);

			//1
			LoginPage loginPage = home00.OpenLoginPage();
			loginPage.InputEmailInLogin(firstMail);
			loginPage.InputPasswordInLogin(password);
			AccountMail mail101 = new AccountMail(driverGoogle);
			Letter newLetter = mail101.OpenNewLetter();
			newLetter.CreateNewLetter(seccondMail, termNewLetter, textNewLetter);
			mail101.Exit();

			//2
			home00.OpenLoginPage();
			loginPage.InputEmailInLogin(seccondMail);
			loginPage.InputPasswordInLogin(password);
			AccountMail mail2 = new AccountMail(driverGoogle);
			mail2.WaitLetterWithTermAndText(termNewLetter, textNewLetter);
			mail2.OpenFirstLetter();
			Letter answerLetter = mail2.OpenAnswerLetter();
			answerLetter.CreateAnswerLetter(textAnswer);
			mail2.Exit();

			//3
			loginPage.InputEmailInLogin(firstMail);
			loginPage.InputPasswordInLogin(password);
			mail101.WaitLetterWithTerm(termNewLetter);
			mail101.OpenFirstLetter();
			var chekTextAnswer = answerLetter.GetTextLetter();
			Assert.AreEqual(chekTextAnswer, textAnswer, "Wrong Text answer.");
			//mail101.Exit();
			driverGoogle.Close();

		}
	}
}