using System;
using System.IO;
using AddressBookWebTests;

namespace AddressBookTestDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var testDataCount = Convert.ToInt32(args[0]);
            var writer = new StreamWriter(args[1]);
            for (var i = 0; i < testDataCount; i++)
            {
                writer.WriteLine(
                    $"{TestBase.GenerateRandomString(10)},{TestBase.GenerateRandomString(20)},{TestBase.GenerateRandomString(20)}");
            }

            writer.Close();
        }
    }
}