
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace MailGoogle
{
	public abstract class BasePage
	{
		protected IWebDriver _driverGoogle;
		protected WebDriverWait _wait;
		const int WaitTime = 30;

		public  BasePage(IWebDriver driverGoogle)
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

		public void RefreshCookies(string nameCookies)
		{
			_driverGoogle.Manage().Cookies.DeleteCookieNamed(nameCookies);
			_driverGoogle.Navigate().Refresh();
		}
	}
}
