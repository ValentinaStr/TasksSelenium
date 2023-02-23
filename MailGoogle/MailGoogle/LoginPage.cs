using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace MailGoogle
{
	public class LoginPage: HomePage
	{
		const string SITE_LOGIN_EMAIL_XPATH = "//input[@id='identifierId']";
		const string SITE_LOGIN_EMAIL_NEXT_BUTTON_XPATH = "//div[@id='identifierNext']";
		const string SITE_LOGIN_PASSWORD_XPATH = "//input[@type='password']";
		const string SITE_LOGIN_PASSWORD_NEXT_BUTTON = "//div[@id='passwordNext']";

		public LoginPage(IWebDriver driverGoogle) : base (driverGoogle)
		{
			
		}

		public void InputEmailInLogin(string email)
		{
			_driverGoogle.Manage().Cookies.DeleteCookieNamed("ACCOUNT_CHOOSER");
			_driverGoogle.Navigate().Refresh();
			Thread.Sleep(300);
			_driverGoogle.FindElement(By.XPath(SITE_LOGIN_EMAIL_XPATH)).SendKeys(email);
			_driverGoogle.FindElement(By.XPath(SITE_LOGIN_EMAIL_NEXT_BUTTON_XPATH)).Click();
		}

		public void InputPasswordInLogin(string password)
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_LOGIN_PASSWORD_XPATH)));
			_driverGoogle.FindElement(By.XPath(SITE_LOGIN_PASSWORD_XPATH)).SendKeys(password);
			_driverGoogle.FindElement(By.XPath(SITE_LOGIN_PASSWORD_NEXT_BUTTON)).Click();
		}
	}
}




