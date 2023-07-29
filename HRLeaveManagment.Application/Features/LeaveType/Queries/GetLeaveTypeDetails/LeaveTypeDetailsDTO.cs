namespace HRLeaveManagment.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class LeaveTypeDetailsDTO
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
