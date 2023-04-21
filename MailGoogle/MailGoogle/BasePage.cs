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
		const int WAITTIME = 30;
		const string NAMEFRAMEACCOUNT = "account";

		public BasePage(IWebDriver driverGoogle)
		{
			_driverGoogle = driverGoogle;
			_wait = new WebDriverWait(_driverGoogle, TimeSpan.FromSeconds(WAITTIME));
		}
		
		protected void GoToUrl(string url)
		{
			_driverGoogle.Url = url;
			_driverGoogle.Manage().Window.Maximize();
		}	

		protected IWebElement FindElementWithWaiter(string xpath)
		{
			return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
		}

		protected ReadOnlyCollection<IWebElement> FindElementsWithWaiter(string xpath)
		{
			return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xpath)));
		}

		public void SwithToFrame()
		{
			FindElementWithWaiter(XPathGoogle.SITE_OPEN_ACCOUNT_XPATH).Click();
			Thread.Sleep(100);
			_driverGoogle.SwitchTo().Frame(NAMEFRAMEACCOUNT);
		}

		public void RefreshCookies(string nameCookies)
		{
			_driverGoogle.Manage().Cookies.DeleteCookieNamed(nameCookies);
			_driverGoogle.Navigate().Refresh();
			Thread.Sleep(100);
		}

		public void AcceptAlert()
		{
			_driverGoogle.SwitchTo().Alert().Accept();
		}

		public string GetTextAlert()
		{
			return _driverGoogle.SwitchTo().Alert().Text;
		}

		public void DismissAlert()
		{
			_driverGoogle.SwitchTo().Alert().Dismiss();
		}

	}
}
