using FluentAssertions;
using GJ.CQRSCore.Interfaces;
using GJ.CQRSCore.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GJ.CQRSCore.UnitTests
{
    [TestClass]
    public class CommandHandlerBaseTests
    {
        public class TestCommand : ICommand { }
        public class TestCommandHandlerBaseClass : CommandHandlerBase<TestCommand>
        {
            public TestCommandHandlerBaseClass() { }
            public TestCommandHandlerBaseClass(IValidator<TestCommand> validator) : base(validator) { }
            public bool Handled { get; set; } = false;
            public override void Handle(TestCommand command)
            {
                Handled = true;
            }
        }

        [TestMethod]
        public void CommandHandlerBaseWithoutValidatorShouldHandle()
        {
            // Arrange

            var commandHandler = new TestCommandHandlerBaseClass();

            // Act

            commandHandler.Handle(new TestCommand());

            // Assert

            commandHandler.Handled.Should().BeTrue();
        }

        [TestMethod]
        public void CommandHandlerBaseWithPositiveValidatorShouldHandle()
        {
            // Arrange

            var validator = new Mock<IValidator<TestCommand>>();
            validator.Setup(x => x.Validate(It.IsAny<ValidationResults>(), It.IsAny<TestCommand>())).Returns(new ValidationResults());
            var commandHandler = new TestCommandHandlerBaseClass();

            // Act

            commandHandler.Handle(new TestCommand());

            // Assert

            commandHandler.Handled.Should().BeTrue();
        }

        [TestMethod]
        public void CommandHandlerBaseWithNegativeValidatorShouldThrowValidationException()
        {
            // Arrange

            var validator = new Mock<IValidator<TestCommand>>();
            var validationResults = new ValidationResults();
            validationResults.AddValidationResult("Test1", "Test message with property: {0}");
            validationResults.AddValidationResult("Test2", "Test message 2 with property: {0}");
            validator.Setup(x => x.Validate(It.IsAny<ValidationResults>(), It.IsAny<TestCommand>())).Returns(validationResults);
            var commandHandler = new TestCommandHandlerBaseClass(validator.Object);

            // Act

            Action act = () => commandHandler.Execute(new TestCommand()); ;

            // Assert

            act.Should().Throw<ValidationException>()
                .WithMessage("Test message with property: Test1\r\nTest message 2 with property: Test2");
        }
    }
}
