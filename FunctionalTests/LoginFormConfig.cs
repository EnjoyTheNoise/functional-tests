using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalTests
{
    public static class LoginFormConfig
    {
        public static string LoginUrl = "https://pimpmyride.azurewebsites.net/login";

        public static string EmailInput = "//*[@id=\"root\"]/div/div[1]/div/form/div[1]/input";
        public static string PasswordInput = "//*[@id=\"root\"]/div/div[1]/div/form/div[2]/input";

        public static string LoginButton = "//*[@id=\"root\"]/div/div[1]/div/form/div[3]/button";

        public static string ErrorLabel = "//*[@id=\"Message\"]";

        public static string ErrorMessage = "Incorrect email or password";
    }
}
