using FluentValidation; 
using KanhaDairy.BAL.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Validators
{
    public class OrderValidator: AbstractValidator<CreateOrderDto>
    {
        public OrderValidator()
        {
            //RuleFor(x => x.FkUserId)
            //     .GreaterThan(0).WithMessage("UserId must be greater than 0");

            //RuleFor(x => x.FkShippingId)
            //    .GreaterThan(0).WithMessage("ShippingId must be greater than 0");

            //RuleFor(x => x.OrderDate)
            //    .NotEmpty().WithMessage("OrderDate must be enter");

            //RuleFor(x => x.FkBillingId)
            //    .GreaterThan(0).WithMessage("Billing Id must be greater than 0");

            //RuleFor(x => x.TotalPrice)
            //   .GreaterThan(0).WithMessage("Total Price must be greater than 0");

            RuleFor(x => x.FkOrderStatusId)
                .GreaterThan(0).WithMessage("Order Status Id must be greater than 0");
        }

        public class UpdateCartValidator : AbstractValidator<UpdateOrderDto>
        {
            public UpdateCartValidator()
            {
                RuleFor(x => x.FkUserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

                //RuleFor(x => x.FkShippingId)
                //    .GreaterThan(0).WithMessage("ShippingId must be greater than 0");

                RuleFor(x => x.OrderDate)
                    .NotEmpty().WithMessage("OrderDate must be enter");

                //RuleFor(x => x.FkBillingId)
                //    .GreaterThan(0).WithMessage("Billing Id must be greater than 0");

                RuleFor(x => x.TotalPrice)
                   .GreaterThan(0).WithMessage("Total Price must be greater than 0");

                RuleFor(x => x.FkOrderStatusId)
                    .GreaterThan(0).WithMessage("Order Status Id must be greater than 0");

            }
        }
        public class DeleteCartValidator : AbstractValidator<DeleteOrderDto>
        {
            public DeleteCartValidator()
            {
                RuleFor(x => x.OrderId)
                    .GreaterThan(0).WithMessage("OrderId  must be greater than 0");

            }
        }
    }
}
