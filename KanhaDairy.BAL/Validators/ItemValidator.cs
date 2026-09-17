using FluentValidation;
using KanhaDairy.BAL.DTOs.ItemDTOs;
using KanhaDairy.BAL.DTOs.RoleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Validators
{
    public class ItemValidator : AbstractValidator<CreateItemDto>
    {
        public ItemValidator()
        {
            RuleFor(x => x.ItemName)
                .NotEmpty()
                .MaximumLength(50)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Item name cannot be blank");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.FkUnitId)
                .GreaterThan(0).WithMessage("Unit is required");

            RuleFor(x => x.FkCategoryId)
                .GreaterThan(0).WithMessage("Category is required");
            
        }
        public class UpdateItemValidator : AbstractValidator<UpdateItemDto>
        {
            public UpdateItemValidator()
            {
                RuleFor(x => x.ItemId)
                    .GreaterThan(0).WithMessage("RoleId  must be greater than 0");

                RuleFor(x => x.ItemName)
               .NotEmpty()
               .MaximumLength(50)
               .Must(x => !string.IsNullOrWhiteSpace(x))
               .WithMessage("Item name cannot be blank");

                RuleFor(x => x.Price)
                    .GreaterThan(0).WithMessage("Price must be greater than 0");

                RuleFor(x => x.FkUnitId)
                    .GreaterThan(0).WithMessage("Unit is required");

                RuleFor(x => x.FkCategoryId)
                    .GreaterThan(0).WithMessage("Category is required");
            }
        }

        public class DeleteItemValidator : AbstractValidator<DeleteItemDto>
        {
            public DeleteItemValidator()
            {
                RuleFor(x => x.ItemId)
                    .GreaterThan(0).WithMessage("RoleId  must be greater than 0");
           
            }
        }
    }
}
