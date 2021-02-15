using FluentAssertions;
using GJ.CQRSCore.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GJ.CQRSCore.UnitTests.Validation
{
    [TestClass]
    public class ValidationExtensionTests
    {
        [TestMethod]
        public void TestValidateNotNullWithNotNullValueShouldReturnNoValidationResults()
        {
            // Arrange

            var validationResults = new ValidationResults();
            int input = 1;

            // Act

            validationResults.ValidateNotNull(input, "input");

            // Assert

            validationResults.GetMessages().Should().Be("");
        }

        [TestMethod]
        public void TestValidateNotNullWithNullValueShouldReturnValidationResults()
        {
            // Arrange

            var validationResults = new ValidationResults();
            int input = -1;

            // Act

            validationResults.ValidateNotNull(input, "input");

            // Assert

            validationResults.GetMessages().Should().Be("input cannot be null");
        }

        [TestMethod]
        public void TestValidateNotNullOrEmptyWithNotNullOrEmptyValueShouldReturnNoValidationResults()
        {
            // Arrange

            var validationResults = new ValidationResults();
            string input = "Test";

            // Act

            validationResults.ValidateNotNullOrEmpty(input, "input");

            // Assert

            validationResults.GetMessages().Should().Be("");
        }

        [TestMethod]
        public void TestValidateNotNullOrEmptyWithNullValueShouldReturnValidationResults()
        {
            // Arrange

            var validationResults = new ValidationResults();
            string input = null;

            // Act

            validationResults.ValidateNotNullOrEmpty(input, "input");

            // Assert

            validationResults.GetMessages().Should().Be("input cannot be null or empty");
        }

        [TestMethod]
        public void TestValidateNotNullOrEmptyWithEmptyValueShouldReturnValidationResults()
        {
            // Arrange

            var validationResults = new ValidationResults();
            string input = "";

            // Act

            validationResults.ValidateNotNullOrEmpty(input, "input");

            // Assert

            validationResults.GetMessages().Should().Be("input cannot be null or empty");
        }
    }
}
