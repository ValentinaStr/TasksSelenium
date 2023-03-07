using MailGoogle;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestGoogleMail
{
	[TestClass]
	public class TestLetter
	{
		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_")]
		public void TestMail(string firstMail, string password)
		{
			var seccondMail = "TSelenium102@gmail.com";
			var termNewLetter = "*)**summer**(*";
			var textNewLetter = "*sun*";
			var textAnswer = "*worm*";
			var nameCookies = "ACCOUNT_CHOOSER";

			WebDriver driverGoogle = new ChromeDriver();

			HomePage home = new HomePage(driverGoogle);
			home.GoToUrl();

			//1
			
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.RefreshCookies(nameCookies);
			loginPage.InputEmailInLogin(firstMail);
			loginPage.InputPasswordInLogin(password);
			AccountMail mail101 = new AccountMail(driverGoogle);
			Letter newLetter = mail101.OpenNewLetter();
			newLetter.CreateNewLetter(seccondMail, termNewLetter, textNewLetter);
			mail101.Exit();

			//2
			home.OpenLoginPage();
			loginPage.RefreshCookies(nameCookies);
			loginPage.InputEmailInLogin(seccondMail);
			loginPage.InputPasswordInLogin(password);
			AccountMail mail2 = new AccountMail(driverGoogle);
			mail2.WaitLetterWithTermAndText(termNewLetter, textNewLetter);
			mail2.OpenFirstLetter();
			Assert.AreEqual(termNewLetter, termNewLetter, "Wrong email subject");
			Assert.AreEqual(textNewLetter, textNewLetter, "Wrong text letter");
			Letter answerLetter = mail2.OpenAnswerLetter();
			answerLetter.CreateAnswerLetter(textAnswer);
			Thread.Sleep(500);
			mail2.Exit();

			//3
			loginPage.RefreshCookies(nameCookies);
			loginPage.InputEmailInLogin(firstMail);
			loginPage.InputPasswordInLogin(password);
			mail101.WaitLetterWithTerm(termNewLetter);
			mail101.OpenFirstLetter();
			var chekTextAnswer = answerLetter.GetTextLetter();
			Assert.AreEqual(chekTextAnswer, textAnswer, "Wrong Text answer.");
			mail101.Exit();
			driverGoogle.Close();

		}
	}
}