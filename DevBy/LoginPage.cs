using OpenQA.Selenium;
namespace DevBy
{
	public class LoginPage : HomePage
	{
		IWebDriver _driverDevBy;

		const string SITE_PARTS_LOGIN_FORM = "//a[@href='https://id.devby.io/@/hello']";
		const string SITE_PARTS_EMAIL = "//input[@name='email']";
		const string SITE_PARTS_PASSWORD = "//input[@name='password']";
		const string SITE_LOGIN_FORM_SUBMIT = "//span[@class='button__content']";

		public LoginPage(IWebDriver driverDevBy): base(driverDevBy)
		{
		
		}

		public void OpenLoginForm()
		{
			_driverDevBy.FindElement(By.XPath(SITE_PARTS_LOGIN_FORM)).Click();
		}

		public void Logining()
		{
			Thread.Sleep(3000);

			var _name = _driverDevBy.FindElement(By.XPath(SITE_PARTS_EMAIL));
			_name.Click();
			_name.SendKeys("vvalentina_@list.ru");

			var _password = _name.FindElement(By.XPath(SITE_PARTS_PASSWORD));
			_password.Click();
			_password.SendKeys("***123");

			Thread.Sleep(3000);

			_driverDevBy.FindElement(By.XPath(SITE_LOGIN_FORM_SUBMIT)).Click();

		}
	}
}
