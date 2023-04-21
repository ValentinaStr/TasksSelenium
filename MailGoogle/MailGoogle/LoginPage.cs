using OpenQA.Selenium;

namespace MailGoogle
{
	public class LoginPage: BasePage
	{
		public LoginPage(IWebDriver _driverGoogle) : base( _driverGoogle)
		{
			
		}
		public void Login(string email, string password)
		{
			InputEmailInLogin(email);
			InputPasswordInLogin(password);
		}
		public void InputEmailInLogin(string email)
		{
			FindElementWithWaiter(XPathGoogle.SITE_LOGIN_EMAIL_XPATH).SendKeys(email);
			FindElementWithWaiter(XPathGoogle.SITE_LOGIN_EMAIL_NEXT_BUTTON_XPATH).Click();
		}
		public void InputPasswordInLogin(string password)
		{
			FindElementWithWaiter(XPathGoogle.SITE_LOGIN_PASSWORD_XPATH).SendKeys(password);
			FindElementWithWaiter(XPathGoogle.SITE_LOGIN_PASSWORD_NEXT_BUTTON).Click();
		}		
	}
}




