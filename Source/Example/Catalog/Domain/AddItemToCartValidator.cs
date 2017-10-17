using FluentValidation;

namespace Domain
{
    public class AddItemToCartValidator : AbstractValidator<AddItemToCart>
    {
        public AddItemToCartValidator()
        {
            RuleFor(_ => _.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity is not correct - it needs to be 1 or greater");
        }
    }
}