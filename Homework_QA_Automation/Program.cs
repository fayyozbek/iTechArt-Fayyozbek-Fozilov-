using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


class Program{

    static void Main(string[] arg){
       
        IWebDriver driver= new FirefoxDriver(new FirefoxOptions());
        driver.Url="https://uzmarketing.com/";
        driver.FindElement(By.XPath("//strong[text()='Services']")).Click();
        IWebElement element= driver.FindElement(By.XPath("//a[contains(@href, '/services/marketing-tools/')]"));
       Console.WriteLine(element.Text); 
       //   element= driver.FindElement(By.XPath("//a[contains(@href, '/services/marketing-tools/')]"));
      // Console.WriteLine(element.Text);
      //driver.Url="https://uzmarketing.com/";
        driver.FindElement(By.ClassName("fa-lightbulb-o")).Click();
        element= driver.FindElement(By.XPath("//h4[text()='Graphic Design']"));
        Console.WriteLine(element.Text); 
        driver.FindElement(By.XPath("//strong[text()='Contact']")).Click();
        element= driver.FindElement(By.XPath("//span[contains(text(), 'Fax')]"));
        Console.WriteLine(element.Text);

    }
}