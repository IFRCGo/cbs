using FluentValidation.TestHelper;
using Xunit;

namespace Domain.Tests
{
    public class AddItemToCartValidatorTests
    {
        private readonly AddItemToCartValidator _validator;

        public AddItemToCartValidatorTests()
        {
            _validator = new AddItemToCartValidator();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-1337)]
        public void AddItemToCartValidator_WhenQuantityIsZeroOrNegative_ShouldBeInvalid(int quantity)
        {
            _validator.ShouldHaveValidationErrorFor(item => item.Quantity, quantity);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(1337)]
        public void AddItemToCartValidator_WhenQuantityIsPositive_ShouldBeValid(int quantity)
        {
            _validator.ShouldNotHaveValidationErrorFor(item => item.Quantity, quantity);
        }
    }
}