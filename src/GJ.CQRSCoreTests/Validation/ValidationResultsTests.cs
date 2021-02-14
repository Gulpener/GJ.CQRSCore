using FluentAssertions;
using GJ.CQRSCore.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GJ.CQRSCore.UnitTests.Validation
{
    [TestClass]
    public class ValidationResultsTests
    {
        [TestMethod]
        public void ValidationResultShouldContainTheCorrectPropertyNames()
        {
            // Arrange

            string message = "{0} This is a message";
            string propertyName = "Test";

            // Act

            var validationResult = new ValidationResult(propertyName, message);

            // Assert

            validationResult.Message.Should().Be(message);
            validationResult.PropertyName.Should().Be(propertyName);
            validationResult.FormattedMessage.Should().Be("Test This is a message");
        }
    }
}
