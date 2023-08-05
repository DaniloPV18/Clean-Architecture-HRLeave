using AutoMapper;
using HRLeaveManagment.Application.Features.LeaveType.Queries.GetAllLeaveType;
using HRLeaveManagment.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HRLeaveManagment.Domain;

namespace HRLeaveManagment.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDTO, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDTO>();
        }
    }
}
