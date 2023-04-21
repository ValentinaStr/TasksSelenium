using MailGoogle;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestGoogleMail
{
	[TestClass]
	public class TestLetter
	{
		private IWebDriver _driverGoogle;

		[TestInitialize]
		public void BeforeTest()
		{
			_driverGoogle = new ChromeDriver();
		}

		[TestCleanup]
		public void ClassCleanup()
		{
			_driverGoogle.Close();
		}
		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "TSelenium102@gmail.com", "*)**summer**(*", "*sun*", "*worm*")]
		public void CheckSendLetterAndGetAnswer(string firstMail,
							string password,
							string secondMail,
							string termNewLetter,
							string textNewLetter,
							string textAnswer)
		{
			var nameCookies = "ACCOUNT_CHOOSER";

			//1
			HomePage home = new HomePage(_driverGoogle);
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.RefreshCookies(nameCookies);
			loginPage.Login(firstMail, password);
			AccountMail mail = home.OpenAccountMailPage();
			Letter newLetter = mail.OpenNewLetter();
			newLetter.CreateNewLetterAndSend(secondMail, termNewLetter, textNewLetter);
			mail.Exit();

			//2
			home.OpenLoginPage();
			loginPage.RefreshCookies(nameCookies);
			loginPage.Login(secondMail, password);
			mail.WaitLetterWithTermAndText(termNewLetter, textNewLetter);
			mail.OpenFirstLetter();
			Assert.AreEqual(termNewLetter, termNewLetter, "Wrong email subject");
			Assert.AreEqual(textNewLetter, textNewLetter, "Wrong text letter");
			Letter answerLetter = mail.OpenAnswerLetter();
			answerLetter.CreateAnswerLetter(textAnswer);			
			mail.Exit();

			//3
			loginPage.RefreshCookies(nameCookies);
			loginPage.Login(firstMail, password);
			mail.WaitLetterWithTerm(termNewLetter);
			mail.OpenFirstLetter();			
			var chekTextAnswer = answerLetter.GetTextLetter();
			Assert.AreEqual(chekTextAnswer, textAnswer, "Wrong text answer.");			
			mail.Exit();
		}

		[TestMethod]
		[DataRow("Gmail")]
		public void CheckNamePostPositive(string namePostExpected)
		{
			HomePage home = new HomePage(_driverGoogle);

			var namePostActual = home.GetNamePost();
			Assert.AreEqual(namePostExpected, namePostActual);
		}

		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "Sele nium")]
		public void CheckUserNamePositive(string firstMail, string password, string nameUserExpected)
		{
			HomePage home = new HomePage(_driverGoogle);
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.Login(firstMail, password);
			AccountMail mail101 = home.OpenAccountMailPage();
			var nameUserActual = mail101.GetUserName();
			Assert.AreEqual(nameUserExpected, nameUserActual);
		}

		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "TSelenium102@gmail.com", "abc", "defj")]
		public void ChekVisibleNewLetterPositive(string firstMail,
							string password,
							string secondMail,
							string termNewLetter,
							string textNewLetter)
		{
			var nameCookies = "ACCOUNT_CHOOSER";
			HomePage home = new HomePage(_driverGoogle);
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.Login(firstMail, password);
			AccountMail mail101 = home.OpenAccountMailPage();
			Letter newLetter = mail101.OpenNewLetter();
			newLetter.CreateNewLetterAndSend(secondMail, termNewLetter, textNewLetter);
			mail101.Exit();
			home.OpenLoginPage();
			loginPage.RefreshCookies(nameCookies);
			loginPage.Login(secondMail, password);
			AccountMail mail2 = home.OpenAccountMailPage();
			mail2.WaitLetterWithTermAndText(termNewLetter, textNewLetter);
			Assert.AreEqual(termNewLetter, termNewLetter, "Wrong email subject");
			Assert.AreEqual(textNewLetter, textNewLetter, "Wrong text letter");
		}

		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "TSelenium101@gmail.com", "Hi", "How are you?")]
		public void CheckCounterNewLetterPositive(string firstMail, string password, string secondMail, string termNewLetter, string textNewLetter)
		{
			HomePage home = new HomePage(_driverGoogle);
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.Login(firstMail, password);

			AccountMail mail = home.OpenAccountMailPage();
			Letter newLetter = mail.OpenNewLetter();
			newLetter.CreateNewLetterAndSend(secondMail, termNewLetter, textNewLetter);
			mail.WaitLetterWithTerm(termNewLetter);
			var counterNewLetter = mail.GetCounterNewLetter();
			Assert.IsNotNull(counterNewLetter);
		}

		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "TSelenium101@gmail.com", "Hell", "Are you?")]
		public void CheckCounterPlusNewLetterPositive(string firstMail, string password, string secondMail, string termNewLetter, string textNewLetter)
		{
			HomePage home = new HomePage(_driverGoogle);
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.Login(firstMail, password);
			AccountMail mail = home.OpenAccountMailPage();
			var counterNewLetter1 = mail.GetCounterNewLetter();
			Letter newLetter = mail.OpenNewLetter();
			newLetter.CreateNewLetterAndSend(secondMail, termNewLetter, textNewLetter);
			mail.WaitLetterWithTerm(termNewLetter);
			var counterNewLetter2 = mail.GetCounterNewLetter();
			Assert.IsTrue((counterNewLetter2 - counterNewLetter1) == 1);
		}

		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "H0", "How you?")]
		public void CheckDraftSavePositive(string firstMail, string password, string termNewLetter, string textNewLetter)
		{
			HomePage home = new HomePage(_driverGoogle);
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.Login(firstMail, password);
			AccountMail mail = home.OpenAccountMailPage();
			Letter newLetter = mail.OpenNewLetter();
			newLetter.CreateNewLetter(firstMail, termNewLetter, textNewLetter);
			newLetter.ClosedNewLetter();
			mail.OpenMoreMenu();
			mail.OpenDraftPage();
			var textDraft = mail.GetTextDraftLetter();
			Assert.AreEqual(termNewLetter, textDraft);
		}

		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_")]
		public void LogoutPositive(string firstMail, string password)
		{
			HomePage home = new HomePage(_driverGoogle);
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.Login(firstMail, password);
			AccountMail mail = home.OpenAccountMailPage();
			mail.Exit();
			Assert.IsNotNull(home.CheckSignInButton());
		}
		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "ERHJHGJKKcom", "summer", "sun")]
		public void CheckSendEmailWithWrongEmail(string firstMail,
							string password,
							string secondMail,
							string termNewLetter,
							string textNewLetter)
		{
			var nameCookies = "ACCOUNT_CHOOSER";
			HomePage home = new HomePage(_driverGoogle);
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.RefreshCookies(nameCookies);
			loginPage.Login(firstMail, password);
			AccountMail mail = home.OpenAccountMailPage();
			Letter newLetter = mail.OpenNewLetter();
			newLetter.CreateNewLetterAndSend(secondMail, termNewLetter, textNewLetter);
			Assert.IsNotNull(newLetter.ErrorNewMessageEmail());
		}
		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "TSelenium101@gmail.com", "", "*****")]
		public void CheckSendEmailWithoutTerm(string firstMail,
							string password,
							string secondMail,
							string termNewLetter,
							string textNewLetter)
		{
			var nameCookies = "ACCOUNT_CHOOSER";
			HomePage home = new HomePage(_driverGoogle);
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.RefreshCookies(nameCookies);
			loginPage.Login(firstMail, password);
			AccountMail mail = home.OpenAccountMailPage();
			Letter letter = mail.OpenNewLetter();
			letter.CreateNewLetterAndSend(secondMail, termNewLetter, textNewLetter);
			mail.WaitLetterWithTerm("(без темы)");
			mail.OpenFirstLetter();
			var textGetLetter = letter.GetTextLetter();
			Assert.AreEqual(textNewLetter, textGetLetter);
		}

		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "TSelenium101@gmail.com", "", "")]
		public void CheckAlertSendEmailWithoutTermAandText(string firstMail,
							string password,
							string secondMail,
							string termNewLetter,
							string textNewLetter)
		{
			var nameCookies = "ACCOUNT_CHOOSER";
			HomePage home = new HomePage(_driverGoogle);
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.RefreshCookies(nameCookies);
			loginPage.Login(firstMail, password);
			AccountMail mail = home.OpenAccountMailPage();
			Letter newLetter = mail.OpenNewLetter();
			newLetter.CreateNewLetterAndSend(secondMail, termNewLetter, textNewLetter);
			var textAlert = mail.GetTextAlert();
			Assert.IsNotNull(textAlert);
			mail.AcceptAlert();
		}

		[TestMethod]
		[DataRow("TSelenium101@gmail.com", "_SeLeNiuM_", "TSelenium101@gmail.com", "", " ")]
		public void CheckSendEmailWithoutTermAandText(string firstMail,
							string password,
							string secondMail,
							string termNewLetter,
							string textNewLetter)
		{
			var nameCookies = "ACCOUNT_CHOOSER";
			HomePage home = new HomePage(_driverGoogle);
			LoginPage loginPage = home.OpenLoginPage();
			loginPage.RefreshCookies(nameCookies);
			loginPage.Login(firstMail, password);
			AccountMail mail = home.OpenAccountMailPage();
			Letter letter = mail.OpenNewLetter();
			letter.CreateNewLetterAndSend(secondMail, termNewLetter, textNewLetter);
			mail.AcceptAlert();
			mail.WaitLetterWithTerm("(без темы)");
			var textGetLetter = mail.CheckTextLetter();
			Assert.AreEqual("no text", textGetLetter);
		}
	}
}