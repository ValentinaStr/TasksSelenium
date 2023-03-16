﻿namespace MailGoogle
{
	internal static class XPathGoogle
	{
		internal const string SITE_EMAIL_LOGIN_XPATH = "//a[@data-action='sign in']";
		internal const string SITE_NAME_POST_XPATH = "//a[@href='/intl/ru/gmail/about/']";
		
		//LoginPage
		internal const string SITE_LOGIN_EMAIL_XPATH = "//input[@id='identifierId']";
		internal const string SITE_LOGIN_EMAIL_NEXT_BUTTON_XPATH = "//div[@id='identifierNext']";
		internal const string SITE_LOGIN_PASSWORD_XPATH = "//input[@type='password']";
		internal const string SITE_LOGIN_PASSWORD_NEXT_BUTTON = "//div[@id='passwordNext']";

		//AccountMail
		internal const string SITE_OPEN_ACCOUNT_XPATH = "//a[@class='gb_e gb_1a gb_s']";
		internal const string SITE_USER_NAME_XPATH = "//div[@class='znj3je NB6Lnc']";
		internal const string SITE_RELOAD_MAIL_XPATH = "//div[@class='T-I J-J5-Ji nu T-I-ax7 L3']";
		internal const string SITE_OPEN_NEW_LETTER_XPATH = "//div[@class='T-I T-I-KE L3']";
		internal const string SITE_OPEN_FIRST_LETTER_XPATH = "//tr[@role='row']";
		internal const string CHECK_TERM_XPATH = "//span[@class='bog']/span";
		internal const string CHECK_TEXT_XPATH = "//div[@class='xT']/span";
		internal const string SITE_EMAIL_COUNTER_NEW_LETTER_XPATH = "//div[@class='bsU']";
		internal const string SITE_EMAIL_LIST_NEW_LETTER_XPATH = "//tr[@class='zA zE']";
		internal const string SITE_ALL_MENU_XPATH = "//a[@class='J-Ke n0']";
		internal const string SITE_MENU_BUTTON_MORE_XPATH = "/ html / body / div[7] / div[3] / div / div[2] / div[1] / div[2] / div / div / div / div / div / div[2] / div / div / div[2] / span"; //"span[@class='J-Ke n4 ah9 aiu']"; 
		internal const string SITE_LIST_DRAFTS = "//tr[@class='zA yO']";
		internal const string SITE_GET_TEXT_DRAFT_LETTER = "//div[@style='display: block;']";
		internal const string SITE_TERM_DREFT_LETTER = "/html/body/div[7]/div[3]/div/div[2]/div[2]/div/div/div/div/div[2]/div/div[1]/div/div[2]/div[4]/div[1]/div/table/tbody/tr[1]/td[5]/div/div/div/span/span";
		
		//Letter
		internal const string SITE_LETTER_ANSWER_XPATH = "//span[@class='ams bkH']";
		internal const string SITE_ACCOUNT_EXIT_XPATH = "//div[@class='SedFmc']";
		internal const string SITE_CHECK_SEND_LETTER = "//span[class='aT']";
		internal const string SITE_NEW_LETTER_ADDRESS_XPATH = "//input[@peoplekit-id='BbVjBd']";
		internal const string SITE_NEW_LETTER_TERM_XPATH = "//input[@name='subjectbox']";
		internal const string SITE_NEW_LETTER_TEXT_XPATH = "//div[@class='Am Al editable LW-avf tS-tW']";
		internal const string SITE_CLOSED_NEW_LETTER_XPATH = "//img[@class='Ha']";
		internal const string SITE_SEND_NEW_LETTER_XPATH = "//td[@class='gU Up']";
		internal const string SITE_OPEN_LETTER_TERM_XPATH = "//h2[@class='hP']";
		internal const string SITE_OPEN_LETTER_TEXT_XPATH = "//div[@class='a3s aiL ']/div[1]";
		internal const string SITE_LETTER_ANSWER_TEXT_XPATH = "//div[@class='Am aO9 Al editable LW-avf tS-tW']";
		internal const string SITE_LETTER_ANSWER_SEND_XPATH = "//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']";
		internal const string SITE_ERROR_MESSAGE_EMAIL = "//div[@class='Kj-JD-K7 Kj-JD-K7-bsT']";
	}
}
