using HRLeaveManagment.Domain;

namespace HRLeaveManagment.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> isTypeLeaveNameUnique(string name);
    }
}
