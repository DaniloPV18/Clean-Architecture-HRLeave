using AutoMapper;
using HRLeaveManagment.Application.Contracts.Persistence;
using MediatR;
using System.Drawing;

namespace HRLeaveManagment.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper _mapper, ILeaveTypeRepository _leaveTypeRepository)
        {
            this._mapper = _mapper;
            this._leaveTypeRepository = _leaveTypeRepository;
        }

        public async Task<LeaveTypeDetailsDTO> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.Id);
            var data = _mapper.Map<LeaveTypeDetailsDTO>(leaveTypes);
            return data;
        }
    }
}
