using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Security.Policy;
using System.Collections.Generic;
using System.Linq;
namespace seleniumTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        int order = 0;
        string userID1 = "Will Ondrik";
        string userID2 = "Isaiah Ondrik";
        string userID3 = "Jake Ondrik";

        string userID1Address = "Burnaby";
        string userID2Address = "Victoria";
        string userID3Address = "Vernon";


       
        [TestMethod]
        public void TestMethod1() // Create Clients
        {
            //string url = "http://localhost:49198/Clients/Create";
            string url = "https://localhost:44328";
            //string url = "http://localhost:49198";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Client")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
           
            // First user
            driver.FindElement(By.Id("Name")).SendKeys(userID1);
            driver.FindElement(By.Id("Address")).SendKeys(userID1Address);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();

            // Second user
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("Name")).SendKeys(userID2);
            driver.FindElement(By.Id("Address")).SendKeys(userID2Address);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();

            // Third user
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("Name")).SendKeys(userID3);
            driver.FindElement(By.Id("Address")).SendKeys(userID3Address);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }
        [TestMethod]
        public void TestMethod2() // Read - Find and verify the clients
        {
            string url = "https://localhost:44328/Clients";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Find all the <td> elements that are expected to contain names
            var nameCells = driver.FindElements(By.CssSelector("table.table tbody tr td:nth-child(1)"));
            var namesList = nameCells.Select(cell => cell.Text).ToList();

            // Expected names
            var expectedNames = new List<string> { "Will Ondrik", "Isaiah Ondrik", "Jake Ondrik" };

            // Check if all expected names are present in the namesList
            bool allNamesFound = expectedNames.All(expectedName => namesList.Contains(expectedName));

            Assert.IsTrue(allNamesFound, "Not all expected client names were found.");
        }



         [TestMethod]
         public void TestMethod3() // Update - Update the existing clients
         {
             string url = "https://localhost:44328";
             ChromeDriver driver = new ChromeDriver();
             driver.Manage().Window.Maximize();
             driver.Navigate().GoToUrl(url);
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
             driver.FindElement(By.LinkText("Client")).Click();
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("William O");

            driver.FindElement(By.Id("Address")).Clear();
            driver.FindElement(By.Id("Address")).SendKeys("Kelowna");

            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }


        

         [TestMethod]
         public void TestMethod4() // Delete the clients
         {
                 string url = "https://localhost:44328";

             ChromeDriver driver = new ChromeDriver();
             driver.Manage().Window.Maximize();
             driver.Navigate().GoToUrl(url);
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
             driver.FindElement(By.LinkText("Client")).Click();
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();



        }
    }
}