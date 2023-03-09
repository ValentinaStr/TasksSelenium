using OpenQA.Selenium;

namespace MailGoogle
{
	public class HomePage: BasePage
	{
		public HomePage(IWebDriver _driverGoogle) : base(_driverGoogle)
		{
			GoToUrl("https://www.google.com/intl/ru/gmail/about/");
			
		}
		public string GetUrl()
		{
			return FindElementWhithWaiter(XPathGoogle.SITE_NAME_POST_XPATH).Text;
		}


	}
}
