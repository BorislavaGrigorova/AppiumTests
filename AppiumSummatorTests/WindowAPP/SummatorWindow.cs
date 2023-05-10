using OpenQA.Selenium.Appium.Windows;

namespace AppiumSummatorTests.WindowAPP
{
    public class SummatorWindow
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public SummatorWindow(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        public WindowsElement textBoxFirstNum => driver.FindElementByAccessibilityId("textBoxFirstNum");
        public WindowsElement textBoxSecondNum => driver.FindElementByAccessibilityId("textBoxSecondNum");
        public WindowsElement buttonCalc => driver.FindElementByAccessibilityId("buttonCalc");
        public WindowsElement textBoxSum => driver.FindElementByAccessibilityId("textBoxSum");

        public string Calculate(string field1, string field2)
        {
            //textBoxFirstNum.Click();
            textBoxFirstNum.SendKeys(field1);

            //textBoxSecondNum.Click();
            textBoxSecondNum.SendKeys(field2);

            buttonCalc.Click(); 

            return textBoxSum.Text;

        }
    }
}
