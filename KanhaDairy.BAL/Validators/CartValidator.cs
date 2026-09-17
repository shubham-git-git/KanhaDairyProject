using FluentValidation;
using KanhaDairy.BAL.DTOs.CartDTOs;
using KanhaDairy.BAL.DTOs.CartDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Validators
{
    public class CartValidator:AbstractValidator<CreateCartDto>
    {
        public CartValidator()
        {           
            RuleFor(x => x.FkItemId)
                .GreaterThan(0).WithMessage("ItemId must be greater than 0");

            RuleFor(x => x.FkUserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            //RuleFor(x => x.FkDiscountId)
            //    .GreaterThan(0).WithMessage("DiscountId must be greater than 0");

            RuleFor(x => x.PricePerUnit)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.Quantity)
               .GreaterThan(0).WithMessage("Quantity must be greater than 0");

            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("Total Price must be greater than 0");
        }
        public class UpdateCartValidator : AbstractValidator<UpdateCartDto>
        {
            public UpdateCartValidator()
            {
                //RuleFor(x => x.CartId)
                //    .GreaterThan(0).WithMessage("CartId  must be greater than 0");

                RuleFor(x => x.FkItemId)
               .GreaterThan(0).WithMessage("ItemId must be greater than 0");

                RuleFor(x => x.FkUserId)
                    .GreaterThan(0).WithMessage("UserId must be greater than 0");

                //RuleFor(x => x.FkDiscountId)
                //    .GreaterThan(0).WithMessage("DiscountId must be greater than 0");

                RuleFor(x => x.PricePerUnit)
                    .GreaterThan(0).WithMessage("Price must be greater than 0");

                RuleFor(x => x.Quantity)
                   .GreaterThan(0).WithMessage("Quantity must be greater than 0");

                RuleFor(x => x.TotalPrice)
                    .GreaterThan(0).WithMessage("Total Price must be greater than 0");

            }
        }

        public class DeleteCartValidator : AbstractValidator<DeleteCartDto>
        {
            public DeleteCartValidator()
            {
                RuleFor(x => x.FkUserId)
                    .GreaterThan(0).WithMessage("UserId  must be greater than 0");

            }
        }
    }
}
