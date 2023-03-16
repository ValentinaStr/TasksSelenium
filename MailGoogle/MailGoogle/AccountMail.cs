﻿using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;

namespace MailGoogle
{
	public class AccountMail : BasePage
	{
		IList<IWebElement> listLetters;
		const int STOPWATCH = 60000;
		
		public AccountMail(IWebDriver _driverGoogle) : base(_driverGoogle)
		{

		}
		public string GetUserName()
		{
			SwithToFrame();
			return FindElementWhithWaiter(XPathGoogle.SITE_USER_NAME_XPATH).Text;
		}

		public void OpenMoreMenu()
		{
			FindElementWhithWaiter(XPathGoogle.SITE_MENU_BUTTON_MORE_XPATH).Click();
		}

		public void OpenDraftPage()
		{
			FindElementsWhithWaiter(XPathGoogle.SITE_ALL_MENU_XPATH)[7].Click();
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
			/*
			while (stopwatch.ElapsedMilliseconds > STOPWATCH)
			{
				try
				{
					FindElementWhithWaiter(XPathGoogle.SITE_RELOAD_MAIL_XPATH).Click();
					var term = CHeckTermLetter();
					if (term == termLetter)
						break;
				}
				catch
				{

				}

			}*/
			while (CHeckTermLetter() != termLetter | stopwatch.ElapsedMilliseconds > STOPWATCH)
			{
				FindElementWhithWaiter(XPathGoogle.SITE_RELOAD_MAIL_XPATH).Click();
			}
			stopwatch.Stop();
		}

		public void OpenFirstLetter()
		{
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
			catch { return "no text"; }
		}

		public string GetTextDraftLetter()
		{
			return FindElementWhithWaiter(XPathGoogle.SITE_TERM_DREFT_LETTER).Text;
		}


		public int GetCounterNewLetter()
		{
			try
			{
				var countOfNewLetter = FindElementWhithWaiter(XPathGoogle.SITE_EMAIL_COUNTER_NEW_LETTER_XPATH).Text;
				int countNewletter = Int32.Parse(countOfNewLetter);
				return countNewletter;
			}
			catch
			{
				return 0;
			}
		}
		public Letter OpenNewLetter()
		{
			FindElementWhithWaiter(XPathGoogle.SITE_OPEN_NEW_LETTER_XPATH).Click();
			return new Letter(_driverGoogle);
		}
		public Letter OpenAnswerLetter()
		{
			FindElementWhithWaiter(XPathGoogle.SITE_LETTER_ANSWER_XPATH).Click();
			return new Letter(_driverGoogle);
		}

		public void Exit()
		{
			try
			{
				_wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(XPathGoogle.SITE_CHECK_SEND_LETTER)));
				SwithToFrame();
				Thread.Sleep(800);
				FindElementsWhithWaiter(XPathGoogle.SITE_ACCOUNT_EXIT_XPATH)[1].Click();
			}
			catch
			{
				AcceptAlert();
			}
		}
	}
}
