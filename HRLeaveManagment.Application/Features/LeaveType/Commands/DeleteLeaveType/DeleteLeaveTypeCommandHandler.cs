using HRLeaveManagment.Application.Contracts.Persistence;
using HRLeaveManagment.Application.Exceptions;
using MediatR;

namespace HRLeaveManagment.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository _leaveTypeRepository)
        {
            this._leaveTypeRepository = _leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteLeaveTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
                throw new BadRequestException($"{request} is Invalid.", validationResult);
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);
            if (leaveTypeToDelete == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
            return Unit.Value;
        }
    }
}
