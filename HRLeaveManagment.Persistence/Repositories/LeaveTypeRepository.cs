using HRLeaveManagment.Application.Contracts.Persistence;
using HRLeaveManagment.Domain;
using HRLeaveManagment.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagment.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HRDatabaseContext _context) : base(_context)
        {
        }

        public async Task<bool> isTypeLeaveNameUnique(string name)
        {
            return await _context.LeaveTypes.AnyAsync( q => q.Name == name);
        }
    }
}