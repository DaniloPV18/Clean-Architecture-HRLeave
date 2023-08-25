using AutoMapper;
using HRLeaveManagment.Application.Contracts.Logging;
using HRLeaveManagment.Application.Contracts.Persistence;
using HRLeaveManagment.Application.Exceptions;
using MediatR;

namespace HRLeaveManagment.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

        public UpdateLeaveTypeCommandHandler(IMapper _mapper, ILeaveTypeRepository _leaveTypeRepository, IAppLogger<UpdateLeaveTypeCommandHandler> _logger)
        {
            this._mapper = _mapper;
            this._leaveTypeRepository = _leaveTypeRepository;
            this._logger = _logger;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            /*if (validationResult.Errors.Any())
                throw new BadRequestException($"{request} is Invalid.", validationResult);*/
            if(validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType), request.Id);
                throw new BadRequestException($"{request} is Invalid.", validationResult);
            }
            var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
            return Unit.Value;
        }
    }
}
