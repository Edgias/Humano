using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class Leave : BaseEntity, IAggregateRoot
    {
        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public LeaveStatus LeaveStatus { get; private set; }

        public Guid? ApprovedBy { get; private set; }

        public string? Remarks { get; private set; }

        public Guid LeaveCategoryId { get; private set; }

        public LeaveCategory LeaveCategory { get; private set; } = null!;

        public Guid EmployeeId { get; private set; }

        public Employee Employee { get; private set; } = null!;

        private readonly List<LeaveDay> _leaveDays = new();

        public IReadOnlyCollection<LeaveDay> LeaveDays => _leaveDays.AsReadOnly();

        public Leave(Guid employeeId, DateTime startDate, DateTime endDate, LeaveStatus leaveStatus,
            Guid leaveCategoryId)
        {
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            LeaveStatus = leaveStatus;
            LeaveCategoryId = leaveCategoryId;
        }

        public Leave(Guid employeeId, DateTime startDate, DateTime endDate, LeaveStatus leaveStatus,
            Guid leaveCategoryId, List<LeaveDay> leaveDays)
        {
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            LeaveStatus = leaveStatus;
            LeaveCategoryId = leaveCategoryId;
            _leaveDays = leaveDays;
        }

        public int DaysTaken()
        {
            return _leaveDays.Count;
        }

        public void AddDay(LeaveDay day) 
        { 
            _leaveDays.Add(day);
        }

        public void AddDays(IEnumerable<LeaveDay> days)
        {
            _leaveDays.AddRange(days);
        }

        public void Approve(Guid approverId)
        {
            LeaveStatus = LeaveStatus.Approved;
            ApprovedBy = approverId;
            SetLastModifiedBy($"{approverId}");
        }

        public void Reject(Guid approverId, string remarks)
        {
            LeaveStatus = LeaveStatus.Rejected;
            ApprovedBy = approverId;
            SetLastModifiedBy($"{approverId}");
            Remarks = remarks;
        }
    }
}
