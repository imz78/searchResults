using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestData
            String[] keyWord = { "Equiniti Crawley", "Shogun wiktionary" };
            String[] targetUrl = { "https://equiniti.com/uk/location", "https://en.wiktionary.org/wiki/shogun" };
            string searchUrl = "https://www.google.co.uk";

            //Initilization of variables
            String getSite = "";
            bool resultStatus = false;
            int count;
            IWebDriver driver = new ChromeDriver();

            //Itteration of the 2 pieces of Test Data above are performed from here.
            for (count = 0; count <= 2; count++)
            {
                if (!resultStatus)
                    if (count != 0)
                    {
                        Console.WriteLine("THE TARGET URL  " + targetUrl[count - 1] + "  WAS NOT SHOWN ON THE FIRST PAGE RESULTS....!!!!!!!");
                    }
                driver.Url = searchUrl;
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

                //This determines if the two searches have been performed, if so the Test will finish here.
                if (count == 2)
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    driver.Close();
                    System.Environment.Exit(1);
                }

                //Search Criteria is entered here and search is search button is clicked.
                driver.FindElement(By.Name("q")).SendKeys(keyWord[count]);
                driver.FindElement(By.Name("btnK")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                //A list of URL's are extracted from the results returned from the search.
                IList<IWebElement> results = driver.FindElements(By.XPath("//div[@class='r']//a"));
                resultStatus = false;

                //Verification is performed here to determine if the required search URL is found in the google search results on the first page only.
                for (int i = 0; i < results.Count; i++)
                {
                    String res = results[i].GetAttribute("href");
                    if (res.Contains(targetUrl[count]))
                    {
                        resultStatus = true;
                        getSite = res;
                        Console.WriteLine("THE SITE  " + getSite + "  IS SHOWING ON THE FIRST PAGE....!!!!!!!");
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        if (count > 1)
                        {
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            driver.Close();
                            System.Environment.Exit(1);
                        }
                        break;
                    }

                }
            }
        }
    }
}
