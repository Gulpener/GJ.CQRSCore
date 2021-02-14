using FluentAssertions;
using GJ.CQRSCore.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GJ.CQRSCore.UnitTests.Validation
{
    [TestClass]
    public class ValidationExceptionTests
    {
        [TestMethod]
        public void ValidationExceptionShouldCorrectlyBeCreatedAndGetTheCorrectMessages()
        {
            // Arrange

            var validationResults = new ValidationResults();
            validationResults.AddValidationResult("test", "Testmessage with property {0}");
            validationResults.AddValidationResult("test2", "Testmessage2 with property {0}");

            // Act

            var exc = new ValidationException(validationResults);

            // Assert

            exc.Message.Should().Be("Testmessage with property test\r\nTestmessage2 with property test2");
        }
    }
}
