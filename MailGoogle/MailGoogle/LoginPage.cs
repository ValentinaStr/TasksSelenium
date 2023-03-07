using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MailGoogle
{
	public class LoginPage: BasePage
	{
		const string SITE_LOGIN_EMAIL_XPATH = "//input[@id='identifierId']";
		const string SITE_LOGIN_EMAIL_NEXT_BUTTON_XPATH = "//div[@id='identifierNext']";
		const string SITE_LOGIN_PASSWORD_XPATH = "//input[@type='password']";
		const string SITE_LOGIN_PASSWORD_NEXT_BUTTON = "//div[@id='passwordNext']";

		public LoginPage(IWebDriver _driverGoogle) : base( _driverGoogle)
		{
			
		}

		public void InputEmailInLogin(string email)
		{
			FindElementWhithWaiter(SITE_LOGIN_EMAIL_XPATH).SendKeys(email);
			FindElementWhithWaiter(SITE_LOGIN_EMAIL_NEXT_BUTTON_XPATH).Click();
		}

		public void InputPasswordInLogin(string password)
		{
			FindElementWhithWaiter(SITE_LOGIN_PASSWORD_XPATH).SendKeys(password);
			FindElementWhithWaiter(SITE_LOGIN_PASSWORD_NEXT_BUTTON).Click();
		}
	}
}




