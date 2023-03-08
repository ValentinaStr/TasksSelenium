using MailGoogle;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using static System.Net.WebRequestMethods;

namespace TestGoogleMail
{
	[TestClass]
	public class TestLetter
	{
		/*[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "TSelenium102@gmail.com", "*)**summer**(*", "*sun*", "*worm*")]
		public void TestMail(string firstMail,
							string password,
							string seccondMail,
							string termNewLetter,
							string textNewLetter,
							string textAnswer)
		{
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

		}*/

		[TestMethod]
		public void CheckNamePostPositive()
		{
			WebDriver driverGoogle = new ChromeDriver();
			HomePage home = new HomePage(driverGoogle);
			home.GoToUrl();
			var namePostExpected = "Gmail";
			var namePostActual = home.GetUrl();
			Assert.AreEqual(namePostExpected, namePostActual);
			driverGoogle.Quit();
		}

		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_")]
		public void CheckUserName(string firstMail, string password)
		{
			WebDriver driverGoogle = new ChromeDriver();
			HomePage home = new HomePage(driverGoogle);
			home.GoToUrl();
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.InputEmailInLogin(firstMail);
			loginPage.InputPasswordInLogin(password);
			AccountMail mail101 = new AccountMail(driverGoogle);
			mail101.SwithToFrame();
			var nameUserExpected = "Sele nium";	
			var nameUserActual = mail101.GetUserName;
			Assert.AreEqual(nameUserExpected, nameUserActual);
			driverGoogle.Quit();
		}

	}
}