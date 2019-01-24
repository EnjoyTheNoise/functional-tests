using System;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace FunctionalTests
{
    public class Tests : IDisposable
    {
        public IWebDriver Driver { get; set; }

        public Tests()
        {
            try
            {
                Driver = new ChromeDriver(Directory.GetCurrentDirectory());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception thrown in Tests.ctor(): {e}");
            }
        }

        [Fact]
        public void ValidateAppTitle()
        {
            Driver.Navigate().GoToUrl(GlobalConfig.BaseUrl);

            Assert.Equal(GlobalConfig.Title, Driver.Title);
        }

        [Fact]
        public void TestSuccessfulLogin()
        {
            Driver.Navigate().GoToUrl(LoginFormConfig.LoginUrl);

            Thread.Sleep(1000);

            var emailInput = Driver.FindElement(By.XPath(LoginFormConfig.EmailInput));
            var passwordInput = Driver.FindElement(By.XPath(LoginFormConfig.PasswordInput));
            var loginButton = Driver.FindElement(By.XPath(LoginFormConfig.LoginButton));

            Assert.NotNull(emailInput);
            Assert.NotNull(passwordInput);
            Assert.NotNull(loginButton);

            emailInput.Clear();
            passwordInput.Clear();

            emailInput.SendKeys(GlobalConfig.DefaultLogin);
            passwordInput.SendKeys(GlobalConfig.DefaultPassword);
            loginButton.Click();

            Thread.Sleep(5000);

            Assert.Equal(GlobalConfig.BaseUrl, Driver.Url);
        }

        [Fact]
        public void TestFailedLogin()
        {
            Driver.Navigate().GoToUrl(LoginFormConfig.LoginUrl);

            Thread.Sleep(1000);

            var loginButton = Driver.FindElement(By.XPath(LoginFormConfig.LoginButton));

            loginButton.Click();

            Assert.NotNull(loginButton);

            Thread.Sleep(100);

            var errorLabel = Driver.FindElement(By.XPath(LoginFormConfig.ErrorLabel));

            Assert.NotNull(errorLabel);
            Assert.Equal(LoginFormConfig.ErrorMessage, errorLabel.Text);
        }

        public void Dispose()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception thrown in Tests.Dispose(): {e}");
            }
        }
    }
}
