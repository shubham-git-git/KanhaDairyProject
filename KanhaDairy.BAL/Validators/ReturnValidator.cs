using FluentValidation;
using KanhaDairy.BAL.DTOs.ReturnDTOs;
using KanhaDairy.BAL.DTOs.RoleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Validators
{
     
    public class ReturnValidator : AbstractValidator<CreateReturnDto>
    {
        public ReturnValidator()
        {
            // ✅ ReturnRegion
            RuleFor(x => x.ReturnRegion)
                .NotEmpty().WithMessage("ReturnRegion is required")
                .MaximumLength(200).WithMessage("Max length is 200");

            //// ✅ CreatedById
            //RuleFor(x => x.CreatedById)
            //    .NotEmpty().WithMessage("CreatedById is required");
        }
    }
    public class UpdateReturnValidator : AbstractValidator<UpdateReturnDto>
    {
        public UpdateReturnValidator()
        {
            RuleFor(x => x.ReturnId)
                .GreaterThan(0).WithMessage("ReturnId  must be greater than 0");

            // ✅ ReturnRegion
            RuleFor(x => x.ReturnRegion)
                .NotEmpty().WithMessage("ReturnRegion is required") // check ""/null
                .MaximumLength(50).WithMessage("Max length is 50");

            //// ✅ IsActive (optional but enforce true/false explicitly)
            //RuleFor(x => x.IsActive)
            //    .NotNull().When(x => x.RoleId > 0).WithMessage("IsActive is required");

            //// ✅ ModifiedById
            //RuleFor(x => x.ModifiedById)
            //    .GreaterThan(0).WithMessage("Modified Id must be greater than 0");

            //// ✅ ModifiedOn
            //RuleFor(x => x.ModifiedOn)
            //    .NotEmpty().WithMessage("Modified on is required");
        }
    }

    public class DeleteReturnValidator : AbstractValidator<DeleteReturnDto>
    {
        public DeleteReturnValidator()
        {
            RuleFor(x => x.ReturnId)
                .GreaterThan(0).WithMessage("RoleId  must be greater than 0");
          
        }
    }
}
