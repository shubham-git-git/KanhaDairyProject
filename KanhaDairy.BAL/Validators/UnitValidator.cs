using FluentValidation;
using KanhaDairy.BAL.DTOs.UnitDTOs;
using KanhaDairy.BAL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Validators
{
    public class UnitValidator : AbstractValidator<CreateUnitDto>
    {
        public UnitValidator()
        {
            // ✅ UnitName
            RuleFor(x => x.UnitName)
                .NotEmpty().WithMessage("Unit name is required")
                .MaximumLength(15).WithMessage("Max length is 15");
                

            // ✅ Abbreviation
            RuleFor(x => x.Abbreviation)
                .NotEmpty().WithMessage("Abbreviation(sort name) is required")                
                .MaximumLength(10).WithMessage("Max length is 10")
                .Matches("^[a-zA-Z]+$").WithMessage("Only alphabets allowed");
                        
            //// ✅ CreatedById
            //RuleFor(x => x.CreatedById)
            //    .NotEmpty().WithMessage("CreatedById is required");

        }
    }

    public class UpdateUnitValidator : AbstractValidator<UpdateUnitDto>
    {
        public UpdateUnitValidator()
        {
            RuleFor(x => x.UnitId)
                .GreaterThan(0).WithMessage("UnitId  must be greater than 0");

            // ✅ UnitName
            RuleFor(x => x.UnitName)
                .NotEmpty().WithMessage("Unit name is required") // check ""/null
                .MaximumLength(15).WithMessage("Max length is 15");               

            // ✅ Abbreviation
            RuleFor(x => x.Abbreviation)
                .NotEmpty().WithMessage("Abbreviation(sort name) is required")
                //.Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Unit name cannot be blank") // check " "
                .MaximumLength(10).WithMessage("Max length is 10")
                .Matches("^[a-zA-Z]+$").WithMessage("Only alphabets allowed");

            //// ✅ IsActive (optional but enforce true/false explicitly)
            //RuleFor(x => x.IsActive)
            //    .NotNull().When(x => x.UnitId > 0).WithMessage("IsActive is required");

            //// ✅ ModifiedById
            //RuleFor(x => x.ModifiedById)
            //    .GreaterThan(0).WithMessage("Modified Id must be greater than 0");

            //// ✅ ModifiedOn
            //RuleFor(x => x.ModifiedOn)
            //    .NotEmpty().WithMessage("Modified on is required");
        }
    }
    public class DeleteUnitValidator : AbstractValidator<DeleteUnitDto>
    {
        public DeleteUnitValidator()
        {
            RuleFor(x => x.UnitId)
                .GreaterThan(0).WithMessage("UserId  must be greater than 0");         

            //// ✅ ModifiedById
            //RuleFor(x => x.ModifiedById)
            //    .GreaterThan(0).WithMessage("Modified Id must be greater than 0");

          
        }
    }
}
