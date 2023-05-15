using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;
using Tests.helpers;

namespace Tests
{
    [TestClass]
    public class Test
    {
        private readonly AndroidDriver<OpenQA.Selenium.Appium.AppiumWebElement> _Driver = Setup.InitializeAndroidDriver();
        [TestMethod]
        public void TestMethod1()
        {
            while (true)
                _Driver.FindElementByAccessibilityId("Reload", WaitConfig.Default).Click();
        }
    }
}