
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace MailGoogle
{
	public abstract class BasePage
	{
		private IWebDriver _driverGoogle;
		protected WebDriverWait _wait;
		const int WaitTime = 30;
		const string nameFrameAccount = "account";

		public BasePage(IWebDriver driverGoogle)
		{
			_driverGoogle = driverGoogle;
		}
		
		public void GoToUrl()
		{
			_driverGoogle.Url = "https://www.google.com/intl/ru/gmail/about/";
			_driverGoogle.Manage().Window.Maximize();
		}	

		public IWebElement FindElementWhithWaiter(string xpath)
		{
		
			_wait = new WebDriverWait(_driverGoogle, TimeSpan.FromSeconds(WaitTime));			
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
			return _driverGoogle.FindElement(By.XPath(xpath));
		}

		public List<IWebElement> FindElementsWhithWaiter(string xpath)
		{

			_wait = new WebDriverWait(_driverGoogle, TimeSpan.FromSeconds(WaitTime));
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
			return _driverGoogle.FindElements(By.XPath(xpath)).ToList();
		}

		public void SwithFrame()
		{
			FindElementWhithWaiter(XPathGoogle.SITE_OPEN_ACCOUNT_XPATH).Click();
			Thread.Sleep(100);
			_driverGoogle.SwitchTo().Frame(nameFrameAccount);
		}


		public void RefreshCookies(string nameCookies)
		{
			_driverGoogle.Manage().Cookies.DeleteCookieNamed(nameCookies);
			_driverGoogle.Navigate().Refresh();
		}
				
		public LoginPage OpenLoginPage()
		{
			FindElementWhithWaiter(XPathGoogle.SITE_EMAIL_XPATH).Click();
			return new LoginPage(_driverGoogle);
		}
		public Letter OpenNewLetter()
		{
			FindElementWhithWaiter(XPathGoogle.SITE_OPEN_NEW_LETTER_XPATH).Click();
			return new Letter(_driverGoogle);
		}
		public Letter OpenAnswerLetter()
		{
			FindElementWhithWaiter(XPathGoogle.SITE_LETTER_ANSWER_XPATH).Click();
			return new Letter(_driverGoogle);
		}
	}
}
