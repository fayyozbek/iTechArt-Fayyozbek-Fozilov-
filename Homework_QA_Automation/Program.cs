using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
class Program{
    static void Main(string[] arg){
       //step 1
       IWebDriver driver= new FirefoxDriver(new FirefoxOptions());//opening FireFox browser
       driver.Url="https://uzmarketing.com/";// move to website by link
       //step 2
       driver.FindElement(By.XPath("//strong[text()='Services']")).Click();// looking for strong which text equal to "Services" and click it
       IWebElement element= driver.FindElement(By.XPath("//a[contains(@href, '/services/marketing-tools/')]"));// looking for hyperlink which href contains the link to marketing tools  
       Console.WriteLine(element.Text); // show expeted result
       //step 3
       driver.FindElement(By.ClassName("fa-lightbulb-o")).Click();// find object by class name and click it
       element= driver.FindElement(By.XPath("//h4[text()='Graphic Design']"));// looking for h4 which text equal to "Graphic Design"
       Console.WriteLine(element.Text); // show expeted result
       // step 4
       driver.FindElement(By.XPath("//strong[text()='Contact']")).Click();// looking for strong which text equal to "Contact" and click it
       element= driver.FindElement(By.XPath("//span[contains(text(), 'Fax')]"));// looking for span which text contains 'fax'
       Console.WriteLine(element.Text);// show expected result
       driver.Quit();
    }
}