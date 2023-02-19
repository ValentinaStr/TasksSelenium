// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using DevBy;

WebDriver driverDevBy = new ChromeDriver();

driverDevBy.Manage().Window.Maximize();

HomePage homePage = new HomePage(driverDevBy);

int countJavaVacanciesHomePage = homePage.GetCountJavaVacanciesHomePage();

SpecializationJava pageJava = new SpecializationJava(driverDevBy);

var countVacanciesJavaPage = pageJava.GetCountJavaVacancies();

Console.WriteLine(countVacanciesJavaPage.Equals(countJavaVacanciesHomePage));

driverDevBy.Close();
