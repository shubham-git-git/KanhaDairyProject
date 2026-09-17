using FluentValidation;
using KanhaDairy.BAL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Validators
{
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            // ✅ UserName
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name is required")
                .MaximumLength(50).WithMessage("Max length is 50");
            // ✅ Mobile
            RuleFor(x => x.Mobile)
                .NotEmpty().WithMessage("Mobile is required")
                .MaximumLength(10).WithMessage("Max length is 10")
                .Matches("^[0-9]+$").WithMessage("Only numbers allowed");
            // ✅ RoleId
            RuleFor(x => x.FkRoleId)
               .GreaterThan(0).WithMessage("RoleId is required");
            RuleFor(x => x.FkUserTypeId)
                .GreaterThan(0).WithMessage("User Type id is required");
            // ✅ Mail
            RuleFor(x => x.Email)                
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(30).WithMessage("Max length is 30");
            //// ✅ CreatedById
            //RuleFor(x => x.CreatedById)
            //    .NotEmpty().WithMessage("CreatedById is required");
        }    
    }    
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId  must be greater than 0");

            // ✅ UserName
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name is required") // check ""/null
                .MaximumLength(50).WithMessage("Max length is 50");

            // ✅ Mobile
            RuleFor(x => x.Mobile)
                .NotEmpty().WithMessage("Mobile is required")
                .MaximumLength(10).WithMessage("Max length is 10")
                .Matches("^[0-9]+$").WithMessage("Only numbers allowed");
            // ✅ Mail
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(30).WithMessage("Max length is 30");
            // ✅ RoleId
            RuleFor(x => x.FkRoleId)
               .GreaterThan(0).WithMessage("RoleId is required");
            RuleFor(x => x.FkUserTypeId)
                .GreaterThan(0).WithMessage("User Type id is required");

            //// ✅ IsActive (optional but enforce true/false explicitly)
            //RuleFor(x => x.IsActive)
            //    .NotNull().When(x => x.UserId > 0).WithMessage("IsActive is required");

            //// ✅ ModifiedById
            //RuleFor(x => x.ModifiedById)
            //    .GreaterThan(0).WithMessage("Modified Id must be greater than 0");

            //// ✅ ModifiedOn
            //RuleFor(x => x.ModifiedOn)
            //    .NotEmpty().WithMessage("Modified on is required");
        }
    }

    public class DeleteUserValidator : AbstractValidator<DeleteUserDto>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId  must be greater than 0");           

            //// ✅ ModifiedById
            //RuleFor(x => x.ModifiedById)
            //    .GreaterThan(0).WithMessage("Modified Id must be greater than 0");     
        }
    }
    
}
