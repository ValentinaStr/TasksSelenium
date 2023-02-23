using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Net;
using System.Threading;

namespace MailGoogle
{
	public class AccountMail:HomePage
	{
		IList<IWebElement> allFrameAccount;
		IList<IWebElement> listLetters;

		const string SITE_OPEN_NEW_LETTER_XPATH = "//div[@class='T-I T-I-KE L3']";
		const string SITE_NEW_LETTER_ADDRESS_XPATH = "//input[@peoplekit-id='BbVjBd']";
		const string SITE_NEW_LETTER_TERM = "//input[@name='subjectbox']";
		const string SITE_SEND_NEW_LETTER_XPATH = "//td[@class='gU Up']";
		const string SITE_OPEN_ACCOUNT_XPATH = "//div[@class='gb_Ef gb_4a gb_qg gb_r']";
		const string SITE_OPEN_LETTER_XPATH = "//tr[@jscontroller='ZdOxDb']";
		const string SITE_OPEN_LETTER_TERM_XPATH = "//h2[@class='hP']";
		const string SITE_LETTER_ANSWER_XPATH = "//span[@class='ams bkH']";
		const string SITE_LETTER_ANSWER_TEXT_XPATH = "//div[@class='Am aO9 Al editable LW-avf tS-tW']";
		const string SITE_LETTER_ANSWER_SEND_XPATH = "//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']";
		const string SITE_ACCOUNT_EXIT = "//div[@class='SedFmc']";
		public AccountMail(IWebDriver driverGoogle) : base(driverGoogle) 
		{

		}
		public void CreateNewLetter(string adress, string term)
		{
			this.OpenNewLetter();
			this.InputNewLetterAddress(adress);
			this.InputNewLetterTerm(term);
			this.SendNewLetter();
		}
		public void OpenNewLetter()
		{
			FindElementWhithWeiter(SITE_OPEN_NEW_LETTER_XPATH).Click();
			//_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_MASSAGE_EMAIL_XPATH)));
			//_driverGoogle.FindElement(By.XPath(SITE_MASSAGE_EMAIL_XPATH)).Click();
		}

		public void InputNewLetterAddress(string address) 
		{
			FindElementWhithWeiter(SITE_NEW_LETTER_ADDRESS_XPATH).SendKeys(address);
			//_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_MASSGE_WHOM_XPATH)));
			//_driverGoogle.FindElement(By.XPath(SITE_MASSGE_WHOM_XPATH)).SendKeys(address);
		}

		public void InputNewLetterTerm(string term)
		{
			FindElementWhithWeiter(SITE_NEW_LETTER_TERM).SendKeys(term);
			//_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_ACCOUNT_TERM)));
			//_driverGoogle.FindElement(By.XPath(SITE_ACCOUNT_TERM)).SendKeys(term);
		}

		public void SendNewLetter()
		{
			FindElementWhithWeiter(SITE_SEND_NEW_LETTER_XPATH).Click();
			//_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_SEND_MASSAGE_XPATH)));
			//_driverGoogle.FindElement(By.XPath(SITE_SEND_MASSAGE_XPATH)).Click();
		}

		public void OpenFirstLetter()
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_OPEN_LETTER_XPATH)));
			listLetters = _driverGoogle.FindElements(By.XPath(SITE_OPEN_LETTER_XPATH));
			listLetters[0].Click();
		}

		public string GetTermLetter()
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_OPEN_LETTER_TERM_XPATH)));
			return _driverGoogle.FindElement(By.XPath(SITE_OPEN_LETTER_TERM_XPATH)).Text;
		}

		public void AnswerLetter(string text)
		{
			this.OpenAnswerLetter();
			this.InputAnswerText(text);
			this.SendAnswerLetter();

		}
		public void OpenAnswerLetter()
		{
			_driverGoogle.FindElement(By.XPath(SITE_LETTER_ANSWER_XPATH)).Click();
		}

		public void InputAnswerText(string text)
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_LETTER_ANSWER_TEXT_XPATH)));
			_driverGoogle.FindElement(By.XPath(SITE_LETTER_ANSWER_TEXT_XPATH)).SendKeys(text);	
		}

		public void SendAnswerLetter()
		{
			_wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(SITE_LETTER_ANSWER_SEND_XPATH)));
			_driverGoogle.FindElement(By.XPath(SITE_LETTER_ANSWER_SEND_XPATH)).Click();
		}

		public void Exit()
		{
			_driverGoogle.FindElement(By.XPath(SITE_OPEN_ACCOUNT_XPATH)).Click();
			Thread.Sleep(3000);
			_driverGoogle.SwitchTo().Frame("account");
			allFrameAccount = _driverGoogle.FindElements(By.XPath(SITE_ACCOUNT_EXIT));
			allFrameAccount[1].Click();
		}
	}
}
