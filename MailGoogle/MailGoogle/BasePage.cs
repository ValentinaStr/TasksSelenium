
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace MailGoogle
{
	public abstract class BasePage
	{
		protected IWebDriver _driverGoogle;
		protected WebDriverWait _wait;
		const int WaitTime = 30;
		const string nameFrameAccount = "account";

		public BasePage(IWebDriver driverGoogle)
		{
			_driverGoogle = driverGoogle;
			_wait = new WebDriverWait(_driverGoogle, TimeSpan.FromSeconds(WaitTime));
		}
		
		public void GoToUrl(string url)
		{
			_driverGoogle.Url = url;
			_driverGoogle.Manage().Window.Maximize();
		}	

		public IWebElement FindElementWhithWaiter(string xpath)
		{
			return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
		}

		public ReadOnlyCollection<IWebElement> FindElementsWhithWaiter(string xpath)
		{
			return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xpath)));
		}

		public void SwithToFrame()
		{
			FindElementWhithWaiter(XPathGoogle.SITE_OPEN_ACCOUNT_XPATH).Click();
			Thread.Sleep(100);
			_driverGoogle.SwitchTo().Frame(nameFrameAccount);
		}


		public void RefreshCookies(string nameCookies)
		{
			_driverGoogle.Manage().Cookies.DeleteCookieNamed(nameCookies);
			_driverGoogle.Navigate().Refresh();
			Thread.Sleep(100);
		}
	}
}
