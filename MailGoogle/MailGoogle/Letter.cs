using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MailGoogle
{
	public class Letter :BasePage
	{		
		const string SITE_NEW_LETTER_ADDRESS_XPATH = "//input[@peoplekit-id='BbVjBd']";
		const string SITE_NEW_LETTER_TERM_XPATH = "//input[@name='subjectbox']";
		const string SITE_NEW_LETTER_TEXT_XPATH = "//div[@class='Am Al editable LW-avf tS-tW']";
		const string SITE_SEND_NEW_LETTER_XPATH = "//td[@class='gU Up']";
		const string SITE_OPEN_LETTER_TERM_XPATH = "//h2[@class='hP']";
		const string SITE_OPEN_LETTER_TEXT_XPATH = "//div[@class='a3s aiL ']/div[1]";
		const string SITE_LETTER_ANSWER_TEXT_XPATH = "//div[@class='Am aO9 Al editable LW-avf tS-tW']";
		const string SITE_LETTER_ANSWER_SEND_XPATH = "//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']";
		const string SITE_LETTER_CLOSED_ALERT = "//div[@class='bBe']";
		const string SITE_CHECK_SEND_LETTER = "//span[class='aT']";
		public Letter (IWebDriver _driverGoogle) : base(_driverGoogle)
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
			
			return FindElementWhithWaiter(SITE_OPEN_LETTER_TERM_XPATH).Text;
		}
		public string GetTextLetter()
		{			
			return FindElementWhithWaiter(SITE_OPEN_LETTER_TEXT_XPATH).Text;
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

		/*public void CloseAlert()
		{
			_wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(SITE_CHECK_SEND_LETTER)));
			FindElementWhithWaiter(SITE_LETTER_CLOSED_ALERT).Click();
			
		}*/
	}
}
