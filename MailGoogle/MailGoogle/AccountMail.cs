using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;

namespace MailGoogle
{
	public class AccountMail : BasePage
	{
		IList<IWebElement> allFrameAccount;
		IList<IWebElement> listLetters;
		const int STOPWATCH = 60000;

		public AccountMail(IWebDriver _driverGoogle) : base(_driverGoogle)
		{

		}
		public string GetUserName()
		{
			var str = FindElementWhithWaiter(XPathGoogle.SITE_USER_NAME_XPATH).Text;
			Console.WriteLine(str);
			Console.WriteLine("________");
			return str;
		}
		public void WaitLetterWithTermAndText(string termLetter, string textLetter)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			while ((CHeckTermLetter() != termLetter && CheckTextLetter() != textLetter) | stopwatch.ElapsedMilliseconds > STOPWATCH)
			{
				FindElementWhithWaiter(XPathGoogle.SITE_RELOAD_MAIL_XPATH).Click();
			}
			stopwatch.Stop();
		}

		public void WaitLetterWithTerm(string termLetter)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			while (stopwatch.ElapsedMilliseconds > STOPWATCH)
			{
				try
				{
					var term = FindElementWhithWaiter(XPathGoogle.CHECK_TERM_XPATH).Text;
					FindElementWhithWaiter(XPathGoogle.SITE_RELOAD_MAIL_XPATH).Click();
					if (term == termLetter)
						break;
				}
				catch
				{

				}

			}
			stopwatch.Stop();
		}

		public void OpenFirstLetter()
		{
			FindElementWhithWaiter(XPathGoogle.SITE_OPEN_FIRST_LETTER_XPATH);
			listLetters = FindElementsWhithWaiter(XPathGoogle.SITE_OPEN_FIRST_LETTER_XPATH);
			listLetters[0].Click();
		}

		public string CHeckTermLetter()
		{
			try { return FindElementWhithWaiter(XPathGoogle.CHECK_TERM_XPATH).Text; }
			catch { return "no letter"; }
		}

		public string CheckTextLetter()
		{
			try
			{
				var textLetter = FindElementWhithWaiter(XPathGoogle.CHECK_TEXT_XPATH).Text;
				return textLetter.Substring(5);
			}
			catch { return "no letter"; }
		}
		public void Exit()
		{
			_wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(XPathGoogle.SITE_CHECK_SEND_LETTER)));
			FindElementWhithWaiter(XPathGoogle.SITE_OPEN_ACCOUNT_XPATH).Click();
			Thread.Sleep(100);
			SwithFrame();
			Thread.Sleep(100);
			allFrameAccount = FindElementsWhithWaiter(XPathGoogle.SITE_ACCOUNT_EXIT_XPATH);
			allFrameAccount[1].Click();
		}
	}
}
