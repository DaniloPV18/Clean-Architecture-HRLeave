using MediatR;
namespace HRLeaveManagment.Application.Features.LeaveType.Queries.GetAllLeaveType
{
    public record GetAllLeaveTypesQuery : IRequest<List<LeaveTypeDTO>>;
}
