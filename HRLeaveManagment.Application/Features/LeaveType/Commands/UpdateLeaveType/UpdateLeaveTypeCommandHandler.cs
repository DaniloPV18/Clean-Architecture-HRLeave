using AutoMapper;
using HRLeaveManagment.Application.Contracts.Persistence;
using HRLeaveManagment.Application.Exceptions;
using MediatR;

namespace HRLeaveManagment.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandHandler(IMapper _mapper, ILeaveTypeRepository _leaveTypeRepository)
        {
            this._mapper = _mapper;
            this._leaveTypeRepository = _leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
                throw new BadRequestException($"{request} is Invalid.", validationResult);
            var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
            return Unit.Value;
        }
    }
}
