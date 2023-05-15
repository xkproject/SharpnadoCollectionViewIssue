using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.helpers
{
    public static class Setup
    {
        public static AndroidDriver<AppiumWebElement> InitializeAndroidDriver()
        {
            DotNetEnv.Env.Load();

            //System.Environment.SetEnvironmentVariable("ANDROID_HOME", "C:\\Users\\edgar\\AppData\\Local\\Android\\Sdk");
            //System.Environment.SetEnvironmentVariable("JAVA_HOME", "C:\\Program Files\\Microsoft\\jdk-11.0.12.7-hotspot");

            var capabilities = new AppiumOptions();

            // - GENERAL CAPABILITIES -
            //capabilities.AddAdditionalCapability(MobileCapabilityType.App, apkPackagePath);
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, Environment.GetEnvironmentVariable("PLATFORM_NAME"));
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, Environment.GetEnvironmentVariable("DEVICE_NAME"));
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, Environment.GetEnvironmentVariable("AUTOMATION_NAME"));

            // - ANDROID CAPABILITIES -
            //capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, Environment.GetEnvironmentVariable("APP_PACKAGE"));
            //capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, Environment.GetEnvironmentVariable("APP_ACTIVITY"));

            // - SERVER OPTIONS -
            var serverOptions = new OptionCollector();
            serverOptions.AddArguments(new KeyValuePair<string, string>("--relaxed-security", ""));

            // - APPIUM SERVER -
            var appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().WithArguments(serverOptions).Build();
            appiumLocalService.Start();

            // - DRIVER -
            return new AndroidDriver<AppiumWebElement>(appiumLocalService, capabilities);
        }
    }
}
