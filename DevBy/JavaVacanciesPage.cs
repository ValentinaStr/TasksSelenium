using OpenQA.Selenium;
namespace DevBy
{
	public class SpecializationJava : HomePage
	{
		IWebDriver _driverDevByVac;
		IList<IWebElement> allVacancies;

		static string SITE_PARTS_LIST_JAVA_VACANCIES = "//a[@class='vacancies-list-item__link_block']";

		public SpecializationJava(IWebDriver driverDevBy): base(driverDevBy)
		{
			_driverDevByVac = driverDevBy;
			_driverDevByVac.Url = "https://jobs.devby.io/?filter[specialization_title]=Java";
		}

		public int GetCountJavaVacancies()
		{
			allVacancies = _driverDevByVac.FindElements(By.XPath(SITE_PARTS_LIST_JAVA_VACANCIES));
			return allVacancies.Count;
		}
	}
}
