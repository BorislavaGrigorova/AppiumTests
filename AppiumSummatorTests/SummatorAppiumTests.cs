using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumSummatorTests
{
    public class SummatorAppiumTests
    {
        private WindowsDriver<WindowsElement> driver; 
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;

        [SetUp]
        public void OpenApp()
        {
            options = new AppiumOptions() { PlatformName = "Windows" }; 
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\WindowsFormsApp.exe"); 

            driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
        }
        [TearDown]
        public void CloseAPP()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Two_Positive_Numbers()
        {
            var textBoxFirstNum = driver.FindElementByAccessibilityId("textBoxFirstNum");
            textBoxFirstNum.SendKeys("5");

            var textBoxSecondNum = driver.FindElementByAccessibilityId("textBoxSecondNum");
            textBoxSecondNum.SendKeys("7");

            var buttonCalc = driver.FindElementByAccessibilityId("buttonCalc");
            buttonCalc.Click();

            var textBoxSum = driver.FindElementByAccessibilityId("textBoxSum");

            Assert.AreEqual("12", textBoxSum.Text);
        }

        [Test]
        public void Test_Invalid_Values()
        {
            var textBoxFirstNum = driver.FindElementByAccessibilityId("textBoxFirstNum");
            textBoxFirstNum.SendKeys("invalid1");

            var textBoxSecondNum = driver.FindElementByAccessibilityId("textBoxSecondNum");
            textBoxSecondNum.SendKeys("invalid2");

            var buttonCalc = driver.FindElementByAccessibilityId("buttonCalc");
            buttonCalc.Click();

            var textBoxSum = driver.FindElementByAccessibilityId("textBoxSum");

            Assert.AreEqual("error", textBoxSum.Text);
        }
    }
}