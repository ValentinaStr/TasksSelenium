using OpenQA.Selenium;

namespace MailGoogle
{
	public class Letter :BasePage
	{
		public Letter (IWebDriver _driverGoogle) : base(_driverGoogle)
		{
		}
		public void CreateNewLetterAndSend(string adress, string term, string text)
		{
			InputNewLetterAddress(adress);
			InputNewLetterTerm(term);
			InputTextNewLetter(text);
			SendNewLetter();
		}

		public void CreateNewLetter(string adress, string term, string text)
		{
			InputNewLetterAddress(adress);
			InputNewLetterTerm(term);
			InputTextNewLetter(text);
		}

		public void InputNewLetterAddress(string address)
		{
			FindElementWithWaiter(XPathGoogle.SITE_NEW_LETTER_ADDRESS_XPATH).SendKeys(address);
		}
		public void InputNewLetterTerm(string term)
		{
			FindElementWithWaiter(XPathGoogle.SITE_NEW_LETTER_TERM_XPATH).SendKeys(term);
		}
		public void InputTextNewLetter(string text)
		{
			FindElementWithWaiter(XPathGoogle.SITE_NEW_LETTER_TEXT_XPATH).SendKeys(text);
		}
		public void SendNewLetter()
		{
			FindElementWithWaiter(XPathGoogle.SITE_SEND_NEW_LETTER_XPATH).Click();
		}

		public string GetTermLetter()
		{
			
			return FindElementWithWaiter(XPathGoogle.SITE_OPEN_LETTER_TERM_XPATH).Text;
		}
		public string GetTextLetter()
		{			
			return FindElementWithWaiter(XPathGoogle.SITE_OPEN_LETTER_TEXT_XPATH).Text;
		}

		public void CreateAnswerLetter(string text)
		{
			InputAnswerText(text);
			SendAnswerLetter();
		}
		public void InputAnswerText(string text)
		{
			FindElementWithWaiter(XPathGoogle.SITE_LETTER_ANSWER_TEXT_XPATH).SendKeys(text);
		}
		public void SendAnswerLetter()
		{
			FindElementWithWaiter(XPathGoogle.SITE_LETTER_ANSWER_SEND_XPATH).Click();
		}
		public void ClosedNewLetter()
		{
			FindElementWithWaiter(XPathGoogle.SITE_CLOSED_NEW_LETTER_XPATH).Click();
		}
		
		public IWebElement ErrorNewMessageEmail()
		{
			return FindElementWithWaiter(XPathGoogle.SITE_ERROR_MESSAGE_EMAIL);
		}
	}
}
