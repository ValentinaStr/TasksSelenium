using OpenQA.Selenium;

namespace MailGoogle
{
	public class HomePage: BasePage
	{
		public HomePage(IWebDriver _driverGoogle) : base(_driverGoogle)
		{
			
		}
		public string GetUrl()
		{
			return FindElementWhithWaiter(XPathGoogle.SITE_NAME_POST_XPATH).Text;
		}		
	}
}
