using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Runtime.Intrinsics.X86;

namespace MailGoogle
{
	public class Letter : AccountMail
	{		
		const string SITE_NEW_LETTER_ADDRESS_XPATH = "//input[@peoplekit-id='BbVjBd']";
		const string SITE_NEW_LETTER_TERM_XPATH = "//input[@name='subjectbox']";
		const string SITE_NEW_LETTER_TEXT_XPATH = "//div[@class='Am Al editable LW-avf tS-tW']";
		const string SITE_SEND_NEW_LETTER_XPATH = "//td[@class='gU Up']";
		const string SITE_OPEN_LETTER_TERM_XPATH = "//h2[@class='hP']";
		const string SITE_OPEN_LETTER_TEXT_XPATH = "//div[@class='a3s aiL ']/div[1]";
		const string SITE_LETTER_ANSWER_TEXT_XPATH = "//div[@class='Am aO9 Al editable LW-avf tS-tW']";
		const string SITE_LETTER_ANSWER_SEND_XPATH = "//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']";
		public Letter (IWebDriver driverGoogle) : base(driverGoogle)
		{
		}
		public void CreateNewLetter(string adress, string term, string text)
		{
			InputNewLetterAddress(adress);
			InputNewLetterTerm(term);
			InputTextNewLetter(text);
			SendNewLetter();
		}

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
		}

		public string GetTermLetter()
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_OPEN_LETTER_TERM_XPATH)));
			return _driverGoogle.FindElement(By.XPath(SITE_OPEN_LETTER_TERM_XPATH)).Text;
		}
		public string GetTextLetter()
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SITE_OPEN_LETTER_TEXT_XPATH)));
			return _driverGoogle.FindElement(By.XPath(SITE_OPEN_LETTER_TEXT_XPATH)).Text;
		}

		public void CreateAnswerLetter(string text)
		{
			InputAnswerText(text);
			SendAnswerLetter();
		}
		public void InputAnswerText(string text)
		{
			FindElementWhithWaiter(SITE_LETTER_ANSWER_TEXT_XPATH).SendKeys(text);
		}
		public void SendAnswerLetter()
		{
			FindElementWhithWaiter(SITE_LETTER_ANSWER_SEND_XPATH).Click();
		}

	}
}
