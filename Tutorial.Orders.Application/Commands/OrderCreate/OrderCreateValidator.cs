using FluentValidation;

namespace Tutorial.Orders.Application.Commands.OrderCreate
{
    public class OrderCreateValidator : AbstractValidator<OrderCreateCommand>
    {
        public OrderCreateValidator()
        {
            // userName email formatında olmalı
            // boş olmamalı
            RuleFor(v => v.SellerUserName)
                .EmailAddress()
                .NotEmpty();

            RuleFor(v => v.ProductId)
                .NotEmpty();
        }
    }
}
