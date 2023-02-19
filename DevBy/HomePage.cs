using OpenQA.Selenium;
namespace DevBy
{
	public class HomePage
	{
		IWebDriver _driverDevBy;

		const string SITE_PARTS_JAVA_VACANCIES = "//a[@title='Java']";
		const string SITE_PARTS_JAVA_VACANCIES_COUNT = "//a[@title='Java']/following-sibling::div";

		public HomePage(IWebDriver driverDevBy)
		{
			_driverDevBy = driverDevBy;
			_driverDevBy.Url = "https://devby.io/";
		}

		internal void OpenJavaVacancies()
		{
			_driverDevBy.FindElement(By.XPath(SITE_PARTS_JAVA_VACANCIES)).Click();
		}

		internal int GetCountJavaVacanciesHomePage()
		{
			var javaVacanсiesAtHomePage = _driverDevBy.FindElement(By.XPath(SITE_PARTS_JAVA_VACANCIES_COUNT));

			try
			{ 
				int countJavaVacanсiesHomePage = Int32.Parse(javaVacanсiesAtHomePage.Text.Trim().Split(' ')[0]);
				return countJavaVacanсiesHomePage;
			}
			catch (FormatException e)
			{
				Console.WriteLine(e.Message);
			}

			return 0;
		}
		
	}
}
