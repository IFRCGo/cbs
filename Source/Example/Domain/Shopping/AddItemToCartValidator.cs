using FluentValidation;

namespace Domain.Shopping
{
    public class AddItemToCartValidator : AbstractValidator<AddItemToCart>
    {
        public AddItemToCartValidator()
        {
            // TODO: Localized messages (Not IStringLocalizer...   ASP.NET Core specific)
            RuleFor(_ => _.Quantity).GreaterThan(0).WithMessage("Quantity is not correct - it needs to be 1 or greater");
        }
    }
}