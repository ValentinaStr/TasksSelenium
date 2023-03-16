﻿using OpenQA.Selenium;

namespace MailGoogle
{
	public class HomePage: BasePage
	{
		public HomePage(IWebDriver _driverGoogle) : base(_driverGoogle)
		{
			GoToUrl("https://www.google.com/intl/ru/gmail/about/");			
		}
		public string GetNamePost()
		{
			return FindElementWhithWaiter(XPathGoogle.SITE_NAME_POST_XPATH).Text;
		}
		public IWebElement CheckSignInButton()
		{
			return FindElementWhithWaiter(XPathGoogle.SITE_EMAIL_LOGIN_XPATH);
		}
		public LoginPage OpenLoginPage()
		{
			FindElementWhithWaiter(XPathGoogle.SITE_EMAIL_LOGIN_XPATH).Click();
			return new LoginPage(_driverGoogle);
		}
		public AccountMail OpenAccountMailPage()
		{
			return new AccountMail(_driverGoogle);
		}
	}
}
