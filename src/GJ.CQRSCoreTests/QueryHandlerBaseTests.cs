using FluentAssertions;
using GJ.CQRSCore.Interfaces;
using GJ.CQRSCore.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GJ.CQRSCore.UnitTests
{
    [TestClass]
    public class QueryHandlerBaseTests
    {
        public class TestQuery : IQuery { }
        public class TestQueryHandlerBaseClass : QueryHandlerBase<TestQuery, bool>
        {
            public TestQueryHandlerBaseClass() { }
            public TestQueryHandlerBaseClass(IValidator<TestQuery> validator) : base(validator) { }
            public bool Handled { get; set; } = false;
            public override bool Handle(TestQuery command)
            {
                Handled = true;
                return Handled;
            }
        }

        [TestMethod]
        public void QueryHandlerBaseWithoutValidatorShouldHandle()
        {
            // Arrange

            var queryHandler = new TestQueryHandlerBaseClass();

            // Act

             var result = queryHandler.Handle(new TestQuery());

            // Assert

            queryHandler.Handled.Should().BeTrue();
            result.Should().BeTrue();

        }

        [TestMethod]
        public void QueryHandlerBaseWithPositiveValidatorShouldHandle()
        {
            // Arrange

            var validator = new Mock<IValidator<TestQuery>>();
            validator.Setup(x => x.Validate(It.IsAny<ValidationResults>(), It.IsAny<TestQuery>())).Returns(new ValidationResults());
            var queryHandler = new TestQueryHandlerBaseClass();

            // Act

            queryHandler.Handle(new TestQuery());

            // Assert

            queryHandler.Handled.Should().BeTrue();
        }

        [TestMethod]
        public void QueryHandlerBaseWithNegativeValidatorShouldThrowValidationException()
        {
            // Arrange

            var validator = new Mock<IValidator<TestQuery>>();
            var validationResults = new ValidationResults();
            validationResults.AddValidationResult("Test1", "Test message with property: {0}");
            validationResults.AddValidationResult("Test2", "Test message 2 with property: {0}");
            validator.Setup(x => x.Validate(It.IsAny<ValidationResults>(), It.IsAny<TestQuery>())).Returns(validationResults);
            var queryHandler = new TestQueryHandlerBaseClass(validator.Object);

            // Act

            Action act = () => queryHandler.Execute(new TestQuery()); ;

            // Assert

            act.Should().Throw<ValidationException>()
                .WithMessage("Test message with property: Test1\r\nTest message 2 with property: Test2");
        }
    }
}
