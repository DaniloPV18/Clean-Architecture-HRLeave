using AutoMapper;
using HRLeaveManagment.Application.Contracts.Persistence;
using HRLeaveManagment.Application.Exceptions;
using MediatR;
namespace HRLeaveManagment.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper _mapper, ILeaveTypeRepository _leaveTypeRepository)
        {
            this._mapper = _mapper;
            this._leaveTypeRepository = _leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
                throw new BadRequestException($"{request} is Invalid.", validationResult);            
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
            return leaveTypeToCreate.Id;
        }
    }
}
