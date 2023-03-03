using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V108.DOM;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace MailGoogle
{
	public class AccountMail:HomePage
	{
		IList<IWebElement> allFrameAccount;
		IList<IWebElement> listLetters;

		const string SITE_RELOAD_MAIL_XPATH ="//div[@class='T-I J-J5-Ji nu T-I-ax7 L3']";
		const string SITE_OPEN_NEW_LETTER_XPATH = "//div[@class='T-I T-I-KE L3']";
		const string SITE_OPEN_ACCOUNT_XPATH = "//a[@class='gb_e gb_0a gb_r']";
		const string SITE_OPEN_FIRST_LETTER_XPATH = "//tr[@role='row']";
		const string CHECK_TERM_XPATH = "//span[@class='bog']/span";
		const string CHECK_TEXT_XPATH = "//div[@class='xT']/span";
		const string SITE_LETTER_ANSWER_XPATH = "//span[@class='ams bkH']";
		const string SITE_ACCOUNT_EXIT_XPATH = "//div[@class='SedFmc']";
		const string SITE_CHECK_SEND_LETTER = "//span[class='aT']";

		public AccountMail(IWebDriver driverGoogle) : base(driverGoogle)
		{

		}
		public Letter OpenNewLetter()
		{
			FindElementWhithWaiter(SITE_OPEN_NEW_LETTER_XPATH).Click();
			return new Letter(_driverGoogle);
		}
		
		public void WaitLetterWithTermAndText(string termLetter,string textLetter )
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			while ((CHeckTermLetter() != termLetter & CheckTextLetter() != textLetter) | stopwatch.ElapsedMilliseconds > 600000)
			{
				FindElementWhithWaiter(SITE_RELOAD_MAIL_XPATH).Click();
			}
			stopwatch.Stop();
		}

		public void WaitLetterWithTerm(string termLetter)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			while (CHeckTermLetter() != termLetter | stopwatch.ElapsedMilliseconds > 600000)
			{
				FindElementWhithWaiter(SITE_RELOAD_MAIL_XPATH).Click();
			}
			stopwatch.Stop();
		}

		public void OpenFirstLetter()
		{
			Thread.Sleep(500);
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_OPEN_FIRST_LETTER_XPATH)));
			listLetters = _driverGoogle.FindElements(By.XPath(SITE_OPEN_FIRST_LETTER_XPATH));
			listLetters[0].Click();
		}

		public string CHeckTermLetter()
		{
			try { return FindElementWhithWaiter(CHECK_TERM_XPATH).Text; }
			catch { return "no letter"; }
		}

		public string CheckTextLetter()
		{
			try
			{
				var textLetter = _driverGoogle.FindElement(By.XPath(CHECK_TEXT_XPATH)).Text;
				return textLetter.Substring(5);
			}
			catch { return "no letter"; }
		}

		public Letter OpenAnswerLetter()
		{
			FindElementWhithWaiter(SITE_LETTER_ANSWER_XPATH).Click();
			return new Letter(_driverGoogle);
		}
		
		public void Exit()
		{

			_wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(SITE_CHECK_SEND_LETTER)));
			_driverGoogle.FindElement(By.XPath(SITE_OPEN_ACCOUNT_XPATH)).Click();
			_driverGoogle.SwitchTo().Frame("account");
			allFrameAccount = _driverGoogle.FindElements(By.XPath(SITE_ACCOUNT_EXIT_XPATH));
			allFrameAccount[1].Click();
		}
	}
}
