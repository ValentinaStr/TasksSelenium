using OpenQA.Selenium;

namespace MailGoogle
{
	public class HomePage: BasePage
	{
		public HomePage(IWebDriver _driverGoogle) : base(_driverGoogle)
		{
			
		}

		public LoginPage OpenLoginPage()
		{
			FindElementWhithWaiter(XPathGoogle.SITE_EMAIL_XPATH).Click();
			return new LoginPage(_driverGoogle);
		}	
		
		public string GetUrl()
		{
			return FindElementWhithWaiter(XPathGoogle.SITE_NAME_POST_XPATH).Text;
		}

		
	}
}
