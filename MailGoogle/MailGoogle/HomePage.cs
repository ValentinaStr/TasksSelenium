using OpenQA.Selenium;

namespace MailGoogle
{
	public class HomePage : BasePage
	{
		const string SITE_EMAIL_XPATH = "//a[@data-action='sign in']";

		public HomePage(IWebDriver _driverGoogle) : base(_driverGoogle)
		{
			
		}		

		public LoginPage OpenLoginPage()
		{
			FindElementWhithWaiter(SITE_EMAIL_XPATH).Click();
			return new LoginPage(_driverGoogle);
		}		
	}
}
