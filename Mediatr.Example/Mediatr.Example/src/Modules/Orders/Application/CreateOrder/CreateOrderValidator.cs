using FluentValidation;

namespace Mediatr.Example.src.Modules.Orders.Application.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Total).GreaterThan(100);
        }
    }
}
