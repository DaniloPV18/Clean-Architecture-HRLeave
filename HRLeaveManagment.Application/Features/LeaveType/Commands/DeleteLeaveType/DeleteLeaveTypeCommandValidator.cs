using FluentValidation;
using HRLeaveManagment.Application.Contracts.Persistence;

namespace HRLeaveManagment.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandValidator : AbstractValidator<DeleteLeaveTypeCommand>
    {
        public DeleteLeaveTypeCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} just numbers.");
        }
    }
}
