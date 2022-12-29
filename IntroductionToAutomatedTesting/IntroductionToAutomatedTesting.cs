using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

class Program{
    
    [Test]
    public void Test(){
       // Step 1
       // Opening Chrome browser
       IWebDriver driver= new ChromeDriver();
       // Move to website by link
       driver.Url="https://uzmarketing.com/";
       
       // Step 2
       // Looking for strong which text equal to "Services" and click it
       driver.FindElement(By.XPath("//strong[text()='Services']")).Click();
       // Looking for hyperlink which href contains the link to marketing tools
       IWebElement element= driver.FindElement(By.XPath("//a[contains(@href, '/services/marketing-tools/')]"));  
       Console.WriteLine(element.Text); // show expeted result
       
       // Step 3
       // Find object by class name and click it
       driver.FindElement(By.ClassName("fa-lightbulb-o")).Click();
       // Looking for h4 which text equal to "Graphic Design"
       element= driver.FindElement(By.XPath("//h4[text()='Graphic Design']"));
       Console.WriteLine(element.Text); // show expeted result
       
       // Step 4
       // Looking for strong which text equal to "Contact" and click it
       driver.FindElement(By.XPath("//strong[text()='Contact']")).Click();
       // Looking for span which text contains 'fax'
       element= driver.FindElement(By.XPath("//span[contains(text(), 'Fax')]"));
       // Show expected result
       Console.WriteLine(element.Text);
       driver.Quit();
    }
}