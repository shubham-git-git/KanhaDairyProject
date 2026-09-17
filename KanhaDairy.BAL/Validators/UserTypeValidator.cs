using FluentValidation;
using KanhaDairy.BAL.DTOs.UserTypeDTOs;


namespace KanhaDairy.BAL.Validators
{
    public class UserTypeValidator : AbstractValidator<CreateUserTypeDto>
    {
        public UserTypeValidator()
        {
            // ✅ UserTypeName
            RuleFor(x => x.UserTypeName)
                .NotEmpty().WithMessage("UserType name is required")
                .MaximumLength(50).WithMessage("Max length is 50");
          
            //// ✅ CreatedById
            //RuleFor(x => x.CreatedById)
            //    .NotEmpty().WithMessage("CreatedById is required");
        }
    }
    public class UpdateUserTypeValidator : AbstractValidator<UpdateUserTypeDto>
    {
        public UpdateUserTypeValidator()
        {
            RuleFor(x => x.UserTypeId)
                .GreaterThan(0).WithMessage("UserTypeId  must be greater than 0");

            // ✅ UserTypeName
            RuleFor(x => x.UserTypeName)
                .NotEmpty().WithMessage("UserType name is required") // check ""/null
                .MaximumLength(50).WithMessage("Max length is 50");

            //// ✅ ModifiedById
            //RuleFor(x => x.ModifiedById)
            //    .GreaterThan(0).WithMessage("Modified Id must be greater than 0");
        }
    }

    public class DeleteUserTypeValidator : AbstractValidator<DeleteUserTypeDto>
    {
        public DeleteUserTypeValidator()
        {
            RuleFor(x => x.UserTypeId)
                .GreaterThan(0).WithMessage("UserTypeId  must be greater than 0");

            //// ✅ ModifiedById
            //RuleFor(x => x.ModifiedById)
            //    .GreaterThan(0).WithMessage("Modified Id must be greater than 0");
        }
    }
}
