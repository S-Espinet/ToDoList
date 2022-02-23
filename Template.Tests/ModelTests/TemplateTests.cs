using Microsoft.VisualStudio.TestTools.UnitTesting;
using Namespace;

namespace Template.Tests
{
  [TestClass]
  public class Classname
  {
    [TestMethod]
    public void NameOfMethodWeAreTesting_DescriptionOfBehavior_ExpectedReturnValue()
    {
      //Example: LeapYear testLeapYear = new LeapYear();
      Assert.AreEqual(ExpectedResult, CodeToTest);
      //Example CodeToTest: testLeapYear.IsLeapYear(2020)
    }
  }
}