using FluentValidation;
using KanhaDairy.BAL.DTOs.RoleDTOs;


namespace KanhaDairy.BAL.Validators
{
    public class RoleValidator : AbstractValidator<CreateRoleDto>
    {
        public RoleValidator()
        {
            // ✅ Role
            RuleFor(x => x.Roles)
                .NotEmpty().WithMessage("Role is required")
                .MaximumLength(50).WithMessage("Max length is 50");

            //// ✅ CreatedById
            //RuleFor(x => x.CreatedById)
            //    .NotEmpty().WithMessage("CreatedById is required");
        }
    }
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("RoleId  must be greater than 0");

            // ✅ RoleName
            RuleFor(x => x.Roles)
                .NotEmpty().WithMessage("Role is required") // check ""/null
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

    public class DeleteRoleValidator : AbstractValidator<DeleteRoleDto>
    {
        public DeleteRoleValidator()
        {
            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("RoleId  must be greater than 0");

            //// ✅ ModifiedById
            //RuleFor(x => x.ModifiedById)
            //    .GreaterThan(0).WithMessage("Modified Id must be greater than 0");
        }
    }
}
