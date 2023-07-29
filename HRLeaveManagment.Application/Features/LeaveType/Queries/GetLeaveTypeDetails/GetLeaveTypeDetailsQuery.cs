using MediatR;

namespace HRLeaveManagment.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDTO>;
}
