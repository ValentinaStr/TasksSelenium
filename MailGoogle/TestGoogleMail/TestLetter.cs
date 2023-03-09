using MailGoogle;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestGoogleMail
{
	[TestClass]
	public class TestLetter
	{
		public static WebDriver driverGoogle;
		/*
		[TestInitialize]
		public static void CreateDriver()
		{
			driverGoogle = new ChromeDriver();
		}

		[TestCleanup]
		public static void ClassCleanup()
		{
			driverGoogle.Quit();
			//GoToUrl();
			//driverGoogle.Close();
		}*/

		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "TSelenium102@gmail.com", "*)**summer**(*", "*sun*", "*worm*")]
		public void TestMail(string firstMail,
							string password,
							string secondMail,
							string termNewLetter,
							string textNewLetter,
							string textAnswer)
		{
			var nameCookies = "ACCOUNT_CHOOSER";


			//1
			WebDriver driverGoogle = new ChromeDriver();

			HomePage home = new HomePage(driverGoogle);
			home.GoToUrl();
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.RefreshCookies(nameCookies);
			loginPage.Login(firstMail, password);
			AccountMail mail101 = new AccountMail(driverGoogle);
			Letter newLetter = mail101.OpenNewLetter();
			newLetter.CreateNewLetter(secondMail, termNewLetter, textNewLetter);
			mail101.Exit();

			//2
			home.OpenLoginPage();
			loginPage.RefreshCookies(nameCookies);
			loginPage.Login(secondMail, password);			
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
			loginPage.Login(firstMail, password);		
			mail101.WaitLetterWithTerm(termNewLetter);
			mail101.OpenFirstLetter();
			var chekTextAnswer = answerLetter.GetTextLetter();
			Assert.AreEqual(chekTextAnswer, textAnswer, "Wrong Text answer.");
			mail101.Exit();
			driverGoogle.Quit();
			//driverGoogle.Close();

		}

		[TestMethod]
		[DataRow("Gmail")]
		public void CheckNamePostPositive(string namePostExpected)
		{
			WebDriver driverGoogle = new ChromeDriver();
			HomePage home = new HomePage(driverGoogle);
			home.GoToUrl();
			var namePostActual = home.GetUrl();
			Assert.AreEqual(namePostExpected, namePostActual);
			driverGoogle.Quit();
		}

		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "Sele nium")]
		public void CheckUserName(string firstMail, string password, string nameUserExpected)
		{
			WebDriver driverGoogle = new ChromeDriver();
			HomePage home = new HomePage(driverGoogle);
			home.GoToUrl();
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.Login(firstMail, password);			
			AccountMail mail101 = new AccountMail(driverGoogle);			
			mail101.SwithFrame();
			Thread.Sleep(100);
			var nameUserActual = mail101.GetUserName();
			Assert.AreEqual(nameUserExpected, nameUserActual);
			driverGoogle.Quit();
		}

		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_")]
		public void ChekVisibleNewLetter(string firstMail,
							string password,
							string secondMail,
							string termNewLetter,
							string textNewLetter)
		{
			var nameCookies = "ACCOUNT_CHOOSER";
			WebDriver driverGoogle = new ChromeDriver();
			HomePage home = new HomePage(driverGoogle);
			home.GoToUrl();
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.Login(firstMail, password);
			AccountMail mail101 = new AccountMail(driverGoogle);
			Letter newLetter = mail101.OpenNewLetter();
			newLetter.CreateNewLetter(secondMail, termNewLetter, textNewLetter);
			mail101.Exit();
			
			home.OpenLoginPage();
			loginPage.RefreshCookies(nameCookies);
			loginPage.Login(secondMail, password);
			AccountMail mail2 = new AccountMail(driverGoogle);
			mail2.WaitLetterWithTermAndText(termNewLetter, textNewLetter);
			Assert.AreEqual(termNewLetter, termNewLetter, "Wrong email subject");
			Assert.AreEqual(textNewLetter, textNewLetter, "Wrong text letter");
		}


	}
}