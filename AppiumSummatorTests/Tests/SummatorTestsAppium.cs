using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using AppiumSummatorTests.WindowAPP;

namespace AppiumSummatorTests.Tests
{
    public class SummatorTestsAppium
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
            driver.Close();
        }

        [Test]
        public void Test_Two_Positive_Numbers()
        {
            var window = new SummatorWindow(driver);

            string value1 = "5";
            string value2 = "15";

            string result = window.Calculate(value1, value2);

            Assert.That(result, Is.EqualTo("20"));
        }

        [Test]
        public void Test_Invalid_Values()
        {
            var window = new SummatorWindow(driver);

            string value1 = "invalid1";
            string value2 = "invalid2";

            string result = window.Calculate(value1, value2);

            Assert.That(result, Is.EqualTo("error"));

        }
    }
}
