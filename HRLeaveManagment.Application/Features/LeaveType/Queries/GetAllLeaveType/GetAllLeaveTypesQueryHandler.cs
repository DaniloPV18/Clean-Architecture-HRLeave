using AutoMapper;
using HRLeaveManagment.Application.Contracts.Logging;
using HRLeaveManagment.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagment.Application.Features.LeaveType.Queries.GetAllLeaveType
{
    public class GetAllLeaveTypesQueryHandler : IRequestHandler<GetAllLeaveTypesQuery, List<LeaveTypeDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetAllLeaveTypesQueryHandler> _logger;
        public GetAllLeaveTypesQueryHandler(IMapper _mapper, ILeaveTypeRepository _leaveTypeRepository, IAppLogger<GetAllLeaveTypesQueryHandler> _logger)
        {
            this._mapper = _mapper;
            this._leaveTypeRepository = _leaveTypeRepository;
            this._logger = _logger;
        }
        public async Task<List<LeaveTypeDTO>> Handle(GetAllLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAsync();
            var data = _mapper.Map<List<LeaveTypeDTO>>(leaveTypes);
            _logger.LogInformation("Leave types were retrieved succesfully");
            return data;
        }
    }
}
