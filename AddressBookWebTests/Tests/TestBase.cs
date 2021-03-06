using System;
using System.Text;
using NUnit.Framework;

namespace AddressBookWebTests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager _applicationManager;

        [SetUp]
        public void SetupApplicationManager()
        {
            _applicationManager = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int maxCharNumber)
        {
            var l = Convert.ToInt32(rnd.NextDouble() * maxCharNumber);
            var builder = new StringBuilder();
            for (var i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(32 + rnd.NextDouble() * 65)));
            }

            return builder.ToString();
        }
    }
}