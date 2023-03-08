using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MailGoogle
{
	public class LoginPage: BasePage
	{
		public LoginPage(IWebDriver _driverGoogle) : base( _driverGoogle)
		{
			
		}

		public void InputEmailInLogin(string email)
		{
			FindElementWhithWaiter(XPathGoogle.SITE_LOGIN_EMAIL_XPATH).SendKeys(email);
			FindElementWhithWaiter(XPathGoogle.SITE_LOGIN_EMAIL_NEXT_BUTTON_XPATH).Click();
		}

		public void InputPasswordInLogin(string password)
		{
			FindElementWhithWaiter(XPathGoogle.SITE_LOGIN_PASSWORD_XPATH).SendKeys(password);
			FindElementWhithWaiter(XPathGoogle.SITE_LOGIN_PASSWORD_NEXT_BUTTON).Click();
		}
	}
}




