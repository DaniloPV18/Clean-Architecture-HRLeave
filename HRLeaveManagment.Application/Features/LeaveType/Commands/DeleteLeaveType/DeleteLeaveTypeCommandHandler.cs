using HRLeaveManagment.Application.Contracts.Persistence;
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
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
            return Unit.Value;
        }
    }
}
