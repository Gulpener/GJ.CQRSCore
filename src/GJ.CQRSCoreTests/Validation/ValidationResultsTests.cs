using FluentAssertions;
using GJ.CQRSCore.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GJ.CQRSCore.UnitTests.Validation
{
    [TestClass]
    public class ValidationResultsTests
    {
        [TestMethod]
        public void ValidationResultsShouldHaveCorrectResultMessage()
        {
            // Arrange

            var validationResults = new ValidationResults();


            // Act

            validationResults.AddValidationResult("Test", "Test message with property: {0}");
            validationResults.AddValidationResult("Test2", "Test message 2 with property: {0}");

            // Assert

            validationResults.GetMessages().Should().Be("Test message with property: Test\r\nTest message 2 with property: Test2");
        }
    }
}
