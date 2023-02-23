using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MailGoogle
{
	public class HomePage
	{
		public IWebDriver _driverGoogle;
		protected WebDriverWait _wait;

		const string SITE_EMAIL_XPATH = "//a[@data-action='sign in']";	

		public HomePage(IWebDriver driverGoogle)
		{
			_wait = new WebDriverWait(driverGoogle, TimeSpan.FromSeconds(30));
			_driverGoogle = driverGoogle;
			_driverGoogle.Manage().Window.Maximize();
		}

		public LoginPage OpenLoginPage()
		{
			FindElementWhithWeiter(SITE_EMAIL_XPATH);
			//Thread.Sleep(3000);
			//_driverGoogle.FindElement(By.XPath(SITE_EMAIL_XPATH)).Click();
			return new LoginPage(_driverGoogle);
		}

		public IWebElement FindElementWhithWeiter(string xpath)
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
			return _driverGoogle.FindElement(By.XPath(xpath));
		}

	}
}
