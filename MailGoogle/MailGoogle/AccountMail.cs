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

		const string SITE_RELOAD_MAIL_XPATH = "//*[@id=':4']/div/div[1]/div[1]/div/div/div[5]/div"; //div[@class='T-I J-J5-Ji nu T-I-ax7 L3']";


		const string SITE_OPEN_NEW_LETTER_XPATH = "//div[@class='T-I T-I-KE L3']";

		const string SITE_NEW_LETTER_ADDRESS_XPATH = "//input[@peoplekit-id='BbVjBd']";
		const string SITE_NEW_LETTER_TERM_XPATH = "//input[@name='subjectbox']";
		const string SITE_NEW_LETTER_TEXT_XPATH = "//div[@class='Am Al editable LW-avf tS-tW']";
		const string SITE_SEND_NEW_LETTER_XPATH = "//td[@class='gU Up']";

		const string SITE_OPEN_ACCOUNT_XPATH = "//div[@class='gb_Ef gb_4a gb_qg gb_r']";

		const string SITE_OPEN_FIRST_LETTER_XPATH = "//tr[@role='row']";
		const string CHECK_TERM = "//span[@class='bog']/span";
		const string CHECK_TEXT_XPATH = "//div[@class='xT']/span";

		const string SITE_OPEN_LETTER_TERM_XPATH = "//h2[@class='hP']";
		const string SITE_OPEN_LETTER_TEXT_XPATH = "//div[@class='a3s aiL ']/div[1]";

		const string SITE_LETTER_ANSWER_XPATH = "//span[@class='ams bkH']";
		const string SITE_LETTER_ANSWER_TEXT_XPATH = "//div[@class='Am aO9 Al editable LW-avf tS-tW']";
		const string SITE_LETTER_ANSWER_SEND_XPATH = "//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']";

		const string SITE_ACCOUNT_EXIT = "//div[@class='SedFmc']";

		public AccountMail(IWebDriver driverGoogle) : base(driverGoogle)
		{

		}
		public Letter OpenNewLetter()
		{
			FindElementWhithWaiter(SITE_OPEN_NEW_LETTER_XPATH).Click();
			return new Letter(_driverGoogle);
		}
		/*
		public void InputNewLetterAddress(string address) 
		{
			FindElementWhithWaiter(SITE_NEW_LETTER_ADDRESS_XPATH).SendKeys(address);
		}
		public void InputNewLetterTerm(string term)
		{
			FindElementWhithWaiter(SITE_NEW_LETTER_TERM_XPATH).SendKeys(term);
		}
		public void InputTextNewLetter(string text)
		{
			FindElementWhithWaiter(SITE_NEW_LETTER_TEXT_XPATH).SendKeys(text);
		}
		public void SendNewLetter()
		{
			FindElementWhithWaiter(SITE_SEND_NEW_LETTER_XPATH).Click();
		}*/

		public void WaitLetterWithTermAndText(string termLetter,string textLetter )
		{
			//_driverGoogle.FindElement(By.XPath(SITE_RELOAD_MAIL_XPATH)).Click();
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			while ((CHeckTermLetter() != termLetter & CheckTextLetter() != textLetter) | stopwatch.ElapsedMilliseconds > 600000)
			{
				_driverGoogle.FindElement(By.XPath(SITE_RELOAD_MAIL_XPATH)).Click();
			}
			stopwatch.Stop();
		}

		public void WaitLetterWithTerm(string termLetter)
		{
			//_driverGoogle.FindElement(By.XPath(SITE_RELOAD_MAIL_XPATH)).Click();
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
			return FindElementWhithWaiter(CHECK_TERM).Text;
		}

		public string CheckTextLetter()
		{
			var textLetter = _driverGoogle.FindElement(By.XPath(CHECK_TEXT_XPATH)).Text;
			return textLetter.Substring(5);
		}

		/*public string GetTermLetter()
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_OPEN_LETTER_TERM_XPATH)));
			return _driverGoogle.FindElement(By.XPath(SITE_OPEN_LETTER_TERM_XPATH)).Text;
		}
		public string GetTextLetter()
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_OPEN_LETTER_TEXT_XPATH)));
			return _driverGoogle.FindElement(By.XPath(SITE_OPEN_LETTER_TEXT_XPATH)).Text;
		}*/

		/*public void CreateAnswerLetter(string text)
		{
			this.OpenAnswerLetter();
			this.InputAnswerText(text);
			this.SendAnswerLetter();
		}*/
		public Letter OpenAnswerLetter()
		{
			FindElementWhithWaiter(SITE_LETTER_ANSWER_XPATH).Click();
			return new Letter(_driverGoogle);
		}
		/*public void InputAnswerText(string text)
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_LETTER_ANSWER_TEXT_XPATH)));
			_driverGoogle.FindElement(By.XPath(SITE_LETTER_ANSWER_TEXT_XPATH)).SendKeys(text);	
		}
		public void SendAnswerLetter()
		{
			_wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(SITE_LETTER_ANSWER_SEND_XPATH)));
			_driverGoogle.FindElement(By.XPath(SITE_LETTER_ANSWER_SEND_XPATH)).Click();
		}*/

		public void Exit()
		{
			_driverGoogle.FindElement(By.XPath(SITE_OPEN_ACCOUNT_XPATH)).Click();
			Thread.Sleep(300);
			_driverGoogle.SwitchTo().Frame("account");
			allFrameAccount = _driverGoogle.FindElements(By.XPath(SITE_ACCOUNT_EXIT));
			allFrameAccount[1].Click();
		}
	}
}
