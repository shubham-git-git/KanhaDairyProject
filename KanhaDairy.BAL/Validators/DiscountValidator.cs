using FluentValidation;
using KanhaDairy.BAL.DTOs.DiscountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Validators
{
    public class DiscountValidator : AbstractValidator<CreateDiscountDto>
    {
        public DiscountValidator()
        {
            RuleFor(x => x.DiscountName)
                .NotEmpty()
                .MaximumLength(50)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Discount name cannot be blank");

            RuleFor(x => x.DiscountType)
                .NotEmpty()
                .MaximumLength(50)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Discount type cannot be blank");

            RuleFor(x => x.DiscountValue)
                .NotEmpty()
                .MaximumLength(50)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Discount value cannot be blank");

            RuleFor(x => x.FkItemId)
                .GreaterThan(0).WithMessage("ItemId must be greater than 0");

            //RuleFor(x => x.StartDate)
            //    .NotEmpty(0).WithMessage("Unit is required");

            //RuleFor(x => x.EndDate)
            //    .GreaterThan(0).WithMessage("Category is required");

        }
        public class UpdateDiscountValidator : AbstractValidator<UpdateDiscountDto>
        {
            public UpdateDiscountValidator()
            {
                RuleFor(x => x.DiscountId)
                    .GreaterThan(0).WithMessage("DiscountId  must be greater than 0");

                RuleFor(x => x.DiscountName)
               .NotEmpty()
               .MaximumLength(50)
               .Must(x => !string.IsNullOrWhiteSpace(x))
               .WithMessage("Discount name cannot be blank");

                RuleFor(x => x.DiscountName)
                .NotEmpty()
                .MaximumLength(50)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Discount name cannot be blank");

                RuleFor(x => x.DiscountType)
                    .NotEmpty()
                    .MaximumLength(50)
                    .Must(x => !string.IsNullOrWhiteSpace(x))
                    .WithMessage("Discount type cannot be blank");

                RuleFor(x => x.DiscountValue)
                    .NotEmpty()
                    .MaximumLength(50)
                    .Must(x => !string.IsNullOrWhiteSpace(x))
                    .WithMessage("Discount value cannot be blank");

                RuleFor(x => x.FkItemId)
                    .GreaterThan(0).WithMessage("DiscountId must be greater than 0");
            }
        }

        public class DeleteDiscountValidator : AbstractValidator<DeleteDiscountDto>
        {
            public DeleteDiscountValidator()
            {
                RuleFor(x => x.DiscountId)
                    .GreaterThan(0).WithMessage("DiscountId  must be greater than 0");

            }
        }
    }
}
