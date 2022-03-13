using AutoFixture;
using AutoFixture.AutoMoq;
using Csharp.Experiment.Experiments.E001_FluentValidation;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Xunit;

namespace Csharp.Experiment.Tests
{
    public class FluentValidationExperimentTests
    {
        private readonly IFixture _fixture;

        public FluentValidationExperimentTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
        }

        /// <summary>
        /// Notes:
        /// (i)     This requires `AutoMoqCustomization` to be working.
        /// (ii)    The validator type must be the same as the one in the constructor, i.e. `AbstractValidator<Customer>`.
        /// (iii)   Using `_fixture.Create<FluentValidationExperiment>()` would automatically use the "freezed" object in the constructor.
        /// </summary>
        [Fact]
        public void ShouldReturnTrue_WhenPassingTheValidator_Version1()
        {
            // --- ARRANGE ---
            var customer = _fixture.Freeze<Customer>();
            var mockCustomerValidator = _fixture.Freeze<Mock<AbstractValidator<Customer>>>();
            mockCustomerValidator
                .Setup(x => x.Validate(It.IsAny<ValidationContext<Customer>>()))
                .Returns(new ValidationResult());

            var sut = _fixture.Create<FluentValidationExperiment>();

            // --- ACT ---
            sut.SimulateExperiment();

            // --- ASSERT ---
            mockCustomerValidator.Verify(v => v.Validate(It.IsAny<ValidationContext<Customer>>()), Times.Once);
        }

        /// <summary>
        /// Notes:
        /// (i)     No need to have `AutoMoqCustomization` in order to make it work.
        /// (ii)    No need to have a mocked type of `AbstractValidator<Customer>` to make it work, i.e. can use `CustomerValidator` to make it work.
        /// </summary>
        [Fact]
        public void ShouldReturnTrue_WhenPassingTheValidator_Version2()
        {
            // --- ARRANGE ---
            var mockCustomerValidator = _fixture.Freeze<Mock<CustomerValidator>>();
            mockCustomerValidator
                .Setup(x => x.Validate(It.IsAny<ValidationContext<Customer>>()))
                .Returns(new ValidationResult());

            var sut = new FluentValidationExperiment(mockCustomerValidator.Object, It.IsAny<Customer>());

            // --- ACT ---
            sut.SimulateExperiment();

            // --- ASSERT ---
            mockCustomerValidator.Verify(v => v.Validate(It.IsAny<ValidationContext<Customer>>()), Times.Once);
        }
    }
}