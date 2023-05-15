using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Tests.helpers
{
    public static class Extensions
    {
        public static TResult WaitUntil<TResult>(this AndroidDriver<AppiumWebElement> driver, Func<TResult> condition, WaitConfig? waitConfig = null)
        {
            waitConfig ??= WaitConfig.Default;

            var wait = new DefaultWait<AndroidDriver<AppiumWebElement>>(driver)
            {
                Timeout = TimeSpan.FromSeconds(waitConfig.Timeout),
                PollingInterval = TimeSpan.FromSeconds(waitConfig.PollingInterval)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait.Until(d => condition());
        }

        public static void Scroll(this AndroidDriver<AppiumWebElement> driver, AppiumWebElement element, ScrollDirection scrollDirection, int scrollDistance = 400, double milliseconds = 500)
        {
            int xOffset, yOffset;

            switch (scrollDirection)
            {
                case ScrollDirection.Up:
                    {
                        xOffset = 0;
                        yOffset = scrollDistance;
                        break;
                    }
                case ScrollDirection.Down:
                    {
                        xOffset = 0;
                        yOffset = -scrollDistance;
                        break;
                    }
                case ScrollDirection.Left:
                    {
                        xOffset = scrollDistance;
                        yOffset = 0;
                        break;
                    }
                case ScrollDirection.Right:
                    {
                        xOffset = -scrollDistance;
                        yOffset = 0;
                        break;
                    }
                default: return;
            }

            var input = new PointerInputDevice(PointerKind.Touch);
            ActionSequence scrollAction = new ActionSequence(input);

            scrollAction.AddAction(input.CreatePointerMove(element, -xOffset, -yOffset, TimeSpan.Zero));
            scrollAction.AddAction(input.CreatePointerDown(MouseButton.Left));

            scrollAction.AddAction(input.CreatePointerMove(element, xOffset, yOffset, TimeSpan.FromMilliseconds(milliseconds)));
            scrollAction.AddAction(input.CreatePointerUp(MouseButton.Left));

            driver.PerformActions(new List<ActionSequence>() { scrollAction });
        }

        public static AppiumWebElement FindElementByText(this AppiumWebElement appiumWebElement, string text, FindType findType = FindType.Equals)
        {
            switch (findType)
            {
                case FindType.Equals: return appiumWebElement.FindElementByXPath($"//*[@text='{text}']");
                case FindType.Contains: return appiumWebElement.FindElementByXPath($"//*[contains(@text,'{text}')]");
                case FindType.EqualsInsensitive: return appiumWebElement.FindElementByXPath($"//*[lower-case(@text)='{text.ToLower()}']");
                case FindType.ContainsInsensitive: return appiumWebElement.FindElementByXPath($"//*[contains(lower-case(@text), '{text.ToLower()}')]");
                default: throw new NotImplementedException();
            }
        }

        public static AppiumWebElement FindElementByText(this AndroidDriver<AppiumWebElement> driver, string text, FindType findType = FindType.Equals, WaitConfig? waitConfig = null)
        {
            switch (findType)
            {
                case FindType.Equals:
                    {
                        if (waitConfig != null)
                        {
                            return driver.WaitUntil(() => driver.FindElementByXPath($"//*[@text='{text}']"), waitConfig);
                        }

                        return driver.FindElementByXPath($"//*[@text='{text}']");
                    }
                case FindType.Contains:
                    {
                        if (waitConfig != null)
                        {
                            return driver.WaitUntil(() => driver.FindElementByXPath($"//*[contains(@text,'{text}')]"), waitConfig);
                        }

                        return driver.FindElementByXPath($"//*[contains(@text,'{text}')]");
                    }
                case FindType.EqualsInsensitive:
                    {
                        if (waitConfig != null)
                        {
                            return driver.WaitUntil(() => driver.FindElementByXPath($"//*[lower-case(@text)='{text.ToLower()}']"), waitConfig);
                        }

                        return driver.FindElementByXPath($"//*[lower-case(@text)='{text.ToLower()}']");
                    }
                case FindType.ContainsInsensitive:
                    {
                        if (waitConfig != null)
                        {
                            return driver.WaitUntil(() => driver.FindElementByXPath($"//*[contains(lower-case(@text), '{text.ToLower()}')]"), waitConfig);
                        }

                        return driver.FindElementByXPath($"//*[contains(lower-case(@text), '{text.ToLower()}')]");
                    }
                default: throw new NotImplementedException();
            }
        }

        public static IReadOnlyCollection<AppiumWebElement> FindElementsByText(this AppiumWebElement appiumWebElement, string text, FindType findType = FindType.Equals)
        {
            switch (findType)
            {
                case FindType.Equals: return appiumWebElement.FindElementsByXPath($"//*[@text='{text}']");
                case FindType.Contains: return appiumWebElement.FindElementsByXPath($"//*[contains(@text,'{text}')]");
                case FindType.EqualsInsensitive: return appiumWebElement.FindElementsByXPath($"//*[lower-case(@text)='{text.ToLower()}']");
                case FindType.ContainsInsensitive: return appiumWebElement.FindElementsByXPath($"//*[contains(lower-case(@text), '{text.ToLower()}')]");
                default: throw new NotImplementedException();
            }
        }

        public static IReadOnlyCollection<AppiumWebElement> FindElementsByText(this AndroidDriver<AppiumWebElement> driver, string text, FindType findType = FindType.Equals, WaitConfig? waitConfig = null)
        {
            switch (findType)
            {
                case FindType.Equals:
                    {
                        if (waitConfig != null)
                        {
                            return driver.WaitUntil(() =>
                            {
                                var elements = driver.FindElementsByXPath($"//*[@text='{text}']");
                                return elements.Any() ? elements : throw new NoSuchElementException();
                            }, waitConfig);
                        }

                        return driver.FindElementsByXPath($"//*[@text='{text}']");
                    }
                case FindType.Contains:
                    {
                        if (waitConfig != null)
                        {
                            return driver.WaitUntil(() =>
                            {
                                var elements = driver.FindElementsByXPath($"//*[contains(@text,'{text}')]");
                                return elements.Any() ? elements : throw new NoSuchElementException();
                            }, waitConfig);
                        }

                        return driver.FindElementsByXPath($"//*[contains(@text,'{text}')]");
                    }
                case FindType.EqualsInsensitive:
                    {
                        if (waitConfig != null)
                        {
                            return driver.WaitUntil(() =>
                            {
                                var elements = driver.FindElementsByXPath($"//*[lower-case(@text)='{text.ToLower()}']");
                                return elements.Any() ? elements : throw new NoSuchElementException();
                            }, waitConfig);
                        }

                        return driver.FindElementsByXPath($"//*[lower-case(@text)='{text.ToLower()}']");
                    }
                case FindType.ContainsInsensitive:
                    {
                        if (waitConfig != null)
                        {
                            return driver.WaitUntil(() =>
                            {
                                var elements = driver.FindElementsByXPath($"//*[contains(lower-case(@text), '{text.ToLower()}')]");
                                return elements.Any() ? elements : throw new NoSuchElementException();
                            }, waitConfig);
                        }

                        return driver.FindElementsByXPath($"//*[contains(lower-case(@text), '{text.ToLower()}')]");
                    }
                default: throw new NotImplementedException();
            }
        }

        public static AppiumWebElement FindElementByAccessibilityId(this AndroidDriver<AppiumWebElement> driver, string accessibilityId, WaitConfig waitConfig)
        {
            if (waitConfig != null)
            {
                return driver.WaitUntil(() => driver.FindElementByAccessibilityId(accessibilityId), waitConfig);
            }

            return driver.FindElementByAccessibilityId(accessibilityId);
        }

        public static IReadOnlyCollection<AppiumWebElement> FindElementsByAccessibilityId(this AndroidDriver<AppiumWebElement> driver, string accessibilityId, WaitConfig waitConfig)
        {
            if (waitConfig != null)
            {
                return driver.WaitUntil(() =>
                {
                    var elements = driver.FindElementsByAccessibilityId(accessibilityId);
                    return elements.Any() ? elements : throw new NoSuchElementException();
                }, waitConfig);
            }

            return driver.FindElementsByAccessibilityId(accessibilityId);
        }
    }
}
