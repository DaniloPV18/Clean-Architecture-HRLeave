using FluentValidation;
using HRLeaveManagment.Application.Contracts.Persistence;

namespace HRLeaveManagment.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository _leaveTypeRepository) 
        {
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(LeaveTypeMustExist);
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters.")
                .NotNull();
            RuleFor(p => p.DefaultDays)
                .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1.")
                .LessThan(100).WithMessage("{PropertyName} cannot exceed 100.");
            RuleFor(p => p)
                .MustAsync(LeaveTypeNameUnique).WithMessage("Leave type already exists");
            this._leaveTypeRepository = _leaveTypeRepository;
        }

        private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
        {
            return (await _leaveTypeRepository.GetByIdAsync(id) != null);
        }

        private Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
        {
            return _leaveTypeRepository.isTypeLeaveNameUnique(command.Name);
        }
    }
}
