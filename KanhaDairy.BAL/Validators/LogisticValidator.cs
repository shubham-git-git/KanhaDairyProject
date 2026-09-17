using FluentValidation;
using KanhaDairy.BAL.DTOs.LogisticDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Validators
{
    public class LogisticValidator :  AbstractValidator<CreateLogisticDto>        
    {
        public LogisticValidator()
        {
            RuleFor(x => x.FkOrderId)
                .GreaterThan(0).WithMessage("Order Id is required.");

            RuleFor(x => x.FkDeliverById)
                .GreaterThan(0).WithMessage("Deliver By Id is required.");

            RuleFor(x => x.FkDeleveryStatusId)
                .GreaterThan(0).WithMessage("Delevery Status Id is required.");

            RuleFor(x => x.DeliveredTime)
                .NotNull().WithMessage("Delivered Time Id is required.");

            // Add more validation rules as needed
        }
        public class UpdateLogisticValidator : AbstractValidator<UpdateLogisticDto>
        {
            public UpdateLogisticValidator()
            {
                RuleFor(x => x.FkOrderId)
                .GreaterThan(0).WithMessage("Order Id is required.");

                RuleFor(x => x.FkDeliverById)
                    .GreaterThan(0).WithMessage("Deliver By Id is required.");

                RuleFor(x => x.FkDeleveryStatusId)
                    .GreaterThan(0).WithMessage("Delevery Status Id is required.");

                RuleFor(x => x.DeliveredTime)
                    .NotNull().WithMessage("Delivered Time Id is required.");
            }
        }

        public class DeleteLogisticValidator : AbstractValidator<DeleteLogisticDto>
        {
            public DeleteLogisticValidator()
            {
                RuleFor(x => x.LogisticId)
                    .GreaterThan(0).WithMessage("LogisticId  must be greater than 0");

            }
        }
    }
}
